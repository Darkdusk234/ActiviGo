import React from "react";
import {useEffect, useState} from "react";
import { useAuth } from '../../contexts/AuthContext';

const SingleResultDisplay = ({result}) => {

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
            {console.log(result)  }
            <h3>{result.name}</h3>
            <p>available: {result.availableSpots}/{result.capacity}</p>
            <p>time: {result.startTime} - {result.endTime}</p>
            <img src="bild"/>
            
            {!showBook ? <button>Boka</button> : ""}
        </div>
        </>
    )
}

export default SingleResultDisplay;