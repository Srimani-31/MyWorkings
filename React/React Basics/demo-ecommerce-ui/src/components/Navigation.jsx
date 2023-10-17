import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Image, Navbar, Nav, NavDropdown, Container } from 'react-bootstrap';

const Navigation = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(true);
  const userAvatar = '/assets/CustomerImages/default.png'; // Update with the correct path to the user's avatar image

  const logout = () => {
    setIsLoggedIn(false);
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
            {isLoggedIn ? (
              <NavDropdown title={<Image src={userAvatar} roundedCircle style={{ width: '30px', height: '30px' }} />} id="basic-nav-dropdown" alignRight>
                <NavDropdown.Item as={Link} to="/profile">
                  View Profile
                </NavDropdown.Item>
                <NavDropdown.Item onClick={logout}>Logout</NavDropdown.Item>
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


// import React from 'react';
// import { Link } from 'react-router-dom';
// import {  Image } from 'react-bootstrap'


// const Navigation = () => {
//   return (
//     <nav className="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
//       <div className="container">
//         <Link to="/" className="navbar-brand">
//           <Image src="/logo2.png" alt="SportsZone"  rounded style={{ width: '70px',height:'70px' }}  />
//         </Link>
//         <button
//           className="navbar-toggler"
//           type="button"
//           data-toggle="collapse"
//           data-target="#navbarNav"
//           aria-controls="navbarNav"
//           aria-expanded="false"
//           aria-label="Toggle navigation"
//         >
//           <span className="navbar-toggler-icon"></span>
//         </button>
//         <div className="collapse navbar-collapse" id="navbarNav">
//           <ul className="navbar-nav ms-auto"> {/* Use ms-auto to move items to the right */}
//             <li className="nav-item">
//               <Link to="/about" className="nav-link">
//                 About
//               </Link>
//             </li>
//             <li className="nav-item">
//               <Link to="/contact" className="nav-link">
//                 Contact Us
//               </Link>
//             </li>
//             <li className="nav-item">
//               <Link to="/signup" className="nav-link">
//                 Sign Up
//               </Link>
//             </li>
//             <li className="nav-item">
//               <Link to="/signin" className="nav-link">
//                 Sign In
//               </Link>
//             </li>
//           </ul>
//         </div>
//       </div>
//     </nav>
//   );
// };

// export default Navigation;
