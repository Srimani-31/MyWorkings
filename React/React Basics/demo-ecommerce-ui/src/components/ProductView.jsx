import React, { useState, useEffect } from 'react';
import { Container, Row, Col, Card, Form, Button } from 'react-bootstrap';
import axios from 'axios';
import { transformImagePath } from './TransformUrl';
// import { useParams } from 'react-router-dom';

const ProductView = () => {
//   const { id } = useParams(); // Get the 'id' parameter from the URL
  const [product, setProduct] = useState({
    ProductID: '',
    ProductName: '',
    ProductImage: '',
    StockCount: 0,
    Price: 0,
    CategoryID: '',
  });
  const [quantity, setQuantity] = useState(1);
  const id = 1;

  useEffect(() => {
    // Fetch product data by ID from the API
    axios.get(`https://localhost:44382/api/Product/GetProductByproductID/${id}`)
      .then((response) => {
        const data = response.data;
        data.ProductImage = transformImagePath(data.ProductImage)
        setProduct(data);
      })
      .catch((error) => {
        console.error('Error fetching product data:', error);
      });
  }, [id]); // Fetch data when the 'id' parameter changes

  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container>
        <Row className="justify-content-center">
          <Col md={8}>
            <Card className="mt-4">
              <Card.Img variant="top" src={product.ProductImage} alt={product.ProductName} />
              <Card.Body>
                <Card.Title>{product.ProductName}</Card.Title>
                <Card.Text>
                  <strong>Product ID:</strong> {product.ProductID}<br />
                  <strong>Stock Count:</strong> {product.StockCount}<br />
                  <strong>Price:</strong> ${product.Price}<br />
                  <strong>Category ID:</strong> {product.CategoryID}
                </Card.Text>

                <Form>
                  <Form.Group controlId="quantity">
                    <Form.Label>Quantity:</Form.Label>
                    <Form.Control
                      type="number"
                      value={quantity}
                      onChange={(e) => setQuantity(e.target.value)}
                      min="1"
                      max="10"
                    />
                  </Form.Group>
                </Form>

                <div className="d-flex justify-content-evenly mt-3">
                  <Button variant="primary">Buy Now</Button>
                  <Button variant="secondary">Add to Cart</Button>
                </div>
              </Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default ProductView;
