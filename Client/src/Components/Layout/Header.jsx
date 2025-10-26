// Header.jsx
import { Link } from "react-router-dom";
import SearchBar from "./Searchbar"; // importera SearchBar-komponenten
import Navbar from "./Navbar";
import NavLogin from "./NavLogin";
import './Header.css';
import LoginDropBox from "./LoginDropBox";
import { useState, useRef, useEffect } from "react";


export default function Header() {
  const [isMenuOpen, setIsMenuOpen] = useState(false);
  const menuRef = useRef(null);

  const toggleMenu = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  const closeMenu = () => {
    setIsMenuOpen(false);
  };

  useEffect(() => {
    const handleClose = (e) => {
      if (e.key === 'Escape' && isMenuOpen) {
        closeMenu();
      } else if (e.type === 'click' && isMenuOpen && menuRef.current && !menuRef.current.contains(e.target)) {
        closeMenu();
      }
    };

    if (isMenuOpen) {
      document.addEventListener('keydown', handleClose);
      // Använd setTimeout för att vänta tills efter att toggle-klicket är klart
      setTimeout(() => {
        document.addEventListener('click', handleClose);
      }, 0);
    }

    return () => {
      document.removeEventListener('keydown', handleClose);
      document.removeEventListener('click', handleClose);
    };
  }, [isMenuOpen]);
  return (
    <header className="header-container">
      <div className="header-nav">
        
        {/* Hamburger-knapp (visas bara på mobil) */}
        <button 
          className={`hamburger-menu ${isMenuOpen ? 'open' : ''}`}
          onClick={toggleMenu}
          aria-label="Toggle menu"
        >
          <span></span>
          <span></span>
          <span></span>
        </button>

        {/* Navbar med klass för att kunna styla responsivt */}
        <div ref={menuRef} className={`navbar-wrapper ${isMenuOpen ? 'mobile-open' : ''}`}>
          <Navbar closeMenu={closeMenu} />
        </div>

        <div className="top-right">
          <SearchBar isCompact={true} />
          <NavLogin />
        </div>
      </div>
      
      <div className="header-title-container">
        <Link to="/">
          <h1 className="header-title">ActiviGo</h1>
        </Link>
      </div>

      {/* Overlay när menyn är öppen */}
      {isMenuOpen && (
        <div className="menu-overlay" onClick={closeMenu}></div>
      )}
    </header>
  );
}
