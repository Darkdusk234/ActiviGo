// SearchBar.jsx
import { useState } from "react";

export default function SearchBar({ onSearch }) {
  const [query, setQuery] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    if (onSearch) {
      onSearch(query);
    }
  };

  return (
    <form
      onSubmit={handleSubmit}
      style={{
        display: "flex",
        alignItems: "center",
        backgroundColor: "#1a1a1a",
        borderRadius: "8px",
        padding: "4px 8px",
      }}
    >
      <input
        type="text"
        value={query}
        onChange={(e) => setQuery(e.target.value)}
        placeholder="Sök..."
        style={{
          border: "none",
          outline: "none",
          backgroundColor: "transparent",
          color: "#fff",
          padding: "6px 8px",
          fontSize: "0.95rem",
        }}
      />
      <button
        type="submit"
        style={{
          border: "none",
          backgroundColor: "#646cff",
          color: "#fff",
          padding: "6px 12px",
          borderRadius: "6px",
          cursor: "pointer",
          marginLeft: "6px",
          fontWeight: 500,
        }}
      >
        Sök
      </button>
    </form>
  );
}
