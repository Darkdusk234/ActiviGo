import React from 'react';
import { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import CategoryListCard from './CategoryListCard';
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

    const [error, setError] = useState(null);   
    const [loading, setLoading] = useState(false);
    const [successMessage, setSuccessMessage] = useState(null);
    
    const showSuccess = (message) => {
        setSuccessMessage(message);
        setTimeout(() => setSuccessMessage(null), 5000); 
    };
    const showError = (message) => {
        setError(message);
    };
    useEffect(() => {
        setCategories(categories);
        setFilteredCategories(categories);
        }, [categories]);
    
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
    const validateCategory = (category) => {
        const errors = [];
        if (!category.name || category.name.trim().length === 0) {
            errors.push('Namn är obligatoriskt');
        } else if (category.name.trim().length < 3) {
            errors.push('Namn måste vara minst 3 tecken');
        } else if (category.name.length > 100) {
            errors.push('Namn får inte överskrida 100 tecken');
        }
        if (category.description && category.description.length > 500) {
            errors.push('Hur orkar du skriva en beskrivning över 500 tecken!!!!');
        }
        return errors;
    };
    
    const handleRemove = async (id) => {
        if (!window.confirm(`Är du säker på att du vill ta bort kategorin med id ${id}?`)) {
            return;
        }
        setLoading(true);
        setError(null);
        try {
            const response = await fetch(`${APIURL}/Category/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(errorText || 'Kunde inte ta bort kategori');
            }
            const newCategories = allCategories.filter(category => category.id !== id);
            setCategories(newCategories);
            setFilteredCategories(newCategories);
            
            showSuccess('✅ Kategori borttagen!');
        } catch (err) {
            console.error('❌ Delete error:', err);
            showError(`Fel vid borttagning: ${err.message}`);
        } finally {
            setLoading(false);

        }
    };

    const handleEdit = async (category) => {
        if (!window.confirm(`Är du säker på att du vill redigera kategorin med id ${category.id}?`)) {
            return;
        }
        const validationErrors = validateCategory(category);
        if (validationErrors.length > 0) {
            showError(`❌ Valideringsfel:\n${validationErrors.join('\n')}`);
            return;
        }
        setLoading(true);
        setError(null);
        try {
            const response = await fetch(`${APIURL}/Category/${category.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(category)
            })            
            .then(response => {
                console.log(response);
                if (!response.ok) 
                {
                    alert('Misslyckades med att uppdatera kategori: ' + response.statusText);
                }
                else
                {
                    alert('Kategori uppdaterad: ' + response.statusText);
                }
            });
            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(errorText || 'Kunde inte uppdatera kategori');
            }
            const newCategories = allCategories.map(cat => 
                cat.id === category.id ? { ...cat, ...category } : cat
            );
            setCategories(newCategories);
            setFilteredCategories(newCategories);
            
            showSuccess('✅ Kategori uppdaterad!');
        } catch (err) {
            console.error('❌ Edit error:', err);
            showError(`Fel vid uppdatering: ${err.message}`);
        } finally {
            setLoading(false);
        }
    };

    const handleCreate = async (category) => {
        const validationErrors = validateCategory(category);
        if (validationErrors.length > 0) {
            showError(`❌ Valideringsfel:\n${validationErrors.join('\n')}`);
            return;
        }
        setLoading(true);
        setError(null);
        try {
            // console.log('Skapar kategori:', JSON.stringify(category));
            const response = await fetch(`${APIURL}/Category`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(category)
            });
            if (!response.ok) {
                const errorText = await response.text();
                console.error('❌ Backend error:', errorText);
                throw new Error(errorText || `HTTP Error: ${response.status}`);
            }
            const contentType = response.headers.get('content-type');
            if (!contentType?.includes('application/json')) {
                const textResponse = await response.text();
                console.error('❌ Inte JSON:', textResponse);
                throw new Error('Backend returnerade inte JSON');
            }
            const newCategory = await response.json();
            console.log('✅ Skapad:', newCategory);
            const updatedCategories = [...allCategories, newCategory];
            setCategories(updatedCategories);
            setFilteredCategories(updatedCategories);
            
            showSuccess('✅ Kategori skapad!');
            setNewPopup(false);
        } catch (err) {
            console.error('❌ Error:', err);
            showError(`Fel: ${err.message}`);
        } finally {
            setLoading(false);
        }
    };
  
    return (
        <>
            <h1>Category Management</h1>
        <div className="management-items-container">
        {error && (
                    <div className="error-banner" style={{ whiteSpace: 'pre-line' }}>
                        {error}
                    </div>
                )}
                {successMessage && (
                    <div className="success-banner">
                        {successMessage}
                    </div>
                )}
            {!user ? <p>Logga in för att hantera kategorier.</p> : (
                <>
                <div className = "admin-buttons">
                        <button className="btn" onClick={()=> setNewPopup(!newPopup)}>Lägg till ny</button>
                    </div>
                    <div className="filter-list">
                            <label>Filtrera med namn:</label> <input type="text" placeholder="Filter..." onChange={handleFilterChange} />
                            
                    </div>
                    <div>
                            {filteredCategories.map(category => (
                                <CategoryListCard key={category.id} item={category} removeCategory={handleRemove} editCategory={handleEdit}/>
                            ))}
                    </div>
                   
                    {newPopup && (<CategoryNewPop handleCreate={handleCreate} closePopup={setNewPopup} />)}
                    
                </>
            )}  
        </div>
        </>
    );
};

export default CategoryManagement;
