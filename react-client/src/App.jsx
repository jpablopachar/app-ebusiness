import { ThemeProvider } from '@mui/material/styles'
import SignUp from './components/Auth/SignUp'
import Navbar from './components/Navbar/Navbar'
import { theme } from './theme/theme'

function App() {
  return (
    <ThemeProvider theme={theme}>
      <Navbar/>
      <SignUp/>
    </ThemeProvider>
  )
}

export default App
