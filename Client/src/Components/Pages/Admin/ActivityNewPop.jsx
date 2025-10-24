import React from 'react';
import { useState, useEffect } from 'react';
import './Admin.css';
import { useCategories } from '../../../contexts/CategoryContext';
import { useAuth } from '../../../contexts/AuthContext';

const ActivityNewPop = ({handleCreate, closePopup}) => {

    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [durationInMinutes, setDurationInMinutes] = useState(30);
    const [price, setPrice] = useState(0);
    const [categoryId, setCategoryId] = useState('');
    const [isActive, setIsActive] = useState(true);
    const { categories } = useCategories();
    const [IMGUrl, setImageUrl] = useState('');                                                                      

    const close = () => {
        closePopup(false);
    }

    useEffect(() => {
        if (categories.length > 0) {
            setCategoryId(categories[0].id);
        }
    }, []);

    return(
        <>
        <div className="popup-background">
            <form className="popup-card" onSubmit={(e) => { e.preventDefault();

                handleCreate({ name, description, durationInMinutes, price, isActive, categoryId, IMGUrl });                
             }}>
                <h2>Ny Aktivitet</h2>
                <label>Namn:</label>
                <input type="text" value={name} onChange={(e) => setName(e.target.value)} />
                <label>Beskrivning:</label>
                <textarea value={description} onChange={(e) => setDescription(e.target.value)} />
                <label>Varaktighet (minuter):</label>
                <input type="number" min="1" value={durationInMinutes} onChange={(e) => setDurationInMinutes(e.target.value)} />
                <label>Pris:</label>
                <input type="number" min="0" value={price} onChange={(e) => setPrice(e.target.value)} />
                <label>BildURL:</label>
                <input type="text" value={IMGUrl} onChange={(e) => setImageUrl(e.target.value)} />
                <label>Aktiv:</label>
                <input type="checkbox" className="checkbox" checked={isActive} onChange={(e) => setIsActive(e.target.checked)} />
                <label>Kategori:</label>
                <select className="select" onChange={(e) => setCategoryId(e.target.value)} required>
                    <option value="" selected>Välj kategori</option>
                    {categories.map((category) => (
                        <option key={category.id} value={category.id}>{category.name}</option>
                    ))}
                </select>
                <button type="submit">Skapa</button>
                <button onClick={close}>Avbryt</button>
            </form>
        </div>
        </>
    )
}

export default ActivityNewPop;