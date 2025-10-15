export default function ActivityOccurrenceCard({ occurrence }) {
  return (
    <div className="occurrence-card">
      <div className="occurrence-card-content">
        <h3 className="occurrence-card-title">
          Aktivitet #{occurrence.activityId}
        </h3>
        <p className="occurrence-card-info">
          🗓 Start: {new Date(occurrence.startTime).toLocaleString("sv-SE")}
        </p>
        <p className="occurrence-card-info">
          ⏰ Slut: {new Date(occurrence.endTime).toLocaleString("sv-SE")}
        </p>
        <p className="occurrence-card-info">
          📍 Plats-ID: {occurrence.subLocationId}
        </p>
        <p className="occurrence-card-info">
          👥 {occurrence.availableSpots} / {occurrence.capacity} platser lediga
        </p>
        {occurrence.isCancelled && (
          <p className="occurrence-card-cancelled">❌ Inställd</p>
        )}
      </div>
    </div>
  );
}
