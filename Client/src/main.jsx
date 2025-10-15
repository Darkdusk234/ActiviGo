import { Activity, StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.jsx'
import { AuthProvider } from './contexts/AuthContext.jsx'
import { ActivityProvider } from './contexts/ActivityContext.jsx'
import { CategoryProvider } from './contexts/CategoryContext.jsx'

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <AuthProvider>
      <CategoryProvider>
        <ActivityProvider>
          <App />
        </ActivityProvider>
      </CategoryProvider>
    </AuthProvider>
  </StrictMode>,
)
