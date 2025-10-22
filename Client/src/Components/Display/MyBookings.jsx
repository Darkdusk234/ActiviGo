import { useState, useEffect, useContext } from 'react';
import { AuthContext } from '../../contexts/AuthContext';
import './MyBookings.css';

const MyBookings = () => {
const [bookings, setBookings] = useState([]);
const [loading, setLoading] = useState(true);
const [error, setError] = useState(null);
const { token } = useContext(AuthContext);

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
    const response = await fetch('https://localhost:7201/api/Booking/bookings/user', {
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
        <p>❌ {error}</p>
        <button onClick={fetchBookings}>Försök igen</button>
        </div>
    </div>
    );
}

return (
    <div className="my-bookings">
    <h1>Mina Bokningar</h1>
    <p className="count">Du har {bookings.length} bokningar</p>
    
    {bookings.length === 0 ? (
        <p className="empty">Du har inga bokningar än.</p>
    ) : (
        <div className="bookings-list">
        {bookings.map(booking => (
            <div key={booking.id} className="booking-item">
            <h3>{booking.activityName || 'Aktivitet'}</h3>
            <p>📅 Bokad: {new Date(booking.bookingTime).toLocaleDateString('sv-SE')}</p>
            <p>👥 Deltagare: {booking.participants}</p>
            <p>🕐 Tid: {(booking.activityStartTime)} - {(booking.activityEndTime)}</p>
            <p>Status: {booking.isCancelled ? '❌ Avbokad' : '✅ Aktiv'}</p>
            </div>
        ))}
        </div>
    )}
    </div>
);
};
export default MyBookings;