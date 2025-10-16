import React, { createContext, useContext, useState, useEffect } from 'react';


const LocationContext = createContext();

export function useLocations() {
  return useContext(LocationContext);
}


export function LocationProvider({ children }) {
  const [locations, setLocations] = useState([]);
  const [loadingLocations, setLoading] = useState(true);
  const [errorLocations, setError] = useState(null);

  useEffect(() => {
    
    async function getData() {
    await fetch('https://localhost:7201/api/Location/')
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
