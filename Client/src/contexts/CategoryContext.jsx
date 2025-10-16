import React, { createContext, useContext, useState, useEffect } from 'react';
import { getCategories } from '../api/Services/categoryService';

const CategoryContext = createContext();

export function useCategories() {
  return useContext(CategoryContext);
}

export function CategoryProvider({ children }) {
  const [categories, setCategories] = useState([]);
  const [loadingCategories, setLoading] = useState(true);
  const [errorCategories, setError] = useState(null);

  useEffect(() => {
    
    async function getData() {
    await getCategories()
      .then(data => {
        setCategories(data);
        setLoading(false);
      })
      .catch(err => {
        setError(err);
        setLoading(false);
      });
  }
  getData();
  }, []);

  return (
    <CategoryContext.Provider value={{ categories, loadingCategories, errorCategories }}>
      {children}
    </CategoryContext.Provider>
  );
}
