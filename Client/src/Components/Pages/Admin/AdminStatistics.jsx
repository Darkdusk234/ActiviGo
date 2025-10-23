import React from 'react';
import './Admin.css';
import { useAuth } from '../../../contexts/AuthContext';
import { useState, useEffect } from 'react';

const AdminStatistics = () => {

    const { user, APIURL } = useAuth();
    const [statistics, setStatistics] = useState(null);

    useEffect(() => {
        const fetchStatistics = async () => {
            try {
                const response = await fetch(`${APIURL}/ActivityOccurence/adminstatistics`, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${user.token}`
                    }
                });
                const data = await response.json();
                console.log(data);
                setStatistics(data);
            } catch (error) {
                console.error("Error fetching statistics:", error);
            }
        };

        fetchStatistics();
    }, [user, APIURL]);

    return (
        <>
            <h1>Administratörsstatistik</h1>
            
            <div className="statistics-container">
            <p>Här kan du se statistik över aktiviteter och deltagare.</p>
            </div>
        </>
    );
};

export default AdminStatistics;