

const API_URL = import.meta.env.VITE_API_URL;


const getAuthHeaders = () => {
  const token = localStorage.getItem('authToken');
  return token
    ? { 'Authorization': `Bearer ${token}` }
    : {};
};



export const getActivities = async () => {
  const res = await fetch(`${API_URL}/Activity`, {
    headers: {
      ...getAuthHeaders(),
    },
  });
  if (!res.ok) throw new Error("Kunde inte hämta aktiviteter");
  return res.json();
};

export const getActivityById = async (id) => {
  const res = await fetch(`${API_URL}/Activity/${id}`, {
    headers: {
      ...getAuthHeaders(),
    },
  });
  if (!res.ok) throw new Error("Kunde inte hämta aktiviteten");
  return res.json();
};
