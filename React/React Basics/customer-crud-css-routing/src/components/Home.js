import React from 'react';
import { Link } from 'react-router-dom';
import Header from './Header';
import Footer from './Footer';
const Home = () => {
  return (
    <div>
      {/* Header
      <Header /> */}

      {/* Customer List */}
      <div className="container mt-4">
        <h1>Welcome to the Home Page</h1>
        {/* Your customer listing can go here */}
      </div>

      {/* Footer */}
      {/* <Footer /> */}
    </div>
  );
};

export default Home;
