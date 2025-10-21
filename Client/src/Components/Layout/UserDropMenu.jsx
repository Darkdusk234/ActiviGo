import React from 'react';
import { useAuth } from '../../contexts/AuthContext';

const UserDropMenu = ({close}) => {

    const { logout } = useAuth();
    const { token } = useAuth(); 

    const handleLogout = () =>
    {
        close();
        logout();
    }

    return(
        <>
        <p className="my-bookings" >Mina bokningar</p>
        <p className="logout" onClick={handleLogout}>Logga ut</p>
        </>
    )
}

export default UserDropMenu;