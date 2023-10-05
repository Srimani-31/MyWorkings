import React, { useState, useEffect } from 'react';
import { Container, Row, Col, Card, Form, Button } from 'react-bootstrap';
// import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const ChoosePaymentMethod = () => {
  const [selectedPaymentMethod, setSelectedPaymentMethod] = useState('');
  const [paymentMethods, setPaymentMethods] = useState([]);
//   const navigate = useNavigate();

  useEffect(() => {
    // Fetch payment methods from the API
    axios.get('https://localhost:44382/api/Payment/GetAllPaymentMethods')
      .then((response) => {
        const data = response.data;
        setPaymentMethods(data);
      })
      .catch((error) => {
        console.error('Error fetching payment methods:', error);
      });
  }, []);

  const handleProceedClick = () => {
    if (selectedPaymentMethod) {
      // Navigate to the payment order summary page
      //navigate('/order-summary', { state: { paymentMethod: selectedPaymentMethod } });
    } else {
      // Show an alert or error message if no payment method is selected
      alert('Please select a payment method.');
    }
  };

  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container>
        <Row>
          <Col md={6}>
            <h2>Select Payment Method</h2>
            {paymentMethods.map((method) => (
              <Card key={method.PaymentID} className="mb-2">
                <Card.Body>
                  <Form.Check
                    type="radio"
                    name="paymentMethod"
                    label={method.PaymentType}
                    checked={selectedPaymentMethod === method.PaymentType}
                    onChange={() => setSelectedPaymentMethod(method.PaymentType)}
                  />
                </Card.Body>
              </Card>
            ))}
          </Col>
        </Row>
        <Row className="mt-3">
          <Col md={6}>
            <Button variant="primary" onClick={handleProceedClick}>
              Proceed
            </Button>
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default ChoosePaymentMethod;
