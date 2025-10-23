import React, { useEffect, useState } from "react";
import { useAuth } from "../../../contexts/AuthContext";
import LoginForm from "../..//LoginForm";
import './Admin.css';
import WeatherCard from "../../Cards/WeatherCard";

const AdminDashboard = () => {

    const { user, APIURL } = useAuth();
    const [weather, setWeather] = useState(null);
    const [code, setCode] = useState(null); 

    useEffect( () => {
        
        const fetchWeather = async () => {
            try {
                const response = await fetch(`${APIURL}/Weather/weather-at-time`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({ latitude: "59", longitude: "19", date: "2025-10-23", time: "14:00:00" }),
                });
                const data = await response.json();
                console.log(data);
                setWeather(data);
            } catch (error) {
                console.error('Error fetching weather data:', error);
            }
        };
        fetchWeather();
    }, []);

    useEffect(() => {
        
        setCode(weather?.symbolCode);
    }, [weather]);
    return (
        <div className="admin-dashboard">
            <h1>Admin Dashboard</h1>
            {!user ? <LoginForm/> : <p>En liten dashboard</p>}
            <div>
                {weather && <WeatherCard weather={weather} />}
                
            </div>
        </div>
    );
};

export default AdminDashboard;
