import React from "react";
import { useState } from "react";

const CategoryListCard = ({item, removeCategory, editCategory}) => {

    const [editMode, setEditMode] = useState(false);
    const [viewDetails, setViewDetails] = useState(false);  


    return (
        <>
        <div className="admin-list-card">
            {editMode && 

                    <form className="edit-card-form" onSubmit={(e) => {
                        e.preventDefault();
                        const formData = new FormData(e.target);
                        const updatedCategory = {
                            id: item.id,
                            name: formData.get("name"),
                            description: formData.get("description")
                        };
                        editCategory(updatedCategory);
                        setEditMode(false);
                    }}>
                        <div className="admin-list-card-info">
                            <p className="id">Id: {item.id} </p>
                            <input type="text" className="input-name"id="name" name="name" defaultValue={item.name} />
                            <textarea id="description" name="description" defaultValue={item.description}></textarea>
                        </div>
                        <div className="admin-list-card-buttons">

                            <button type="submit">Save</button>
                            <button type="button" onClick={() => setEditMode(false)}>Cancel</button>
                        </div>
                    </form>
                }
            {!editMode && (
                <><div className="admin-list-card-info">
                        <p className="id">Id: {item.id}</p>
                        <h3>{item.name}</h3>
                        
                        {!viewDetails && <p className="details" onClick={() => setViewDetails(true)}>Click for more details...</p>}
                        {viewDetails && (
                            <div className="details-view">
                                <p>Description:</p>
                                <p className="Description">{item.description}</p>
                            </div>
                        )}
                    </div>
                    <div className="admin-list-card-buttons">
                            <button onClick={() => setEditMode(true)}>Edit</button>
                            <button onClick={() => removeCategory(item.id)}>Remove</button>

                    </div></>)}
        </div>
        </>
    );
};

export default CategoryListCard;
