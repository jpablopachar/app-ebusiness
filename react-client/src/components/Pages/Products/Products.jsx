import {
  Avatar,
  Button,
  Card,
  CardContent,
  CardMedia,
  Container,
  Grid,
  Typography,
} from '@mui/material'
import { useNavigate } from 'react-router-dom'
import { Products as ProductsList } from '../../../data/products'

const Products = () => {
  const navigate = useNavigate()

  const viewProduct = (id) => {
    navigate(`/detalleProducto/${id}`)
  }

  return (
    <Container className="container-mt">
      <Typography variant="h4" className="text-title">
        Productos
      </Typography>
      <Grid container spacing={4}>
        {ProductsList.map((product) => (
          <Grid item lg={3} md={4} sm={6} xs={12} key={product.key}>
            <Card>
              <CardMedia
                className="media"
                image="https://images.pexels.com/photos/54206/pexels-photo-54206.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                title="mi producto"
              >
                <Avatar variant="square" className="price">
                  ${product.price}
                </Avatar>
              </CardMedia>
              <CardContent>
                <Typography variant="h6" className="text-card">
                  {product.title}
                </Typography>
                <Button
                  variant="contained"
                  color="primary"
                  fullWidth
                  onClick={() => viewProduct(product.key)}
                >
                  MAS DETALLES
                </Button>
              </CardContent>
            </Card>
          </Grid>
        ))}
      </Grid>
    </Container>
  )
}

export default Products
