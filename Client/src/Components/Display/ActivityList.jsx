import { useEffect, useState } from "react";
import { getActivities } from "../../api/Services/activityService";
import DisplayList from "./DisplayList";
import ActivityCard from "../Cards/ActivityCard";
import { useAuth } from "../../contexts/AuthContext";

export default function ActivityList() {
  const { user } = useAuth();
  const [activities, setActivities] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
      const load = async () => {
          setLoading(true);
          try {
          const data = await getActivities();
          setActivities(data); 
          setError(null);
          } catch (err) {
          setError(err.message);
          } finally {
          setLoading(false);
          }
      };
  
      load();
      }, []); // 👈 kör en gång på mount, oberoende av user
  
  if (loading) return <p className="Loading">Laddar aktiviteter...</p>;
  if (error) return <p className="Loading-failed">{error}</p>;

  return (
    <DisplayList
      items={activities}
      renderItem={(activity) => <ActivityCard activity={activity} />}
    />
  );
}
