import { Outlet } from "react-router-dom";
import Navbar from "./Navbar";
import Footer from "./Footer";
import Header from "./Header";
import "./Layout.css"
export default function Layout() {

  // What are these class names? /Gustav
  return (
    <div className="flex flex-col min-h-screen"> 
      <Header />
      <main className="flex-1">
        <Outlet />
      </main>
      <Footer />
    </div>
  );
}
