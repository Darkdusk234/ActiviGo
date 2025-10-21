import React, { useState } from "react";

const BookingListCard = ({ item, removeBooking, editBooking }) => {
    const [editMode, setEditMode] = useState(false);
    const [viewDetails, setViewDetails] = useState(false);

    return (
        <div className="admin-list-card">
            {editMode ? (
                <form className="edit-card-form" onSubmit={e => {
                    e.preventDefault();
                    const formData = new FormData(e.target);
                    const updatedBooking = {
                        id: item.id,
                        userId: formData.get("userId"),
                        activityId: formData.get("activityId"),
                        bookingDate: formData.get("bookingDate"),
                        status: formData.get("status")
                    };
                    editBooking(updatedBooking);
                    setEditMode(false);
                }}>
                    <div className="admin-list-card-info">
                        <p className="id">Id: {item.id}</p>
                        <input type="text" className="input-userId" id="userId" name="userId" defaultValue={item.userId} placeholder="User ID" />
                        <input type="text" className="input-activityId" id="activityId" name="activityId" defaultValue={item.activityId} placeholder="Activity ID" />
                        <input type="date" className="input-bookingDate" id="bookingDate" name="bookingDate" defaultValue={item.bookingDate} placeholder="Booking Date" />
                        <input type="text" className="input-status" id="status" name="status" defaultValue={item.status} placeholder="Status" />
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
                        <h3>Booking for User {item.userId} - Activity {item.activityId}</h3>
                        {!viewDetails && <p className="details" onClick={() => setViewDetails(true)}>Click for more details...</p>}
                        {viewDetails && (
                            <div className="details-view">
                                <p>Booking Date: {item.bookingDate}</p>
                                <p>Status: {item.status}</p>
                            </div>
                        )}
                    </div>
                    <div className="admin-list-card-buttons">
                        <button onClick={() => setEditMode(true)}>Edit</button>
                        <button onClick={() => removeBooking(item.id)}>Remove</button>
                    </div>
                </>
            )}
        </div>
    );
};

export default BookingListCard;
