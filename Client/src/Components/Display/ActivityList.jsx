import { useEffect, useState } from "react";
import { getActivities } from "../Services/activityService";
import DisplayList from "./DisplayList";
import ActivityCard from "../Cards/ActivityCard";

export default function ActivityList() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    getActivities().then(setActivities).catch(console.error);
  }, []);

  return (
    <DisplayList
      items={activities}
      renderItem={(activity) => <ActivityCard activity={activity} />}
    />
  );
}
