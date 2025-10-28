import React from 'react';
import { useState, useEffect } from 'react';
import './Admin.css';

import { useAuth } from '../../../contexts/AuthContext';

const CategoryNewPop = ({handleCreate, closePopup}) => {

    const [name, setName] = useState('');
    const [description, setDescription] = useState('');

    const close = () => {
        closePopup(false);
    }
    return(
        <>
        <div className="popup-background">
            <div className="popup-card">
                <h2>Ny Kategori</h2>
                <label>Namn:</label>
                <input type="text" value={name} onChange={(e) => setName(e.target.value)} />
                <label>Beskrivning:</label>
                <textarea value={description} onChange={(e) => setDescription(e.target.value)} />
                <button onClick={() => handleCreate({ name, description })}>Skapa</button>
                <button onClick={() => close()}>Avbryt</button>
            </div>
        </div>
        </>
    )
}

export default CategoryNewPop;