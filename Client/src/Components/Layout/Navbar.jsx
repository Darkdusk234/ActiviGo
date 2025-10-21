import { Link } from "react-router-dom";
import "./Header.css";

export default function Navbar() {
  return (
    <nav className="nav-menu">
      <div className="menu-items">
        <Link to="/">Home</Link>
        <Link to="/categories">Categories</Link>
        <Link to="/my-bookings">Mina Bokningar</Link>
        <Link to="/about">About</Link>
        <Link to="/search">Search</Link>
      </div>
    </nav>
  );
}
