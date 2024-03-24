import { useState } from 'react';
import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Landing from './Landing';
import Workspace from './Workspace';
import AboutUs from './AboutUs';
import Navbar from './Navbar';
import SignIn from './SignIn';
import SignUp from './SignUp';

const Router = () => {
  const [token, setToken] = useState(localStorage.getItem('token'));
  const [username, setUsername] = useState(localStorage.getItem('username'));
  const serviceToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5"

  const handleSignIn = (username) => {
    // Store the new token
    localStorage.setItem('token', serviceToken);
    localStorage.setItem('username', username)
    // Update the state
    setUsername(username);
  };
  const handleSignOut = () => {
    // Clear the token from local storage
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    // Update the state
    setToken(null);
    setUsername(null)
  };
  return (
    <div>
      <Navbar token={token} onSignOut={handleSignOut} x />
      <Routes>
        <Route path="/workspace" element={<Workspace />} />
        <Route path="/about" element={<AboutUs />} />
        <Route path="/" element={<Landing />} />
        <Route path="/signin" element={<SignIn onSignIn={handleSignIn} />} />
        <Route path="/signup" element={<SignUp />} />
      </Routes>
    </div>
  );
};

export default Router;
