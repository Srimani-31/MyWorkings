import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Image, Navbar, Nav, NavDropdown, Container } from 'react-bootstrap';
import axios from 'axios';
import { transformImagePath } from './TransformUrl';
const Navigation = ({ token, onSignOut, customerId }) => {
  const navigate = useNavigate();
  const [userProfilePhoto, setUserProfilePhoto] = useState(null);

  const handleSignOut = () => {
    // Clear the token from local storage
    onSignOut();
    navigate('/signin'); // Redirect to the sign-in page or another appropriate destination

  };

  useEffect(() => {
    // Check if the user is authenticated based on the token.
    const isLoggedIn = !!token;

    if (isLoggedIn) {
      // Fetch the user's profile information, including the profile photo URL.
      fetchUserProfilephoto(); // Fetch user profile data

      // Fetch the user's profile photo URL
      //fetchUserProfilePhoto(); // New function to fetch user profile photo
    }
  }, [token]);

  // Function to fetch the user's profile data.
  const fetchUserProfilephoto = async () => {
    try {
      // Make an API request to retrieve the user's profile data, which should include the profile photo URL.
      const response = await axios.get(`https://localhost:44382/api/Customer/GetCustomerByCustomerID/${customerId}`); // Replace with your API endpoint
      if (response.status === 200) {
        const data = response.data;
        // Assume data contains profilePhotoURL
        const userPhotoURL = transformImagePath(data.ProfilePhoto);; // Replace with the actual property from your API response.
        setUserProfilePhoto(userPhotoURL);
      } else {
        console.error('Error fetching user profile data.');
      }
    } catch (error) {
      console.error('Error fetching user profile data:', error);
    }
  };

  return (
    <Navbar bg="dark" expand="lg" variant="dark" fixed="top">
      <Container>
        <Navbar.Brand as={Link} to="/">
          <Image src="/logo2.png" alt="SportsZone" rounded style={{ width: '70px', height: '70px' }} />
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="navbarNav" />
        <Navbar.Collapse id="navbarNav">
          <Nav className="ms-auto">
            <Nav.Link as={Link} to="/about">
              About
            </Nav.Link>
            <Nav.Link as={Link} to="/contact">
              Contact Us
            </Nav.Link>
            {token ? ( // Check if token exists
              <NavDropdown title={<Image src={userProfilePhoto} roundedCircle style={{ width: '30px', height: '30px' }} />} id="basic-nav-dropdown" alignRight>
                <NavDropdown.Item as={Link} to="/profile">
                  View Profile
                </NavDropdown.Item>
                <NavDropdown.Item onClick={handleSignOut}>Logout</NavDropdown.Item>
              </NavDropdown>
            ) : (
              <>
                <Nav.Link as={Link} to="/signup">
                  Sign Up
                </Nav.Link>
                <Nav.Link as={Link} to="/signin">
                  Sign In
                </Nav.Link>
              </>
            )}
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default Navigation;

