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
            <div className="admin-links">

                <Link to="/admin">Startsida</Link>
                {/* <Link to="/admin/bookings">Manage Bookings*</Link> */}
                <Link to="/admin/activities">Aktiviteter</Link>
                <Link to="/admin/categories">Kategorier</Link>
                <Link to="/admin/locations">Platser</Link>
                <Link to="/admin/sublocations">Lokaler</Link>
                <Link to="/admin/statistics">Statistik</Link>
            </div>
            {!user ? (
                <div className="admin-logged-in"><NavLogin/></div>
            ) : (
                <p className="admin-logged-in" onClick={() => handleLogout(user)}>Logga ut</p>
            )}
        </nav>
    );
};

export default AdminNavBar;
