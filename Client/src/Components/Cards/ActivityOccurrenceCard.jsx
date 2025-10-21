import "./ActivityOccurrenceCard.css";
import { useNavigate } from "react-router-dom";

export default function ActivityOccurrenceCard({ occurrence }) {
  const navigate = useNavigate();

  const handleClick = () => {
        navigate(`/occurrence/${occurrence.id}`);
    };
  return (
    <div className="occurrence-card"
    onClick={handleClick}
    >
        <img
        src={`https://picsum.photos/400/250?random=${occurrence.id}` || occurrence.imgUrl}
        alt={"bild"}
      />
      <div className="occurrence-card-content">
        <h3 className="occurrence-card-title">
          {occurrence.activityName}
        </h3>
        <p className="occurrence-card-info">
          Datum: {new Date(occurrence.startTime).toLocaleDateString("sv-SE", { day: '2-digit', month: '2-digit' })}
        </p>
        <p className="occurrence-card-info">
          🗓 Start: {new Date(occurrence.startTime).toLocaleTimeString("sv-SE", { hour: '2-digit', minute: '2-digit' })}
        </p>
        <p className="occurrence-card-info">
          ⏰ Slut: {new Date(occurrence.endTime).toLocaleTimeString("sv-SE", { hour: '2-digit', minute: '2-digit' })}
        </p>
        <p className="occurrence-card-info">
          📍 Plats: {occurrence.subLocationName}
        </p>
        <p className="occurrence-card-info">
          👥 {occurrence.availableSpots} / {occurrence.capacity} platser lediga
        </p>
        <p className="occurrence-card-info">
          Pris: {occurrence.price}kr
        </p>
        {occurrence.isCancelled && (
          <p className="occurrence-card-cancelled">❌ Inställd</p>
        )}
      </div>
    </div>
  );
}
