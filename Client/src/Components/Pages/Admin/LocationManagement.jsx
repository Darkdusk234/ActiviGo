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



    const handleFilterChange = (e) => {
        const value = e.target.value;
        setNameFilter(value);
        setFilteredLocations(
            allLocations.filter(location =>
                location.name.toLowerCase().includes(value.toLowerCase())
            )
        );
    };

    const handleRemove = async (id) => {
        if (window.confirm(`Are you sure you want to remove location with id ${id}?`)) {
            const newLocations = allLocations.filter(location => location.id !== id);
            setLocations(newLocations);
            setFilteredLocations(newLocations.filter(location =>
                location.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
            await fetch(`${APIURL}/Location/${id}`, {
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
        }
    };

    const handleEdit = async (location) => {
        console.log(location);
        if (window.confirm(`Are you sure you want to edit location with id ${location.id}?`)) {
            await fetch(`${APIURL}/Location/${location.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(location)
            })
            .then(async response => {
                if (!response.ok) {
                    const data = await response.json();
                    alert('Misslyckades med att redigera plats: ' + data.map(error => error.errorMessage).join(', '));
                    return;
                }
                if (response.ok) {
                    alert('Plats redigerad: ' + location.name);
                    // update local state
                    const newLocations = allLocations.map(loc => loc.id === location.id ? { ...loc, ...location } : loc);
                    setLocations(newLocations);
                    setFilteredLocations(newLocations.filter(loc =>
                    loc.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
                }
            });
          
            
        }
    };

    const handleCreate = async (location) => {
        console.log(JSON.stringify(location));
        const response = await fetch(`${APIURL}/Location`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('authToken')}`
            },
            body: JSON.stringify(location)
        });
        if(!response.ok) {
            const data = await response.json();
            console.log(data.map(error => error.errorMessage).join(', '));
            alert('Misslyckades med att skapa plats: \n ' + data.map(error => error.errorMessage).join(', '));
            
            setNewPopup(false);
            return;
        }
        if(response.ok) {
            const data = await response.json();
            alert('Plats skapad: ' + data.name);

        setLocations([...locations, data]);
        setFilteredLocations([...filteredLocations, data]);
        setNewPopup(false);
        }

    }

    useEffect(() => {
        setLocations(locations);
        setFilteredLocations(locations);
    }, [locations]);

    return (
        <>
            <h1>Location Management</h1>
            <div className="management-items-container">
            {!user ? <p>Please log in to manage locations.</p> : (
                <>
                <div className = "admin-buttons">
                           <button className="btn" onClick={() => setNewPopup(!newPopup)}>Lägg till ny</button>

                       </div>
                       <div className="filter-list">

                               <label>Filtrera med namn:</label> <input type="text" placeholder="Filter..." onChange={handleFilterChange} />
                        </div>
                       <div className="item-list">
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
