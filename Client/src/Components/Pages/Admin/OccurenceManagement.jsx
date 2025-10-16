import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import OccurenceListCard from './OccurenceListCard';
import './Admin.css';
import DetailedSearch from '../../DetailedSearch';
import { useCategories } from '../../../contexts/CategoryContext';
import { useActivities } from '../../../contexts/ActivityContext';
import { useLocations } from '../../../contexts/LocationContext';

const OccurenceManagement = () => {
    const [results, setResults] = useState([]);
    const [loading, setLoading] = useState(true);
    const [occurences, setOccurences] = useState([]); // full list
    const [filteredOccurences, setFilteredOccurences] = useState([]); // filtered list
    const [activityIdFilter, setActivityIdFilter] = useState('');
    const [locationIdFilter, setLocationIdFilter] = useState('');
    const [view, setView] = useState(false);

    const { categories } = useCategories();
    const { activities } = useActivities();
    const { locations } = useLocations();

    const handleViewToggle = () => {
        setView(!view);
    };
    const { user } = useAuth();

    const handleActivityIdFilterChange = (e) => {
        setActivityIdFilter(e.target.value);
    };
    const handleLocationIdFilterChange = (e) => {
        setLocationIdFilter(e.target.value);
    };

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
};

    useEffect(() => {
        const fetchOccurences = async () => {
            const response = await fetch('https://localhost:7201/api/ActivityOccurence', {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
            const data = await response.json();
            setOccurences(data);
            setFilteredOccurences(data);
        };
        fetchOccurences();
    }, []);


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
                               {results.map((aresult, index) => (
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
