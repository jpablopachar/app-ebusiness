import { ThemeProvider } from '@mui/material/styles'
import { Route, BrowserRouter as Router, Routes } from 'react-router-dom'
import './App.css'
import Login from './components/Auth/Login'
import SignUp from './components/Auth/SignUp'
import Navbar from './components/Navbar/Navbar'
import ProductDetail from './components/Pages/Products/ProductDetail'
import Products from './components/Pages/Products/Products'
import { theme } from './theme/theme'

function App() {
  return (
    <ThemeProvider theme={theme}>
      <Router>
        <Navbar />
        <Routes>
          <Route exact path="/iniciarSesion" element={<Login />} />
          <Route exact path="/registro" element={<SignUp />} />
          <Route exact path="/" element={<Products />} />
          <Route exact path="/detalleProducto/:id" element={<ProductDetail />} />
        </Routes>
      </Router>
    </ThemeProvider>
  )
}

export default App
