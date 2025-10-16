import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import ActivityListCard from './ActivityListCard';
import './Admin.css';
import { useCategories } from '../../../contexts/CategoryContext';

const ActivityManagement = () => {
    const [activities, setActivities] = useState([]); // full list
    const [filteredActivities, setFilteredActivities] = useState([]); // filtered list
    const [nameFilter, setNameFilter] = useState('');
    const [lengthFilter, setLengthFilter] = useState('');
    const [maxLengthFilter, setMaxLengthFilter] = useState('');
    const [maxParticipantsFilter, setMaxParticipantsFilter] = useState('');
    const [maxPriceFilter, setMaxPriceFilter] = useState('');
    const [categoryFilter, setCategoryFilter] = useState('');
    const [view, setView] = useState(false);

    const { categories } = useCategories(); 

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


    const { user } = useAuth();

    const handleRemove = async (id) => {
        if (window.confirm(`Are you sure you want to remove activity with id ${id}?`)) {
            const newActivities = activities.filter(activity => activity.id !== id);
            setActivities(newActivities);
            setFilteredActivities(newActivities.filter(activity =>
                activity.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
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
            // update local state
            const newActivities = activities.map(act => act.id === activity.id ? { ...act, ...activity } : act);
            setActivities(newActivities);
            setFilteredActivities(newActivities.filter(act =>
                act.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
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
    }, []);

    useEffect(() => {
        let filtered = activities;
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
    }, [activities, nameFilter, lengthFilter, maxLengthFilter, maxParticipantsFilter, maxPriceFilter, categoryFilter]);

    return (
        <>
            <h1>Activity Management</h1>
                    <div className="management-items-container">
            {!user ? <p>Please log in to manage activities.</p> : (
                <>
                <div className = "admin-buttons">
                           <button className="btn" onClick={handleViewToggle}>View Activities</button>
                           <button className="btn">Add New</button>
                           <button className="btn">Search</button>
                       </div>
                       <div className="view-toggle">
                        {!view ? (
                               <p></p>
                           ) : (<div className="filter-list">

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
                           {filteredActivities.map(activity => (
                               <ActivityListCard key={activity.id} item={activity} removeActivity={handleRemove} editActivity={handleEdit}/>
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

export default ActivityManagement;
