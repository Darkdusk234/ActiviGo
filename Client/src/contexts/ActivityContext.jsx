import React, { createContext, useContext, useState, useEffect } from 'react';
import { getActivities } from '../api/Services/activityService';

const ActivityContext = createContext();

export function useActivities() {
  return useContext(ActivityContext);
}

export function ActivityProvider({ children }) {
  const [activities, setActivities] = useState([]);
  const [activitiesInCategory, setActivitiesInCategory] = useState([]);
  const [loadingActivities, setLoading] = useState(true);
  const [errorActivities, setError] = useState(null);

  useEffect(() => {
    
    async function getData() {
    await getActivities()
      .then(data => {
        setActivities(data);
        setLoading(false);
      })
      .catch(err => {
        setError(err);
        setLoading(false);
      });
  }
  getData();
  }, []);

  return (
    <ActivityContext.Provider value={{ activities, loadingActivities, errorActivities, activitiesInCategory, setActivitiesInCategory }}>
      {children}
    </ActivityContext.Provider>
  );
}
