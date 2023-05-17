import {
  Avatar,
  Button,
  Card,
  Container,
  Grid,
  Icon,
  Link,
  TextField,
  Typography,
} from '@mui/material'
import { styled } from '@mui/system'
import { useState } from 'react'

const MyForm = styled('form')`
  margin-top: 40px;
  margin-bottom: 40px;
  text-align: center;
`

const clearUser = {
  name: '',
  lastName: '',
  email: '',
  password: '',
}

const SignUp = () => {
  const [user, setUser] = useState({
    name: '',
    lastName: '',
    email: '',
    password: '',
  })

  const handleChange = (event) => {
    const { name, value } = event.target

    setUser((prev) => ({
      ...prev,
      [name]: value,
    }))
  }

  const saveUser = () => {
    setUser(clearUser)
  }

  return (
    <Container sx={{ mt: '30px' }}>
      <Grid container justifyContent="center">
        <Grid item lg={5} md={6}>
          <Card
            sx={{
              display: 'flex',
              flexDirection: 'column',
              alignItems: 'center',
              p: '30px',
            }}
          >
            <Avatar sx={{ bgcolor: '#0F80AA', width: '80px', height: '80px' }}>
              <Icon sx={{ fontSize: '60px' }}>person</Icon>
            </Avatar>
            <Typography variant="h5" color="primary">
              Ingrese su Usuario
            </Typography>
            <MyForm onSubmit={(event) => event.preventDefault()}>
              <Grid container spacing={2}>
                <Grid item xs={12} md={6} sx={{ mb: '20px' }}>
                  <TextField
                    type="text"
                    label="Nombres"
                    variant="outlined"
                    fullWidth
                    name="name"
                    value={user.name}
                    onChange={handleChange}
                  />
                </Grid>
                <Grid item xs={12} md={6} sx={{ mb: '20px' }}>
                  <TextField
                    type="text"
                    label="Apellidos"
                    variant="outlined"
                    fullWidth
                    name="lastName"
                    value={user.lastName}
                    onChange={handleChange}
                  />
                </Grid>
                <Grid item xs={12} md={12} sx={{ mb: '20px' }}>
                  <TextField
                    type="email"
                    label="Correo"
                    variant="outlined"
                    fullWidth
                    name="email"
                    value={user.email}
                    onChange={handleChange}
                  />
                </Grid>
                <Grid item xs={12} md={12} sx={{ mb: '20px' }}>
                  <TextField
                    type="password"
                    label="Contraseña"
                    variant="outlined"
                    fullWidth
                    name="password"
                    value={user.password}
                    onChange={handleChange}
                  />
                </Grid>
                <Grid item xs={12} sx={{ mb: '20px' }}>
                  <Button
                    type="button"
                    variant="contained"
                    color="primary"
                    fullWidth
                    onClick={saveUser}
                  >
                    Crear Cuenta
                  </Button>
                </Grid>
              </Grid>
              <Link href="/" variant="body1" sx={{ mt: '8px' }}>
                ¿Ya tienes cuenta?, Inicia Sesión
              </Link>
            </MyForm>
          </Card>
        </Grid>
      </Grid>
    </Container>
  )
}

export default SignUp
