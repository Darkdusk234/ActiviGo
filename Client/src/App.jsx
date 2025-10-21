import { useState } from 'react'
import './App.css'
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./Components/Layout/Layout";
import Home from "./Components/Pages/Home";
import LoginForm from './Components/LoginForm'
import SearchResults from './Components/Pages/SearchResults';
import GeneralSearch from './Components/Pages/GeneralSearch';
import AdminPage from './Components/Pages/Admin/AdminPage';
import AdminDashboard from './Components/Pages/Admin/AdminDashboard';
import UserManagement from './Components/Pages/Admin/UserManagement';
import ActivityManagement from './Components/Pages/Admin/ActivityManagement';
import LocationManagement from './Components/Pages/Admin/LocationManagement';
import SubLocationManagement from './Components/Pages/Admin/SubLocationManagement';
import CategoryManagement from './Components/Pages/Admin/CategoryManagement';
import OccurenceManagement from './Components/Pages/Admin/OccurenceManagement';
import BookingManagement from './Components/Pages/Admin/BookingManagement';
import CategoryListPage from './Components/Pages/CategoryListPage';


function App() {


  return (
    <BrowserRouter className="app-content">
      <Routes>
        <Route element={<Layout />}>
          <Route path="/search" element={<SearchResults />} />
          <Route path="/general-search" element={<GeneralSearch />} />
          <Route path="/" element={<Home />} />   
          <Route path="/categories" element={<CategoryListPage />}/>
        </Route>
        <Route element ={<AdminPage />}>
          <Route path="/admin" element={<AdminDashboard />} />
          <Route path="/admin/users" element={<UserManagement />} />
          <Route path="/admin/activities" element={<ActivityManagement />} />
          <Route path="/admin/locations" element={<LocationManagement />} />
          <Route path="/admin/sublocations" element={<SubLocationManagement />} />
          <Route path="/admin/categories" element={<CategoryManagement />} />
          <Route path="/admin/occurrences/:filter/:id" element={<OccurenceManagement />} />

          <Route path="/admin/bookings" element={<BookingManagement />} />
        </Route>
      </Routes>
    </BrowserRouter>


  )
}

export default App
