import { ThemeProvider } from '@mui/material/styles'
import { Route, BrowserRouter as Router, Routes } from 'react-router-dom'
import { Login } from './components/Auth/Login'
import { SignUp } from './components/Auth/SignUp'
import { Navbar } from './components/Navbar/Navbar'
import { theme } from './theme/theme'

function App() {
  return (
    <ThemeProvider theme={theme}>
      <Router>
        <Navbar />
        <Routes>
          <Route exact path="/iniciarSesion" element={<Login />} />
          <Route exact path="/registro" element={<SignUp />} />
        </Routes>
      </Router>
    </ThemeProvider>
  )
}

export default App
