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
      const [newPopup, setNewPopup] = useState(false);
    const { APIURL, user } = useAuth();

    const { categories } = useCategories(); 
    const { activities } = useActivities();

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

    const handleCreate = async (activity) => {
        const response = await fetch(`${APIURL}/Activity`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('authToken')}`
            },
            body: JSON.stringify(activity)
        });
        if (!response.ok) {
            const data = await response.json();
            alert('Misslyckades med att skapa aktivitet: ' + data.map(error => error.errorMessage).join(', '));
            setNewPopup(false);
            return;
        }
        if (response.ok) {
            const data = await response.json();
            alert("Aktivitet skapad.");
            setActivities([...allActivities, data]);
            setFilteredActivities([...filteredActivities, data]);
            setNewPopup(false);
        }
    };


    const handleRemove = async (id) => {
        if (window.confirm(`Är du säker på att du vill ta bort aktiviteten med id ${id}?`)) {
            
            await fetch(`${APIURL}/Activity/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            })
            .then(async response => {
                if (!response.ok) {
                    const data = await response.json();
                    alert('Misslyckades med att ta bort aktivitet: ' + data.map(error => error.errorMessage).join(', '));
                    return;
                }
                if (response.ok) {
                    alert("Aktivitet borttagen.");
                                // update local state
                    const newActivities = allActivities.filter(activity => activity.id !== id);
                    setActivities(newActivities);
                    setFilteredActivities(newActivities);
                }
            });
        }
    };

    const handleEdit = async (activity) => {
        if (window.confirm(`Är du säker på att du vill redigera aktiviteten med id ${activity.id}?`)) {
            await fetch(`${APIURL}/Activity/${activity.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(activity)
            })
            .then(async response => {
                if (!response.ok) {
                    console.log(response);
                    const data = await response.json();
                    console.log(data);
                    setNewPopup(false);
                    return;
                }
            });
            // update local state
            const newActivities = allActivities.map(act => act.id === activity.id ? { ...act, ...activity } : act);
            setActivities(newActivities);
            setFilteredActivities(newActivities.filter(act =>
                act.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
            setNewPopup(false);
        }
    };

    useEffect(() => {
        setActivities(activities);
        setFilteredActivities(activities);
        console.log(activities);
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

    return (
        <>
            <h1>Activity Management</h1>
                    <div className="management-items-container">
            {!user ? <p>Vänligen logga in för att hantera aktiviteter.</p> : (
                <>
                <div className = "admin-buttons">
                           <button className="btn" onClick={() => setNewPopup(!newPopup)}>Lägg till ny</button>
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
};

export default ActivityManagement;
