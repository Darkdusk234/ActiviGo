import React from "react";
import { HashRouter, Routes, Route, Outlet } from "react-router-dom";
import AdminNavBar from "./AdminNavBar";
import AdminDashboard from "./AdminDashboard";

export default function AdminPage() {
  return (
    <>
        <AdminNavBar />
        <Outlet />
    </>
  );
}
