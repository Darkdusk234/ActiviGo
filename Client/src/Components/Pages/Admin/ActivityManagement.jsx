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
    const [maxPriceFilter, setMaxPriceFilter] = useState('');
    const [categoryFilter, setCategoryFilter] = useState('');

    const [view, setView] = useState(false);
    const [newPopup, setNewPopup] = useState(false);

    const { APIURL, user } = useAuth();

    const { categories } = useCategories(); 
    const { activities } = useActivities();

    const [error, setError] = useState(null);   // for error message
    const [loading, setLoading] = useState(false);
    const [successMessage, setSuccessMessage] = useState(null); // for great succes

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


    const handleLengthFilterChange = (e) => {
        setLengthFilter(Number.parseInt(e.target.value));
    };

    const handleMaxLengthFilterChange = (e) => {
        setMaxLengthFilter(Number.parseInt(e.target.value));
    };

    const handleFilterChange = (e) => {
        setNameFilter(e.target.value);
    };

    const handleMaxPriceChange = (e) => {
        setMaxPriceFilter(Number.parseFloat(e.target.value));
    };
    const handleCategoryFilterChange = (e) => {
        setCategoryFilter(e.target.value);
    };



    // const handleCreate = async (activity) => {
    //     const response = await fetch(`${APIURL}/Activity`, {
    //         method: 'POST',
    //         headers: {
    //             'Content-Type': 'application/json',
    //             'Authorization': `Bearer ${localStorage.getItem('authToken')}`
    //         },
    //         body: JSON.stringify(activity)
    //     });
    //     if (!response.ok) {
    //         const data = await response.json();
    //         alert('Misslyckades med att skapa aktivitet: ' + data.map(error => error.errorMessage).join(', '));
    //         setNewPopup(false);
    //         return;
    //     }
    //     if (response.ok) {
    //         const data = await response.json();
    //         alert("Aktivitet skapad.");
    //         setActivities([...allActivities, data]);
    //         setFilteredActivities([...filteredActivities, data]);
    //         setNewPopup(false);
    //     }
    // };


    // const handleRemove = async (id) => {
    //     if (window.confirm(`Är du säker på att du vill ta bort aktiviteten med id ${id}?`)) {
            
    //         await fetch(`${APIURL}/Activity/${id}`, {
    //             method: 'DELETE',
    //             headers: {
    //                 'Content-Type': 'application/json',
    //                 'Authorization': `Bearer ${localStorage.getItem('authToken')}`
    //             }
    //         })
    //         .then(async response => {
    //             if (!response.ok) {
    //                 const data = await response.json();
    //                 alert('Misslyckades med att ta bort aktivitet: ' + data.map(error => error.errorMessage).join(', '));
    //                 return;
    //             }
    //             if (response.ok) {
    //                 alert("Aktivitet borttagen.");
    //                             // update local state
    //                 const newActivities = allActivities.filter(activity => activity.id !== id);
    //                 setActivities(newActivities);
    //                 setFilteredActivities(newActivities);
    //             }
    //         });
    //     }
    // };

    // const handleEdit = async (activity) => {
    //     if (window.confirm(`Är du säker på att du vill redigera aktiviteten med id ${activity.id}?`)) {
    //         await fetch(`${APIURL}/Activity/${activity.id}`, {
    //             method: 'PUT',
    //             headers: {
    //                 'Content-Type': 'application/json',
    //                 'Authorization': `Bearer ${localStorage.getItem('authToken')}`
    //             },
    //             body: JSON.stringify(activity)
    //         })
    //         .then(async response => {
    //             if (!response.ok) {
    //                 console.log(response);
    //                 const data = await response.json();
    //                 console.log(data);
    //                 setNewPopup(false);
    //                 return;
    //             }
    //         });
    //         // update local state
    //         const newActivities = allActivities.map(act => act.id === activity.id ? { ...act, ...activity } : act);
    //         setActivities(newActivities);
    //         setFilteredActivities(newActivities.filter(act =>
    //             act.name.toLowerCase().includes(nameFilter.toLowerCase())
    //         ));
    //         setNewPopup(false);
    //     }
    // };

    useEffect(() => {
        setActivities(activities);
        setFilteredActivities(activities);
    }, [activities]);

    useEffect(() => {
        let filtered = allActivities;
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
    }, [activities, allActivities, nameFilter, lengthFilter, maxLengthFilter, maxPriceFilter, categoryFilter]);

    const validateActivity = (activity) => {    // to check the wrong doings/inputs
        const errors = [];
        if (!activity.name || activity.name.trim().length === 0) {
            errors.push('Namn är obligatoriskt');
        }
        if (!activity.description || activity.description.trim().length === 0) {
            errors.push('Beskrivning är obligatorisk');
        }
        if (activity.isActive === undefined || activity.isActive === null) {
            errors.push('IsActive måste anges');
        }
        if (!activity.durationInMinutes) {
            errors.push('Längd är obligatorisk');
        } else if (activity.durationInMinutes <= 30) {
            errors.push('Längd måste vara större än 30 minuter');
        }
        if (!activity.maxParticipants) {
            errors.push('MaxParticipants är obligatoriskt');
        } else if (activity.maxParticipants <= 1) {
            errors.push('MaxParticipants måste vara större än 1');
        }
        if (activity.price === undefined || activity.price === null) {
            errors.push('Pris är obligatoriskt');
        } else if (activity.price < 0) {
            errors.push('Pris måste vara större än eller lika med 0');
        }
        if (!activity.categoryId) {
            errors.push('Du måste välja en kategori');
        }
        return errors;
    };

    const handleCreate = async (activity) => {
        // rules for creating
        const validationErrors = validateActivity(activity);
        if (validationErrors.length > 0) {
            showError(`❌ Valideringsfel:\n${validationErrors.join('\n')}`);
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
        const validationErrors = validateActivity(activity);
        if (validationErrors.length > 0) {
            showError(`❌ Valideringsfel:\n${validationErrors.join('\n')}`);
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

    return (
        <>
        <h1>Activity Management</h1>
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
            <div className="management-items-container">
            {!user ? <p>Please log in to manage activities.</p> : (
                <>
                <div className = "admin-buttons">
                        
                        <button className="btn" onClick={() => setNewPopup(!newPopup)}>Add New</button>
                    </div>
                    
                        <div>
                            <div className="filter-list">
                            <label>Filtrera med namn:</label> <input type="text" placeholder="Filter..." onChange={handleFilterChange} />
                            <label>Minimumlängd:</label> <input type="number" placeholder="Min längd..." onChange={handleLengthFilterChange} />
                            <label>Maximumlängd:</label> <input type="number" placeholder="Max längd..." onChange={handleMaxLengthFilterChange} />
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
                        
                    
                    {newPopup && (<ActivityNewPop handleCreate={handleCreate} closePopup={setNewPopup} />)}
                </>
            )}
            </div>
        </>
    );
}
export default ActivityManagement;