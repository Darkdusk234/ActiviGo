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
    const { user, APIURL } = useAuth();
      const [newPopup, setNewPopup] = useState(false);
    const { subLocations } = useSubLocations();


    const handleFilterChange = (e) => {
        const value = e.target.value;
        setNameFilter(value);
        setFilteredSubLocations(
            allSubLocations.filter(subLocation =>
                subLocation.name.toLowerCase().includes(value.toLowerCase())
            )
        );
    };

    const handleRemove = async (id) => {
        if (window.confirm(`Är du säker på att du vill ta bort underplats med id ${id}?`)) {
            const newSubLocations = allSubLocations.filter(subLocation => subLocation.id !== id);
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
        
        if (window.confirm(`Är du säker på att du vill redigera underplats med id ${subLocation.id}?`)) {
            await fetch(`${APIURL}/SubLocation/${subLocation.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(subLocation)
            })
            .then(async response => {
                if (!response.ok) {
                    const data = await response.json();
                    alert('Misslyckades med att redigera underplats: ' + data.map(error => error.errorMessage).join(', '));
                    return;
                }
                if (response.ok) {
                    alert("Underplats uppdaterad.");
                                // update local state
            const newSubLocations = allSubLocations.map(loc => loc.id === subLocation.id ? { ...loc, ...subLocation } : loc);
            setSubLocations(newSubLocations);
            setFilteredSubLocations(newSubLocations.filter(loc =>
                loc.name.toLowerCase().includes(nameFilter.toLowerCase())
            ));
                }
            });

        }
    };

        const handleCreate = async (subLocation) => {
            console.log(JSON.stringify(subLocation));
        const response = await fetch(`${APIURL}/SubLocation`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('authToken')}`
            },
            body: JSON.stringify(subLocation)
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
            setSubLocations([...allSubLocations, data]);
            setFilteredSubLocations([...filteredSubLocations, data]);
            setNewPopup(false);}
    };

    useEffect(() => {
        setSubLocations(subLocations);
        setFilteredSubLocations(subLocations);
    }, []);

    return (
        <>
            <h1>SubLocation Management</h1>
                    <div className="management-items-container">
            {!user ? <p>Logga in för att hantera underplatser.</p> : (
                <>
                <div className = "admin-buttons">
                           <button className="btn" onClick={() => setNewPopup(!newPopup)}>Lägg till ny</button>
                       </div>
                       
                        <div className="filter-list">

                               <label>Filtrera med namn:</label> <input type="text" placeholder="Filter..." onChange={handleFilterChange} />
                          </div>
                          <div className="item-list">
                           {filteredSubLocations.map(subLocation => (
                               <SubLocationListCard key={subLocation.id} item={subLocation} removeSubLocation={handleRemove} editSubLocation={handleEdit}/>
                           ))}
                       </div>
                           
                       

                  {newPopup && (<SubLocationNewPop handleCreate={handleCreate} closePopup={setNewPopup} />)}

                </>
            )}
        </div>
        </>
    );
};

export default SubLocationManagement;

