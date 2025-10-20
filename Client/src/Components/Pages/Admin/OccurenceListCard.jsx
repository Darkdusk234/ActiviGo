import React, { useEffect, useState } from "react";

const OccurenceListCard = ({ item, removeOccurence, editOccurence, cancelOccurence }) => {
    const [editMode, setEditMode] = useState(false);
    const [viewDetails, setViewDetails] = useState(false);
    const [date, setDate] = useState("");
    const [startTime, setStartTime] = useState("");
    const [endTime, setEndTime] = useState("");
    const [isCancelled, setIsCancelled] = useState(item.isCancelled);

    useEffect(() => {
        splitDateTime(item.startTime, item.endTime);
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
        setIsCancelled(true);
    }

    return (
        <div className="admin-list-card">
            {editMode ? (
                <form className="edit-card-form" onSubmit={e => {
                    e.preventDefault();
                    const formData = new FormData(e.target);
                    const updatedOccurence = {
                        id: item.id,
                        activityId: formData.get("activityId"),
                        startTime: formData.get("startTime"),
                        endTime: formData.get("endTime"),
                        locationId: formData.get("locationId")
                    };
                    editOccurence(updatedOccurence);
                    setEditMode(false);
                }}>
                    <div className="admin-list-card-info">
                        <p className="id">Id: {item.id}</p>
                        <input type="text" className="input-activityId" id="activityId" name="activityId" defaultValue={item.activityId} placeholder="Activity ID" />
                        <input type="datetime-local" className="input-startTime" id="startTime" name="startTime" defaultValue={item.startTime} placeholder="Start Time" />
                        <input type="datetime-local" className="input-endTime" id="endTime" name="endTime" defaultValue={item.endTime} placeholder="End Time" />
                        <input type="text" className="input-locationId" id="locationId" name="locationId" defaultValue={item.locationId} placeholder="Location ID" />
                    </div>
                    <div className="admin-list-card-buttons">
                        <button type="submit">Save</button>
                        <button type="button" onClick={() => setEditMode(false)}>Cancel</button>¨
                        
                    </div>
                </form>
            ) : (
                <>
                    <div className="admin-list-card-info">
                        <p className="id">Id: {item.id}</p>
                        <h3 className={!item.isCancelled ? '' : 'cancelled' }>{item.activityName}</h3>
                        <p>{date}</p>
                        <p>{startTime} - {endTime}</p>
                        {!viewDetails && <p className="details" onClick={() => setViewDetails(true)}>Click for more details...</p>}
                        {viewDetails && (
                            <div className="details-view">
                                <p>Date: </p><p>{date}</p>
                                <p>Start Time: </p><p>{startTime}</p>
                                <p>End Time: </p><p>{endTime}</p>
                                <p>Location: </p><p>{item.subLocationName}, {item.locationName}</p>
                                <p>Category: </p><p>{item.categoryName}</p>
                                <p>Current participation count: </p><p>{item.capacity - item.availableSpots} / {item.capacity}</p>
                                <p>Price: </p><p>{item.price} SEK</p>
                                
                            </div>
                        )}
                    </div>
                    <div className="admin-list-card-buttons">
                        <button onClick={() => setEditMode(true)}>Edit</button>
                        <button onClick={() => removeOccurence(item.id)}>Remove</button>
                        <button type="button" onClick={handleCancel}>{isCancelled ? 'Uncancel' : 'Cancel'}</button>
                    </div>
                </>
            )}
        </div>
    );
};

export default OccurenceListCard;
