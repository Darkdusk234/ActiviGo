import { useActivities } from "../../contexts/ActivityContext";
import "./CategoryCard.css";

export default function CategoryCard({ category }) {
  const { setActivitiesInCategory, activities } = useActivities()

  const handleMove = () => {
    
  }

  return (
    <div className="category-card">
      <div className="category-card-content">
        <h3 className="category-card-title">{category.name}</h3>
        {category.description && (
          <p className="category-card-description">{category.description}</p>
        )}
      </div>
    </div>
  );
}
