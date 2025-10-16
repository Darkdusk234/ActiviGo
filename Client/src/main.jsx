import { Activity, StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.jsx'
import { AuthProvider } from './contexts/AuthContext.jsx'
import { ActivityProvider } from './contexts/ActivityContext.jsx'
import { CategoryProvider } from './contexts/CategoryContext.jsx'
import { LocationProvider } from './contexts/LocationContext.jsx'

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <AuthProvider>
      <CategoryProvider>
        <LocationProvider>
          <ActivityProvider>
            <App />
          </ActivityProvider>
        </LocationProvider>
      </CategoryProvider>
    </AuthProvider>
  </StrictMode>,
)
