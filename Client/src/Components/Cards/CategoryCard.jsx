import { useNavigate } from "react-router-dom";
import { useActivities } from "../../contexts/ActivityContext";
import "./CategoryCard.css";

export default function CategoryCard({ category }) {
  const imageUrl = `https://picsum.photos/400/250?random=${category.id}`;
  const { setActivitiesInCategory, activities } = useActivities()
  const navigate = useNavigate();

  const handleMove = () => {
    const connectedActivities = activities.filter((activity) => activity.categoryId === category.id)
    setActivitiesInCategory(connectedActivities);

    navigate(`/activities/${category.name}`)
  }

  return (
    <div className="category-card" 
    onClick={handleMove}
    style={{backgroundImage:`url(https://picsum.photos/400/250?random=${category.id})`}}
    >
      <div className="category-card-content">
        <h3 className="category-card-title">{category.name}</h3>
        {category.description && (
          <p className="category-card-description">{category.description}</p>
        )}
      </div>
    </div>
  );
}
