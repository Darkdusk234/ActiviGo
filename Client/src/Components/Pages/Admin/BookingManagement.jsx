import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import BookingListCard from './BookingListCard';
import './Admin.css';

const BookingManagement = () => {
    const [bookings, setBookings] = useState([]); // full list
    const [filteredBookings, setFilteredBookings] = useState([]); // filtered list
    const [userIdFilter, setUserIdFilter] = useState('');
    const [statusFilter, setStatusFilter] = useState('');
    const { user, APIURL } = useAuth();

    const handleUserIdFilterChange = (e) => {
        setUserIdFilter(e.target.value);
    };
    const handleStatusFilterChange = (e) => {
        setStatusFilter(e.target.value);
    };

    const handleRemove = async (id) => {
        if (window.confirm(`Are you sure you want to remove booking with id ${id}?`)) {
            const newBookings = bookings.filter(booking => booking.id !== id);
            setBookings(newBookings);
            setFilteredBookings(newBookings.filter(booking =>
                (userIdFilter ? booking.userId.toString().includes(userIdFilter) : true) &&
                (statusFilter ? booking.status.toLowerCase().includes(statusFilter.toLowerCase()) : true)
            ));
            await fetch(`${APIURL}/Booking/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
        }
    };

    const handleEdit = async (booking) => {
        if (window.confirm(`Are you sure you want to edit booking with id ${booking.id}?`)) {
            await fetch(`${APIURL}/Booking/${booking.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(booking)
            });
            // update local state
            const newBookings = bookings.map(b => b.id === booking.id ? { ...b, ...booking } : b);
            setBookings(newBookings);
            setFilteredBookings(newBookings.filter(b =>
                (userIdFilter ? b.userId.toString().includes(userIdFilter) : true) &&
                (statusFilter ? b.status.toLowerCase().includes(statusFilter.toLowerCase()) : true)
            ));
        }
    };

    useEffect(() => {
        const fetchBookings = async () => {
            const response = await fetch(`${APIURL}/Booking`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
            const data = await response.json();

            setBookings(data);
            setFilteredBookings(data);
        };
        fetchBookings();
    }, []);

    useEffect(() => {
        let filtered = bookings;
        if (userIdFilter) {
            filtered = filtered.filter(booking => booking.userId.toString().includes(userIdFilter));
        }
        if (statusFilter) {
            filtered = filtered.filter(booking => booking.status.toLowerCase().includes(statusFilter.toLowerCase()));
        }
        setFilteredBookings(filtered);
    }, [bookings, userIdFilter, statusFilter]);

    return (
        <>
            <h1>Booking Management</h1>
            <div className="management-items-container">
                {!user ? <p>Please log in to manage bookings.</p> : (
                    <>
                        <input type="text" placeholder="Filter by User ID..." onChange={handleUserIdFilterChange} />
                        <input type="text" placeholder="Filter by Status..." onChange={handleStatusFilterChange} />
                        {filteredBookings.map(booking => (
                            <BookingListCard key={booking.id} item={booking} removeBooking={handleRemove} editBooking={handleEdit} />
                        ))}
                    </>
                )}
            </div>
        </>
    );
};

export default BookingManagement;
