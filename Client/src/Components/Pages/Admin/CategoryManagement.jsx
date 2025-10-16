import React from 'react';
import { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import AdminListCard from './CategoryListCard';

import './Admin.css';

const CategoryManagement = () => {

    const [categories, setCategories] = useState([]);

    const { user } = useAuth();

    const handleRemove = async (id) => {

        if (confirm(`Är du säker på att du vill ta bort kategorin med id ${id}?`)) {
            setCategories(categories.filter(category => category.id !== id));

             await fetch(`https://localhost:7201/api/Category/${id}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('authToken')}`
            }
        });
        }
       
    }

    const handleEdit = async (category) => {
       if(confirm(`Är du säker på att du vill redigera kategorin med id ${category.id}?`)) {

        await fetch(`https://localhost:7201/api/Category/${category.id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('authToken')}`
            },
            body: JSON.stringify(category)
        });
       }
    }




    useEffect(() => {
        // Fetch categories from API
        const fetchCategories = async () => {
            const response = await fetch('https://localhost:7201/api/Category',
                { method: 'GET', 
                    headers: { 'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}` }
                }
            );
            const data = await response.json();
            setCategories(data);

        };
        fetchCategories();
    }, [handleEdit]);

    return (
        <>
            <h1>Category Management</h1>
        <div className="management-items-container">
            {!user ? <p>Please log in to manage categories.</p> : (
                categories.map(category => (
                    <AdminListCard key={category.id} item={category} removeCategory={handleRemove} editCategory={handleEdit}/>
                ))
            )}
        </div>
        </>
    );
};

export default CategoryManagement;
