import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import ActivityListCard from './ActivityListCard';
import './Admin.css';

const ActivityManagement = () => {
    const [activities, setActivities] = useState([]);
    const { user } = useAuth();

    const handleRemove = async (id) => {
        if (window.confirm(`Are you sure you want to remove activity with id ${id}?`)) {
            setActivities(activities.filter(activity => activity.id !== id));
            await fetch(`https://localhost:7201/api/Activity/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
        }
    };

    const handleEdit = async (activity) => {
        if (window.confirm(`Are you sure you want to edit activity with id ${activity.id}?`)) {
            await fetch(`https://localhost:7201/api/Activity/${activity.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(activity)
            });
        }
    };

    useEffect(() => {
        const fetchActivities = async () => {
            const response = await fetch('https://localhost:7201/api/Activity', {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
            const data = await response.json();
            setActivities(data);
        };
        fetchActivities();
    }, [handleEdit]);

    return (
        <>
            <h1>Activity Management</h1>
            <div className="management-items-container">
                {!user ? <p>Please log in to manage activities.</p> : (
                    activities.map(activity => (
                        <ActivityListCard key={activity.id} item={activity} removeActivity={handleRemove} editActivity={handleEdit} />
                    ))
                )}
            </div>
        </>
    );
};

export default ActivityManagement;
