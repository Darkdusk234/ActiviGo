import React, { useState } from "react";

const UserListCard = ({ item, removeUser, editUser }) => {
    const [editMode, setEditMode] = useState(false);
    const [viewDetails, setViewDetails] = useState(false);

    return (
        <div className="admin-list-card">
            {editMode ? (
                <form className="edit-card-form" onSubmit={e => {
                    e.preventDefault();
                    const formData = new FormData(e.target);
                    const updatedUser = {
                        id: item.id,
                        userName: formData.get("userName"),
                        name: formData.get("name"),
                        email: formData.get("email")
                    };
                    editUser(updatedUser);
                    setEditMode(false);
                }}>
                    <div className="admin-list-card-info">
                        <p className="id">Id: {item.id}</p>
                        <input type="text" className="input-name" id="userName" name="userName" defaultValue={item.userName} placeholder="Username" />
                        <input type="text" className="input-name" id="name" name="name" defaultValue={item.name} placeholder="Name" />
                        <input type="email" className="input-email" id="email" name="email" defaultValue={item.email} placeholder="Email" />
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
                        <h3>{item.userName || item.name}</h3>
                        {!viewDetails && <p className="details" onClick={() => setViewDetails(true)}>Click for more details...</p>}
                        {viewDetails && (
                            <div className="details-view">
                                <p>Name: {item.name}</p>
                                <p>Email: {item.email}</p>
                            </div>
                        )}
                    </div>
                    <div className="admin-list-card-buttons">
                        <button onClick={() => setEditMode(true)}>Edit</button>
                        <button onClick={() => removeUser(item.id)}>Remove</button>
                    </div>
                </>
            )}
        </div>
    );
};

export default UserListCard;
