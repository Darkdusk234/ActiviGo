import React from 'react';
import { createContext, useContext, useState, useEffect} from 'react';

export const AuthContext = createContext(null);

export function useAuth() {
    return useContext(AuthContext);
}

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [token, setToken] = useState(localStorage.getItem('authToken'));
    const [loading, setLoading] = useState(true);
    const APIURL = import.meta.env.VITE_API_URL;


    useEffect(() => {
        const fetchUser = async () => {
            const storedToken = localStorage.getItem('authToken');
            
            if (!storedToken || storedToken === 'undefined' || storedToken === '[object Object]') {
                console.log("No valid token found");
                setLoading(false);
                return;
            }
            try {
                const response = await fetch('https://localhost:7201/api/Auth/AuthCheck', {
                    credentials: 'include',
                    headers: {
                        'Authorization': `Bearer ${storedToken}`
                    }
                });
                if (response.ok) {
                    const data = await response.json();
                    if (data.user) {
                        setUser(data.user);
                    }
                }
            } catch (e) {
                console.log("Not logged in", e);
            } finally {

                setLoading(false);
            }
        };
        
        fetchUser();

    }, []);


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
            
            // console.log('Login response:', data);
            // console.log('Response type:', typeof data);
            
            // extracht token
            let tokenString = null;
            
            if (typeof data === 'string') {
                tokenString = data;
            } else if (data.token) {
                tokenString = data.token;
            } else if (data.accessToken) {
                tokenString = data.accessToken;
            }
            
            if (tokenString) {
                console.log('Token extracted:', tokenString.substring(0, 30) + '...');
                localStorage.setItem('authToken', tokenString);
                setToken(tokenString); 
            } else {
                console.error('No token found in response!');
            }

            if (data.user) {
                setUser(data.user);
            } else if (typeof data === 'object') {
                setUser(data);
            }

            return data;

        })
    };

    const logout = (user) => {
        setUser(null);

        setToken(null); // clear token
        localStorage.removeItem('authToken');   // remove from storage

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

        <AuthContext.Provider value={{ user, token, login, APIURL, register, logout }}>      
            {loading ? <div>Loading...</div> : children}

        </AuthContext.Provider>
    );

}
