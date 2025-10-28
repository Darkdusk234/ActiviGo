import React from 'react'
import { useState, useEffect } from 'react'
import LoginForm from '../LoginForm'
import { useAuth } from '../../contexts/AuthContext'
import './Login.css'
import UserDropMenu from './UserDropMenu';
const LoginDropBox = ({close}) => {
    const { user } = useAuth();

    return(
            <div className="login-dropbox">
                {user ? (
                <UserDropMenu close={close} />
                ) : (<LoginForm close={close} />)}
            </div>
        
    )
}

export default LoginDropBox;