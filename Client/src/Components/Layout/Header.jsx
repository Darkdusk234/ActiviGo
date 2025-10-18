// Header.jsx
import { Link } from "react-router-dom";
import SearchBar from "./Searchbar"; // importera SearchBar-komponenten
import Navbar from "./Navbar";
import NavLogin from "./NavLogin";
import './Layout.css';

export default function Header({ onSearch }) {
  return (
    <header>
      <Navbar/>
      <div className="header-title-container">
        <Link to="/"> <h1 className="header-title">ActiviGo!</h1> </Link>
      </div>
      <div className="searchbar-container">
        <SearchBar onSearch={onSearch} />
      </div>
      <div className="NavLogin-container">
        <NavLogin />
      </div>
    </header>
  );
}
