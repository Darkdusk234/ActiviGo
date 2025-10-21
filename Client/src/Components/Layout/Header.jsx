// Header.jsx
import { Link } from "react-router-dom";
import SearchBar from "./Searchbar"; // importera SearchBar-komponenten
import Navbar from "./Navbar";
import NavLogin from "./NavLogin";
import './Header.css';
import LoginDropBox from "./LoginDropBox";

export default function Header() {
  return (
    <header className="header-container">
      <div className="header-nav">
      <Navbar/>
      <div className="top-right">
      <SearchBar isCompact={true} />
      <NavLogin/>
        </div>
      </div>
      <div className="header-title-container">
        <Link to="/"> <h1 className="header-title">ActiviGo!</h1> </Link>
      </div>
    </header>
  );
}
