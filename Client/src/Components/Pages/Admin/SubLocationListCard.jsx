import React, { useState, useEffect } from "react";
import { useLocations } from "../../../contexts/LocationContext";
import './Admin.css';

const SubLocationListCard = ({ item, removeSubLocation, editSubLocation }) => {
    const [editMode, setEditMode] = useState(false);
    const [viewDetails, setViewDetails] = useState(false);

    const { locations, loadingLocations, errorLocations } = useLocations();
    const [locationNames, setLocationNames] = useState([]);
    
    const [selectedLocationId, setSelectedLocationId] = useState(item.locationId);

    const [allLocations, setLocations] = useState([]);


    useEffect(() => {   // fuck this
        if (editMode) {
            setSelectedLocationId(item.locationId);
        }
    }, [editMode, item.locationId]);

    useEffect(() => {
        const handleClickOutside = (event) => {
            if (!event.target.closest('.details-view') && !event.target.closest('.details')) {
                setViewDetails(false);
            }
        };
        
        document.addEventListener('click', handleClickOutside);
        
        return () => {
            document.removeEventListener('click', handleClickOutside);
        };
    }, []);
  
    useEffect(() => {
        const getData = async () => {
            if (!loadingLocations && locations) {
                const names = locations.map(location => location.name);
                setLocationNames(names);
            }
        };
        getData();
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
                        locationId: selectedLocationId 
                    };
                    
                    // console.log('📤 Skickar uppdaterad SubLocation:', updatedSubLocation); 
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

                            <p>At location:</p>
                            <select 
                                name="locationId"
                                value={selectedLocationId}
                                onChange={(e) => setSelectedLocationId(parseInt(e.target.value))}
                            >
                                {locations && locations.map((location) => (
                                    <option key={location.id} value={location.id}>
                                        {location.name}
                                    </option>
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