import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import SubLocationListCard from './SubLocationListCard';
import './Admin.css';

const SubLocationManagement = () => {
    const [subLocations, setSubLocations] = useState([]); // full list
    const [filteredSubLocations, setFilteredSubLocations] = useState([]); // filtered list
    const [nameFilter, setNameFilter] = useState('');
    const [view, setView] = useState(false);
    const { user, APIURL } = useAuth();

    const handleViewToggle = () => {
        setView(!view);
    };

    const handleFilterChange = (e) => {
        const value = e.target.value;
        setNameFilter(value);
        setFilteredSubLocations(
            subLocations.filter(subLocation =>
                subLocation.name.toLowerCase().includes(value.toLowerCase())
            )
        );
    };

    const handleRemove = async (id) => {
        if (window.confirm(`Are you sure you want to remove sublocation with id ${id}?`)) {
            const newSubLocations = subLocations.filter(subLocation => subLocation.id !== id);
            setSubLocations(newSubLocations);
            setFilteredSubLocations(newSubLocations.filter(subLocation =>
                subLocation.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
            await fetch(`${APIURL}/SubLocation/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
        }
    };

    const handleEdit = async (subLocation) => {
        if (window.confirm(`Are you sure you want to edit sublocation with id ${subLocation.id}?`)) {
            await fetch(`${APIURL}/SubLocation/${subLocation.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(subLocation)
            });
            // update local state
            const newSubLocations = subLocations.map(loc => loc.id === subLocation.id ? { ...loc, ...subLocation } : loc);
            setSubLocations(newSubLocations);
            setFilteredSubLocations(newSubLocations.filter(loc =>
                loc.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
        }
    };

    useEffect(() => {
        const fetchSubLocations = async () => {
            const response = await fetch(`${APIURL}/SubLocation`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
            const data = await response.json();
            setSubLocations(data);
            setFilteredSubLocations(data.filter(subLocation =>
                subLocation.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
        };
        fetchSubLocations();
    }, [handleEdit]);

    return (
        <>
            <h1>SubLocation Management</h1>
                    <div className="management-items-container">
            {!user ? <p>Please log in to manage sublocations.</p> : (
                <>
                <div className = "admin-buttons">
                           <button className="btn" onClick={() => setView(!view)}>View SubLocations</button>
                           <button className="btn">Add New</button>
                       </div>
                       <div className="view-toggle">
                        {!view ? (
                               <p></p>
                           ) : (<div className="filter-list">

                               <label>Filtrera med namn:</label> <input type="text" placeholder="Filter..." onChange={handleFilterChange} />

                           {filteredSubLocations.map(subLocation => (
                               <SubLocationListCard key={subLocation.id} item={subLocation} removeSubLocation={handleRemove} editSubLocation={handleEdit}/>
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

export default SubLocationManagement;
