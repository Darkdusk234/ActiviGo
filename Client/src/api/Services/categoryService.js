
const API_URL = "http://localhost:7201/api";

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
