import React from 'react';
import { Container, Row, Col } from 'react-bootstrap';

const ContactUs = () => {
  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container>
        <h2 className="my-4">Contact Us</h2>
        <Row>
          <Col md={6}>
            <h4>Email</h4>
            <p>sportszone@gmail.com</p>

            <h4>Phone</h4>
            <p>+1 (123) 456-7890</p>
          </Col>
          <Col md={6}>
            {/* You can add a contact form or map here if needed */}
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default ContactUs;
