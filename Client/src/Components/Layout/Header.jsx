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
      <div className ="not-nav-navbar">
        <div className="searchbar-container">
          <SearchBar onSearch={onSearch} />
        </div>
       
      </div>
    </header>
  );
}
