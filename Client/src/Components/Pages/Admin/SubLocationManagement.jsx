import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import SubLocationListCard from './SubLocationListCard';
import './Admin.css';

const SubLocationManagement = () => {
    const [subLocations, setSubLocations] = useState([]);
    const { user } = useAuth();

    const handleRemove = async (id) => {
        if (window.confirm(`Are you sure you want to remove sublocation with id ${id}?`)) {
            setSubLocations(subLocations.filter(subLocation => subLocation.id !== id));
            await fetch(`https://localhost:7201/api/SubLocation/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
        }
    };

    const handleEdit = async (subLocation) => {
        if (window.confirm(`Are you sure you want to edit sublocation with id ${subLocation.id}?`)) {
            await fetch(`https://localhost:7201/api/SubLocation/${subLocation.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(subLocation)
            });
        }
    };

    useEffect(() => {
        const fetchSubLocations = async () => {
            const response = await fetch('https://localhost:7201/api/SubLocation', {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
            const data = await response.json();
            setSubLocations(data);
        };
        fetchSubLocations();
    }, [handleEdit]);

    return (
        <>
            <h1>SubLocation Management</h1>
            <div className="management-items-container">
                {!user ? <p>Please log in to manage sublocations.</p> : (
                    subLocations.map(subLocation => (
                        <SubLocationListCard key={subLocation.id} item={subLocation} removeSubLocation={handleRemove} editSubLocation={handleEdit} />
                    ))
                )}
            </div>
        </>
    );
};

export default SubLocationManagement;
