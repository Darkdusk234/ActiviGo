import { Link } from "react-router-dom";

export default function Navbar() {
  return (
    <nav style={{ padding: "1rem", background: "#eee" }}>
      <Link to="/">Home</Link> | <Link to="/booking">Booking</Link> | <Link to="/about">About</Link>
    </nav>
  );
}
