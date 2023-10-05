import React, { useState, useEffect } from 'react';
import { Container, Row, Col, Form, Button, Card } from 'react-bootstrap';
import axios from 'axios';
import { useParams } from 'react-router-dom';

const ChooseShippingAddress = () => {
  //   const { id } = useParams(); // Get the 'id' parameter from the URL
  const id = 'cristiano@gmail.com'
  const [addresses, setAddresses] = useState([]);
  const [newAddress, setNewAddress] = useState({
    Address: '',
    City: '',
    Country: '',
    ZipCode: '',
    Landmark: '',
    BelongsTo: id, // Set the BelongsTo (CustomerID) to the current user's ID
  });

  useEffect(() => {
    // Fetch shipping addresses by Customer ID from the API
    axios.get(`https://localhost:44382/api/Shipping/GetAllShippingAddressesByCustomerID/${id}`)
      .then((response) => {
        const data = response.data;
        setAddresses(data);
      })
      .catch((error) => {
        console.error('Error fetching shipping addresses:', error);
      });
  }, [id]); // Fetch data when the 'id' parameter changes

  const handleNewAddressSubmit = (e) => {
    e.preventDefault();

    // Post the new shipping address to the API
    axios.post('https://localhost:44382/api/Shipping/AddNewShippingAddress', newAddress)
      .then(() => {
        // Refresh the list of addresses after adding a new one
        axios.get(`https://localhost:44382/api/Shipping/GetAllShippingAddressesByCustomerID/${id}`)
          .then((response) => {
            const data = response.data;
            setAddresses(data);
          })
          .catch((error) => {
            console.error('Error fetching shipping addresses:', error);
          });

        // Clear the form fields
        setNewAddress({
          Address: '',
          City: '',
          Country: '',
          ZipCode: '',
          Landmark: '',
          BelongsTo: id,
        });
      })
      .catch((error) => {
        console.error('Error adding new shipping address:', error);
      });
  };
  const handleProceedToPayment = (e) =>{
    e.preventDefault();
    
  }

  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container>
        <Row>
          <Col md={12}>
            <h2>Your Shipping Addresses</h2>
            <Form onSubmit={handleNewAddressSubmit}>
              {addresses.map((address) => (
                <Card key={address.ShippingID} className="mb-2">
                  <Card.Body>
                    <Form.Check
                      type="radio"
                      name="shippingAddress"
                      label={`${address.Address}, ${address.City}, ${address.Country}, ${address.ZipCode}`}
                    />
                  </Card.Body>
                </Card>
              ))}
              <br></br>
              <Button variant="primary" type="submit" onClick={handleProceedToPayment}>
                Proceed
              </Button>
            </Form>
          </Col>
          <Col md={12}>
            <h2>Add New Shipping Address</h2>
            <Form onSubmit={handleNewAddressSubmit}>
              <Form.Group controlId="address">
                <Form.Label>Address</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Enter Address"
                  value={newAddress.Address}
                  onChange={(e) => setNewAddress({ ...newAddress, Address: e.target.value })}
                  required
                />
              </Form.Group>

              <Form.Group controlId="city">
                <Form.Label>City</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Enter City"
                  value={newAddress.City}
                  onChange={(e) => setNewAddress({ ...newAddress, City: e.target.value })}
                  required
                />
              </Form.Group>

              <Form.Group controlId="country">
                <Form.Label>Country</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Enter Country"
                  value={newAddress.Country}
                  onChange={(e) => setNewAddress({ ...newAddress, Country: e.target.value })}
                  required
                />
              </Form.Group>

              <Form.Group controlId="zipCode">
                <Form.Label>Zip Code</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Enter Zip Code"
                  value={newAddress.ZipCode}
                  onChange={(e) => setNewAddress({ ...newAddress, ZipCode: e.target.value })}
                  required
                />
              </Form.Group>

              <Form.Group controlId="landmark">
                <Form.Label>Landmark</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Enter Landmark"
                  value={newAddress.Landmark}
                  onChange={(e) => setNewAddress({ ...newAddress, Landmark: e.target.value })}
                />
              </Form.Group>
              <br></br>
              <Button variant="primary" type="submit">
                Add Address
              </Button>
            </Form>
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default ChooseShippingAddress;
