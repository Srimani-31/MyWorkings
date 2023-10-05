// import React from 'react';
// import { Container, Row, Col, Form, Button } from 'react-bootstrap';

// const SignIn = () => {
//   return (
//     <div className="bg-light" style={{ minHeight: '100vh' }}>
//       <Container>
//         <Row className="justify-content-center align-items-center" style={{ minHeight: '100vh' }}>
//           <Col md={6}>
//             <Form>
//               <Form.Group controlId="formEmail">
//                 <Form.Control type="email" placeholder="Email" />
//               </Form.Group>

//               <Form.Group controlId="formPassword">
//                 <Form.Control type="password" placeholder="Password" />
//               </Form.Group>

//               <Button variant="primary" type="submit" block>
//                 Sign In
//               </Button>

//               <div className="text-center mt-3">
//                 <a href="#">Forgot Password</a>
//               </div>

//               <div className="text-center mt-3">
//                 <a href="#">New User? Sign Up</a>
//               </div>
//             </Form>
//           </Col>
//         </Row>
//       </Container>
//     </div>
//   );
// };

// export default SignIn;

import React from 'react';
import { Container, Row, Col, Form, Button } from 'react-bootstrap';

const SignIn = () => {
  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container className="d-flex justify-content-center align-items-center" style={{ minHeight: '100vh' }}>
        <div className="p-5 border rounded-lg bg-white shadow-sm">
          <h2 className="text-center mb-4">SportsZone</h2>
          <Form>
            <Form.Group controlId="formEmail" className="mb-3">
              <Form.Control type="email" placeholder="Email" />
            </Form.Group>

            <Form.Group controlId="formPassword" className="mb-3">
              <Form.Control type="password" placeholder="Password" />
            </Form.Group>

            <Button variant="primary" type="submit" block>
              Sign In
            </Button>

            <div className="text-center mt-3">
              <a href="#">Forgot Password</a>
            </div>

            <div className="text-center mt-3">
              <a href="#">New User? Sign Up</a>
            </div>
          </Form>
        </div>
      </Container>
    </div>
  );
};

export default SignIn;
