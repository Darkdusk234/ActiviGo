import React from 'react';
import { useAuth } from '../../contexts/AuthContext';
import './Login.css'
import { Link } from 'react-router-dom';

const UserDropMenu = ({close}) => {

    const { logout } = useAuth();
    const { token } = useAuth(); 

    const handleLogout = () =>
    {
        close();
        logout();
    }

    return(
        <div class="user-drop-menu">
            <p className="my-bookings"><Link to="/my-bookings">Mina bokningar</Link></p>
            <p className="logout" onClick={handleLogout}>Logga ut</p>
        </div>
    )
}

export default UserDropMenu;