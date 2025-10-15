import { useEffect, useState } from "react";
import { getActivityOccurrence } from "../../api/Services/activityOccurrenceService";
import DisplayList from "./DisplayList";
import ActivityOccurrenceCard from "../Cards/ActivityOccurrenceCard";

export default function ActivityOccurrenceList() {
  const [occurrences, setOccurrences] = useState([]);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const load = async () => {
      setLoading(true);
      try {
        const data = await getActivityOccurrence();
        setOccurrences(data);
        setError(null);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    load();
  }, []);

  if (loading) return <p className="text-center py-8">Laddar tillfällen...</p>;
  if (error) return <p className="text-center text-red-500">{error}</p>;

  return (
    <div>
        <DisplayList
            items={occurrences}
            renderItem={(occurrence) => <ActivityOccurrenceCard occurrence={occurrence} />}
          />
        </div>
  );
}
