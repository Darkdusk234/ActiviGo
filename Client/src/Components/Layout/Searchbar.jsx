// SearchBar.jsx
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./Searchbar.css";

export default function SearchBar() {
  const [query, setQuery] = useState("");
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();
    if (query.trim() !== "") {
      navigate(`/general-search?query=${encodeURIComponent(query)}`);
    }
  };

  return (
    <form
      className="searchform"
      onSubmit={handleSubmit}
    >
      <input
        type="text"
        value={query}
        onChange={(e) => setQuery(e.target.value)}
        placeholder="Sök..."

      />
      <button
        type="submit"
      >
        Sök
      </button>
    </form>
  );
}
