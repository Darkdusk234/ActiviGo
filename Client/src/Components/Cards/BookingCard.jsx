import React, { useContext } from 'react';
import { AuthContext } from '../../contexts/AuthContext'; // Importera AuthContext
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCalendarAlt, faUsers, faClock, faTimes, faCheck } from '@fortawesome/free-solid-svg-icons';
import "./BookingCard.css";

const BookingCard = ({ items }) => {
    const { token, APIURL } = useContext(AuthContext); // Hämta token och APIURL från kontext

    const handleCancelBooking = async () => {
        if (!token) {
            alert('Du måste vara inloggad för att avboka!');
            return;
        }

        if (window.confirm('Är du säker på att du vill avboka denna bokning?')) {
            try {
                const response = await fetch(`${APIURL}/Booking/cancel/${items.id}`, {
                    method: 'PUT', // Använd DELETE för avbokning
                    headers: {
                        'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                    }
                });

                if (!response.ok) {
                    throw new Error(`Avbokning misslyckades (${response.status})`);
                }

                alert('Bokningen har avbokats!');
            } catch (err) {
                alert('Ett fel uppstod vid avbokning: ' + err.message);
            }
        }
    };

    return (
        <div className="booking-card">
            <div className='booking-img'>
                <img
                    src={`https://picsum.photos/400/250?random=${items.activityId}` || items.imgUrl}
                    alt={items.activityName || 'Aktivitet'}
                />
            </div>
            <div className='info'>
                <h3>{items.activityName || 'Aktivitet'}</h3>
                <p><FontAwesomeIcon icon={faCalendarAlt} /> Datum: {new Date(items.activityStartTime).toLocaleDateString('sv-SE')}</p>
                <p><FontAwesomeIcon icon={faUsers} /> Bokade platser: {items.participants}</p>
                <p><FontAwesomeIcon icon={faClock} /> Tid: {new Date(items.activityStartTime).toLocaleTimeString('sv-SE', { hour: '2-digit', minute: '2-digit' })} - {new Date(items.activityEndTime).toLocaleTimeString('sv-SE', { hour: '2-digit', minute: '2-digit' })}</p>
                <p>Status: {items.isCancelled ? <FontAwesomeIcon icon={faTimes} /> : <FontAwesomeIcon icon={faCheck} />} {items.isCancelled ? 'Avbokad' : 'Aktiv'}</p>
                <p>{items.isOutdoor ? 'Utomhus' : 'Inomhus'}</p>
                <p>{items.subLocationName}</p>
            </div>
            <div className='booking-cancel-btn'>
                {!items.isCancelled && ( // Visa bara om bokningen inte redan är avbokad
                    <button onClick={handleCancelBooking}>Avboka</button>
                )}
            </div>
        </div>
    );
};

export default BookingCard;
