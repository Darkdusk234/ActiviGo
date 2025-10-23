import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import OccurenceListCard from './OccurenceListCard';
import './Admin.css';
import DetailedSearch from '../../DetailedSearch';
import { useCategories } from '../../../contexts/CategoryContext';
import { useActivities } from '../../../contexts/ActivityContext';
import { useSubLocations } from '../../../contexts/SubLocationContext';
import { useParams } from 'react-router-dom';

const OccurenceManagement = () => {

    const { user, APIURL } = useAuth();
    const { id } = useParams();
    const { filter } = useParams();
    const [occurrences, setOccurrences] = useState([]);
    const [filtered, setFiltered] = useState([]);
    const [idName, setIdName] = useState('');

    // To get names for ids
    const { activities } = useActivities();
    const { subLocations } = useSubLocations();


    const filterOccurences = (filter, id) => {
        if(filter === 'activity')
        {
            return occurrences.filter(occ => occ.activityId.toString() === id);
        }
        // if(filter === 'location')
        //     return occurrences.filter(occ => occ.locationId.toString() === id);
        if(filter === 'sublocation')
            return occurrences.filter(occ => occ.subLocationId.toString() === id);
        // if(filter === 'category')
        //     return occurrences.filter(occ => occ.categoryId.toString() === id);
    }

    const getNameById = (type, id) => {
        if(type === 'activity')
        {
            
            const activity = activities.find(act => act.id.toString() === id);

            return activity ? activity.name : '';
        }
        if(type === 'sublocation')
        {
            const subLocation = subLocations.find(loc => loc.id.toString() === id);
            return subLocation ? subLocation.name : '';
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
            {

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
                    }
                });
            }
        }
    }

        const filterActive = () => {
        
        const activeOccurrences = filtered.filter(occ => !occ.isCancelled);
        console.log(activeOccurrences);
        setFiltered(activeOccurrences);
        console.log(filtered);
        
    }

    useEffect(() => {
        // fetch all occurences
        
        const fetchOccurrences = async () => {
            try {
                const response = await fetch(`${APIURL}/ActivityOccurence/admin`, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                    }
                });
                const data = await response.json();
                setOccurrences(data);
                setFiltered(filterOccurences(filter, id));
                
                
            } catch (error) {
                console.error("Error fetching occurrences:", error);
            }
        };

        fetchOccurrences();
    }, [handleEdit, filterActive]);



    return (
        <>
        <div className="management-items-container">
            <h1>Hantera tillfällen</h1>
            <h2>Aktivitetstillfällen för {filter.charAt(0).toUpperCase() + filter.slice(1)}: {getNameById(filter, id)}</h2>
            {/* <button className="admin-button" onClick={filterActive}>Visa endast aktiva</button> */}
            {filtered.map(occ => (
                    <OccurenceListCard key={occ.id} item={occ} removeOccurence={handleRemove} editOccurence={handleEdit} cancelOccurence={handleCancel} />
                
            ))}
        </div>
           
        </>
    );
};

export default OccurenceManagement;
