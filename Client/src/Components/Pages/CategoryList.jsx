import React, { useState } from 'react'
import { useCategories } from '../../contexts/CategoryContext'
import CategoryCard from '../Cards/CategoryCard'

const CategoryList = () => {
    const { categories } = useCategories

  return (
    <>
    <div className='CategoryListContainer'>
        <ul className='CategoryList'>
            {categories.map((category, index) => (
                <li key={index}>
                    <CategoryCard category={category} />
                </li>
            ))}
        </ul>
    </div>
    </>
  )
}

export default CategoryList