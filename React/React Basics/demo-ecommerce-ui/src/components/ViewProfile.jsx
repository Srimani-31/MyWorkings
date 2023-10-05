import React, { useState, useEffect, useRef } from 'react';
import { Container, Row, Col, Form, Button, Image } from 'react-bootstrap';
import axios from 'axios';
import { transformImagePath } from './TransformUrl';

const ViewProfile = () => {
  const customerId = "srimani@gmail.com";
  const [customer, setCustomer] = useState({
    Email: '',
    FirstName: '',
    LastName: '',
    ContactNumber: '',
    Address: '',
    City: '',
    Country: '',
    ZipCode: '',
    ProfilePhoto: '', // Path to the profile photo
  });
  const [editMode, setEditMode] = useState(false); // Editing mode flag
  const [newProfilePhoto, setNewProfilePhoto] = useState(null); // For updating profile photo
  const fileInputRef = useRef();

  useEffect(() => {
    // Fetch customer details by customer ID
    axios.get(`https://localhost:44382/api/Customer/GetCustomerByCustomerID/${customerId}`)
      .then((response) => {
        const data = response.data;
        data.ProfilePhoto = transformImagePath(data.ProfilePhoto); // Transform the profile photo URL
        setCustomer(data);
      })
      .catch((error) => {
        console.error('Error fetching customer details:', error);
      });
  }, [customerId]);

  const handleUpdate = () => {
    // Prepare the updated customer object
    const updatedCustomer = {
      ...customer,
      ProfilePhoto: newProfilePhoto || customer.ProfilePhoto, // Use the new photo if provided
    };

    // Send a PUT request to update the customer details
    axios.put('https://localhost:44382/api/Customer/UpdateCustomer', updatedCustomer)
      .then(() => {
        setEditMode(false); // Exit editing mode
      })
      .catch((error) => {
        console.error('Error updating customer details:', error);
      });
  };

  const handleFileInputButtonClick = () => {
    fileInputRef.current.click();
  };

  const handleFileInputChange = (event) => {
    const file = event.target.files[0];
    setNewProfilePhoto(null); // Clear the previous image
    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        setNewProfilePhoto(e.target.result);
      };
      reader.readAsDataURL(file);
    }
  };

  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container>
        <h2 className="my-4">My Profile</h2>
        <Row>
          <Col md={4}>
            <div className="text-center" style={{ maxHeight: '100px' }}>
              {/* Profile Photo */}
              {editMode ? (
                <Image
                  src={newProfilePhoto || customer.ProfilePhoto || '/assets/CustomerImages/default.png'}
                  alt="Profile"
                  roundedCircle
                  fluid
                  style={{ height: '350px', width: '80%', borderColor: 'GrayText', borderStyle: 'solid' }}

                />
              ) : (
                <Image
                  src={customer.ProfilePhoto || '/assets/CustomerImages/default.png'}
                  alt="Profile"
                  roundedCircle
                  fluid
                  style={{ height: '350px', width: '80%', borderColor: 'GrayText', borderStyle: 'solid' }}
                />
              )}
              {editMode && (
                <div>
                  <br></br>
                  <Button
                    variant="primary"
                    onClick={handleFileInputButtonClick}
                  >
                    Edit
                  </Button>
                  <input
                    type="file"
                    ref={fileInputRef}
                    style={{ display: 'none' }}
                    onChange={handleFileInputChange}
                    accept="image/*"
                  />
                  &nbsp;
                  <Button
                    variant="danger"
                    onClick={() => {
                      // Set the profile photo to the default image
                      setCustomer({ ...customer, ProfilePhoto: '/assets/CustomerImages/default.png' });
                    }}
                  >
                    Delete
                  </Button>
                </div>
              )}
            </div>
          </Col>
          <Col md={8}>
            <Form>
              <Form.Group>
                <Form.Label>Email</Form.Label>
                <Form.Control type="text" value={customer.Email} readOnly />
              </Form.Group>
              <br></br>
              <Form.Group>
                <Form.Label>First Name</Form.Label>
                <Form.Control
                  type="text"
                  value={customer.FirstName}
                  readOnly={!editMode}
                  onChange={(e) => setCustomer({ ...customer, FirstName: e.target.value })}
                />
                <br></br>
              </Form.Group>
              <Form.Group>
                <Form.Label>Last Name</Form.Label>
                <Form.Control
                  type="text"
                  value={customer.LastName}
                  readOnly={!editMode}
                  onChange={(e) => setCustomer({ ...customer, LastName: e.target.value })}
                />
                <br></br>
              </Form.Group>
              <Form.Group>
                <Form.Label>Contact Number</Form.Label>
                <Form.Control
                  type="text"
                  value={customer.ContactNumber}
                  readOnly={!editMode}
                  onChange={(e) => setCustomer({ ...customer, ContactNumber: e.target.value })}
                />
              </Form.Group>
              <br></br>
              <Form.Group>
                <Form.Label>Address</Form.Label>
                <Form.Control
                  type="text"
                  value={customer.Address}
                  readOnly={!editMode}
                  onChange={(e) => setCustomer({ ...customer, Address: e.target.value })}
                />
              </Form.Group>
              <br></br>
              <Form.Group>
                <Form.Label>City</Form.Label>
                <Form.Control
                  type="text"
                  value={customer.City}
                  readOnly={!editMode}
                  onChange={(e) => setCustomer({ ...customer, City: e.target.value })}
                />
                </Form.Group>
                <br></br>
                <Form.Group>
                <Form.Label>Country</Form.Label>
                <Form.Control
                  type="text"
                  value={customer.Country}
                  readOnly={!editMode}
                  onChange={(e) => setCustomer({ ...customer, Country: e.target.value })}
                />
                </Form.Group>
                <br></br>
                <Form.Group>
                <Form.Label>ZipCode</Form.Label>
                <Form.Control
                  type="text"
                  value={customer.ZipCode}
                  readOnly={!editMode}
                  onChange={(e) => setCustomer({ ...customer, ZipCode: e.target.value })}
                />
                </Form.Group>
                <br></br>
              {editMode && (
                <Button variant="primary" onClick={handleUpdate}>
                  Update
                </Button>
              )}
            </Form>
            {editMode || (
              <div className="mt-3">
                <Button
                  variant="primary"
                  onClick={() => setEditMode(true)}
                  className="me-2"
                >
                  Edit
                </Button>
              </div>
            )}
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default ViewProfile;
