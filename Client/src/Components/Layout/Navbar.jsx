import { Link } from "react-router-dom";
import "./Header.css";

export default function Navbar({ closeMenu }) {
  const handleClick = () => {
    if (closeMenu) {
      closeMenu();
    }
  };
  return (
    <nav className="nav-menu">
      <div className="menu-items">
        <Link to="/">Home</Link>
        <Link to="/categories">Categories</Link>
        <Link to="/about">About</Link>
      </div>
    </nav>
  );
}
