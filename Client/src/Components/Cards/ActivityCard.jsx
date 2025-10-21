import "./ActivityCard.css";
export default function ActivityCard({ activity }) {
  return (
    <div className="activity-card">
      <img
        src={`https://picsum.photos/400/250?random=${activity.id}` || activity.imgUrl}
        alt={activity.name}
      />
      <div className="activity-card-content">
        <h3 className="activity-card-title">{activity.name}</h3>
        <p className="activity-card-description">{activity.description}</p>
        <div className="activity-card-meta">
          <span>{activity.durationInMinutes} min</span>
          <span>{activity.price} kr</span>
        </div>
      </div>
    </div>
  );
}
