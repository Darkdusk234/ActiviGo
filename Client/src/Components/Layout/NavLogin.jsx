import React from "react";
import { useRef, useEffect, useState, useContext } from "react";
import { useAuth } from '../../contexts/AuthContext';
import LoginDropBox from "./LoginDropBox";
import './Layout.css';

const NavLogin = () => {

    const [isLoggedIn, setIsLoggedIn] = useState(true);
    const [loginVisible, setLoginVisible] = useState(false);
    const { user } = useAuth();

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

    const showLoginBox = () => {

        setLoginVisible(!loginVisible);

    }

    return(
        <>
            {!isLoggedIn ? (<img src="../src/assets/loginpic.png" alt="Login" className="NavLogin" onClick={() => showLoginBox()}/> ) : (<div className="NavLogin" onClick="//Länk till mina sidor">Mina Sidor</div>) }
            {loginVisible ? (<LoginDropBox />) : ("")}
        </>
    )
}

export default NavLogin;