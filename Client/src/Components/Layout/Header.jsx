// Header.jsx
import { Link } from "react-router-dom";
import SearchBar from "./Searchbar"; // importera SearchBar-komponenten
import Navbar from "./Navbar";
import NavLogin from "./NavLogin";
import './Layout.css';

export default function Header() {
  return (
    <header>
      <Navbar/>
      <div className="searchbar-container">
        <SearchBar/>
      </div>
    </header>
  );
}
