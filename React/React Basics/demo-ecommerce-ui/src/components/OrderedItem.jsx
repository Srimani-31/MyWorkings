import React, { useEffect, useState } from 'react';
import { Card, Container, Row, Col } from 'react-bootstrap';
import axios from 'axios';
import { transformImagePath } from './TransformUrl';

const OrderedItem = () => {
  const orderId = "SPRTZN-20230914163655-dac6-0003";
  const [orderedItems, setOrderedItems] = useState([]);

  // Function to fetch product details by ProductID
  async function fetchProductDetails(productId) {
    try {
      const response = await axios.get(`https://localhost:44382/api/Product/GetProductByproductID/${productId}`);
      response.data.ProductImage = transformImagePath(response.data.ProductImage); // Update the ProductImage here
      return response.data; // Assuming the API returns product details as JSON

    } catch (error) {
      console.error('Error fetching product details:', error);
      return null;
    }
  }

  useEffect(() => {
    // Fetch all ordered items by the order ID from the API
    axios.get(`https://localhost:44382/api/OrderItem/GetAllOrderedItemsByOrderId/${orderId}`)
      .then(async (response) => {
        const data = response.data;

        // Fetch product details for each ordered item
        const itemsWithDetails = [];
        for (const orderedItem of data) {
          const productDetails = await fetchProductDetails(orderedItem.ProductID);
          if (productDetails) {
            itemsWithDetails.push({ ...orderedItem, Product: productDetails });
          }
        }

        setOrderedItems(itemsWithDetails);
      })
      .catch((error) => {
        console.error('Error fetching ordered items:', error);
      });
  }, [orderId]);

  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container>
        <h2 className="my-4">Ordered Items</h2>
        {orderedItems.map((orderedItem) => (
          <Card key={orderedItem.OrderItemID} className="my-3">
            <Card.Body>
              <Container>
                <Row>
                  <Col md={4}>
                    <Card.Img
                      variant="top"
                      src={orderedItem.Product.ProductImage || 'placeholder-image.jpg'}
                      alt={orderedItem.Product.ProductName}
                    />
                  </Col>
                  <Col md={8}>
                    <Row>
                      <Col>
                        <Card.Title>{orderedItem.Product.ProductName}</Card.Title>
                      </Col>
                    </Row>
                    <Row>
                      <Col>
                        <p>Quantity: {orderedItem.Quantity}</p>
                        <p>Total Price: ${orderedItem.TotalPrice}</p>
                      </Col>
                    </Row>
                  </Col>
                </Row>
              </Container>
            </Card.Body>
          </Card>
        ))}
      </Container>
    </div>
  );
};

export default OrderedItem;
