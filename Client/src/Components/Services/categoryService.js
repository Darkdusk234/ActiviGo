const API_URL = "http://localhost:5210/api";

export const getCategories = async () => {
  const res = await fetch(`${API_URL}/Category`);
  if (!res.ok) throw new Error("Kunde inte hämta kategorier");
  return res.json();
};

export const getCategoryById = async (id) => {
  const res = await fetch(`${API_URL}/Category/${id}`);
  if (!res.ok) throw new Error("Kunde inte hämta kategorin");
  return res.json();
};
