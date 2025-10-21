import { useNavigate } from "react-router-dom";
import { useActivities } from "../../contexts/ActivityContext";
import "./CategoryCard.css";

export default function CategoryCard({ category }) {
  const { setActivitiesInCategory, activities } = useActivities()

  const handleMove = () => {
    const connectedActivities = activities.filter((activity) => activity.categoryId === category.id)
    setActivitiesInCategory(connectedActivities);

    window.location.replace("/activities/test");
  }

  return (
    <div className="category-card" onClick={handleMove}>
      <div className="category-card-content">
        <h3 className="category-card-title">{category.name}</h3>
        {category.description && (
          <p className="category-card-description">{category.description}</p>
        )}
      </div>
    </div>
  );
}
