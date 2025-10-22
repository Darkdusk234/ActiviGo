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
      <main className="middle-content">
          <Outlet />
      </main>
      <div className="footer-content">
        <Footer />
      </div>
    </div>
      
  );
}
