import React from "react";
import "./WeatherCard.css";

const WeatherCard = ({ weather }) => {
    if (!weather) {
        return (<div>No weather data available.</div>);
    }
    return (
        <div className="weather-card">
            <img src={`../../../public/weatherpics/${weather.symbolCode}.svg`} alt="Weather" />
            <p>Temperatur: {weather.airTemperature}°C</p>
            <p>Risk för nederbörd: {weather.probabilityOfPrecipitation}%</p>
            <p>Vindhastighet: {weather.windSpeed} m/s</p>
        </div>
    );
};

export default WeatherCard;
