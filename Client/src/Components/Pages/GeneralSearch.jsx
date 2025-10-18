import React from "react";
import {useState, useEffect} from 'react';
import { useLocation } from "react-router-dom";
import SingleResultDisplay from "../Display/SingleResultDisplay";

const GeneralSearch = () => {
    const [loading, setLoading] = useState(true);
    const [results, setResults] = useState([]);
    const location = useLocation();
    const queryParams = new URLSearchParams(location.search);
    const query = queryParams.get("query") || "";

useEffect(() => {
    const fetchResults = async () => {
      setLoading(true);
      try {
        const res = await fetch("http://localhost:5210/api/ActivityOccurence/general-search", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({ query }) // skickar query till backend
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
    <div className ="search-results">
        {loading ? "No results..." : results.map((results, index) => {
           return <SingleResultDisplay key={index} result={results}/>;
        })}
    </div>
  );
};

export default GeneralSearch;