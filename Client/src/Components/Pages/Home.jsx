import CategoryList from "../Display/CategoryList";
import ActivityList from "../Display/ActivityList";

import SearchResults from "../Pages/SearchResults";

import ActivityOccurrenceList from "../Display/ActivityOccurrenceList";
import SearchBar from "../Layout/Searchbar";


export default function Home() {
  return (
    <div>
     <div className="welcome-message">
        <h1>Välkommen till ActiviGo!</h1>
        <p >
          Upptäck spännande aktiviteter och evenemang i din närhet. Använd vår sökfunktion för att hitta det som passar just dig!
        </p>
        <div className="searchbar-container">
          <SearchBar/>
        </div>
      </div>
      <div className="explore-prompt">
        <p>Utforska vårt utbut. Välj bland kategorier, aktiviteter eller kommande händelser</p>
      </div>
      <div className="carousels">
        <h2>Kategorier</h2>
        <div className="divider"></div>
        <CategoryList />
        <h2 className="text-2xl font-bold mt-8 mb-4">Aktiviteter</h2>
        <div className="divider"></div>
        <ActivityList />
        <h2 className="text-2xl font-bold mt-8 mb-4">Händelser</h2>
        <div className="divider"></div>
        <ActivityOccurrenceList />
      </div>
      <div style={{height:"10vh"}}>
        <p></p>
      </div>
     </div>
  );
}
