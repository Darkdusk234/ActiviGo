import React from "react";
import { useRef, useEffect, useState, useContext } from "react";
import { useAuth } from '../../contexts/AuthContext';
import LoginDropBox from "./LoginDropBox";
import './Layout.css';
import { AuthContext } from "../../contexts/AuthContext";
const NavLogin = () => {

    const [isLoggedIn, setIsLoggedIn] = useState(true);
    const [loginVisible, setLoginVisible] = useState(false);
    const { user } = useAuth();

    useEffect(() => {

        if(user)
            {
                setIsLoggedIn(true);
            }
    }, [])

    const showLoginBox = () => {

        setLoginVisible(!loginVisible);

    }

    return(
        <>
            {isLoggedIn ? (<div className="NavLogin" onClick={() => showLoginBox()}> Klicka för att logga in</div>) : (<div className="NavLogin" onClick="//Länk till mina sidor">Mina Sidor</div>) }
            {!loginVisible ? (<LoginDropBox />) : ("")}
        </>
    )
}

export default NavLogin;