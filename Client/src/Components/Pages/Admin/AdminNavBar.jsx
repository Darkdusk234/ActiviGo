import React from "react";
import { Link } from "react-router-dom";

const AdminNavBar = () => {
    return (
        <nav className="admin-nav">
            <ul>
                <li><Link to="/admin">Dashboard</Link></li>
                <li><Link to="/admin/users">Manage Users</Link> *</li>
                <li><Link to="/admin/activities">Manage Activities</Link></li>
                <li><Link to="/admin/categories">Manage Categories</Link></li>
                <li><Link to="/admin/locations">Manage Locations</Link></li>
                <li><Link to="/admin/sublocations">Manage Sublocations</Link></li>
                <li><Link to="/admin/settings">Site Settings</Link> *</li>
            </ul>
        </nav>
    );
};

export default AdminNavBar;
