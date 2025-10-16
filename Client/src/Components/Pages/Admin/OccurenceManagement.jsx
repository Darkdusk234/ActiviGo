import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import OccurenceListCard from './OccurenceListCard';
import './Admin.css';
import DetailedSearch from '../../DetailedSearch';
import { useCategories } from '../../../contexts/CategoryContext';
import { useActivities } from '../../../contexts/ActivityContext';
import { useLocations } from '../../../contexts/LocationContext';

const OccurenceManagement = () => {
    const [loading, setLoading] = useState(true);
    const [occurences, setOccurences] = useState([]); // full list
    const [filteredOccurences, setFilteredOccurences] = useState([]); // filtered list
    const { categories } = useCategories();
    const { activities } = useActivities();
    const { locations } = useLocations();

    const handleViewToggle = () => {
        setView(!view);
    };
    const { user } = useAuth();



    const handleRemove = async (id) => {
        if (window.confirm(`Are you sure you want to remove occurence with id ${id}?`)) {
            const newOccurences = occurences.filter(occurence => occurence.id !== id);
            setOccurences(newOccurences);
            setFilteredOccurences(newOccurences.filter(occurence =>
                (activityIdFilter ? occurence.activityId.toString().includes(activityIdFilter) : true) &&
                (locationIdFilter ? occurence.locationId.toString().includes(locationIdFilter) : true)
            ));
            await fetch(`https://localhost:7201/api/ActivityOccurence/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
        }
    };

    const handleEdit = async (occurence) => {
        if (window.confirm(`Are you sure you want to edit occurence with id ${occurence.id}?`)) {
            await fetch(`https://localhost:7201/api/ActivityOccurence/${occurence.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(occurence)
            });
            // update local state
            const newOccurences = occurences.map(o => o.id === occurence.id ? { ...o, ...occurence } : o);
            setOccurences(newOccurences);
            setFilteredOccurences(newOccurences.filter(o =>
                (activityIdFilter ? o.activityId.toString().includes(activityIdFilter) : true) &&
                (locationIdFilter ? o.locationId.toString().includes(locationIdFilter) : true)
            ));
        }
    };

const fetchResults = async (searchTerms) => {
    // Extract search terms
    const locationId = locations.find(location => location.name === searchTerms.location)?.id || '';
    const activityId = activities.find(activity => activity.name === searchTerms.activity)?.id || '';
    const categoryId = categories.find(category => category.name === searchTerms.category)?.id || '';
    const fromDate = searchTerms.fromDate || '';
    const toDate = searchTerms.toDate || '';
    const available = searchTerms.availableSpots;

    setLoading(true);
    await fetch('https://localhost:7201/api/ActivityOccurence/search', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            nameFilter: searchTerms.name,
            locationId: locationId,
            activityId: activityId,
            categoryId: categoryId,
            startTime: fromDate,
            endTime: toDate,
            availableToBook: available
        })
    })
    .then(response => response.json())
    .then(data => {
        setOccurences(data);
        setLoading(false);
    })
    .catch(err => {
        console.error('Error fetching search results:', err);
        setLoading(false);
    });
};



    return (
        <>
            <h1>Occurence Management</h1>
                    <div className="management-items-container">
            {!user ? <p>Please log in to manage activities.</p> : (
                <>
                <div className = "admin-buttons">
                           <button className="btn" onClick={handleViewToggle}>Search Occurences</button>
                          
                          
                       </div>
                       <div className="view-toggle">
                        {!view ? (
                               <p></p>
                           ) : (<div className="filter-list">

                               <DetailedSearch fetchResults={fetchResults} />
                           
                       </div>
                           )}
                        </div>
                        <div className="results-section">
                        {loading ? (
                            <p>Loading...</p>
                        ) : (
                            <ul>
                               {occurences.map((aresult, index) => (
                                   <OccurenceListCard key={index} item={aresult} />
                               ))}
                            </ul>
                        )}
                       </div>
                      
                  
                
                </>
            )}
        </div>
        </>
    );
};

export default OccurenceManagement;
