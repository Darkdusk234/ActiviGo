import CategoryList from "../Display/CategoryList";
import ActivityList from "../Display/ActivityList";
import ActivityOccurrenceList from "../Display/ActivityOccurrenceList";

export default function Home() {
  return (
    <div className="p-4">
      <h2 className="text-2xl font-bold mb-4">Kategorier</h2>
      <CategoryList />
      <h2 className="text-2xl font-bold mt-8 mb-4">Händelser</h2>
      <ActivityOccurrenceList />
      <h2 className="text-2xl font-bold mt-8 mb-4">Aktiviteter</h2>
      <ActivityList />
    </div>
  );
}
