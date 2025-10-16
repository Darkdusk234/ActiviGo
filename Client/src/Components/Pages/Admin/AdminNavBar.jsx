import React from "react";
import { Link } from "react-router-dom";
import './Admin.css';

const AdminNavBar = () => {
    return (
        <nav className="admin-nav">
            <Link to="/admin">Dashboard</Link>
            <Link to="/admin/users">Manage Users*</Link>
            <Link to="/admin/occurences">Manage Occurrences*</Link>
            <Link to="/admin/bookings">Manage Bookings*</Link>
            <Link to="/admin/activities">Manage Activities</Link>
            <Link to="/admin/categories">Manage Categories</Link>
            <Link to="/admin/locations">Manage Locations</Link>
            <Link to="/admin/sublocations">Manage Sublocations</Link>
            <Link to="/admin/settings">Site Settings*</Link>

        </nav>
    );
};

export default AdminNavBar;
