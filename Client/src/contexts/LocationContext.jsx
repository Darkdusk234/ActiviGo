import React, { createContext, useContext, useState, useEffect } from 'react';


const LocationContext = createContext();

export function useLocations() {
  return useContext(LocationContext);
}


export function LocationProvider({ children }) {
  const [locations, setLocations] = useState([]);
  const [loadingLocations, setLoading] = useState(true);
  const [errorLocations, setError] = useState(null);
  const APIURL = import.meta.env.VITE_API_URL;
  useEffect(() => {
    
    async function getData() {
    await fetch(`${APIURL}/Location/`, { method: 'GET', headers: { 'Content-Type': 'application/json' } })
      .then(response => response.json())
      .then(data => {
        setLocations(data);
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
    <LocationContext.Provider value={{ locations, loadingLocations, errorLocations }}>
      {children}
    </LocationContext.Provider>
  );
}
