// Header.jsx
import { Link } from "react-router-dom";
import SearchBar from "./Searchbar"; // importera SearchBar-komponenten
import Navbar from "./Navbar";
import NavLogin from "./NavLogin";
import './Layout.css';

export default function Header() {
  return (
    <header>
      
      <div className="header-content">
        <Navbar/>
        <Link to="/"> <h1 className="header-title">ActiviGo!</h1> </Link>
      
      <div className="searchbar-container">
        <SearchBar/>
      </div>
      <NavLogin/>
      </div>
    </header>
  );
}
