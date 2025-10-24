import React, { useEffect, useState } from "react";
import { useSubLocations } from "../../../contexts/SubLocationContext";
import './Admin.css';

const OccurenceListCard = ({ item, removeOccurence, editOccurence, cancelOccurence }) => {
    const [editMode, setEditMode] = useState(false);
    const [viewDetails, setViewDetails] = useState(false);
    const [date, setDate] = useState("");
    const [startTime, setStartTime] = useState("");
    const [endTime, setEndTime] = useState("");
    const [isCancelled, setIsCancelled] = useState(item.isCancelled);
    const { subLocations } = useSubLocations();

                // Close details view when clicking outside
        const handleClickOutside = (event) => {
            if (!event.target.closest('.details-view') && !event.target.closest('.details')) {
                setViewDetails(false);
            }
        };

        document.addEventListener('click', handleClickOutside);

    useEffect(() => {
        splitDateTime(item.startTime, item.endTime);
        setIsCancelled(item.isCancelled);
    }, []); 

        const splitDateTime = (startTime, endTime) => {
        const [startDatePart, startTimePart] = startTime.split('T');
        const [endDatePart, endTimePart] = endTime.split('T');
        setDate(startDatePart);
        setStartTime(startTimePart.slice(0,-3));
        setEndTime(endTimePart.slice(0,-3));
    }

    const handleCancel = () => {
        cancelOccurence(item.id);
        
    }

    return (
        <div className="admin-list-card">
            {editMode ? (
                <form className="edit-card-form" onSubmit={e => {
                    e.preventDefault();
                    const formData = new FormData(e.target);
                    const updatedOccurence = {
                        id: item.id,
                        activityId: item.activityId,
                        startTime: formData.get("startTime"),
                        endTime: formData.get("endTime"),
                        sublocationId: formData.get("sublocationId"),
                        capacity: formData.get("capacity"),
                        price: formData.get("price")
                    };
                    editOccurence(updatedOccurence);
                    console.log(updatedOccurence);
                    setEditMode(false);
                }}>
                    <div className="admin-list-card-info">
                        <p className="id">Id: {item.id}</p>
                        <h3>{item.activityName}</h3>
                        <div className="editable-areas">
                            <p>Starttid:</p>
                            <input type="datetime-local" className="input-startTime" id="startTime" name="startTime" defaultValue={item.startTime} placeholder="Start Time" />
                            <p>Sluttid:</p>
                            <input type="datetime-local" className="input-endTime" id="endTime" name="endTime" defaultValue={item.endTime} placeholder="End Time" />
                            <p>Plats:</p>
                            <select id="sublocationId" name="sublocationId" defaultValue={item.subLocationId}>
                                {subLocations.map(loc => (
                                    <option key={loc.id} value={loc.id}>{loc.name}</option>
                                ))}
                            </select>
                          <p>Max antal deltagare:</p>
                            <input type="number" className="input-capacity" id="capacity" name="capacity" defaultValue={item.capacity} placeholder="Max Capacity" />
                        </div>
                    </div>
                    <div className="admin-list-card-buttons">
                        <button type="submit">Spara</button>
                        <button type="button" onClick={() => setEditMode(false)}>Avbryt</button>

                    </div>
                </form>
            ) : (
                <>
                    <div className="admin-list-card-info">
                        <p className="id">Id: {item.id}</p>
                        <h3 className={!item.isCancelled ? '' : 'cancelled' }>{!item.isCancelled ? item.activityName : item.activityName + " (Inställd)"}</h3>
                        <p>Datum: {date}</p>
                        <p>Tid: {startTime} - {endTime}</p>

                        {!viewDetails && <p className="details" onClick={() => setViewDetails(true)}>Klicka för ytterligare detaljer...</p>}
                        {viewDetails && (
                            <div className="details-view">

                                <p>Plats: </p><p>{item.subLocationName}, {item.locationName}</p>
                                <p>Nuvarande deltagarantal: </p><p>{(parseInt(item.capacity) - parseInt(item.availableSpots))} / {item.capacity}</p>
                                <p>Pris: </p><p>{item.price} SEK</p>

                            </div>
                        )}
                    </div>
                    <div className="admin-list-card-buttons">
                        <button onClick={() => setEditMode(true)}>Redigera</button>
                        <button onClick={() => removeOccurence(item.id)}>Ta bort</button>
                        {!isCancelled ? <button type="button" onClick={handleCancel}>Ställ in</button> : ''}
                        
                    </div>
                </>
            )}
        </div>
    );
};

export default OccurenceListCard;
