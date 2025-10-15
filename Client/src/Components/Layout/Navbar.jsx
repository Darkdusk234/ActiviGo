import { Link } from "react-router-dom";
import SearchBar from "./Searchbar"; // importera den vi gjorde tidigare

export default function Navbar() {
  const handleSearch = (query) => {
    console.log("Söker efter:", query);
    // Här kan du navigera eller filtrera listor baserat på query
  };

  return (
    <nav
      style={{
        padding: "1rem 2rem",
        background: "#eee",
        display: "flex",
        justifyContent: "space-between",
        alignItems: "center",
      }}
    >
      <div style={{ display: "flex", gap: "1rem" }}>
        <Link to="/">Home</Link>
        <Link to="/booking">Booking</Link>
        <Link to="/about">About</Link>
      </div>
    </nav>
  );
}
