import { Link } from "react-router-dom";
import SearchBar from "./Searchbar"; // importera den vi gjorde tidigare
import NavLogin from "./NavLogin";
import './Layout.css'

export default function Navbar() {
  return (
    <nav

    >
      <div className="menu-items">
        <Link to="/">Home</Link>
        <Link to="/booking">Booking</Link>
        <Link to="/my-bookings">Mina Bokningar</Link>
        <Link to="/about">About</Link>
        <Link to="/search">Search</Link>
      </div>
    </nav>
  );
}
