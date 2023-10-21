import React, { useState } from 'react';
import { Route, Routes } from 'react-router-dom';

import Home from './Home';
import AboutUs from './AboutUs';
import ContactUs from './ContactUs';
import ViewProfile from './ViewProfile';
import SignIn from './SignIn';
import SignUp from './SignUp';
import Navigation from './Navigation';

const Router = () => {
    const [token, setToken] = useState(localStorage.getItem('token'));
    const [customerId, setCustomerId] = useState(localStorage.getItem('customerId'));


    const handleSignIn = (newToken,customerId) => {
        // Store the new token
        localStorage.setItem('token', newToken);
        localStorage.setItem('customerId',customerId)
        // Update the state
        setToken(newToken);
        setCustomerId(customerId);
    };
    const handleSignOut = () => {
        // Clear the token from local storage
        localStorage.removeItem('token');
        localStorage.removeItem('customerId');
        // Update the state
        setToken(null);
        setCustomerId(null)
    };


    return (
        <div>
            <Navigation token={token} onSignOut={handleSignOut} customerId={customerId} /> {/* Pass the token as a prop to Navigation */}
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/about" element={<AboutUs />} />
                <Route path="/contact" element={<ContactUs />} />
                <Route path="/profile" element={<ViewProfile customerId={customerId}/>} />
                <Route path="/signin" element={<SignIn onSignIn={handleSignIn} />} />
                <Route path="/signup" element={<SignUp />} />
            </Routes>
        </div>
    );
};

export default Router;

