import React, { useState } from 'react';
import { Container, Form, Button } from 'react-bootstrap';
import { useNavigate, Link } from 'react-router-dom';
import axios from 'axios'; 

const SignIn = ({ onSignIn }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleSignIn = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('https://localhost:44382/api/Auth/Login', {
        email,
        password,
      }, {
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (response.status === 200) {
        // Extract the token from the response data
        const token = response.data;
        // Redirect to the Home component
        setEmail(email);
        onSignIn(token, email);
        navigate('/');
      } else {
        // Handle authentication error (e.g., show an error message)
      }
    } catch (error) {
      console.error('Authentication error:', error);
    }
  };

  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container className="d-flex justify-content-center align-items-center" style={{ minHeight: '100vh' }}>
        <div className="p-5 border rounded-lg bg-white shadow-sm">
          <h2 className="text-center mb-4">SportsZone</h2>
          <Form className="text-center" onSubmit={handleSignIn}>
            <Form.Group controlId="formEmail" className="mb-3">
              <Form.Control
                type="email"
                placeholder="Email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
            </Form.Group>

            <Form.Group controlId="formPassword" className="mb-3">
              <Form.Control
                type="password"
                placeholder="Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </Form.Group>

            <Button variant="primary" type="submit" className="mx-auto">
              Sign In
            </Button>
          </Form>

          <div className="text-center mt-3">
            <a href="#">Forgot Password</a>
          </div>

          <div className="text-center mt-3">
            <Link to="/signup">
              New User? Sign Up
            </Link>
          </div>
        </div>
      </Container>
    </div>);
};

export default SignIn;