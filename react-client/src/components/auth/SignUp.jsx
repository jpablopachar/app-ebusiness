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

const MyForm = styled('form')`
  margin-top: 40px;
  margin-bottom: 40px;
  text-align: center;
`

export const SignUp = () => {
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
            <MyForm>
              <Grid container spacing={2}>
                <Grid item xs={12} md={6} sx={{ mb: '20px' }}>
                  <TextField
                    type="text"
                    label="Nombres"
                    variant="outlined"
                    fullWidth
                  />
                </Grid>
                <Grid item xs={12} md={6} sx={{ mb: '20px' }}>
                  <TextField
                    type="text"
                    label="Apellidos"
                    variant="outlined"
                    fullWidth
                  />
                </Grid>
                <Grid item xs={12} md={12} sx={{ mb: '20px' }}>
                  <TextField
                    type="email"
                    label="Correo"
                    variant="outlined"
                    fullWidth
                  />
                </Grid>
                <Grid item xs={12} md={12} sx={{ mb: '20px' }}>
                  <TextField
                    type="password"
                    label="Contraseña"
                    variant="outlined"
                    fullWidth
                  />
                </Grid>
                <Grid item xs={12} sx={{ mb: '20px' }}>
                  <Button variant="contained" color="primary" fullWidth>
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
