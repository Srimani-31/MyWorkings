// Home.js
import React from 'react';
import { Link } from 'react-router-dom'

const Navigation = () => {
  return (
    <nav className="navbar navbar-expand-lg navbar-light bg-light">
      <Link to="/" className="navbar-brand">
        Home
      </Link>
      <button
        className="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#navbarNav"
        aria-controls="navbarNav"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span className="navbar-toggler-icon"></span>
      </button>
      <div className="collapse navbar-collapse" id="navbarNav">
        <ul className="navbar-nav">
          <li className="nav-item">
            <Link to="/about" className="nav-link">
              About
            </Link>
          </li>
          <li className="nav-item">
            <Link to="/contact" className="nav-link">
              Contact Us
            </Link>
          </li>         
          <li className="nav-item">
            <Link to="/signup" className="nav-link">
              Sign Up
            </Link>
          </li>
          <li className="nav-item">
            <Link to="/signin" className="nav-link">
              Sign In
            </Link>
          </li>
        </ul>
      </div>
    </nav>
  );
};

export default Navigation;
