

const API_URL = import.meta.env.VITE_API_URL;


const getAuthHeaders = () => {
  const token = localStorage.getItem('authToken');
  return token ? { Authorization: `Bearer ${token}` } : {};
};



export const getCategories = async () => {
  const res = await fetch(`${API_URL}/Category`, {
    headers: {
      ...getAuthHeaders(),
    },
  });
  if (!res.ok) throw new Error("Kunde inte hämta kategorier");
  return res.json();
};


export const getCategoryById = async (id) => {
  const res = await fetch(`${API_URL}/Category/${id}`, {
    headers: {
      ...getAuthHeaders(),
    },
  });
  if (!res.ok) throw new Error("Kunde inte hämta kategorin");
  return res.json();
};
