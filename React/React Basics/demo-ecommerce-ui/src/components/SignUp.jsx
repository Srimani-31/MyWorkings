import React, { useState } from 'react';
import { Container, Form, Button } from 'react-bootstrap';
import { useNavigate, Link } from 'react-router-dom';
import axios from 'axios';
import './SignUp.css'

const SignUp = ({ onSignUp }) => {
  const [email, setEmail] = useState('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [contactNumber, setContactNumber] = useState('');
  const [address, setAddress] = useState('');
  const [city, setCity] = useState('');
  const [country, setCountry] = useState('');
  const [zipcode, setZipcode] = useState('');
  const [profilePhoto, setProfilePhoto] = useState(null);
  const navigate = useNavigate();

  const handleFileChange = (e) => {
    setProfilePhoto(e.target.files[0]);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const formData = new FormData();
    formData.append('email', email);
    formData.append('firstName', firstName);
    formData.append('lastName', lastName);
    formData.append('contactNumber', contactNumber);
    formData.append('address', address);
    formData.append('city', city);
    formData.append('country', country);
    formData.append('zipcode', zipcode);
    formData.append('profilePhoto', profilePhoto);
    formData.append('createdUpdatedBy',email);

    try {
      const response = await axios.post(
        'https://localhost:44382/api/Customer/CreateCustomer',
        formData,
        {
          headers: {
            'Content-Type': 'multipart/form-data', // Set the content type to multipart/form-data
          },
        }
      );
      // const response = await axios.post('https://localhost:44382/api/Customer/CreateCustomer', {
      //   email,
      //   firstName,
      //   lastName,
      //   contactNumber,
      //   address,
      //   city,
      //   country,
      //   zipcode,
      //   profilePhoto,
      //   createdUpdatedBy: email
      // });

      if (response.status === 200) {
        // Handle the successful response here if needed.
        console.log(response)
        navigate('/signin');
      } else {
        // Handle authentication error (e.g., show an error message)
        console.error(response)
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container className="d-flex justify-content-center align-items-center" style={{ minHeight: '100vh' }}>
        <div className="p-5 border rounded-lg bg-white shadow-sm">
          <h2 className="text-center mb-4">SportsZone</h2>
          <Form onSubmit={handleSubmit}>
            <Form.Group controlId="formEmail" className="mb-4">
              <Form.Control
                type="email"
                placeholder="Email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                required
              />
            </Form.Group>

            <Form.Group controlId="formFirstName" className="mb-4">
              <Form.Control
                type="text"
                placeholder="First Name"
                value={firstName}
                onChange={(e) => setFirstName(e.target.value)}
                required
              />
            </Form.Group>

            <Form.Group controlId="formLastName" className="mb-4">
              <Form.Control
                type="text"
                placeholder="Last Name"
                value={lastName}
                onChange={(e) => setLastName(e.target.value)}
                required
              />
            </Form.Group>

            <Form.Group controlId="formContactNumber" className="mb-4">
              <Form.Control
                type="tel"
                placeholder="Contact Number"
                value={contactNumber}
                onChange={(e) => setContactNumber(e.target.value)}
              />
            </Form.Group>

            <Form.Group controlId="formAddress" className="mb-4">
              <Form.Control
                type="text"
                placeholder="Address"
                value={address}
                onChange={(e) => setAddress(e.target.value)}
              />
            </Form.Group>

            <Form.Group controlId="formCity" className="mb-4">
              <Form.Control
                type="text"
                placeholder="City"
                value={city}
                onChange={(e) => setCity(e.target.value)}
              />
            </Form.Group>
            <Form.Group controlId="formCountry" className="mb-4">
              <Form.Control
                type="text"
                placeholder="Country"
                value={country}
                onChange={(e) => setCountry(e.target.value)}
              />
            </Form.Group>

            <Form.Group controlId="formZipcode" className="mb-4">
              <Form.Control
                type="text"
                placeholder="Zipcode"
                value={zipcode}
                onChange={(e) => setZipcode(e.target.value)}
              />
            </Form.Group>

            <Form.Group controlId="formProfilePhoto" className="mb-4">
              <Form.Control
                type="file"
                placeholder="Profile Photo"
                onChange={handleFileChange}
              />
            </Form.Group>

            <Button variant="secondary" type="reset" className="custom-button">
              Reset
            </Button>
            <Button variant="primary" type="submit" className="mr-2 custom-button">
              Submit
            </Button>

            <div className="text-center mt-3">
              <Link to="/signin">
                Already have an account? Sign In
              </Link>
            </div>
          </Form>
        </div>
      </Container>
    </div>
  );
};

export default SignUp;
