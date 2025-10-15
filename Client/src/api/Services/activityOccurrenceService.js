const API_URL = "http://localhost:5210/api";

const getAuthHeaders = () => {
  const token = localStorage.getItem('authToken');
  return token
    ? { 'Authorization': `Bearer ${token}` }
    : {};
};

export const getActivityOccurrence = async () => {
  const res = await fetch(`${API_URL}/ActivityOccurence`, {
    headers: {
      ...getAuthHeaders(),
    },
  });
  if (!res.ok) throw new Error("Kunde inte hämta händelserna");
  return res.json();
};

export const getActivityOccurrenceById = async (id) => {
  const res = await fetch(`${API_URL}/ActivityOccurence/${id}`, {
    headers: {
      ...getAuthHeaders(),
    },
  });
  if (!res.ok) throw new Error("Kunde inte hämta händelserna");
  return res.json();
};
