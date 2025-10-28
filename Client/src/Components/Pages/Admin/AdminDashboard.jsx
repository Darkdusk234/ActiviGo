import React, { useEffect, useState } from "react";
import { useAuth } from "../../../contexts/AuthContext";
import LoginForm from "../..//LoginForm";
import { Link } from "react-router-dom";
import './Admin.css';


const AdminDashboard = () => {

    const { user, APIURL } = useAuth();



    return (
        <div className="admin-dashboard">
            <h1>Admin Dashboard</h1>
            {!user ? <LoginForm/> : <p>Navigera i menyn eller med knapparna nedanför</p>}
            <div className="dashboard-content">
                {!user ? <p>Vänligen logga in för att administrera ActiviGo!</p> : (
                    <div className="dashboard-items">
                        <Link to="/admin/locations" className="dashboard-item">
                        <div>
                            <h4>Hantera platser</h4>
                            <p>Skapa, redigera och ta bort platser där aktiviteter kan äga rum.</p>
                        </div>
                        </Link>
                        <Link to="/admin/sub-locations" className="dashboard-item">
                        <div>
                            <h4>Hantera underplatser</h4>
                            <p>Skapa, redigera och ta bort underplatser kopplade till platser.</p>
                        </div>
                        </Link>
                        <Link to="/admin/activities" className="dashboard-item">       
                        <div >
                            <h4>Hantera aktiviteter</h4>
                            <p>Skapa, redigera och ta bort aktiviteter.</p>
                            <p>Hantera tillfällen för aktiviteter</p>
                        </div>
                        </Link>
                        <Link to="/admin/categories" className="dashboard-item">
                        <div>
                            <h4>Hantera kategorier</h4>
                            <p>Skapa, redigera och ta bort kategorier för att organisera aktiviteter.</p>
                        </div>
                        </Link>
                        <Link to="/admin/statistics" className="dashboard-item">
                        <div>
                            <h4>Hantera statistik</h4>
                            <p>Visa och analysera statistik för aktiviteter och användare.</p>
                        </div>
                        </Link>
                    </div>
                )}
                
            </div>
        </div>
    );
};

export default AdminDashboard;
