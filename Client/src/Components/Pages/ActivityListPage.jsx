import React from 'react'
import ActivityCard from '../Cards/ActivityCard'
import './ActivityList.css'
import { useActivities } from '../../contexts/ActivityContext'

const ActivityListPage = () => {
    const {activitiesInCategory} = useActivities();
    
  return (
    <>
    <div className='ActivityListContainer'>
            <ul className='ActivityList'>
                {activitiesInCategory.map((activity, index) => (
                    <li key={index}>
                        <ActivityCard activity={activity} />
                    </li>
                ))}
            </ul>
        </div>
    </>
  )
}

export default ActivityListPage