import {
  Avatar,
  Button,
  Card,
  Container,
  Grid,
  Icon,
  Link,
  TextField,
  Typography
} from '@mui/material'
import styled from '@mui/system'

const MyForm = styled('form')`
  margin-top: 40px;
  margin-bottom: 40px;
`

export const Login = () => {
  return (
    <Container sx={{ mt: '30px' }}>
      <Grid container justifyContent="center">
        <Grid item lg={5} md={6}>
          <Card
            sx={{
              display: 'flex',
              flexDirection: 'column',
              alignItems: 'center',
              p: '30px'
            }}
          >
            <Avatar sx={{ bgcolor: '#3a0ca3', width: '80px', height: '80px' }}>
              <Icon sx={{ fontSize: '60px' }}>person</Icon>
            </Avatar>
            <Typography variant="h5" color="primary">
              Ingrese su Usuario
            </Typography>
            <MyForm>
              <Grid container spacing={2}>
                <Grid item xs={12}>
                  <TextField
                    type="email"
                    label="Correo"
                    variant="outlined"
                    fullWidth
                  />
                </Grid>
                <Grid item xs={12}>
                  <TextField
                    type="password"
                    label="Contraseña"
                    variant="outlined"
                    fullWidth
                  />
                </Grid>
                <Grid item xs={12}>
                  <Button variant="contained" color="primary" fullWidth>
                    Ingresar
                  </Button>
                </Grid>
              </Grid>
              <Link href="/" variant="body1">
                ¿No tienes cuenta?, Regístrate
              </Link>
            </MyForm>
          </Card>
        </Grid>
      </Grid>
    </Container>
  )
}
