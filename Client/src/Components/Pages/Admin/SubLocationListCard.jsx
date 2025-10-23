import React, { useState, useEffect } from "react";
import { useLocations } from "../../../contexts/LocationContext";
import './Admin.css';
import ReactDOM from 'react-dom';

const SubLocationListCard = ({ item, removeSubLocation, editSubLocation }) => {
    const [editMode, setEditMode] = useState(false);
    const [viewDetails, setViewDetails] = useState(false);
       const { locations, loadingLocations, errorLocations } = useLocations();
        const [allLocations, setLocations] = useState([]);

        // Close details view when clicking outside
        const handleClickOutside = (event) => {
            if (!event.target.closest('.details-view') && !event.target.closest('.details')) {
                setViewDetails(false);
            }
        };

        document.addEventListener('click', handleClickOutside);



        useEffect( () => {
            setLocations(locations);
        }, [loadingLocations, locations]);

    return (
        <div className="admin-list-card">
            {editMode ? (
                <form className="edit-card-form" onSubmit={e => {
                    e.preventDefault();
                    const formData = new FormData(e.target);
                    const updatedSubLocation = {
                        id: item.id,
                        name: formData.get("name"),
                        description: formData.get("description"),
                        maxCapacity: parseInt(formData.get("maxCapacity")),
                        indoors: formData.get("indoors") === "on",
                        locationId: parseInt(formData.get("location"))
                    };
                    editSubLocation(updatedSubLocation);
                    setEditMode(false);
                }}>
                    <div className="admin-list-card-info">
                        <p className="id">Id: {item.id}</p>
                        <input type="text" className="input-name" id="name" name="name" defaultValue={item.name} />
                        <div className="editable-areas">
                            <p>Beskrivning:</p>
                                <textarea id="description" name="description" defaultValue={item.description}></textarea>
                            <p>Max kapacitet:</p>
                            <input type="number" className="input-number" id="maxCapacity" name="maxCapacity" defaultValue={item.maxCapacity}></input>
                            <p>Inomhus:</p>
                            <input type="checkbox" id="indoors" className="checkbox" name="indoors" defaultChecked={item.indoors}></input>
                            <p>Plats:</p>
                            <select id="location" name="location" defaultValue={item.locationId} >
                                {allLocations.map((location, index) => (
                                    <option key={index} value={location.id}>{location.name}</option>
                                ))}
                            </select>
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
                        <h3>{item.name}</h3>
                        {!viewDetails && <p className="details" onClick={() => setViewDetails(true)}>Klicka för ytterligare detaljer...</p>}
                        {viewDetails && (
                            <div className="details-view">
                                <p>Beskrivning:</p>
                                <p className="Description">{item.description}</p>
                                <p>MaxKapacitet:</p>
                                <p className="MaxCapacity">{item.maxCapacity}</p>
                                <p>Inomhus:</p>
                                <p className="Indoors">{item.indoors ? "Ja" : "Nej"}</p>
                                <p>Plats:</p>
                                <p className="LocationId">{item.locationName}</p>
                            </div>
                        )}
                    </div>
                    <div className="admin-list-card-buttons">
                        <button onClick={() => setEditMode(true)}>Redigera</button>
                        <button onClick={() => removeSubLocation(item.id)}>Ta bort</button>
                    </div>
                </>
            )}
        </div>
    );
};

export default SubLocationListCard;
