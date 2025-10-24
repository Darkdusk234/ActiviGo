import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import OccurenceListCard from './OccurenceListCard';
import './Admin.css';
import DetailedSearch from '../../DetailedSearch';
import { useCategories } from '../../../contexts/CategoryContext';
import { useActivities } from '../../../contexts/ActivityContext';
import { useSubLocations } from '../../../contexts/SubLocationContext';
import { useParams } from 'react-router-dom';
import OccurenceNewPop from './OccurenceNewPop';

const OccurenceManagement = () => {

    const { user, APIURL } = useAuth();
    const { id } = useParams();
    const { filter } = useParams();
    const [occurrences, setOccurrences] = useState([]);
    const [filtered, setFiltered] = useState([]);
    const [idName, setIdName] = useState('');
    const [showPopup, setShowPopup] = useState(false);

    // To get names for ids
    const { activities } = useActivities();
    const { subLocations } = useSubLocations();

    const handleParticipantFilterChange = (e) => {
        const value = e.target.value;
        setFiltered(filtered.filter(occ =>
            occ.availableSpots >= Number.parseInt(value)
        ));
    };

    const handleMinParticipantsChange = (e) => {
        const value = e.target.value;
        setFiltered(filtered.filter(occ =>
            (occ.capacity - occ.availableSpots) >= Number.parseInt(value)
        ));
    }
    const handleCategoryFilterChange = (e) => {
        const value = e.target.value;
        setFiltered(filtered.filter(occ =>
            occ.subLocationId.toString() === value || value === ''
        ));
    };
    const handleFromTimeChange = (e) => {
        const value = e.target.value;
        setFiltered(filtered.filter(occ =>
            new Date(occ.startTime) >= new Date(value)
        ));
    };
    const handleToTimeChange = (e) => {
        const value = e.target.value;
        setFiltered(filtered.filter(occ =>
            new Date(occ.startTime) <= new Date(value)
        ));
    }

    const getNameAndId = (type, id) => {
        if(type === 'activity')
        {
            
            const activity = activities.find(act => act.id.toString() === id);
            return activity ? { name: activity.name, id: activity.id } : { name: '', id: '' };
        }
        if(type === 'sublocation')
        {
            const subLocation = subLocations.find(loc => loc.id.toString() === id);
            return subLocation ? { name: subLocation.name, id: subLocation.id } : { name: '', id: '' };
        }
    }

    const handleCancel = async (id) => {
        if (window.confirm(`Är du säker på att du vill ställa in tillfället med id ${id}?`)) {
        await fetch(`${APIURL}/ActivityOccurence/cancel/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('authToken')}`
            }
        })
        .then(async response => {
            if (!response.ok) {
                const data = await response.json();
                alert('Misslyckades med att ställa in tillfälle: ' + data.map(error => error.errorMessage).join(', '));
                return;
            }
            if( response.ok) {
                alert("Tillfälle inställt.");
            }
        });
        }
    }

    const handleRemove = async (id) => {
        if (window.confirm(`Är du säker på att du vill ta bort tillfället med id ${id}?`)) {
            await fetch(`${APIURL}/ActivityOccurence/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            }).then(async response => {
                if (!response.ok) {
                    const data = await response.json();
                    alert('Misslyckades med att ta bort tillfälle: ' + data.map(error => error.errorMessage).join(', '));
                    return;
                }
                if (response.ok) {
                    alert("Tillfälle borttaget.");
                }
            });
        }
    }

    const handleEdit = async (occurrence) => {
        console.log(occurrence);
        if (window.confirm(`Är du säker på att du vill uppdatera tillfället med id: ${occurrence.id}?`)) {
            await fetch(`${APIURL}/ActivityOccurence/${occurrence.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                },
                body: JSON.stringify(occurrence)
            })
            .then(async response => {
                if (!response.ok) {
                    const data = await response.json();
                    alert('Redigering av tillfälle misslyckades: ' + data.map(error => error.errorMessage).join(', '));
                    return;
                }
                if (response.ok) {
                    alert("Tillfälle uppdaterat.");
                    // update both states
                    const newOccurrences = occurrences.map(occ => occ.id === occurrence.id ? { ...occ, ...occurrence } : occ);
                    setOccurrences(newOccurrences);
                    setFiltered(newOccurrences.filter(occ => {
                        if (filter === 'activity') return occ.activityId.toString() === id;
                        if (filter === 'sublocation') return occ.subLocationId.toString() === id;
                        return false;
                    }));
                }
            });
        }
    }


    const handleCreate = async (occurrence) => {
        console.log(occurrence);
        console.log(JSON.stringify(occurrence));
        const response = await fetch(`${APIURL}/ActivityOccurence`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('authToken')}`
            },
            body: JSON.stringify(occurrence)
        }).then(async response => {
            if (!response.ok) {
                const data = await response.json();
                alert('Misslyckades med att skapa tillfälle: ' + data.map(error => error.errorMessage).join(', '));
                return;
            }
            if (response.ok) {
                alert("Tillfälle skapat.");
                const data = await response.json();
                setOccurrences([...occurrences, data]);
                setFiltered([...filtered, data]);
                setShowPopup(false);
            }
        });


}

    useEffect(() => {
        // fetch all occurrences
        
        const fetchOccurrences = async (filter, id) => {

            try {
                const response = await fetch(`${APIURL}/ActivityOccurence/admin`, { // fetch all occurrences, admin endpoint
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                    }
                })
                .then(async response => {
                    const data = await response.json();
                    console.log(data);
                    setOccurrences(data);
                    setFiltered(data.filter(occ => {
                    if(filter === 'activity') return occ.activityId.toString() === id;
                    if(filter === 'sublocation') return occ.subLocationId.toString() === id;
                    return false;
                    }));
                });
                
                
                
            } catch (error) {
                console.error("Error fetching occurrences:", error);
            }
        };

        fetchOccurrences(filter, id);
    }, [filter, id]);

    

    return (
        <>
        
            <h1>Hantera tillfällen</h1>
            
            <div className="management-items-container">
                <h2>Aktivitetstillfällen för: {getNameAndId(filter, id).name}</h2>
                <div className="admin-buttons">
                    <button className="admin-button" onClick={() => setShowPopup(true)}>Skapa nytt tillfälle</button>
                </div>
                <div>
                    <div className="filter-list">

                               <label>Minst antal lediga platser:</label> <input type="number" placeholder="0" onChange={handleParticipantFilterChange} />
                               <label>Minst antal deltagare:</label> <input type="number" placeholder="0" onChange={handleMinParticipantsChange} />
                               <label>Plats:</label><select onChange={handleCategoryFilterChange}>
                                                    <option value="">Alla</option>
                                                    {subLocations.map(subLocation => (
                                                        <option key={subLocation.id} value={subLocation.id}>{subLocation.name}</option>
                                                    ))}
                                                    </select>
                                <label>Från datum:</label> <input type="date" onChange={handleFromTimeChange} />
                                <label>Till datum:</label> <input type="date" onChange={handleToTimeChange} />
                            </div>
                    <div className="results-section">

                    {filtered.map(occ => (
                        <OccurenceListCard key={occ.id} 
                        item={occ} 
                        removeOccurence={handleRemove} 
                        editOccurence={handleEdit} 
                        cancelOccurence={handleCancel} />
                        
                    ))}
                    </div>



                </div>
            </div>

             {showPopup && <OccurenceNewPop 
             handleCreate={handleCreate} 
             closePopup={() => setShowPopup(false)} 
             subLocations={subLocations}
             activity={getNameAndId(filter, id)}/>}
        </>
    );
};

export default OccurenceManagement;
