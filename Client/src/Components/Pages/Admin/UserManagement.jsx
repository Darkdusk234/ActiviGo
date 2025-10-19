import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import UserListCard from './UserListCard';
import './Admin.css';

const UserManagement = () => {
    const [users, setUsers] = useState([]);
    const { user, APIURL } = useAuth();

    const handleRemove = async (id) => {
        if (window.confirm(`Are you sure you want to remove user with id ${id}?`)) {
            setUsers(users.filter(userItem => userItem.id !== id));
            await fetch(`${APIURL}/User/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
        }
    };

    const handleEdit = async (userItem) => {
        if (window.confirm(`Are you sure you want to edit user with id ${userItem.id}?`)) {
            await fetch(`${APIURL}/User/${userItem.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(userItem)
            });
        }
    };

    useEffect(() => {
        const fetchUsers = async () => {
            const response = await fetch(`${APIURL}/User`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
            const data = await response.json();
            setUsers(data);
        };
        fetchUsers();
    }, [handleEdit]);

    return (
        <>
            <h1>User Management</h1>
            <div className="management-items-container">
                {!user ? <p>Please log in to manage users.</p> : (
                    users.map(userItem => (
                        <UserListCard key={userItem.id} item={userItem} removeUser={handleRemove} editUser={handleEdit} />
                    ))
                )}
            </div>
        </>
    );
};

export default UserManagement;
