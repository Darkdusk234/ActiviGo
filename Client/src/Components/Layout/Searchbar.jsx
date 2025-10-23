// SearchBar.jsx
import { useState, useRef } from "react";
import { useNavigate } from "react-router-dom";
import "./Searchbar.css";

export default function SearchBar({ isCompact = false }) {
  const [query, setQuery] = useState("");
  const [isExpanded, setIsExpanded] = useState(false);
  const navigate = useNavigate();
  const inputRef = useRef(null);


  const handleSubmit = (e) => {
    e.preventDefault();
    if (query.trim() !== "") {

      navigate('/search', { state: {searchQuery: query, source: 'general'} });
      if (isCompact) {
        setIsExpanded(false); // Collapse after search in compact mode
        setQuery(""); // Clear input
      }
    }
  };


  // const handleSubmit = (e) => {
  //   e.preventDefault();
  //   if (query.trim() !== "") {
  //     navigate(`/general-search?query=${encodeURIComponent(query)}`);
  //     if (isCompact) {
  //       setIsExpanded(false); // Collapse after search in compact mode
  //       setQuery(""); // Clear input
  //     }
  //   }
  // };
  const handleIconClick = () => {
    if (isCompact) {
      setIsExpanded(true);
      setTimeout(() => inputRef.current?.focus(), 0); // Focus input after expansion
    }
  };

  const handleBlur = () => {
    if (isCompact && query.trim() === "") {
      setIsExpanded(false); // Collapse if input is empty and loses focus
    }
  };

  return (
    <form
      className={`searchform ${isCompact ? "compact" : "full"} ${isExpanded ? "expanded" : ""}`}
      onSubmit={handleSubmit}
    >
      <div className="input-wrapper">
        <input
          ref={inputRef}
          type="text"
          value={query}
          onChange={(e) => setQuery(e.target.value)}
          onBlur={handleBlur}
          placeholder="Sök..."
          className="searchbar-input"
        />
        {isCompact && !isExpanded && (
          <span className="search-icon" onClick={handleIconClick}>
            {/* Inline SVG for search icon */}
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="2rem"
              height="2rem"
              fontSize="1rem"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              strokeWidth="5"
              strokeLinecap="round"
              strokeLinejoin="round"
            >
              <circle cx="11" cy="11" r="8" />
              <line x1="21" y1="21" x2="16.65" y2="16.65" />
            </svg>
          </span>
        )}
      </div>
      {!isCompact && (
        <button type="submit" className="searchbar-button" id="search-btn">
          Sök
        </button>
      )}
    </form>
  );
}
