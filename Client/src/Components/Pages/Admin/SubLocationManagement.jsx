import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import SubLocationListCard from './SubLocationListCard';
import './Admin.css';
import SubLocationNewPop from './SubLocationNewPop';
import { useSubLocations } from '../../../contexts/SubLocationContext';

const SubLocationManagement = () => {
    const [allSubLocations, setSubLocations] = useState([]); // full list
    const [filteredSubLocations, setFilteredSubLocations] = useState([]); // filtered list
    const [nameFilter, setNameFilter] = useState('');
    const [view, setView] = useState(false);
    const { user, APIURL } = useAuth();
    const [newPopup, setNewPopup] = useState(false);
    const { subLocations } = useSubLocations();

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
        setSubLocations(subLocations);
        setFilteredSubLocations(subLocations);
    }, [subLocations]);
    const handleViewToggle = () => {
        setView(!view);
    };

    const handleFilterChange = (e) => {
        const value = e.target.value;
        setNameFilter(value);
        setFilteredSubLocations(
            allSubLocations.filter(subLocation =>
                subLocation.name.toLowerCase().includes(value.toLowerCase())
            )
        );
    };
    const validateSubLocation = (subLocation) => {
        const errors = [];
        if (!subLocation.name || subLocation.name.trim().length === 0) {
            errors.push('Namn är obligatoriskt');
        } else if (subLocation.name.trim().length < 2) {
            errors.push('Namn måste vara minst 2 tecken');
        } else if (subLocation.name.length > 100) {
            errors.push('Namn får inte överskrida 100 tecken');
        }
        if (subLocation.description && subLocation.description.length > 500) {
            errors.push('Hur orkar du skriva en beskrivning över 500 tecken!!!!');
        }
        if (!subLocation.maxCapacity || subLocation.maxCapacity <= 0) {
            errors.push('MaxCapacity måste vara större än 0');
        }
        if (!subLocation.locationId || subLocation.locationId <= 0) {
            errors.push('LocationId måste vara ett positivt heltal');
        }
        return errors;
    };
    const handleRemove = async (id) => {
        if (!window.confirm(`Är du säker på att du vill ta bort detta området med id ${id}?`)) {
            return;
        }
        setLoading(true);
        setError(null);

        try {
            const response = await fetch(`${APIURL}/SubLocation/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(errorText || 'Kunde inte ta bort detta området');
            }
            const newSubLocations = allSubLocations.filter(subLocation => subLocation.id !== id);
            setSubLocations(newSubLocations);
            setFilteredSubLocations(newSubLocations);
            
            showSuccess('✅ Området borttagen!');
        } catch (err) {
            console.error('❌ Delete error:', err);
            showError(`Fel vid borttagning: ${err.message}`);
        } finally {
            setLoading(false);
        }
    };

    const handleEdit = async (subLocation) => {
        if (!window.confirm(`Är du säker på att du vill redigera området med id ${subLocation.id}?`)) {
            return;
        }
        const validationErrors = validateSubLocation(subLocation);
        if (validationErrors.length > 0) {
            showError(`❌ Valideringsfel:\n${validationErrors.join('\n')}`);
            return;
        }
        setLoading(true);
        setError(null);

        try {
            const response = await fetch(`${APIURL}/SubLocation/${subLocation.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(subLocation)
            });
            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(errorText || 'Kunde inte uppdatera området');
            }
            const newSubLocations = allSubLocations.map(loc => 
                loc.id === subLocation.id ? { ...loc, ...subLocation } : loc
            );
            setSubLocations(newSubLocations);
            setFilteredSubLocations(newSubLocations);
            
            showSuccess('✅ Området uppdaterad!');
        } catch (err) {
            console.error('❌ Edit error:', err);
            showError(`Fel vid uppdatering: ${err.message}`);
        } finally {
            setLoading(false);
        }
    };

    const handleCreate = async (subLocation) => {
        const validationErrors = validateSubLocation(subLocation);
        if (validationErrors.length > 0) {
            showError(`❌ Valideringsfel:\n${validationErrors.join('\n')}`);
            return;
        }
        setLoading(true);
        setError(null);

        try {
            // console.log('Skapar sublocation:', JSON.stringify(subLocation));
            
            const response = await fetch(`${APIURL}/SubLocation`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(subLocation)
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
            const newSubLocation = await response.json();
            console.log('✅ Skapad:', newSubLocation);
            
            const updatedSubLocations = [...allSubLocations, newSubLocation];
            setSubLocations(updatedSubLocations);
            setFilteredSubLocations(updatedSubLocations);
            
            showSuccess('✅ Området skapad!');
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
            <h1>SubLocation Management</h1>
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
            {!user ? <p>Du behöver logga in för att göra ändringar.</p> : (
                <>
                <div className = "admin-buttons">
                        <button className="btn" onClick={() => setView(!view)}>View SubLocations</button>
                        <button className="btn" onClick={() => setNewPopup(!newPopup)}>Add New</button>
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
                {newPopup && (<SubLocationNewPop handleCreate={handleCreate} closePopup={setNewPopup} />)}
                </>
            )}
        </div>
        </>
    );
};

export default SubLocationManagement;