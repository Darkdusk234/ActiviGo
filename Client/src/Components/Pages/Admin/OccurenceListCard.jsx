import React, { useState } from "react";

const OccurenceListCard = ({ item, removeOccurence, editOccurence }) => {
    const [editMode, setEditMode] = useState(false);
    const [viewDetails, setViewDetails] = useState(false);

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
                        <button type="button" onClick={() => setEditMode(false)}>Cancel</button>
                    </div>
                </form>
            ) : (
                <>
                    <div className="admin-list-card-info">
                        <p className="id">Id: {item.id}</p>
                        <h3>Occurence for Activity {item.activityId}</h3>
                        {!viewDetails && <p className="details" onClick={() => setViewDetails(true)}>Click for more details...</p>}
                        {viewDetails && (
                            <div className="details-view">
                                <p>Start Time: </p><p>{item.startTime}</p>
                                <p>End Time: </p><p>{item.endTime}</p>
                                <p>Location ID: </p><p>{item.locationId}</p>
                                <p>Category ID: </p><p>{item.categoryId}</p>
                                <p>Activity ID: </p><p>{item.activityId}</p>
                            </div>
                        )}
                    </div>
                    <div className="admin-list-card-buttons">
                        <button onClick={() => setEditMode(true)}>Edit</button>
                        <button onClick={() => removeOccurence(item.id)}>Remove</button>
                    </div>
                </>
            )}
        </div>
    );
};

export default OccurenceListCard;
