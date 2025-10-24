import React from "react";
import {useEffect, useState} from "react";
import { useAuth } from '../../contexts/AuthContext';
import './Result.css';
import { useNavigate } from "react-router-dom";

const SingleResultDisplay = ({ result }) => {
  const navigate = useNavigate();

  const { user } = useAuth(); 
  const [showBook, setShowBook] = useState(false);
  const [date, setDate] = useState('');
  const [startTime, setStartTime] = useState('');
  const [endTime, setEndTime] = useState('');
  
    const handleClick = () => {
        navigate(`/occurrence/${result.id}`);
    };

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
        setStartTime(startTimePart.slice(0,-3));
        setEndTime(endTimePart.slice(0,-3));
    }

    return(
        <>
        <div className="expedia-result">
            <div className="result-image" onClick={handleClick}>
                <img src={`https://picsum.photos/400/250?random=${result.id}`} alt={result.activityName} />
            </div>
            <div className="result-details" onClick={handleClick}>
                <div className="top">
                    <h4 className="result-title">{result.activityName}</h4>
                    <p>Time: {startTime} - {endTime}</p>
                </div>
                <div className="result-info">
                    <p>Available spots: {result.availableSpots}/{result.capacity}</p>
                    <p>Date: {date}</p>
                    <p>Category: {result.categoryName}</p>
                    <p>Location: {result.subLocationName}, {result.locationName}</p>
                    <div className="right-bottom-tag">
                        <p>Price: {!result.price ? 0 : result.price} SEK</p>
                        <button className="book-button" onClick={(e) => { e.stopPropagation(); navigate(`/occurrence/:${result.id}`); }}>
                        Boka
                    </button>
                    </div>
                </div>
            </div>
        </div>
        </>
    )
}

export default SingleResultDisplay;