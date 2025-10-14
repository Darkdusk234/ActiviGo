import { useEffect, useState } from "react";
import { getCategories } from "../../api/Services/categoryService";
import DisplayList from "./DisplayList";
import CategoryCard from "../Cards/CategoryCard";
import { useAuth } from "../../contexts/AuthContext";

export default function CategoryList() {
  const { user } = useAuth();
  const [categories, setCategories] = useState([]);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const load = async () => {
        setLoading(true);
        try {
        const data = await getCategories(); // eller getActivities()
        setCategories(data); // eller setActivities
        setError(null);
        } catch (err) {
        setError(err.message);
        } finally {
        setLoading(false);
        }
    };

    load();
    }, []); // 👈 kör en gång på mount, oberoende av user

  if (loading) return <p className="text-center py-8">Laddar kategorier...</p>;
  if (error) return <p className="text-center text-red-500">{error}</p>;

  return (
    <div style={{ display: "flex", flexDirection: "column", height: "100vh" }}>
      <DisplayList
        items={categories}
        renderItem={(category) => <CategoryCard category={category} />}
      />
    </div>
  );
}
