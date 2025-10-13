import { useEffect, useState } from "react";
import { getCategories } from "../Services/categoryService";
import DisplayList from "./DisplayList";
import CategoryCard from "../Cards/CategoryCard";

export default function CategoryList() {
  const [categories, setCategories] = useState([]);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const load = async () => {
      try {
        const data = await getCategories();
        setCategories(data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };
    load();
  }, []);

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
