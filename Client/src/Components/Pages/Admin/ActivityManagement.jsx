import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import ActivityListCard from './ActivityListCard';
import ActivityNewPop from './ActivityNewPop';
import './Admin.css';
import { useCategories } from '../../../contexts/CategoryContext';
import { useActivities } from '../../../contexts/ActivityContext';

const ActivityManagement = () => {
    const [allActivities, setActivities] = useState([]); // full list
    const [filteredActivities, setFilteredActivities] = useState([]); // filtered list
    const [nameFilter, setNameFilter] = useState('');
    const [lengthFilter, setLengthFilter] = useState('');
    const [maxLengthFilter, setMaxLengthFilter] = useState('');
    const [maxParticipantsFilter, setMaxParticipantsFilter] = useState('');
    const [maxPriceFilter, setMaxPriceFilter] = useState('');
    const [categoryFilter, setCategoryFilter] = useState('');
    const [view, setView] = useState(false);
    const [newPopup, setNewPopup] = useState(false);
    const { APIURL, user } = useAuth();

    const { categories } = useCategories(); 
    const { activities } = useActivities();

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
        setActivities(activities);
        setFilteredActivities(activities);
    }, [activities]);

    const handleViewToggle = () => {
        setView(!view);
    };

    const handleLengthFilterChange = (e) => {
        setLengthFilter(Number.parseInt(e.target.value));
    };

    const handleMaxLengthFilterChange = (e) => {
        setMaxLengthFilter(Number.parseInt(e.target.value));
    };

    const handleFilterChange = (e) => {
        setNameFilter(e.target.value);
    };

    const handleMaxParticipantsChange = (e) => {
        setMaxParticipantsFilter(Number.parseInt(e.target.value));
    };
    const handleMaxPriceChange = (e) => {
        setMaxPriceFilter(Number.parseFloat(e.target.value));
    };
    const handleCategoryFilterChange = (e) => {
        setCategoryFilter(e.target.value);
    };

    const handleCreate = async (activity) => {
        // rules for creating
        if (!activity.name || activity.name.trim().length < 2) {
            showError('❌ Aktivitetsnamn måste vara minst 2 tecken');
            return;
        }
    
        if (!activity.description || activity.description.trim().length < 5) {
            showError('❌ Beskrivning måste vara minst 5 tecken');
            return;
        }
    
        if (!activity.durationInMinutes || activity.durationInMinutes < 29) {
            showError('❌ Längd måste vara minst 30 minut');
            return;
        }
    
        if (!activity.categoryId) {
            showError('❌ Du måste välja en kategori');
            return;
        }
        setLoading(true);
        setError(null);
        try {
            // console.log('Skickar activity:', JSON.stringify(activity));
            
            const response = await fetch(`${APIURL}/Activity`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(activity)
            });
            // console.log('Response status:', response.status);

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
            const newActivity = await response.json();
            console.log('✅ Skapad:', newActivity);
            
            const updatedActivities = [...allActivities, newActivity];
            setActivities(updatedActivities);
            setFilteredActivities(updatedActivities);
            
            showSuccess('✅ Aktivitet skapad!');
            setNewPopup(false); 
        } catch (err) {
            console.error('❌ Error:', err);
            showError(`Fel: ${err.message}`);
        } finally {
            setLoading(false);
        }
    };

    const handleRemove = async (id) => {
        if (!window.confirm(`Är du säker på att du vill ta bort aktivitet med id ${id}?`)) {
            return;
        }
        setLoading(true);
        setError(null);
        try {
            const response = await fetch(`${APIURL}/Activity/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(errorText || 'Kunde inte ta bort aktivitet');
            }
            const newActivities = allActivities.filter(activity => activity.id !== id);
            setActivities(newActivities);
            setFilteredActivities(newActivities);
            
            showSuccess('✅ Aktivitet borttagen!');
        } catch (err) {
            console.error('Delete error:', err);
            showError(`❌ Fel vid borttagning: ${err.message}`);
        } finally {
            setLoading(false);
        }
    };

    const handleEdit = async (activity) => {
        if (!window.confirm(`Är du säker på att du vill redigera aktivitet med id ${activity.id}?`)) {
            return;
        }
        setLoading(true);
        setError(null);
        try {
            const response = await fetch(`${APIURL}/Activity/${activity.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(activity)
            });
            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(errorText || 'Kunde inte uppdatera aktivitet');
            }
            const newActivities = allActivities.map(act => 
                act.id === activity.id ? { ...act, ...activity } : act
            );
            setActivities(newActivities);
            setFilteredActivities(newActivities);
            
            showSuccess('✅ Aktivitet uppdaterad!');
        } catch (err) {
            console.error('Edit error:', err);
            showError(`❌ Fel vid uppdatering: ${err.message}`);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        setActivities(activities);
        setFilteredActivities(activities);
    }, [allActivities]);

    useEffect(() => {
        let filtered = allActivities;
        console.log(allActivities);
        if (nameFilter) {
            filtered = filtered.filter(activity =>
                activity.name.toLowerCase().includes(nameFilter.toLowerCase())
            );
        }
        if (lengthFilter) {
            filtered = filtered.filter(activity =>
                activity.durationInMinutes >= lengthFilter
            );
        }
        if (maxLengthFilter) {
            filtered = filtered.filter(activity =>
                activity.durationInMinutes <= maxLengthFilter
            );
        }
        if (maxParticipantsFilter) {
            filtered = filtered.filter(activity =>
                activity.maxParticipants <= maxParticipantsFilter
            );
        }
        if (maxPriceFilter) {
            filtered = filtered.filter(activity =>
                activity.price <= maxPriceFilter
            );
        }
        if (categoryFilter) {
            filtered = filtered.filter(activity =>
                activity.categoryId === Number.parseInt(categoryFilter)
            );
        }
        setFilteredActivities(filtered);
    }, [allActivities, nameFilter, lengthFilter, maxLengthFilter, maxParticipantsFilter, maxPriceFilter, categoryFilter]);

    return (
        <>
        <h1>Activity Management</h1>
        {error && (
                <div className="error-banner">
                    {error}
                </div>
            )}
                {successMessage && (
                <div className="success-banner">
                    {successMessage}
                </div>
            )}
            <div className="management-items-container">
            {!user ? <p>Please log in to manage activities.</p> : (
                <>
                <div className = "admin-buttons">
                        <button className="btn" onClick={handleViewToggle}>View Activities</button>
                        <button className="btn" onClick={() => setNewPopup(!newPopup)}>Add New</button>
                    </div>
                    <div className="view-toggle">
                        {!view ? (
                        <p></p>
                        ) : (<div>
                            <div className="filter-list">
                            <label>Filtrera med namn:</label> <input type="text" placeholder="Filter..." onChange={handleFilterChange} />
                            <label>Minimumlängd:</label> <input type="number" placeholder="Min längd..." onChange={handleLengthFilterChange} />
                            <label>Maximumlängd:</label> <input type="number" placeholder="Max längd..." onChange={handleMaxLengthFilterChange} />
                            <label>Max deltagare:</label> <input type="number" placeholder="Max deltagare..." onChange={handleMaxParticipantsChange} />
                            <label>Maxpris:</label> <input type="number" placeholder="Maxpris..." onChange={handleMaxPriceChange} /> 
                            <label>Kategori:</label><select onChange={handleCategoryFilterChange}>
                                <option value="">Alla</option>
                                    {categories.map(category => (
                                        <option key={category.id} value={category.id}>{category.name}</option>
                                    ))}
                            </select>
                            </div>
                            <div className="results-section">
                        {filteredActivities.map(activity => (
                            <ActivityListCard key={activity.id} item={activity} removeActivity={handleRemove} editActivity={handleEdit}/>
                        ))}
                            </div>
                        </div>
                        )}
                    </div>
                    {newPopup && (<ActivityNewPop handleCreate={handleCreate} closePopup={setNewPopup} />)}
                </>
            )}
            </div>
        </>
    );
}
export default ActivityManagement;