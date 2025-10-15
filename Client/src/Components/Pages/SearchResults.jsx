import React from "react";
import {useState, useEffect} from 'react';
import DetailedSearch from "../DetailedSearch";
import SingleResultDisplay from "../Display/SingleResultDisplay";

const SearchResults = ({searchresults}) => {

const [loading, setLoading] = useState(true);
const [results, setResults] = useState([]);

useEffect(() => {

    if(searchresults)
    {

        setResults(searchresults);
        setLoading(false);
    }

},[])

const fetchResults = async (searchTerms) => {
    // Fetch data based on searchTerms
    await fetch('https://localhost:7201/api/ActivityOccurence/search', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(searchTerms)
    })
    .then(response => response.json())
    .then(data => {
        setResults(data);
        setLoading(false);
    })
    .catch(err => {
        console.error('Error fetching search results:', err);
        setLoading(false);
    });
    
}

return (
    <>
    <div className = "detail-search">
        <DetailedSearch fetchResults={fetchResults}/>
    </div>
    <div className ="search-results">

        {loading ? "No results..." : results.map((aresult, index) => {
           return <SingleResultDisplay key={index} result={aresult}/>;
        })}
    </div>
    </>
)
}

export default SearchResults;