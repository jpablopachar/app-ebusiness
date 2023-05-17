import {
  Button,
  CardMedia,
  Container,
  Grid,
  MenuItem,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableRow,
  TextField,
  Typography
} from '@mui/material'
import React from 'react'
import { useNavigate } from 'react-router-dom'

const ProductDetail = () => {
  const navigate = useNavigate()

  const addToCart = () => {
    navigate('/carrito')
  }

  return (
    <Container className="container-mt">
      <Typography variant="h4" className="container-mt">
        ABRIGO VAXI
      </Typography>
      <Grid container spacing={4}>
        <Grid item lg={8} md={8} xs={12}>
          <Paper className="paper-img" variant="outlined" square>
            <CardMedia
              className="media-detalle"
              image="https://images.pexels.com/photos/54206/pexels-photo-54206.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
              title="Mi producto"
            />
          </Paper>
        </Grid>
        <Grid item lg={4} md={4} xs={12}>
          <TableContainer component={Paper} variant="outlined">
            <Table>
              <TableBody>
                <TableRow>
                  <TableCell>
                    <Typography variant="subtitle2">Precio</Typography>
                  </TableCell>
                  <TableCell>
                    <Typography variant="subtitle2">$25.99</Typography>
                  </TableCell>
                </TableRow>
                <TableRow>
                  <TableCell>
                    <Typography variant="subtitle2">Cantidad</Typography>
                  </TableCell>
                  <TableCell>
                    <TextField size="small" select variant="outlined">
                      <MenuItem key={1} selected={true}>1</MenuItem>
                      <MenuItem key={2}>2</MenuItem>
                      <MenuItem key={3}>3</MenuItem>
                    </TextField>
                  </TableCell>
                </TableRow>
                <TableRow>
                  <TableCell colSpan={2}>
                    <Button
                      variant="contained"
                      color="primary"
                      size="large"
                      onClick={addToCart}
                    >
                      Agregar a Carrito
                    </Button>
                  </TableCell>
                </TableRow>
              </TableBody>
            </Table>
          </TableContainer>
        </Grid>
        <Grid item lg={8} md={8} xs={12}>
          <Grid container spacing={2}>
            <Grid item md={6}>
              <Typography className="text-detalle">Precio: $25.99</Typography>
              <Typography className="text-detalle">
                Unidades Disponibles: 15
              </Typography>
              <Typography className="text-detalle">Marca: Vaxi</Typography>
              <Typography className="text-detalle">
                Temporada: Invierno
              </Typography>
            </Grid>
            <Grid item md={6}>
              <Typography className="text-detalle">Descripcion:</Typography>
              <Typography className="text-detalle">
                Abrigo vaxi talla M, de algodon puro, de color Negro con botones
                y cierre, ideal para el invierno, con bolsillos al exterior e
                interior suave al tacto con la piel
              </Typography>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </Container>
  )
}

export default ProductDetail
