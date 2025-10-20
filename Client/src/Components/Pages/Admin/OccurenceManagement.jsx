import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import OccurenceListCard from './OccurenceListCard';
import './Admin.css';
import DetailedSearch from '../../DetailedSearch';
import { useCategories } from '../../../contexts/CategoryContext';
import { useActivities } from '../../../contexts/ActivityContext';
import { useLocations } from '../../../contexts/LocationContext';
import { useParams } from 'react-router-dom';

const OccurenceManagement = () => {

    const { user, APIURL } = useAuth();
    const { id } = useParams();
    const { filter } = useParams();
    console.log(useParams());
    const [occurrences, setOccurrences] = useState([]);
    const [idName, setIdName]   = useState('');

    useEffect(() => {
        // fetch all occurences
        
        const fetchOccurrences = async () => {
            try {
                const response = await fetch(`${APIURL}/ActivityOccurence`);
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
            return occurrences.filter(occ => occ.activityId.toString() === id);
        // if(filter === 'location')
        //     return occurrences.filter(occ => occ.locationId.toString() === id);
        if(filter === 'sublocation')
            return occurrences.filter(occ => occ.subLocationId.toString() === id);
        // if(filter === 'category')
        //     return occurrences.filter(occ => occ.categoryId.toString() === id);
    }


    return (
        <>
        <div className="management-items-container">
            <h1>Occurence Management</h1>
            <h2>Occurences by: {filter}: {id}</h2>
            {filterOccurences(filter, id).map(occ => (
                <OccurenceListCard key={occ.id} item={occ} />
            ))}
        </div>
           
        </>
    );
};

export default OccurenceManagement;
