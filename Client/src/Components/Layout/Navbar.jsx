import { Link } from "react-router-dom";
import SearchBar from "./Searchbar"; // importera den vi gjorde tidigare
import NavLogin from "./NavLogin";
import './Layout.css'

export default function Navbar() {
  const handleSearch = (query) => {
    console.log("Söker efter:", query);
    // Här kan du navigera eller filtrera listor baserat på query
  };

  return (
    <nav

    >
      <div className="menu-items">
        <Link to="/">Home</Link>
        <Link to="/booking">Booking</Link>
        <Link to="/about">About</Link>

        <Link to="/search">Search</Link>

        
      </div>
      <div>
        <SearchBar/>
      </div>
      <div>
      <NavLogin />

      </div>
    </nav>
  );
}
