import React from 'react';
import { Container, Form, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';

const SignIn = () => {
  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container className="d-flex justify-content-center align-items-center" style={{ minHeight: '100vh' }}>
        <div className="p-5 border rounded-lg bg-white shadow-sm">
          <h2 className="text-center mb-4">SportsZone</h2>
          <Form className="text-center"> {/* Apply text-center class to center the form contents */}
            <Form.Group controlId="formEmail" className="mb-3">
              <Form.Control type="email" placeholder="Email" />
            </Form.Group>

            <Form.Group controlId="formPassword" className="mb-3">
              <Form.Control type="password" placeholder="Password" />
            </Form.Group>

            <Button variant="primary" type="submit" className="mx-auto"> {/* Apply mx-auto class to center the button */}
              Sign In
            </Button>

            <div className="text-center mt-3">
              <a href="#">Forgot Password</a>
            </div>

            <div className="text-center mt-3">
              <Link to="/signup">
                New User? Sign Up
              </Link>
            </div>
          </Form>
        </div>
      </Container>
    </div>
  );
};

export default SignIn;
