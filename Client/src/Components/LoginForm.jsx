import React from 'react';
import { useState } from 'react';
import { useAuth } from '../contexts/AuthContext';
import './Layout/Login.css';

const LoginForm = ( {close}) => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const { login } = useAuth();
    const { user } = useAuth();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const result = await login({ userName, password });
            if (result) {
                console.log('Login successful');
                // Redirect to dashboard or another page
            }
        } catch (error) {
            console.error('Login failed:', error);
        }
        close();
    };

    return (
        <>
        {user ? <p>Welcome!</p> : <p>Please log in.</p>}
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
        </>
    );
};

export default LoginForm;
