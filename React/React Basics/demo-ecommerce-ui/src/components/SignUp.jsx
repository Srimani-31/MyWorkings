import React from 'react';
import { Container, Row, Col, Form, Button } from 'react-bootstrap';
//adding custom css
import './SignUp.css'

const SignUp = () => {
  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container className="d-flex justify-content-center align-items-center" style={{ minHeight: '100vh' }}>
        <div className="p-5 border rounded-lg bg-white shadow-sm">
          <h2 className="text-center mb-4">SportsZone</h2>
          <Form>
            <Form.Group controlId="formEmail" className="mb-4">
              <Form.Control type="email" placeholder="Email" />
            </Form.Group>

            <Form.Group controlId="formFirstName" className="mb-4">
              <Form.Control type="text" placeholder="First Name" />
            </Form.Group>

            <Form.Group controlId="formLastName" className="mb-4">
              <Form.Control type="text" placeholder="Last Name" />
            </Form.Group>

            <Form.Group controlId="formContactNumber" className="mb-4">
              <Form.Control type="tel" placeholder="Contact Number" />
            </Form.Group>

            <Form.Group controlId="formAddress" className="mb-4">
              <Form.Control type="text" placeholder="Address" />
            </Form.Group>

            <Form.Group controlId="formCity" className="mb-4">
              <Form.Control type="text" placeholder="City" />
            </Form.Group>

            <Form.Group controlId="formCountry" className="mb-4">
              <Form.Control type="text" placeholder="Country" />
            </Form.Group>

            <Form.Group controlId="formZipcode" className="mb-4">
              <Form.Control type="text" placeholder="Zipcode" />
            </Form.Group>

            <Form.Group controlId="formProfilePhoto" className="mb-4">
              <Form.Control type="file" placeholder="Profile Photo" />
            </Form.Group>

            <Button variant="primary" type="submit" className="mr-2 custom-button">
              Submit
            </Button>

            <Button variant="secondary" type="reset" className="custom-button">
              Reset
            </Button>

            <div className="text-center mt-3">
              <a href="#">New User? Sign In</a>
            </div>
          </Form>
        </div>
      </Container>
    </div>
  );
};

export default SignUp;
