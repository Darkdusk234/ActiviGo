import "./ActivityOccurrenceCard.css";
import { useNavigate } from "react-router-dom";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faMapMarkerAlt as FaMapMarkerAlt } from '@fortawesome/free-solid-svg-icons';
import { faCalendarAlt as FaCalendarAlt } from '@fortawesome/free-solid-svg-icons';
import { faClock } from '@fortawesome/free-solid-svg-icons';

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
        <div className="top-content">
          <h3 className="occurrence-card-title">
            {occurrence.activityName}
          </h3>
          <p className="occurrence-card-time">
            <span className="icon"><FontAwesomeIcon icon={faClock} />  </span>
          {new Date(occurrence.startTime).toLocaleTimeString("sv-SE", { hour: '2-digit', minute: '2-digit' })} -
            {new Date(occurrence.endTime).toLocaleTimeString("sv-SE", { hour: '2-digit', minute: '2-digit' })}
          </p>
        </div>
        <p className="occurrence-card-info">
          <span className="icon"><FontAwesomeIcon icon={FaCalendarAlt} />  </span>{new Date(occurrence.startTime).toLocaleDateString("sv-SE", { day: '2-digit', month: '2-digit' })}
        </p>
        <p className="occurrence-card-info">
          <span className="icon"><FontAwesomeIcon icon={FaMapMarkerAlt} />  </span>
          {occurrence.subLocationName}
        </p>
        <p className="occurrence-card-info">
          👥 {occurrence.availableSpots} / {occurrence.capacity} platser lediga
        </p>
        {occurrence.isCancelled && (
          <p className="occurrence-card-cancelled">❌ Inställd</p>
        )}
        <div className="bottom-content">
          <p className="occurrence-card-info">
            {occurrence.price} SEK
          </p>
        </div>
      </div>
    </div>
  );
}
