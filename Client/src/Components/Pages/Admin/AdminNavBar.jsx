import React from "react";
import { Link } from "react-router-dom";
import './Admin.css';
import { useAuth } from "../../../contexts/AuthContext";
import NavLogin from "../../Layout/NavLogin";

const AdminNavBar = () => {

    const { user, logout } = useAuth();

    const handleLogout = async (user) => {
        await logout();
    }

    return (
        <nav className="admin-nav">
            <Link to="/admin">Dashboard</Link>
            {/* <Link to="/admin/bookings">Manage Bookings*</Link> */}
            <Link to="/admin/activities">Manage Activities</Link>
            <Link to="/admin/categories">Manage Categories</Link>
            <Link to="/admin/locations">Manage Locations</Link>
            <Link to="/admin/sublocations">Manage Sublocations</Link>
            <Link to="/admin/statistics">Statistics*</Link>
            {!user ? (
                <div className="admin-logged-in"><NavLogin/></div>
            ) : (
                <p className="admin-logged-in" onClick={() => handleLogout(user)}>Logga ut</p>
            )}
        </nav>
    );
};

export default AdminNavBar;
