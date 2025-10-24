import { useState, useEffect, useContext } from 'react';
import { AuthContext } from '../../contexts/AuthContext';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCalendarAlt, faUsers, faClock, faTimes, faCheck } from '@fortawesome/free-solid-svg-icons';
import './MyBookings.css';
import BookingCard from '../Cards/BookingCard';

const MyBookings = () => {
    const [bookings, setBookings] = useState([]);
    const [filteredBookings, setFilteredBookings] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [filter, setFilter] = useState('upcoming'); // Standard: 'upcoming', 'past', 'cancelled'
    const { token, APIURL } = useContext(AuthContext);

    useEffect(() => {
        if (!token) {
            setError('Du måste vara inloggad');
            setLoading(false);
            return;
        }
        fetchBookings();
    }, [token]);

    const fetchBookings = async () => {
        try {
            const response = await fetch(`${APIURL}/Booking/bookings/user`, {
                method: 'GET',
                credentials: 'include',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                }
            });

            if (!response.ok) {
                throw new Error(`Kunde inte hämta bokningar (${response.status})`);
            }

            const data = await response.json();
            setBookings(data);
            setFilteredBookings(data);
            setError(null);
        } catch (err) {
            setError(err.message);
        } finally {
            setLoading(false);
        }
    };

    const applyFilter = () => {
        const now = new Date().getTime();
        let filtered = [...bookings];

        switch (filter) {
            case 'upcoming':
                filtered = filtered.filter(booking => (new Date(booking.activityStartTime) >= now) && !booking.isCancelled);
                break;
            case 'past':
                filtered = filtered.filter(booking => new Date(booking.activityStartTime) < now && !booking.isCancelled);
                break;
            case 'cancelled':
                filtered = filtered.filter(booking => booking.isCancelled);
                break;
            default:
                filtered = [...bookings];
        }

        setFilteredBookings(filtered);
    };

    useEffect(() => {
        applyFilter();
    }, [filter, bookings]);

    if (loading) {
        return (
            <div className="my-bookings">
                <h1>Mina Bokningar</h1>
                <p>Laddar...</p>
            </div>
        );
    }

    if (error) {
        return (
            <div className="my-bookings">
                <h1>Mina Bokningar</h1>
                <div className="error">
                    <p><FontAwesomeIcon icon={faTimes} /> {error}</p>
                    <button onClick={fetchBookings}>Försök igen</button>
                </div>
            </div>
        );
    }

    return (
        <div className="my-bookings">
            <h1>Mina Bokningar</h1>
            <div className="filter-tabs">
                <button className={filter === 'upcoming' ? 'active' : ''} onClick={() => setFilter('upcoming')}>
                    Kommande
                </button>
                <button className={filter === 'past' ? 'active' : ''} onClick={() => setFilter('past')}>
                    Gamla
                </button>
                <button className={filter === 'cancelled' ? 'active' : ''} onClick={() => setFilter('cancelled')}>
                    Avbokade
                </button>
            </div>
            <p className="count">Du har {filteredBookings.length} {filteredBookings.length == 1 ? ('bokning') : ('bokningar')}</p>
            
            {filteredBookings.length === 0 ? (
                <p className="empty">Inga bokningar matchar filtret.</p>
            ) : (
                <div className="bookings-list">
                    {filteredBookings.map(booking => (
                        <BookingCard key={booking.id || booking.bookingTime} items={booking} applyFilter={applyFilter} />
                    ))}
                </div>
            )}
        </div>
    );
};

export default MyBookings;