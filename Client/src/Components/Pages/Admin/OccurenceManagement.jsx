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
    const [idName, setIdName] = useState('');

    // To get names for ids
    const { activities } = useActivities();
    const { subLocations } = useSubLocations();

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
                
            } catch (error) {
                console.error("Error fetching occurrences:", error);
            }
        };

        fetchOccurrences();
    }, []);

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
        if (window.confirm(`Are you sure you want to cancel occurrence with id ${id}?`)) {
        await fetch(`${APIURL}/ActivityOccurence/cancel/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('authToken')}`
            }
        });
    }
    }

    const handleRemove = async (id) => {
        if (window.confirm(`Are you sure you want to remove occurrence with id ${id}?`)) {
            await fetch(`${APIURL}/ActivityOccurence/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
        }
    }

    const handleEdit = async (occurrence) => {

        if (window.confirm(`Are you sure you want to edit occurrence with id ${occurrence.id}?`)) {
            {

                await fetch(`${APIURL}/ActivityOccurence/${occurrence.id}`, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                    },
                    body: JSON.stringify(occurrence)
                });
            }
        }
    }

    return (
        <>
        <div className="management-items-container">
            <h1>Occurence Management</h1>
            <h2>Occurences for {filter.charAt(0).toUpperCase() + filter.slice(1)}: {getNameById(filter, id)}</h2>
            <button>Sort by latest</button>
            {filterOccurences(filter, id).map(occ => (
                <OccurenceListCard key={occ.id} item={occ} removeOccurence={handleRemove} editOccurence={handleEdit} cancelOccurence={handleCancel} />
            ))}
        </div>
           
        </>
    );
};

export default OccurenceManagement;
