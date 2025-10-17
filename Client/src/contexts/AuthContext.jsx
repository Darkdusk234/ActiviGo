import React from 'react';
import { createContext, useContext, useState, useEffect} from 'react';

export const AuthContext = createContext(null);

export function useAuth() {
    return useContext(AuthContext);
}

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [loading, setLoading] = useState(true);


    useEffect(() => {
        // Check if user is logged in on component mount
        const fetchUser = async () => {
            fetch('https://localhost:7201/api/Auth/AuthCheck')
            .then(response => response.json())
            .then(data => {
                if (data.user) {
                    setUser(data.user);
                    setLoading(false);
                }
            })
            .catch((e) => {
                console.log("not logged in");
                setLoading(false);
            });
        };
        fetchUser();
        setLoading(false);
        }, []);

    const setToken = (token) => {
        localStorage.setItem('authToken', token);
    }

    const login = (credentials) => {
        fetch('https://localhost:7201/api/Auth/Login', {
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
            setToken(data);
            setUser(data);
            
            
        })
        .catch(error => {
            console.error('Error logging in:', error);
        });
    };

    const logout = (user) => {
        setUser(null);
        fetch('https://localhost:7201/api/Auth/Logout', { method: 'POST' })
        .catch(error => {
            console.error('Error logging out:', error);
        });
    };

    const register = (registrationInfo) => {
        fetch('https://localhost:7201/api/Auth', {
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
        <AuthContext.Provider value={{ user, login, logout }}>      
            {loading ? <div>Loading...</div> : children}
        </AuthContext.Provider>
    );

}
