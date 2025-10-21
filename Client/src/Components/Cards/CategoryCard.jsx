import { useNavigate } from "react-router-dom";
import { useActivities } from "../../contexts/ActivityContext";
import "./CategoryCard.css";

export default function CategoryCard({ category }) {
  const { setActivitiesInCategory, activities } = useActivities()

  const handleMove = () => {
    const connectedActivities = activities.filter((activity) => activity.CategoryId === category.Id)
    setActivitiesInCategory(connectedActivities);
    
    useNavigate('/activities/test')
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
