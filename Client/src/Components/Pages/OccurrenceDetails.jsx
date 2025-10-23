import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { useAuth } from '../../contexts/AuthContext';
import { getActivityOccurrenceById } from "../../api/Services/activityOccurrenceService";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faMapMarkerAlt, faCalendarAlt, faClock, faInfoCircle, faUsers, faTag, faMoneyBillWave } from '@fortawesome/free-solid-svg-icons';
import "./OccurrenceDetails.css";
import WeatherCard from "../Cards/WeatherCard";
import OccurenceListCard from "./Admin/OccurenceListCard";

const OccurrenceDetails = () => {
  const { id } = useParams();
  const [occurrence, setOccurrence] = useState(null);
  const [loading, setLoading] = useState(true);
  const [date, setDate] = useState('');
  const [startTime, setStartTime] = useState('');
  const [endTime, setEndTime] = useState('');
  const [participants, setParticipants] = useState('');
  
  const { user, loading: authLoading, APIURL, token } = useAuth();


  useEffect(() => {
    setLoading(true);
    const fetchOccurrence = async () => {
      try {
        const data = await getActivityOccurrenceById(id);

        setOccurrence(data);
      } catch (err) {
        console.error("Failed to load occurrence details:", err);
      } finally {
        setLoading(false);
      }
    };

    fetchOccurrence();
  }, []);

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
    if (isNaN(participants))
    {
        const res = await fetch(`${APIURL}/Booking`, {
          method: "Post",
          headers: { 
            "Content-Type": "application/json" ,
            "Authorization": `Bearer ${token}`
          },
          body: JSON.stringify({ "activityOccurenceId": id, "participants": participants })
        });

        if (res.ok) {
          alert("Bokningen lyckades!");
        } else {
          alert("Något gick fel vid bokning");
          console.log(res.ok);
        }
        return;
      } catch (err) {
        console.error("Booking error:", err);
        return;
      }
    };

  const splitDateTime = (startTime, endTime) => {
    const [startDatePart, startTimePart] = startTime.split('T');
    const [endDatePart, endTimePart] = endTime.split('T');
    setDate(startDatePart);
    setStartTime(startTimePart.slice(0, -3));
    setEndTime(endTimePart.slice(0, -3));
  };

  if (loading) return <div>Laddar...</div>;
  if (!occurrence) return <div>Ingen aktivitet hittades</div>;

  return (
    <div className="occurrence-details-container">
      <div className="img-container"></div>
      <div className="details-title"></div>
      <div className="text-container">
        <div className="content-info" style={{ backgroundImage: `url(https://picsum.photos/400/250?random=${occurrence.id})` }}>
          <h4>{occurrence.activityName}</h4>
          <h2><FontAwesomeIcon icon={faMapMarkerAlt} /> Plats: {occurrence.subLocationName}, {occurrence.locationName}</h2>
          <h2><FontAwesomeIcon icon={faCalendarAlt} /> Datum: {date}</h2>
          <h2><FontAwesomeIcon icon={faClock} /> Tid: {startTime} - {endTime}</h2>
          <h2><FontAwesomeIcon icon={faInfoCircle} /> Beskrivning: {occurrence.activityDescription}</h2>
          <h2><FontAwesomeIcon icon={faUsers} /> Lediga platser: {occurrence.availableSpots}/{occurrence.capacity}</h2>
          <h2><FontAwesomeIcon icon={faTag} /> Kategori: {occurrence.categoryName}</h2>
          <h2><FontAwesomeIcon icon={faMoneyBillWave} /> Pris: {!occurrence.price ? 0 : occurrence.price} SEK</h2>
        </div>
        <div className="container-wrapper">
          <div className="weather-div">
            <WeatherCard/>
          </div>
          <div className="book-container">
            <h3>Boka aktivitet</h3>
            <p>Ange antalet platser du vill boka</p>
            <div className="book-availablespots">
              <h2>Lediga platser: {occurrence.availableSpots}</h2>

            </div>
            <form onSubmit={handleBooking} className="booking-form">
              <div>
                <label>Deltagare</label>
                <input
                  type="text"
                  value={participants}
                  onChange={(e) => setParticipants(e.target.value)}
                  required
                />
              </div>
              <button type="submit">Boka</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default OccurrenceDetails;