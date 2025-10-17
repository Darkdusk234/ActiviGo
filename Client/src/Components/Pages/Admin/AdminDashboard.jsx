import React from "react";
import { useAuth } from "../../../contexts/AuthContext";
import LoginForm from "../..//LoginForm";
import './Admin.css';

const AdminDashboard = () => {

    const { user } = useAuth();

    return (
        <div className="admin-dashboard">
            <h1>Admin Dashboard</h1>
            {!user ? <LoginForm/> : <p>En liten dashboard</p>}
        </div>
    );
};

export default AdminDashboard;
