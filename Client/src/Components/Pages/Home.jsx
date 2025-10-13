import CategoryList from "../Display/CategoryList";
import ActivityList from "../Display/ActivityList";

export default function Home() {
  return (
    <div className="p-4">
      <h1 className="text-2xl font-bold mb-4">Kategorier</h1>
      <CategoryList />

      <h1 className="text-2xl font-bold mt-8 mb-4">Aktiviteter</h1>
      <ActivityList />
    </div>
  );
}
