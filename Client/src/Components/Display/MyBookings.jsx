import { useState, useEffect, useContext } from 'react';
import { AuthContext } from '../../contexts/AuthContext';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCalendarAlt, faUsers, faClock, faTimes, faCheck } from '@fortawesome/free-solid-svg-icons';
import './MyBookings.css';

const MyBookings = () => {
    const [bookings, setBookings] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
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
            setError(null);
        } catch (err) {
            setError(err.message);
        } finally {
            setLoading(false);
        }
    };

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
            <p className="count">Du har {bookings.length} {bookings.length == 1 ? ('bokning') : ('bokningar')}</p>
            
            {bookings.length === 0 ? (
                <p className="empty">Du har inga bokningar än.</p>
            ) : (
                <div className="bookings-list">
                    {bookings.map(booking => (
                        <div className="booking-item" key={booking.id || booking.bookingTime}>
                            <div className='booking-img'>
                            <img
                                src={`https://picsum.photos/400/250?random=${booking.activityId}` || activity.imgUrl}
                                alt={booking.activityName}
                            />
                            </div>
                            <div className='info'>
                                <h3>{booking.activityName || 'Aktivitet'}</h3>
                                <p><FontAwesomeIcon icon={faCalendarAlt} /> Bokad: {new Date(booking.bookingTime).toLocaleDateString('sv-SE')}</p>
                                <p><FontAwesomeIcon icon={faUsers} /> Bokade platser: {booking.participants}</p>
                                <p><FontAwesomeIcon icon={faClock} /> Tid: {new Date(booking.activityStartTime).toLocaleTimeString('sv-SE', { hour: '2-digit', minute: '2-digit' })} - {new Date(booking.activityEndTime).toLocaleTimeString('sv-SE', { hour: '2-digit', minute: '2-digit' })}</p>
                                <p>Status: {booking.isCancelled ? <FontAwesomeIcon icon={faTimes} /> : <FontAwesomeIcon icon={faCheck} />} {booking.isCancelled ? 'Avbokad' : 'Aktiv'}</p>
                                <p>{booking.isOutdoor ? 'Utomhus' : 'Inomhus'}</p>
                                <p>{booking.subLocationName}</p>
                            </div>
                            <div className='booking-cancel-btn'>
                                <button>Avboka</button>
                            </div>
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
};

export default MyBookings;