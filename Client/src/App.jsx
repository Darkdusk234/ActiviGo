import { useState } from 'react'
import './App.css'
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./Components/Layout/Layout";
import Home from "./Components/Pages/Home";
import LoginForm from './Components/LoginForm'
import SearchResults from './Components/Pages/SearchResults';
import MyBookings from './Components/Display/MyBookings';


function App() {


  return (
    <BrowserRouter className="app-content">
      <Routes>
        <Route element={<Layout />}>
          <Route path="/search" element={<SearchResults />} />
          <Route path="/" element={<Home />} />
          <Route path="/my-bookings" element={<MyBookings />} />
        </Route>
      </Routes>
    </BrowserRouter>


  )
}

export default App
