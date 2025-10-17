import React from "react";
import {useEffect, useState} from "react";
import { useAuth } from '../../contexts/AuthContext';
import './Result.css';

const SingleResultDisplay = ({result}) => {

    const { user } = useAuth(); 
    const [showBook, setShowBook] = useState(false);
    const [date, setDate] = useState('');
    const [startTime, setStartTime] = useState('');
    const [endTime, setEndTime] = useState('');
    

    useEffect(() => {

        if(user)
        {
            setShowBook(true);
        }
        else
        {
            setShowBook(false);
        }
        splitDateTime(result.startTime, result.endTime);
    }, [])

    const splitDateTime = (startTime, endTime) => {
        const [startDatePart, startTimePart] = startTime.split('T');
        const [endDatePart, endTimePart] = endTime.split('T');
        setDate(startDatePart);
        setStartTime(startTimePart);
        setEndTime(endTimePart);
    }

    return(
        <>
        <div className = "single-result">
            {console.log(result)  }
            <h4>{result.activityName}</h4>
            <p>available spots: {result.availableSpots}/{result.capacity}</p>
            <p>date: {date}</p>
            <p>time: {startTime} - {endTime}</p>
            <p>Category: {result.categoryName}</p>
            <p>Location: {result.subLocationName}, {result.locationName} </p>
            <img src="bild"/>
            
            {!showBook ? <button>Boka</button> : ""}
        </div>
        </>
    )
}

export default SingleResultDisplay;