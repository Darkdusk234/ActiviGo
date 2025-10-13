export default function ActivityCard({ activity }) {
  return (
    <div className="border rounded-lg overflow-hidden shadow-sm">
      <img
        src={activity.imgUrl || "https://via.placeholder.com/300x200"}
        alt={activity.name}
        className="w-full h-48 object-cover"
      />
      <div className="p-4">
        <h3 className="text-lg font-bold">{activity.name}</h3>
        <p className="text-sm text-gray-600 mb-2">{activity.description}</p>
        <div className="flex justify-between text-sm text-gray-700">
          <span>{activity.durationInMinutes} min</span>
          <span>{activity.price} kr</span>
        </div>
      </div>
    </div>
  );
}
