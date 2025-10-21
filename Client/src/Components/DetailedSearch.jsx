import React from "react";
import { useState, useEffect } from "react";
import { useActivities } from "../contexts/ActivityContext";
import { useCategories } from "../contexts/CategoryContext";
import { useLocations } from "../contexts/LocationContext";

const DetailedSearch = ({fetchResults}) => {

    const { activities, loadingActivities, errorActivities } = useActivities();
    const { categories, loadingCategories, errorCategories } = useCategories();
    const { locations, loadingLocations, errorLocations } = useLocations();

    // State to hold names for dropdowns

    const [categoryNames, setCategoryNames] = useState([]);
    const [activityNames, setActivityNames] = useState([]);
    const [locationsInfo, setLocations] = useState([]);

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
    );

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

    useEffect( () => {
        const getData = async () => {
            if (!loadingLocations && locations) {
                setLocations(locations)}
        }
        getData();
    }, [locations, loadingLocations])

    const handleSubmit = async (e) => {
        e.preventDefault();
        const formData = new FormData(e.target);
        const data = Object.fromEntries(formData.entries());
       
        fetchResults({
            name: data.name,
            category: data.category,
            activity: data.activity,
            fromDate: data.fromDate,
            toDate: data.toDate,
            availableSpots: data.minAvailableSpots,
            location: data.location,
            nearLat: null,
            nearLong: null
        });

    }



    return(
        <>
            <form className = "detailed-search-form" onSubmit={handleSubmit}>
                <input type= "text" name="name" placeholder="Fritext..."/>
               <label htmlFor="fromDate">Från:</label> <input type= "date" name="fromDate"/>
               <label htmlFor="toDate">Till:</label> <input type= "date" name="toDate"/>
               <label htmlFor="activity">Aktivitet:</label> <select id ="activity" name="activity">
                <option value="">Alla</option>
                    {activityNames.map((activity, index) => (
                        <option key={index} value={activity}>{activity}</option>
                    ))}
                </select>
                <label htmlFor="category">Kategori:</label> <select id ="category" name="category">
                    <option value="">Alla</option>
                    {categoryNames.map((category, index) => (
                        <option key={index} value={category}>{category}</option>
                    ))}
                </select>
                <label htmlFor="location">Plats:</label><select id ="location" name="location">
                    <option value="">Alla</option>
                    {locationsInfo.map((location, index) => (
                        <option key={index} value={location.name}>{location.name}</option>
                    ))}
                </select>
                <label htmlFor="minAvailableSpots">Minst antal lediga platser:</label> <input type= "number" name="minAvailableSpots" /> 

                <button type="submit">Sök</button>
            </form>
        </>
    )
}

export default DetailedSearch;