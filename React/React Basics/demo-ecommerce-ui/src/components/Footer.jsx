import React from 'react';
import { Container, Row, Col } from 'react-bootstrap';

const Footer = () => {
  return (
    <footer className="bg-dark text-light">
      <Container>
        <Row>
          <Col>
            <p>&copy; {new Date().getFullYear()} SportsZone</p>
          </Col>
          <Col>
            <p>Contact: sportszone@gmail.com</p>
          </Col>
        </Row>
      </Container>
    </footer>
  );
};

export default Footer;
