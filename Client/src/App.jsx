import { useState } from 'react'
import './App.css'
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./Components/Layout/Layout";
import Home from "./Components/Pages/Home";
import LoginForm from './Components/LoginForm'


function App() {


  return (
    <BrowserRouter className="app-content">
      <Routes>
        <Route element={<Layout />}>
          <Route path="/" element={<Home />} />
        </Route>
      </Routes>
      <LoginForm />
    </BrowserRouter>


  )
}

export default App
