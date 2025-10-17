import React from 'react';
import { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import AdminListCard from './CategoryListCard';

import './Admin.css';

const CategoryManagement = () => {

    const [categories, setCategories] = useState([]); // full list
    const [filteredCategories, setFilteredCategories] = useState([]); // filtered list
    const [view, setView] = useState(false);
    const { user } = useAuth();

    const [nameFilter, setNameFilter] = useState('');  

    const handleFilterChange = (e) => {
        const value = e.target.value;
        setNameFilter(value);
        setFilteredCategories(
            categories.filter(category =>
                category.name.toLowerCase().includes(value.toLowerCase())
            )
        );
    }

    

    const handleRemove = async (id) => {

        if (confirm(`Är du säker på att du vill ta bort kategorin med id ${id}?`)) {
            const newCategories = categories.filter(category => category.id !== id);
            setCategories(newCategories);
            setFilteredCategories(newCategories.filter(category =>
                category.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
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
            // update local state
            const newCategories = categories.map(cat => cat.id === category.id ? { ...cat, ...category } : cat);
            setCategories(newCategories);
            setFilteredCategories(newCategories.filter(cat =>
                cat.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
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
            setFilteredCategories(data.filter(category =>
                category.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
        };
        fetchCategories();
    }, [handleEdit]);

    return (
        <>
            <h1>Category Management</h1>
        <div className="management-items-container">
            {!user ? <p>Please log in to manage categories.</p> : (
                <>
                <div className = "admin-buttons">
                           <button className="btn" onClick={() => setView(!view)}>View Categories</button>
                           <button className="btn">Add New</button>
                       </div>
                       <div className="view-toggle">
                        {!view ? (
                               <p></p>
                           ) : (<div className="filter-list">

                               <label>Filtrera med namn:</label> <input type="text" placeholder="Filter..." onChange={handleFilterChange} />
                                 
                           {filteredCategories.map(category => (
                               <AdminListCard key={category.id} item={category} removeCategory={handleRemove} editCategory={handleEdit}/>
                           ))}
                       </div>
                           )}
                       </div>
                      
                  
                
                </>
            )}
        </div>
        </>
    );
};

export default CategoryManagement;
