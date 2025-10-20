import React from 'react';
import { createContext, useContext, useState, useEffect} from 'react';

export const AuthContext = createContext(null);

export function useAuth() {
    return useContext(AuthContext);
}

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [loading, setLoading] = useState(true);
    const APIURL = import.meta.env.VITE_API_URL;


    useEffect(() => {
        // Check if user is logged in on component mount
        const fetchUser = async () => {
            fetch(`${APIURL}/Auth/AuthCheck`, { method: 'GET', headers: { 'Content-Type': 'application/json',
            'Authorization': `Bearer ${localStorage.getItem('authToken')}` } })
            .then(response => response.json())
            .then(data => {
                
                    setUser(data);
                    setLoading(false);
                    
                    console.log("logged in");
                
            })
            .catch((e) => {
                console.log("not logged in");
                setLoading(false);
            });
        };
        fetchUser();
        
        }, []);

    const setToken = (token) => {
        localStorage.setItem('authToken', token);
    }

    const login = (credentials) => {
        fetch(`${APIURL}/Auth/Login`, {
            method: 'POST',
            headers: {  'Content-Type': 'application/json' },
            body: JSON.stringify(credentials)
        })
        .then(response => {
            if (response.ok) {
                return response.json();
            }
            throw new Error('Login failed');
        })
        .then(data => {
            setToken(data.token);
            setUser(data);
            
            
        })
        .catch(error => {
            console.error('Error logging in:', error);
        });
    };

    const logout = (user) => {
        setUser(null);
        fetch(`${APIURL}/Auth/Logout`, { method: 'POST' })
        .catch(error => {
            console.error('Error logging out:', error);
        });
    };

    const register = (registrationInfo) => {
        fetch(`${APIURL}/Auth`, {
            method: 'Post',
            headers: {  'Content-Type': 'application/json' },
            body: JSON.stringify(registrationInfo)
        })
        .then(response => {
            if(response.ok)
            {
                return "Registration complete."
            }
            throw new Error('Registration Failed')
        })
    }

    return (
        <AuthContext.Provider value={{ user, login, logout, APIURL, register }}>      
            {children}
        </AuthContext.Provider>
    );

}
