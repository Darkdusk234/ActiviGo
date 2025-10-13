const API_URL = "http://localhost:5210/api";

export const getActivities = async () => {
  const res = await fetch(`${API_URL}/Activity`);
  if (!res.ok) throw new Error("Kunde inte hämta aktiviteter");
  return res.json();
};

export const getActivityById = async (id) => {
  const res = await fetch(`${API_URL}/Activity/${id}`);
  if (!res.ok) throw new Error("Kunde inte hämta aktiviteten");
  return res.json();
};
