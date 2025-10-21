import React from "react";
import { useRef, useEffect, useState, useContext } from "react";
import { useAuth } from '../../contexts/AuthContext';
import LoginDropBox from "./LoginDropBox";
import UserDropBox from "./UserDropMenu";
import './Login.css';

const NavLogin = () => {

    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [boxVisible, setBoxVisible] = useState(false);
    const { user } = useAuth();

    
    function showBox() {

        setBoxVisible(!boxVisible);

    }

    function closeBox() {
        setBoxVisible(false);
    }

    useEffect(() => {

        if(user) // If "truthy" set status to logged in
            {
                setIsLoggedIn(true);
            }
            else
            {
                setIsLoggedIn(false);
            }
    }, [])



    return(
        <>
            <img src="../src/assets/loginpic.png" alt="Login" className="NavLogin" onClick={() => showBox()}/> 
            {boxVisible ? (<LoginDropBox close={closeBox}/>) : ""}
        </>
    )
}

export default NavLogin;