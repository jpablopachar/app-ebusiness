import {
  AppBar,
  Button,
  Container,
  Drawer,
  Icon,
  IconButton,
  Link,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Toolbar,
  Typography,
} from '@mui/material'
import { useState } from 'react'
import './Navbar.css'

const Navbar = () => {
  const [open, setOpen] = useState(false)

  const openToggle = () => {
    setOpen(true)
  }

  const closeToggle = () => {
    setOpen(false)
  }

  return (
    <AppBar position="static" sx={{ pt: '8px', pb: '8px' }}>
      <Container>
        <Toolbar>
          <div className="mobile">
            <IconButton color="inherit" onClick={openToggle}>
              <Icon fontSize="large">menu</Icon>
            </IconButton>
          </div>
          <Drawer open={open} onClose={closeToggle}>
            <List style={{ width: '250px' }}>
              <ListItem button onClick={closeToggle} sx={{ p: 0 }}>
                <Link
                  color="inherit"
                  underline="none"
                  sx={{
                    display: 'inline-flex',
                    alignItems: 'center',
                    w: '100%',
                    p: '8px 16px',
                  }}
                >
                  <ListItemIcon sx={{ minWidth: '35px' }}>
                    <Icon>person</Icon>
                  </ListItemIcon>
                  <ListItemText>Iniciar Sesión</ListItemText>
                </Link>
              </ListItem>
            </List>
          </Drawer>
          <div className="grow">
            <Link
              color="inherit"
              underline="none"
              sx={{ display: 'inline-flex', alignItems: 'center' }}
            >
              <Icon fontSize="large" sx={{ mr: '3px' }}>
                store
              </Icon>
              <Typography variant="h5" component="span">
                ONLINE STORE
              </Typography>
            </Link>
          </div>
          <div className="desktop">
            <Button color="inherit" sx={{ fontSize: '14px', p: 0 }}>
              <Link
                color="inherit"
                underline="none"
                sx={{
                  display: 'inline-flex',
                  alignItems: 'center',
                  p: '6px 16px',
                }}
              >
                <Icon sx={{ mr: '3px' }}>person</Icon>
                Iniciar Sesión
              </Link>
            </Button>
          </div>
        </Toolbar>
      </Container>
    </AppBar>
  )
}

export default Navbar
