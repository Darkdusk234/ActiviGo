import React from 'react'
import { useState, useEffect } from 'react'
import LoginForm from '../LoginForm'
import './Layout.css'

const LoginDropBox = () => {



    return(
        <>
            <div className="login-dropbox">
                <LoginForm />
            </div>
        </>
    )
}

export default LoginDropBox;