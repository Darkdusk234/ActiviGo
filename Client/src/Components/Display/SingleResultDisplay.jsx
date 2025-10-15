import React from "react";
import {useEffect, useState} from "react";
import { useAuth } from '../contexts/AuthContext';

const SingleResultDisplay = (result) => {

    const { user } = useAuth(); 
    const [showBook, setShowBook] = useState(false);

    

    useEffect(() => {

        if(user)
        {
            setShowBook(true);
        }
        else
        {
            setShowBook(false);
        }

    }, [])

    return(
        <>
        <div className = "single-result">
            <h3>{result.name}</h3>
            <p>{result.locationName}</p>
            <p>{result.startTime} - {result.endTime}</p>
            <img src="bild"/>
            <WeatherSmall lat = {result.lat} long = {result.long} time = {result.startTime}/>
            {!showBook ? <button>Boka</button> : ""}
        </div>
        </>
    )
}

export default SingleResultDisplay;