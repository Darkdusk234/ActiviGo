import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import LocationListCard from './LocationListCard';
import LocationNewPop from './LocationNewPop';
import { useLocations } from '../../../contexts/LocationContext';
import './Admin.css';

const LocationManagement = () => {
    const [allLocations, setLocations] = useState([]); // full list
    const [filteredLocations, setFilteredLocations] = useState([]); // filtered list
    const [nameFilter, setNameFilter] = useState('');

    const { user, APIURL } = useAuth();
    const [newPopup, setNewPopup] = useState(false);

    const { locations } = useLocations();

    const [error, setError] = useState(null);   
    const [loading, setLoading] = useState(false);
    const [successMessage, setSuccessMessage] = useState(null);

    const showSuccess = (message) => {
        setSuccessMessage(message);
        setTimeout(() => setSuccessMessage(null), 5000);
    }
    const showError = (message) => {
        setError(message);
    }
    const handleViewToggle = () => {
        setView(!view);
    };


    const handleFilterChange = (e) => {
        const value = e.target.value;
        setNameFilter(value);
        setFilteredLocations(
            allLocations.filter(location =>
                location.name.toLowerCase().includes(value.toLowerCase())
            )
        );
    };
    const validateLocation = (location) => {
        const errors = [];
        if (!location.name || location.name.trim().length === 0) {
            errors.push('Namn är obligatoriskt');
        } else if (location.name.trim().length < 3) {
            errors.push('Namn måste vara minst 3 tecken');
        } else if (location.name.length > 100) {
            errors.push('Namn får inte överskrida 100 tecken');
        }

        if (location.description && location.description.length > 500) {
            errors.push('Beskrivning får inte överskrida 500 tecken');
        }

        if (location.adress && location.adress.length > 200) {
            errors.push('Adress får inte överskrida 200 tecken');
        }

        if (!location.latitude || location.latitude.trim().length === 0) {
            errors.push('Latitud är obligatoriskt');
        } else if (location.latitude.trim().length < 2) {
            errors.push('Latitud måste vara minst 2 tecken');
        } else {
            const lat = parseFloat(location.latitude);
            if (isNaN(lat) || lat < 55 || lat > 69) {
                errors.push('Latitud måste vara ett giltigt decimaltal mellan 55 och 69');
            }
        }

        if (!location.longitude || location.longitude.trim().length === 0) {
            errors.push('Longitud är obligatoriskt');
        } else if (location.longitude.trim().length < 2) {
            errors.push('Longitud måste vara minst 2 tecken');
        } else {
            const lon = parseFloat(location.longitude);
            if (isNaN(lon) || lon < 10 || lon > 25) {
                errors.push('Longitud måste vara ett giltigt decimaltal mellan 10 och 25');
            }
        }
        return errors;
    };

    const handleRemove = async (id) => {
        if (!window.confirm(`Är du säker på att du vill ta bort plats med id ${id}?`)) {
            return;
        }
        setLoading(true);
        setError(null);
        try{
            const response = await fetch(`${APIURL}/Location/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            })
            .then(async response => {
                if (!response.ok) 
                {
                    const data = await response.json();
                    alert('Misslyckades med att ta bort plats: ' + data.map(error => error.errorMessage).join(', '));
                }
                else
                {
                    console.log(response);
                    alert('Plats borttagen.');
                }
            });
            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(errorText || 'Kunde inte ta bort plats');
            }
            const newLocations = allLocations.filter(location => location.id !== id);
            setLocations(newLocations);
            setFilteredLocations(newLocations);
            
            showSuccess('✅ Plats borttagen!');
        } catch (err) {
            console.error('❌ Delete error:', err);
            showError(`Fel vid borttagning: ${err.message}`);
        } finally {
            setLoading(false);
        }
    };

    const handleEdit = async (location) => {
        console.log(location);
        if (!window.confirm(`Är du säker på att du vill redigera plats med id ${location.id}?`)) {
            return;
        }
        const validationErrors = validateLocation(location);
        if (validationErrors.length > 0) {
            showError(`❌ Valideringsfel:\n${validationErrors.join('\n')}`);
            return;
        }
        setLoading(true);
        setError(null);
        try {
            const response = await fetch(`${APIURL}/Location/${location.id}`, {

                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(location)
            });
            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(errorText || 'Kunde inte uppdatera plats');
            }
            // update local state
            const newLocations = allLocations.map(loc => 
                loc.id === location.id ? { ...loc, ...location } : loc
            );
            setLocations(newLocations);
            setFilteredLocations(newLocations);
            
            showSuccess('✅ Plats uppdaterad!');
        } catch (err) {
            console.error('❌ Edit error:', err);
            showError(`Fel vid uppdatering: ${err.message}`);
        } finally {
            setLoading(false);
        }
    };
    
    const handleCreate = async (location) => {
        const validationErrors = validateLocation(location);
        if (validationErrors.length > 0) {
            showError(`❌ Valideringsfel:\n${validationErrors.join('\n')}`);
            return;
        }
        setLoading(true);
        setError(null);
        try {
            console.log(JSON.stringify(location));
            const response = await fetch(`${APIURL}/Location`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(location)
            });
            if(!response.ok){
                const errorText = await response.text();
                console.error('❌ Backend error:', errorText);
                throw new Error(errorText || `HTTP Error: ${response.status}`);
            }
            const newLocation = await response.json();
            console.log('✅ Skapad:', newLocation);
            const updatedLocations = [...allLocations, newLocation];
            setLocations(updatedLocations);
            setFilteredLocations(updatedLocations);
            
            showSuccess('✅ Plats skapad!');
            setNewPopup(false);
        } catch (err) {
            console.error('❌ Error:', err);
            showError(`Fel: ${err.message}`);
        } finally {
            setLoading(false);
        }
    };


    useEffect(() => {
        setLocations(locations);
        setFilteredLocations(locations);
    }, [locations]);

    return (
        <>
            <h1>Location Management</h1>
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
            {!user ? <p>Behöver logga in för att göra ändringar.</p> : (
                <>
                <div className = "admin-buttons">
                        <button className="btn" onClick={() => setNewPopup(!newPopup)}>Add New</button>
                    </div>
                    
                        <div className="filter-list">
                            <label>Filtrera med namn:</label> <input type="text" placeholder="Filter..." onChange={handleFilterChange} />
                        </div>
                        <div>
                        {filteredLocations.map(location => (
                            <LocationListCard key={location.id} item={location} removeLocation={handleRemove} editLocation={handleEdit}/>
                        ))}
                    </div>
                    
                    
                {newPopup && (<LocationNewPop handleCreate={handleCreate} closePopup={setNewPopup} />)}

                </>
            )}
        </div>
        </>
    );
};

export default LocationManagement;
