import React from 'react';
import { useState, useEffect } from 'react';
import './Admin.css';
import { useLocations } from '../../../contexts/LocationContext';
import { useAuth } from '../../../contexts/AuthContext';

const SubLocationNewPop = ({handleCreate, closePopup}) => {

    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [maxCapacity, setMaxCapacity] = useState(1);
    const [indoor, setIndoor] = useState(false);
    const [locationId, setLocationId] = useState(null);

    const { locations } = useLocations();

    useEffect(() => {
        if (locations.length > 0) {
            setLocationId(locations[0].id);
        }
    }, []);

    const close = () => {
        closePopup(false);
    }
    return(
        <>
        <div className="popup-background">
            <form className="popup-card" onSubmit={(e) => {
                e.preventDefault();
                
                handleCreate({name, description, maxCapacity, indoor, locationId});
                
            }}>
                <h2>Ny Underplats</h2>
                <label>Namn:</label>
                <input type="text" value={name} onChange={(e) => setName(e.target.value)} required/>
                <label>Beskrivning:</label>
                <textarea value={description} onChange={(e) => setDescription(e.target.value)} required/>
                <label>Maxkapacitet:</label>
                <input type="number" min="1" required value={maxCapacity} onChange={(e) => setMaxCapacity(e.target.value)} />
                <label>Inomhus:</label>
                <input className="checkbox" type="checkbox" checked={indoor} onChange={(e) => setIndoor(e.target.checked)}/>
                <label>Plats:</label>
                <select className="select"required onChange={e => setLocationId(e.target.value)}>
                    {locations.map((location) => (
                        <option key={location.id} value={location.id}>{location.name}</option>
                    ))}
                </select>
                <button type="submit">Skapa</button>
                <button type="button" onClick={close}>Avbryt</button>
            </form>
        </div>
        </>
    )
}

export default SubLocationNewPop;
