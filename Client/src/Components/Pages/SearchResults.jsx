import React from "react";
import {useState, useEffect} from 'react';

const SearchResults = (searchresults) => {

const [loading, setLoading] = useState(true);
const [results, setResults] = useState([]);

useEffect(() => {

    setResults(searchresults);
    setLoading(false);

},[])

return (
    <>
    <div className = "detail-search">
        
    </div>
    <div className ="search-results">

        {loading ? "Loading results..." : results.map((index, aresult) => {
            <SingleResultDisplay result={aresult}/>
        })}
    </div>
    </>
)
}

export default SearchResults;