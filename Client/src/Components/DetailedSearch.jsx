import React from "react";
import { useState, useEffect } from "react";
import { useActivities } from "../contexts/ActivityContext";
import { useCategories } from "../contexts/CategoryContext";
import { useLocations } from "../contexts/LocationContext";
import './Layout/Layout.css';

const DetailedSearch = ({fetchResults}) => {

    const { activities, loadingActivities, errorActivities } = useActivities();
    const { categories, loadingCategories, errorCategories } = useCategories();
    const { locations, loadingLocations, errorLocations } = useLocations();

    // State to hold names for dropdowns

    const [categoryInfo, setCategories] = useState([]);
    const [activityInfo, setActivities] = useState([]);
    const [locationsInfo, setLocations] = useState([]);

  

    useEffect( () => {
        
        const getData = async () => {
            if (!loadingActivities && activities) {
                setActivities(activities);
            }
        }
        getData();
    }, [activities, loadingActivities])

    useEffect( () => {
        const getData = async () => {
            if (!loadingCategories && categories) {
                setCategories(categories);
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
            name: !data.name ? null : data.name,
            categoryId: !data.category ? null : data.category,
            activityId: !data.activity ? null : data.activity,
            locationId: !data.location ? null : data.location,
            subLocationId: null,
            startTime: !data.fromDate ? null : data.fromDate,
            endTime: !data.toDate? null : data.toDate,
            availableSpots: !data.availableSpots? null : data.minAvailableSpots,
            location: !data.location ? null : data.location,
            nearLat: null,
            nearLong: null
        });

    }



    return(
        <>
        <h4>Filtrera din sökning:</h4>
            <form className = "detailed-search-form" onSubmit={handleSubmit}>
                <input type= "text" name="name" placeholder="Fritext..."/>
               <label htmlFor="fromDate">Från:</label> <input type= "date" name="fromDate"/>
               <label htmlFor="toDate">Till:</label> <input type= "date" name="toDate"/>
               <label htmlFor="activity">Aktivitet:</label> <select id ="activity" name="activity">
                <option value="">Alla</option>
                    {activityInfo.map((activity, index) => (
                        <option key={index} value={activity.id}>{activity.name}</option>
                    ))}
                </select>
                <label htmlFor="category">Kategori:</label> <select id ="category" name="category">
                    <option value="">Alla</option>
                    {categoryInfo.map((category, index) => (
                        <option key={index} value={category.id}>{category.name}</option>
                    ))}
                </select>
                <label htmlFor="location">Plats:</label><select id ="location" name="location">
                    <option value="">Alla</option>
                    {locationsInfo.map((location, index) => (
                        <option key={index} value={location.id}>{location.name}</option>
                    ))}
                </select>
                <label htmlFor="availableToBook">Minst antal lediga platser:</label> <input type="checkbox" id="availableToBook" name="availableToBook"/>

                <button type="submit">Sök</button>
            </form>
        </>
    )
}

export default DetailedSearch;