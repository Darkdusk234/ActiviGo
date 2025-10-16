import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import LocationListCard from './LocationListCard';
import './Admin.css';

const LocationManagement = () => {
    const [locations, setLocations] = useState([]);
    const { user } = useAuth();

    const handleRemove = async (id) => {
        if (window.confirm(`Are you sure you want to remove location with id ${id}?`)) {
            setLocations(locations.filter(location => location.id !== id));
            await fetch(`https://localhost:7201/api/Location/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
        }
    };

    const handleEdit = async (location) => {
        if (window.confirm(`Are you sure you want to edit location with id ${location.id}?`)) {
            await fetch(`https://localhost:7201/api/Location/${location.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(location)
            });
        }
    };

    useEffect(() => {
        const fetchLocations = async () => {
            const response = await fetch('https://localhost:7201/api/Location', {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
            const data = await response.json();
            setLocations(data);
        };
        fetchLocations();
    }, [handleEdit]);

    return (
        <>
            <h1>Location Management</h1>
            <div className="management-items-container">
                {!user ? <p>Please log in to manage locations.</p> : (
                    locations.map(location => (
                        <LocationListCard key={location.id} item={location} removeLocation={handleRemove} editLocation={handleEdit} />
                    ))
                )}
            </div>
        </>
    );
};

export default LocationManagement;
