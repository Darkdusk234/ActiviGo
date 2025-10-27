import React, { useState, useEffect } from "react";
import { useCategories } from "../../../contexts/CategoryContext";
import './Admin.css';
import { Link } from "react-router-dom";

const ActivityListCard = ({ item, removeActivity, editActivity }) => {
    const [editMode, setEditMode] = useState(false);
    const [viewDetails, setViewDetails] = useState(false);
    const { categories, loadingCategories, errorCategories } = useCategories();
    const [allCategories, setCategories] = useState([]);

            // Close details view when clicking outside
        const handleClickOutside = (event) => {
            if (!event.target.closest('.details-view') && !event.target.closest('.details')) {
                setViewDetails(false);
            }
        };

        document.addEventListener('click', handleClickOutside);

    useEffect( () => {
        const getData = async () => {
            if (!loadingCategories && categories) {
                setCategories(categories);
            }
        };
        getData();
    }, [loadingCategories, categories]);

    return (
        <div className="admin-list-card">
            {editMode ? (
                <form className="edit-card-form" onSubmit={e => {
                    e.preventDefault();
                    const formData = new FormData(e.target);
                    const updatedActivity = {
                        id: item.id,
                        name: formData.get("name"),
                        description: formData.get("description"),
                        durationInMinutes: formData.get("durationInMinutes"),
                        price: formData.get("price"),
                        isActive: formData.get("isActive") === "on",
                        categoryId: parseInt(formData.get("category")) || null
                    };
                    editActivity(updatedActivity);
                    setEditMode(false);
                }}>
                    <div className="admin-list-card-info">
                        <p className="id">Id: {item.id}</p>
                        <input type="text" className="input-name" id="name" name="name" defaultValue={item.name} />
                        <div className="editable-areas">
                            <p>Beskrivning:</p>
                        <textarea id="description" name="description" defaultValue={item.description}></textarea>
                            <p>Längd:</p>
                        <input type="number" className="input-number" id="durationInMinutes" name="durationInMinutes" defaultValue={item.durationInMinutes} />
                            <p>Pris:</p>
                        <input type="number" step="10" className="input-number" id="price" name="price" defaultValue={item.price} />
                            <p>Är tillgänglig:</p>
                        <input className="checkbox" type="checkbox" id="isActive" name="isActive" defaultChecked={item.isActive} />
                            <p>Kategori:</p>
                            <select id ="category" name="category" defaultValue={item.categoryId}>
                                {allCategories.map((category, index) => (
                                    <option key={index} value={category.id}>{category.name}</option>
                                ))}
                            </select>
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
                        {!viewDetails && <p className="details" onClick={() => setViewDetails(true)}>Klicka för ytterligare detaljer...</p>}
                        {viewDetails && (
                            <div className="details-view">
                                <p>Beskrivning:</p>
                                <p className="Description">{item.description}</p>
                                <p>Längd:</p>
                                <p className="Duration">{item.durationInMinutes} minuter</p>
                                <p>Pris:</p>
                                <p className="Price">{Number.parseFloat(item.price).toFixed(2)} SEK</p>
                                <p>Är tillgänglig:</p>
                                <p className="Available">{item.isActive ? 'Ja' : 'Nej'}</p>
                                <p>Kategori:</p>
                                <p className="CategoryId">{categories.find(cat => cat.id === item.categoryId)?.name}</p>
                            </div>
                        )}
                    </div>
                    <div className="admin-list-card-buttons">
                        <button onClick={() => setEditMode(true)}>Redigera</button>
                        <button onClick={() => removeActivity(item.id)}>Ta bort</button>
                        <Link to={`/admin/occurrences/activity/${item.id}`} className="show-occ">Visa händelser</Link>
                    </div>
                </>
            )}
        </div>
    );
};

export default ActivityListCard;
