import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import LocationListCard from './LocationListCard';
import './Admin.css';

const LocationManagement = () => {
    const [locations, setLocations] = useState([]); // full list
    const [filteredLocations, setFilteredLocations] = useState([]); // filtered list
    const [nameFilter, setNameFilter] = useState('');
    const [view, setView] = useState(false);

    const handleViewToggle = () => {
        setView(!view);
    };

    const handleFilterChange = (e) => {
        const value = e.target.value;
        setNameFilter(value);
        setFilteredLocations(
            locations.filter(location =>
                location.name.toLowerCase().includes(value.toLowerCase())
            )
        );
    };
    const { user } = useAuth();

    const handleRemove = async (id) => {
        if (window.confirm(`Are you sure you want to remove location with id ${id}?`)) {
            const newLocations = locations.filter(location => location.id !== id);
            setLocations(newLocations);
            setFilteredLocations(newLocations.filter(location =>
                location.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
            await fetch(`https://localhost:7201/api/Location/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
        }
    };

    const handleEdit = async (location) => {
        if (window.confirm(`Are you sure you want to edit location with id ${location.id}?`)) {
            await fetch(`https://localhost:7201/api/Location/${location.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(location)
            });
            // update local state
            const newLocations = locations.map(loc => loc.id === location.id ? { ...loc, ...location } : loc);
            setLocations(newLocations);
            setFilteredLocations(newLocations.filter(loc =>
                loc.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
        }
    };

    useEffect(() => {
        const fetchLocations = async () => {
            const response = await fetch('https://localhost:7201/api/Location', {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
            const data = await response.json();
            setLocations(data);
            setFilteredLocations(data.filter(location =>
                location.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
        };
        fetchLocations();
    }, [handleEdit]);

    return (
        <>
            <h1>Location Management</h1>
            <div className="management-items-container">
            {!user ? <p>Please log in to manage locations.</p> : (
                <>
                <div className = "admin-buttons">
                           <button className="btn" onClick={() => setView(!view)}>View Locations</button>
                           <button className="btn">Add New</button>
                           <button className="btn">Search</button>
                       </div>
                       <div className="view-toggle">
                        {!view ? (
                               <p></p>
                           ) : (<div className="filter-list">

                               <label>Filtrera med namn:</label> <input type="text" placeholder="Filter..." onChange={handleFilterChange} />

                           {filteredLocations.map(location => (
                               <LocationListCard key={location.id} item={location} removeLocation={handleRemove} editLocation={handleEdit}/>
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

export default LocationManagement;
