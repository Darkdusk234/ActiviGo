import React from 'react';
import { useState, useEffect } from 'react';
import './Admin.css';

import { useAuth } from '../../../contexts/AuthContext';

const LocationNewPop = ({handleCreate, closePopup}) => {

    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [adress, setAdress] = useState('');
    const [latitude, setLatitude] = useState('');
    const [longitude, setLongitude] = useState('');

    const close = () => {
        closePopup(false);
    }
    return(
        <>
        <div className="popup-background">
            <form className="popup-card" onSubmit={(e) => {
                e.preventDefault();
                handleCreate({ name, description, adress, latitude, longitude });
            }}>
                <h2>Ny Plats</h2>
                
                <label>Namn:</label>
                <input type="text" value={name} onChange={(e) => setName(e.target.value)} required />
                <label>Beskrivning:</label>
                <textarea value={description} onChange={(e) => setDescription(e.target.value)} required />
                <label>Adress:</label>
                    <input type="text" value={adress} onChange={(e) => setAdress(e.target.value)} required />
                <label>Latitude:</label>
                    <input type="text" value={latitude} onChange={(e) => setLatitude(e.target.value)} required />

                <label>Longitude:</label>
                    <input type="text" value={longitude} onChange={(e) => setLongitude(e.target.value)} required />

                <button type="submit">Skapa</button>
                <button type="button" onClick={close}>Avbryt</button>
                </form>
        </div>
        
        </>
    )
}

export default LocationNewPop;