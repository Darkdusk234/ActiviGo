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
                        'Authorization': `Bearer ${localStorage.getItem('authToken')}`
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
    }, [user]);

    return (
        <>
            <h1>Administratörsstatistik</h1>
            <div className="statistics-container">
                {!user ? (
                    <p>Vänligen logga in för att se statistik.</p>
                ) : (
                    <div className="statistics-content">
                        {statistics ? (

                            <>
                            <div className="statistics-category">
                                <h3>Aktiviteter</h3>
                                <p>Total antal aktiviteter:</p> <p>{statistics.activitiesCount}</p>
                                <p>Mest bokade aktivitet: </p> <p>{statistics.mostBookedActivity.name}</p>
                             </div>
                                
                                <div className="statistics-category">
                                    <h3>Händelser</h3>
                                    <p>Total antal händelser:</p> <p>{statistics.activityOccurrencesCount}</p>
                                    
                                </div>
                                
                                <div className="statistics-category">
                                    <h3>Kategorier</h3>
                                    <p>Totalt antal kategorier:</p> <p>{statistics.categoriesCount}</p>
                                    <p>Mest bokade kategori:</p> <p>{statistics.mostBookedCategory.name}</p>
                                </div>
                                
                                <div className="statistics-category">
                                    <h3>Platser</h3>
                                    <p>Totalt antal platser:</p> <p>{statistics.locationsCount}</p>
                                    <p>Mest bokade plats:</p> <p>{statistics.mostBookedLocation.name}</p>
                                </div>
                                
                                <div className="statistics-category">
                                    <h3>Bokningar</h3>
                                    <p>Bokningar senaste månaden:</p> <p>{statistics.bookingsLastMonth}</p>
                                </div>
                            </>
                        ) : (
                            <p>Laddar statistik...</p>
                        )}
                    </div>
                )}
            </div>
        </>
    );
};

export default AdminStatistics;