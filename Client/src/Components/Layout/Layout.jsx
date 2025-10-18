import { Outlet } from "react-router-dom";
import Navbar from "./Navbar";
import Footer from "./Footer";
import Header from "./Header";
import "./Layout.css"
export default function Layout() {

  // What are these class names? /Gustav
  return (
    <div className="main-content"> 
    <div className="header-content">
      <Header />
      </div>
      <main className="flex-1">
        <Outlet />
      </main>
      <Footer />
    </div>
  );
}
