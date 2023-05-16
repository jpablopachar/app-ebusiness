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
// import { styled } from '@mui/system'

const Navbar = () => {
  return (
    <AppBar position="static" sx={{ pt: '8px', pb: '8px' }}>
      <Container>
        <Toolbar>
          <div>
            <IconButton color="inherit">
              <Icon fontSize="large"></Icon>
            </IconButton>
          </div>
          <Drawer open={true}>
            <List style={{ width: '250px' }}>
              <ListItem button sx={{ p: 0 }}>
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
          <div style={{ flexGrow: '1' }}>
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
          <div>
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
