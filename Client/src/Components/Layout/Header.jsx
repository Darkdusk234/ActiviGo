// Header.jsx
import { Link } from "react-router-dom";
import SearchBar from "./Searchbar"; // importera SearchBar-komponenten
import Navbar from "./Navbar";

export default function Header({ onSearch }) {
  return (
    <header style={{ padding: "1rem", background: "#f5f5f5" }}>
      <Navbar/>

      <div style={{ display: "flex", justifyContent: "center" }}>
        <div style={{ maxWidth: "400px", width: "100%" }}>
          <SearchBar onSearch={onSearch} />
        </div>
      </div>
    </header>
  );
}
