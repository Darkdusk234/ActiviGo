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

    const login = async (credentials) => {
        try {
            const response = await fetch('https://localhost:7201/api/Auth/Login', {
                method: 'POST',
                credentials: 'include',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(credentials)
            });

            if (!response.ok) {
                throw new Error('Login failed');
            }

            const data = await response.json();
            
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

        } catch (error) {
            console.error('Error logging in:', error);
            throw error;
        }
    };

    const logout = (user) => {
        setUser(null);
        setToken(null); // clear token
        localStorage.removeItem('authToken');   // remove from storage
        fetch('https://localhost:7201/api/Auth/Logout', { method: 'POST' })
        .catch(error => {
            console.error('Error logging out:', error);
        });
    };

    return (
        <AuthContext.Provider value={{ user, token, login, logout }}>      
            {loading ? <div>Loading...</div> : children}
        </AuthContext.Provider>
    );

}
