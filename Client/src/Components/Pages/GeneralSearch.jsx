import React from "react";
import {useState, useEffect} from 'react';
import { useLocation } from "react-router-dom";
import SingleResultDisplay from "../Display/SingleResultDisplay";
import SearchBar from "../Layout/Searchbar";


const GeneralSearch = () => {
  const [loading, setLoading] = useState(true);
  const [results, setResults] = useState([]);
  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);
  const query = queryParams.get("query") || "";
  const API_URL = import.meta.env.VITE_API_URL;

useEffect(() => {
    const fetchResults = async () => {
      setLoading(true);
      try {
        const res = await fetch(`${API_URL}/ActivityOccurence/general-search`, {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({ query })
        });
        const data = await res.json();
        setResults(data);
      } catch (err) {
        console.error("Error fetching search results:", err);
      } finally {
        setLoading(false);
      }
    };

    if (query) fetchResults();
  }, [query]);

  return (
    <div className="general-search-page">
      <div className="welcome-message">
              <p >
                Upptäck spännande aktiviteter och evenemang i din närhet. Använd vår sökfunktion för att hitta det som passar just dig!
              </p>
              <div className="searchbar-container">
                <SearchBar/>
              </div>
            </div>
      <div className ="search-results">
          {loading ? "No results..." : results.map((results, index) => {
            return <SingleResultDisplay key={index} result={results}/>;
          })}
      </div>
    </div>
  );
};

export default GeneralSearch;