import React, { useState, useEffect } from 'react';
import { Container, Row, Col, Card } from 'react-bootstrap';
import axios from 'axios';

// Function to transform a local file path into a URL path
function transformImagePath(localPath) {
  // Replace backslashes with forward slashes
  const forwardSlashesPath = localPath.replace(/\\/g, '/');
  // Find the 'public' directory and remove everything before it
  const startIndex = forwardSlashesPath.indexOf('/assets/');
  if (startIndex !== -1) {
    const relativePath = forwardSlashesPath.substring(startIndex);
    return relativePath;
  }
  // If 'public' directory is not found, return the original path
  return forwardSlashesPath;
}

const Home = () => {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    // Fetch product data from the API
    axios.get('https://localhost:44382/api/Product/GetAllProducts')
      .then((response) => {
        // Modify the image URLs in the response data
        const modifiedData = response.data.map((product) => ({
          ...product,
          ProductImage: transformImagePath(product.ProductImage)
        }));
        setProducts(modifiedData);
      })
      .catch((error) => {
        console.error('Error fetching product data:', error);
      });
  }, []); // Empty dependency array to run the effect only once

  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container>
        <Row className="justify-content-center">
          {products.map((product) => (
            <Col key={product.ProductID} md={4} sm={6} xs={12}>
              <Card
                className="mb-4 clickable-card"
                onClick={() => {
                  // Navigate to the ProductView component with product details
                  // navigate(`/product/${product.ProductID}`);
                }}
              >
                {/* Maintain aspect ratio while fitting within a fixed height */}
                <Card.Img
                  variant="top"
                  src={product.ProductImage}
                  alt={product.ProductName}
                  style={{ width: 'auto', height: '300px' }} // Adjust the height as needed
                />
                <Card.Body>
                  <Card.Title>{product.ProductName}</Card.Title>
                  <Card.Text>Price: ${product.Price}</Card.Text>
                </Card.Body>
              </Card>
            </Col>
          ))}
        </Row>
      </Container>
    </div>
  );
};

export default Home;
