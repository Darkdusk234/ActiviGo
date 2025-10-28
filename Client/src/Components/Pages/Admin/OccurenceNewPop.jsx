import React from "react";

import { useState, useEffect } from "react";
import { useAuth } from "../../../contexts/AuthContext";
import './Admin.css';
const OccurenceNewPop = ({ activity, subLocations, handleCreate, closePopup }) => {

    const { user, APIURL } = useAuth();

    const [newOccurrence, setNewOccurrence] = useState({
        activityId: activity.id,
        subLocationId: '',
        startTime: '',
        endTime: '',
        capacity: 1,
    });

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setNewOccurrence(prevState => ({
            ...prevState,
            [name]: value
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        await handleCreate(newOccurrence);
        closePopup();
    };

    return (
        <div className="popup-background">
            <h2>Nytt tillfälle</h2>
            <form onSubmit={handleSubmit} className="popup-card">
                
                    <label> Aktivitet: </label>
                    <p className="new-occurrence-activity">{activity.name}</p>
                
                <label>
                    Plats:
                    </label>
                    <select className="select" required name="subLocationId" value={newOccurrence.subLocationId} onChange={handleInputChange}>
                        <option value="">Välj plats</option>
                        {subLocations.map(subLocation => (
                            <option key={subLocation.id} value={subLocation.id}>
                                {subLocation.name}
                            </option>
                        ))}
                    </select>
                <label>Max antal deltagare:</label>
                <input type="number" name="capacity" min="1" value={newOccurrence.capacity} onChange={handleInputChange} />
                <label>
                    Starttid:
                    </label>
                    <input type="datetime-local" name="startTime" value={newOccurrence.startTime} onChange={handleInputChange} />
                
                <label>
                    Sluttid:
                     </label>
                    <input type="datetime-local" name="endTime" value={newOccurrence.endTime} onChange={handleInputChange} />
               
                <button type="submit">Skapa</button>
                <button type="button" onClick={closePopup}>Avbryt</button>
            </form>
        </div>
    );
};

export default OccurenceNewPop;
