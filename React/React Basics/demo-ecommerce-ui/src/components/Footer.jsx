import React from 'react';
import { Container } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
  faFacebook,
  faTwitter,
  faGoogle,
  faInstagram,
  faLinkedin,
  faGithub,
} from '@fortawesome/free-brands-svg-icons';

const Footer = () => {
  return (
    <footer className="text-center text-dark" style={{ backgroundColor: '#343a40' }}>
      <Container className="pt-4">
        {/* Section: Social media */}
        <section className="mb-4">
          <a
            href="#!"
            className="btn btn-link btn-floating btn-lg text-light m-1"
            role="button"
            data-mdb-ripple-color="dark"
          >
            <FontAwesomeIcon icon={faFacebook} />
          </a>

          <a
            href="#!"
            className="btn btn-link btn-floating btn-lg text-light m-1"
            role
            ="button"
            data-mdb-ripple-color="dark"
          >
            <FontAwesomeIcon icon={faTwitter} />
          </a>
          <a
            href="#!"
            className="btn btn-link btn-floating btn-lg text-light m-1"
            role="button"
            data-mdb-ripple-color="dark"
          >
            <FontAwesomeIcon icon={faInstagram} />
          </a>

          <a
            href="#!"
            className="btn btn-link btn-floating btn-lg text-light m-1"
            role="button"
            data-mdb-ripple-color="dark"
          >
            <FontAwesomeIcon icon={faLinkedin} />
          </a>
        </section>
        {/* Section: Social media */}
      </Container>
      <div style={{ backgroundColor: 'rgba(0, 0, 0, 0.5)' }} className="text-light p-3">
        © {new Date().getFullYear()} Copyright:
        <a className="text-light" href="#">SportsZone.com</a>
      </div>
    </footer>
  );
};

export default Footer;

