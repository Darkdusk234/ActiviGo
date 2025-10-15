import { useState } from 'react'
import './App.css'
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./Components/Layout/Layout";
import Home from "./Components/Pages/Home";
import LoginForm from './Components/LoginForm'
import SearchResults from './Components/Pages/SearchResults';


function App() {


  return (
    <BrowserRouter className="app-content">
      <Routes>
        <Route element={<Layout />}>
          <Route path="/search" element={<SearchResults />} />
          <Route path="/" element={<Home />} />
        </Route>
      </Routes>
      <LoginForm />
    </BrowserRouter>


  )
}

export default App
