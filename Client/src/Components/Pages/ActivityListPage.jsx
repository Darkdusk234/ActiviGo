import React from 'react'
import ActivityCard from '../Cards/ActivityCard'

const ActivityListPage = () => {

    
  return (
    <>
    <div className='ActivityListContainer'>
            <ul className='ActivityList'>
                {activitiesInCategory.map((activity, index) => (
                    <li key={index}>
                        <ActivityCardCard activity={activity} />
                    </li>
                ))}
            </ul>
        </div>
    </>
  )
}

export default ActivityListPage