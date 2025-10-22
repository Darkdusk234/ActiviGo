import React, { useRef, useEffect, useState } from "react"; // Removed useContext since not used
import { useAuth } from '../../contexts/AuthContext';
import LoginDropBox from "./LoginDropBox";
import './Login.css';

const NavLogin = () => {
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [boxVisible, setBoxVisible] = useState(false);
    const { user } = useAuth();
    const wrapperRef = useRef(null);

    function showBox() {
        setBoxVisible(true);
    }

    function closeBox() {
        setBoxVisible(false);
    }

    useEffect(() => {
        if (user) {
            setIsLoggedIn(true);
        } else {
            setIsLoggedIn(false);
        }
    }, [user]);

    useEffect(() => {
        const handleClose = (e) => {
            if (e.key === 'Escape' && boxVisible) {
                console.log('Esc pressed, closing');
                closeBox();
            } else if (e.type === 'click' && boxVisible && wrapperRef.current && !wrapperRef.current.contains(e.target)) {
                console.log('Click outside, closing. Target:', e.target.className);
                closeBox();
            }
        };

        if (boxVisible) {
            document.addEventListener('keydown', handleClose);
            document.addEventListener('click', handleClose);
        }

        return () => {
            document.removeEventListener('keydown', handleClose);
            document.removeEventListener('click', handleClose);
        };
    }, [boxVisible]); // Dependency on boxVisible to add/remove listeners

    return (
        <>
            <div ref={wrapperRef}>
                <img src="../src/assets/loginpic.png" alt="Login" className="NavLogin" onClick={showBox} />
                {boxVisible && <LoginDropBox close={closeBox} />}
            </div>
        </>
    );
}

export default NavLogin;