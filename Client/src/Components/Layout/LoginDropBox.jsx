import React from 'react'
import { useState, useEffect } from 'react'
import LoginForm from '../LoginForm'
import { useAuth } from '../../contexts/AuthContext'
import './Layout.css'

const LoginDropBox = () => {

const { user } = useAuth();

    return(
        <>
            <div className="login-dropbox">
                {user ? (
                <p>LINK TILL MY PAGES</p>
                ) : (<LoginForm />)}
            </div>
        </>
    )
}

export default LoginDropBox;