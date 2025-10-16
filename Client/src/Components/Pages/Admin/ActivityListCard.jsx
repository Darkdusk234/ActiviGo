import React, { useState, useEffect } from "react";
import { useCategories } from "../../../contexts/CategoryContext";
import './Admin.css';

const ActivityListCard = ({ item, removeActivity, editActivity }) => {
    const [editMode, setEditMode] = useState(false);
    const [viewDetails, setViewDetails] = useState(false);
    const { categories, loadingCategories, errorCategories } = useCategories();
    const [categoryNames, setCategoryNames] = useState([]);

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
                const names = categories.map(category => category.name);
                setCategoryNames(names);
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
                        category: formData.get("category")
                    };
                    editActivity(updatedActivity);
                    setEditMode(false);
                }}>
                    <div className="admin-list-card-info">
                        <p className="id">Id: {item.id}</p>
                        <input type="text" className="input-name" id="name" name="name" defaultValue={item.name} />
                        <div className="editable-areas">
                            <p>Description:</p>
                        <textarea id="description" name="description" defaultValue={item.description}></textarea>
                            <p>Duration:</p>
                        <input type="number" className="input-number" id="durationInMinutes" name="durationInMinutes" defaultValue={item.durationInMinutes} />
                            <p>Price:</p>
                        <input type="number" step="10" className="input-number" id="price" name="price" defaultValue={item.price} />
                            <p>Category:</p>
                            <select id ="category" name="category">
                                <option value="">{item.categoryId}</option>
                                {categoryNames.map((category, index) => (
                                    <option key={index} value={category}>{category}</option>
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
                        {!viewDetails && <p className="details" onClick={() => setViewDetails(true)}>Click for more details...</p>}
                        {viewDetails && (
                            <div className="details-view">
                                <p>Description:</p>
                                <p className="Description">{item.description}</p>
                                <p>Duration:</p>
                                <p className="Duration">{item.durationInMinutes} minutes</p>
                                <p>Price:</p>
                                <p className="Price">{Number.parseFloat(item.price).toFixed(2)} SEK</p>
                                <p>CategoryId:</p>
                                <p className="CategoryId">{item.categoryId} (want name)</p>
                            </div>
                        )}
                    </div>
                    <div className="admin-list-card-buttons">
                        <button onClick={() => setEditMode(true)}>Edit</button>
                        <button onClick={() => removeActivity(item.id)}>Remove</button>
                    </div>
                </>
            )}
        </div>
    );
};

export default ActivityListCard;
