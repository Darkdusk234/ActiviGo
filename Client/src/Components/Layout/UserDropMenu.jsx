import React, { useEffect, useState } from 'react';
import { useAuth } from '../../contexts/AuthContext';
import './Login.css';
import { Link } from 'react-router-dom';

const UserDropMenu = ({ close }) => {
    const { logout, user, token } = useAuth(); 
    const [displayName, setDisplayName] = useState(user?.name || 'Användare'); // Lokal state för namn

    const handleLogout = () => {
        close();
        logout();
    };

    useEffect(() => {
        if (token && user) {
            setDisplayName(user?.userName || 'Användare'); // Uppdatera namn från fetchUser
        }
    }, [token, user]); // Kör när token eller fetchUser ändras

    return (
        <div className="user-drop-menu">
            <h2>{displayName}</h2>
            <p className="my-bookings"><Link to="/my-bookings">Mina bokningar</Link></p>
            <p className="logout" onClick={handleLogout}>Logga ut</p>
        </div>
    );
};

export default UserDropMenu;