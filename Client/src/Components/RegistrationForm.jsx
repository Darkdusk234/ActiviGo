import React, { useState } from 'react'
import "./Pages/RegistrationFormPage.css"
import { useAuth } from '../contexts/AuthContext';

const RegistrationForm = () => {
    const [userName, setUserName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [birthDate, setBirthDate] = useState("");
    const [address, setAddress] = useState("");
    const { register } = useAuth();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try
        {
            const result = await register({ UserName: userName, Email: email, Password: password, FirstName: firstName, LastName: lastName, DateOfBirth: birthDate, Adress: address})
            if(result)
            {
                console.log(result);
                // maybe log person in or redirect back to home page?
            }
        }
        catch (error)
        {
            console.error('Registration failed:', error);
        }
    }

    var today = new Date();
    var day = today.getDate();
    var month = today.getMonth() + 1;
    var yyyy = today.getFullYear() - 18;
    
    if (day < 10) {
        day = '0' + day;
    }

    if (month < 10) {
        month = '0' + month;
    } 
    
    today = yyyy + '-' + month + '-' + day;

  return (
    <div className='form-container'>
    <form onSubmit={handleSubmit} className='registrationForm'>
            <input
                type="text"
                value={userName}
                maxLength="50"
                onChange={(e) => setUserName(e.target.value)}
                placeholder="Username"
                required
            />
            <input
                type="password"
                value={password}
                minLength="6"
                maxLength="100"
                onChange={(e) => setPassword(e.target.value)}
                placeholder="Password"
                required
            />
            <input
                type="email"
                value={email}
                maxLength="100"
                onChange={(e) => setEmail(e.target.value)}
                placeholder="Email"
                required
            />
            <input
                type="text"
                value={firstName}
                minLength="2"
                maxLength="50"
                onChange={(e) => setFirstName(e.target.value)}
                placeholder="First Name"
                required
            />
            <input
                type="text"
                value={lastName}
                minLength="2"
                maxLength="50"
                onChange={(e) => setLastName(e.target.value)}
                placeholder="Last Name"
                required
            />
            <input
                type="date"
                value={birthDate}
                max={today}
                onChange={(e) => setBirthDate(e.target.value)}
                placeholder="Date Of Birth"
                required
            />
            <input:optional
                type="text"
                value={address}
                onChange={(e) => setAddress(e.target.value)}
                placeholder="Address"
            />
            <button type="submit">Register</button>
        </form>
        </div>
  )
}

export default RegistrationForm