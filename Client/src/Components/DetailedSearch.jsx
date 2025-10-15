import React from "react";
import { useState, useEffect } from "react";
import { useActivities } from "../contexts/ActivityContext";
import { useCategories } from "../contexts/CategoryContext";

const DetailedSearch = () => {

    const { activities, loadingActivities, errorActivities } = useActivities();
    const { categories, loadingCategories, errorCategories } = useCategories();

    // State to hold names for dropdowns

    const [categoryNames, setCategoryNames] = useState([]);
    const [activityNames, setActivityNames] = useState([]);
    const [locationNames, setLocationNames] = useState([]);

    const [searchTerms, setSearchTerms] = useState(
        {
            // category : null,
            // activity : null,
            // fromDate: null,
            // toDate: null,
            // availableSpots: null,
            // location: null,
            // nearLat: null, // For use in "activities near me"
            // nearLong: null // For use in "activities near me"

        }
    )

    useEffect( () => {
        
        const getData = async () => {
            if (!loadingActivities && activities) {
                setActivityNames(activities.map(activity => activity.name));
            }
        }
        getData();
    }, [activities, loadingActivities])

    useEffect( () => {
        const getData = async () => {
            if (!loadingCategories && categories) {
                setCategoryNames(categories.map(category => category.name));
            }
        }
        getData();
    }, [categories, loadingCategories])

    return(
        <>
            <form className = "detailed-search-form">
                <input type= "text" placeholder="Fritext..."/>
               <label htmlFor="fromDate">Från:</label> <input type= "date" name="fromDate"/>
               <label htmlFor="toDate">Till:</label> <input type= "date" name="toDate"/>
               <label htmlFor="activity">Aktivitet:</label> <select id ="activity" name="activity">
                    {activityNames.map((activity, index) => (
                        <option key={index} value={activity}>{activity}</option>
                    ))}
                </select>
                <label htmlFor="category">Kategori:</label> <select id ="category" name="category">
                    {categoryNames.map((category, index) => (
                        <option key={index} value={category}>{category}</option>
                    ))}
                </select>
                <label htmlFor="location">Plats:</label><select id ="location" name="location">
                    {locationNames.map((location, index) => (
                        <option key={index} value={location}>{location}</option>
                    ))}
                </select>
            </form>
        </>
    )
}

export default DetailedSearch;