import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { useAuth } from '../../contexts/AuthContext';
import "./OccurrenceDetails.css";

const OccurrenceDetails = () => {
  const { id } = useParams();
  const [occurrence, setOccurrence] = useState(null);
  const [loading, setLoading] = useState(true);
  const [date, setDate] = useState('');
  const [startTime, setStartTime] = useState('');
  const [endTime, setEndTime] = useState('');
  const [participants, setParticipants] = useState('');
  const API_URL = import.meta.env.VITE_API_URL;
  const { user } = useAuth();

  useEffect(() => {
    const fetchOccurrence = async () => {
      try {
        const res = await fetch(`${API_URL}/ActivityOccurence/${id}`);
        const data = await res.json();
        setOccurrence(data);
      } catch (err) {
        console.error("Failed to load occurrence details:", err);
      } finally {
        setLoading(false);
      }
    };

    fetchOccurrence();
  }, [id]);

  useEffect(() => {
    if (occurrence && occurrence.startTime && occurrence.endTime) {
      splitDateTime(occurrence.startTime, occurrence.endTime);
    }
  }, [occurrence]);

  const handleBooking = async (e) => {
    e.preventDefault();
    if (!user) {
      alert("Du måste vara inloggad för att boka!");
      return;
    }

    if (!participants || isNaN(participants) 
      || participants <= 0 || participants <= occurrence.availableSpots) 
    {
      try {
        const res = await fetch(`${API_URL}/Booking`, {
          method: "Post",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({"activityOccurenceId": user.id, "participants": participants})
        });

        if (res.ok) {
          alert("Bokningen lyckades!");
        } else {
          alert("Något gick fel vid bokning");
        }
      } catch (err) {
        console.error("Booking error:", err);
      }
    }
  };
  const splitDateTime = (startTime, endTime) => {
        const [startDatePart, startTimePart] = startTime.split('T');
        const [endDatePart, endTimePart] = endTime.split('T');
        setDate(startDatePart);
        setStartTime(startTimePart.slice(0,-3));
        setEndTime(endTimePart.slice(0,-3));
    }

  if (loading) return <div>Laddar...</div>;
  if (!occurrence) return <div>Ingen aktivitet hittades</div>;

  return (
    <div className="occurrence-details-container">
     {console.log(occurrence)}
      <div className="details-title">
        <h4>{occurrence.activityName}</h4>
        <img src={occurrence.imgUrl} alt={occurrence.activityName}/>
      </div>
        <h2>Location: {occurrence.subLocationName}, {occurrence.locationName} </h2>
        <h2>date: {date}</h2>
        <h2>time: {startTime} - {endTime}</h2>
        <h2>Description: {occurrence.activityDescription}</h2>
        <h2>available spots: {occurrence.availableSpots}/{occurrence.capacity}</h2>
        <h2>Category: {occurrence.categoryName}</h2>
        <h2>Price: {!occurrence.price ? 0 : occurrence.price} SEK</h2>
            
      <form onSubmit={handleBooking} className="booking-form">
        <div>
          <label>Participants</label>
          <input
            type="text"
            value={participants}
            onChange={(e) => setParticipants(e.target.value)}
            required
          />
        </div>
        <button
          type="submit"
        >
          Boka
        </button>
      </form>
    </div>
  );
};

export default OccurrenceDetails;
