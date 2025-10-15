import React from "react";
import { useState } from "react";

const DetailedSearch = () => {

    const [categoryNames, setCategoryNames] = useState([]);
    const [activityNames, setActivityNames] = useState([]);

    const [searchTerms, setSearchTerms] = useState(
        {
            category : null,
            activity : null,
            fromDate: null,
            toDate: null,
            availableSpots: null,
            location: null,
            nearLat: null, // For use in "activities near me"
            nearLong: null // For use in "activities near me"

        }
    )

    useEffect = (() => {

        const baseUrl = "http://localhost:blabla";
        const fetchActivityNames = async () => {

            await fetch(baseUrl + "activities bla bla")
            .then(response =>response.json())
            .then(data => {
                if(data) {
                    setActivityNames(data);
                }
            })
            .catch((e) => {
                console.log("Error fetching activity names");
            });

        };
                const fetchCategoryNames = async () => {

            await fetch(baseUrl + "activities bla bla")
            .then(response =>response.json())
            .then(data => {
                if(data) {
                    setCategoryNames(data);
                }
            })
            .catch((e) => {
                console.log("Error fetching activity names");
            });

        };

        fetchActivityNames();
        fetchCategoryNames();

    }, [])

    const handleSearch = () => {

        

    }


    return(
        <>
            <form className = "detailed-search-form" onSubmit={handleSearch()}>
                <input type= "text" placeholder="Fritext..."/>
               <label for="fromDate">Från:</label> <input type= "date" name="fromDate"/>
               <label for="toDate">Till:</label> <input type= "date" name="toDate"/>
               <label for="activity"></label>
            </form>
        </>
    )
}

export default DetailedSearch;