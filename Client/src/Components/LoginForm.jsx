import React from 'react';
import { useState } from 'react';
import { Link } from "react-router-dom";
import { useAuth } from '../contexts/AuthContext';
import './Layout/Login.css';

const LoginForm = ( {close}) => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [message, setMessage] = useState('');
    const { login } = useAuth();
    const { user } = useAuth();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const result = await login({ userName, password });
            if (result) {
                //denna if funkar inte. kommer inte in här vid lyckad login
                console.log('Login successful');
                setMessage('Login successful');
                setTimeout(() => {
                    setMessage('');
                    close(); // Stäng bara vid framgång
                }, 20000);
                // Redirect to dashboard or another page
            }
            else {
                setMessage('Login failed');
                setTimeout(() => setMessage(''), 2000);
            }
        } catch (error) {
            console.error('Login failed:', error);
            setMessage('Login successful');
            setTimeout(() => setMessage(''), 2000);
        }
        
    };

    return (
        <>
        {user ? <p>Welcome!</p> : <p className='login-message'>Logga In, annars feg</p>}
        {<p className="message">{message}</p>}
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                value={userName}
                onChange={(e) => setUserName(e.target.value)}
                placeholder="Username"
                required
            />
            <input
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                placeholder="Password"
                required
            />
            <button type="submit">Login</button>
        </form>
        <Link to={"/register"}>Registrera dig</Link>
        </>
    );
};

export default LoginForm;
