import React from 'react';
import { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import AdminListCard from './CategoryListCard';
import { useCategories } from '../../../contexts/CategoryContext';

import './Admin.css';
import CategoryNewPop from './CategoryNewPop';

const CategoryManagement = () => {

    const [allCategories, setCategories] = useState([]); // full list
    const [filteredCategories, setFilteredCategories] = useState([]); // filtered list
    const [view, setView] = useState(false);
    const { user, APIURL } = useAuth();
    const [newPopup, setNewPopup] = useState(false);

    const {categories} = useCategories();


    const [nameFilter, setNameFilter] = useState('');  

    const handleFilterChange = (e) => {
        const value = e.target.value;
        setNameFilter(value);
        setFilteredCategories(
            allCategories.filter(category =>
                category.name.toLowerCase().includes(value.toLowerCase())
            )
        );
    }

    

    const handleRemove = async (id) => {

        if (confirm(`Är du säker på att du vill ta bort kategorin med id ${id}?`)) {
            const newCategories = allCategories.filter(category => category.id !== id);
            setCategories(newCategories);
            setFilteredCategories(newCategories.filter(category =>
                category.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
            await fetch(`${APIURL}/Category/${id}`, {
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
            await fetch(`${APIURL}/Category/${category.id}`, {
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

    const handleCreate = async (category) => {
        const response = await fetch(`${APIURL}/Category`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('authToken')}`
            },
            body: JSON.stringify(category)
        });
        const data = await response.json();
        setCategories([...categories, data]);
        setFilteredCategories([...filteredCategories, data]);
    }

    useEffect(() => {
       setCategories(categories);
       setFilteredCategories(categories);
    }, []);

    return (
        <>
            <h1>Category Management</h1>
        <div className="management-items-container">
            {!user ? <p>Please log in to manage categories.</p> : (
                <>
                <div className = "admin-buttons">
                           <button className="btn" onClick={() => setView(!view)}>View Categories</button>
                           <button className="btn" onClick={()=> setNewPopup(!newPopup)}>Add New</button>
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
                       {newPopup && (<CategoryNewPop handleCreate={handleCreate} closePopup={setNewPopup} />)}
                      
                  
                
                </>
            )}
        </div>
        </>
    );
};

export default CategoryManagement;
