import React from "react";
import {useState, useEffect} from 'react';
import DetailedSearch from "../DetailedSearch";
import SingleResultDisplay from "../Display/SingleResultDisplay";
import { useAuth } from "../../contexts/AuthContext";
import "./SearchResults.css";
import {useLocation} from 'react-router-dom';

const SearchResults = ({searchResults}) => {

const [loading, setLoading] = useState(true);
const [results, setResults] = useState([]);
const { APIURL } = useAuth();


const {state} = useLocation();  

const { searchQuery, source } = state;


useEffect(() => {

    if(searchResults)
    {
        setResults(searchResults);
        setLoading(false);
        return;
    }

    if(source === 'general')
    {
        fetchGeneralResults(searchQuery);
        return;
    }

    if(source === 'detailed')
        {
            fetchResults(searchQuery);
            return;
        }
},[state])



const fetchGeneralResults = async(searchTerms) => {
    const term = { query: searchTerms};
    await fetch(`${APIURL}/ActivityOccurence/general-search`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(term)
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

const fetchResults = async (searchTerms) => {
    console.log(searchTerms);
    // Fetch data based on searchTerms
    await fetch(`${APIURL}/ActivityOccurence/search`, {
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
    <div className="results-page">
        <div className = "detail-search">
            <DetailedSearch fetchResults={fetchResults}/>
        </div>
        <div className ="search-results">

            {loading ? "No results..." : results.map((aresult, index) => {
            return <SingleResultDisplay key={index} result={aresult}/>;
            })}
        </div>
    </div>
)
}

export default SearchResults;