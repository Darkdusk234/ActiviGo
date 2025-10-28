import React from "react";
import { useState, useEffect } from "react";
import { useActivities } from "../contexts/ActivityContext";
import { useCategories } from "../contexts/CategoryContext";
import { useLocations } from "../contexts/LocationContext";
//import './Layout/Layout.css';
import './DetailedSearch.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faMapMarkerAlt as FaMapMarkerAlt } from '@fortawesome/free-solid-svg-icons';
import { faCalendarAlt as FaCalendarAlt } from '@fortawesome/free-solid-svg-icons';

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
            nameFilter: !data.name ? null : data.name,
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
        <div className="search-form-container">
            <h4 className="form-tag">Filtrera din sökning:</h4>
            <form className = "detailed-search-form" onSubmit={handleSubmit}>
                <div className="searchform">
                    <input className="search-input" type= "text" name="name" placeholder="Sök..."/>
                    <button className="search-button" type="submit">Sök</button>
                </div>
                <div className="filter-section">
                <div className="search-field">
                <div className="select-row">
                <p>Aktivitet</p>
                    <select className="option-filter" id ="activity" name="activity">
                    <option value="">Välj</option>
                        {activityInfo.map((activity, index) => (
                            <option key={index} value={activity.id}>{activity.name}</option>
                        ))}
                    </select>
                </div>
                </div>
                <div className="search-field">
                    <div className="select-row">
                        <p>Kategori</p>
                        <select className="option-filter" id ="category" name="category">
                            <option value="">Kategori</option>
                            {categoryInfo.map((category, index) => (
                                <option key={index} value={category.id}>{category.name}</option>
                            ))}
                        </select>
                    </div>
                </div>
                <div className="search-field">
                    <span className="icon"><FontAwesomeIcon icon={FaMapMarkerAlt} /></span>
                    <div className="select-row">
                        <p>Plats</p>
                            <select className="option-filter" id ="location" name="location">
                                <option value="">Välj</option>
                                {locationsInfo.map((location, index) => (
                                    <option key={index} value={location.id}>{location.name}</option>
                                ))}
                            </select>

                    </div>
                </div>
                </div>
                <div className="datefilter">
                    <div className="date-box">
                    <span className="icon"><FontAwesomeIcon icon={FaCalendarAlt} /></span>
                        <div className="date-input-wrapper">
                            <p>Från</p>
                            <input type= "date" name="fromDate"/>
                        </div>
                    </div>
                    <div className="date-box">
                        <span className="icon"><FontAwesomeIcon icon={FaCalendarAlt} /></span>
                        <div className="date-input-wrapper">
                            <p>Till</p>
                            <input type= "date" name="toDate"/>
                        </div>
                    </div>
                
                
                </div>
                <div className="checkbox-filter">
                   <label className="checkbox-container">
                        <input
                            type="checkbox"
                            className="checkbox-input"
                            id="availableToBook" 
                            name="availableToBook"
                        />
                        <span className="checkbox-custom"></span>
                        Minst antal lediga platser
                </label>
                </div>
            </form>
        </div>
        </>
    )
}

export default DetailedSearch;