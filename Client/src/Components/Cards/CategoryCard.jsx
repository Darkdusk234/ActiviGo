import "./CategoryCard.css";

export default function CategoryCard({ category }) {
  const imageUrl = `https://picsum.photos/400/250?random=${category.id}`;
  return (
    <div className="category-card"
    style={{ backgroundImage: imageUrl ? `url(${imageUrl})` : 'none' }}
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
