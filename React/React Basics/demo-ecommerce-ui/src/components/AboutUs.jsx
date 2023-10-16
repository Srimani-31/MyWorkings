import React from 'react';
import { Container, Row, Col } from 'react-bootstrap';

const AboutUs = () => {
  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container>
        <h2 className="my-4">About SportsZone</h2>
        <Row>
          <Col md={8}>
            <p>
              Welcome to SportsZone, your one-stop destination for all things related to sports. We are dedicated to providing you with the best quality sports products, including accessories, equipment, clothing, nutrition, and much more.
            </p>
            <p>
              At SportsZone, we understand the passion and dedication that sports enthusiasts have for their favorite activities. That's why we are committed to offering a wide range of products to cater to your needs.
            </p>
            <p>
              Our mission is to support and empower individuals in their pursuit of an active and healthy lifestyle. We believe that everyone should have access to the tools and gear they need to excel in their chosen sport.
            </p>
          </Col>
          <Col md={4}>
            {/* You can add an image or any other relevant content here */}
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default AboutUs;
