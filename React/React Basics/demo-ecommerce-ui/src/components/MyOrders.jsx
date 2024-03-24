import React, { useEffect, useState } from 'react';
import { Card, Button, Container, Row, Col } from 'react-bootstrap';
import axios from 'axios';

const MyOrder = () => {
  const customerId = "cristiano@gmail.com";
  const [orders, setOrders] = useState([]);

  useEffect(() => {
    axios.get(`https://localhost:44382/api/Order/GetAllOrdersByCustomerID/${customerId}`)
      .then(async (response) => {
        const data = response.data;

        // Fetch payment types and shipping addresses for each order
        const ordersWithDetails = await Promise.all(
          data.map(async (order) => {
            const paymentResponse = await axios.get(`https://localhost:44382/api/Payment/GetPaymentMethod/${order.PaymentID}`);
            const shippingResponse = await axios.get(`https://localhost:44382/api/Shipping/GetShippingAddressByShippingID/${order.ShippingID}`);

            const paymentType = paymentResponse.data.PaymentType; // Assuming the API response contains the PaymentType field
            const shippingAddress = shippingResponse.data; // Assuming the API response contains the shipping address details

            return { ...order, PaymentType: paymentType, ShippingAddress: shippingAddress };
          })
        );

        setOrders(ordersWithDetails);
      })
      .catch((error) => {
        console.error('Error fetching orders:', error);
      });
  }, [customerId]);

  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container>
        <h2 className="my-4">My Orders</h2>
        {orders.map((order) => (
          <Card key={order.OrderID} className="my-3">
            <Card.Body>
              <Container>
                <Row>
                  <Col md={8}>
                    <Row>
                      <Col>
                        <Card.Title>Order ID: {order.OrderID}</Card.Title>
                      </Col>
                    </Row>
                    <Row>
                      <Col>
                        <p>Status: {order.Status}</p>
                        <p>Payment Type: {order.PaymentType}</p>
                        <p>Shipping Address: {`${order.ShippingAddress.Address}, ${order.ShippingAddress.City}, ${order.ShippingAddress.Country}, ${order.ShippingAddress.ZipCode}`}</p>
                        <p>Order Date: {new Date(order.OrderDate).toLocaleDateString()}</p>
                      </Col>
                    </Row>
                  </Col>
                  <Col md={4} className="d-flex align-items-center justify-content-end">
                    <Button
                      variant="primary"
                      onClick={() => {
                        // Navigate to the order items view component
                        // You can specify the route for viewing order items here
                      }}
                    >
                      View Details
                    </Button>
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

export default MyOrder;
