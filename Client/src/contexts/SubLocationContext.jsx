import React, { createContext, useContext, useState, useEffect } from 'react';


const SubLocationContext = createContext();

export function useSubLocations() {
  return useContext(SubLocationContext);
}


export function SubLocationProvider({ children }) {
  const [subLocations, setSubLocations] = useState([]);
  const [loadingSubLocations, setSubLoading] = useState(true);
  const [errorSubLocations, setSubError] = useState(null);
  const APIURL = import.meta.env.VITE_API_URL;
  useEffect(() => {
    
    async function getData() {
    await fetch(`${APIURL}/SubLocation/`, { method: 'GET', headers: { 'Content-Type': 'application/json' } })
      .then(response => response.json())
      .then(data => {
        setSubLocations(data);
        setSubLoading(false);
      })
      .catch(err => {
        setSubError(err);
        setSubLoading(false);
      });
  }
  getData();
  }, []);

  return (
    <SubLocationContext.Provider value={{ subLocations, loadingSubLocations, errorSubLocations }}>
      {children}
    </SubLocationContext.Provider>
  );
}
