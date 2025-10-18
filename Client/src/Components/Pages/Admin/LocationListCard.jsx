import React, { useState } from "react";
import './Admin.css';
import { Link } from "react-router-dom";

const LocationListCard = ({ item, removeLocation, editLocation }) => {
    const [editMode, setEditMode] = useState(false);
    const [viewDetails, setViewDetails] = useState(false);
    
        // Close details view when clicking outside
        const handleClickOutside = (event) => {
            if (!event.target.closest('.details-view') && !event.target.closest('.details')) {
                setViewDetails(false);
            }
        };

        document.addEventListener('click', handleClickOutside);

    return (
        <div className="admin-list-card">
            {editMode ? (
                <form className="edit-card-form" onSubmit={e => {
                    e.preventDefault();
                    const formData = new FormData(e.target);
                    const updatedLocation = {
                        id: item.id,
                        name: formData.get("name"),
                        description: formData.get("description"),
                        adress: formData.get("adress"),
                        latitude: formData.get("latitude"),
                        longitude: formData.get("longitude"),
                        isActive: formData.get("isActive") === "on"
                    };
                    editLocation(updatedLocation);
                    setEditMode(false);
                }}>
                    <div className="admin-list-card-info">
                        <p className="id">Id: {item.id}</p>
                        <input type="text" className="input-name" id="name" name="name" defaultValue={item.name} />
                        <div className="editable-areas">
                            <p>Description:</p>
                                <textarea id="description" name="description" defaultValue={item.description}></textarea>
                            <p>Adress:</p>
                            <input type="text" id="adress" name="adress" defaultValue={item.adress}></input>
                            <p>Lat:</p>
                            <input type="number" id="latitude" name="latitude" defaultValue={item.latitude}></input>
                            <p>Long:</p>
                            <input type="number" id="longitude" name="longitude" defaultValue={item.longitude}></input>
                            <p>Active:</p>
                            <input type="checkbox" id="isActive" className="checkbox" name="isActive" defaultChecked={item.isActive}></input>
                        </div>
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
                        <h3>{item.name}</h3>
                        {!viewDetails && <p className="details" onClick={() => setViewDetails(true)}>Click for more details...</p>}
                        {viewDetails && (
                            <div className="details-view">
                                <p>Description:</p>
                                <p className="Description">{item.description}</p>
                                <p>Address:</p>
                                <p className="Address">{item.adress}</p>
                                <p>Lat , Long:</p>
                                <p className="LatLong">{Number.parseFloat(item.latitude).toFixed(2)} , {Number.parseFloat(item.longitude).toFixed(2)}</p>
                                <p>Active:</p>
                                <p className="Active">{item.isActive ? "Yes" : "No"}</p>
                            </div>
                        )}
                    </div>
                    <div className="admin-list-card-buttons">
                        <button onClick={() => setEditMode(true)}>Edit</button>
                        <button onClick={() => removeLocation(item.id)}>Remove</button>
                        <Link to={`/admin/sublocations/${item.id}`}>View sub-locations</Link>
                    </div>
                </>
            )}
        </div>
    );
};

export default LocationListCard;
