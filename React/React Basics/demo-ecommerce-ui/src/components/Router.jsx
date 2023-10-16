import React from 'react';
import { Route, Routes } from 'react-router-dom';

import Home from './Home';
import AboutUs from './AboutUs';
import ContactUs from './ContactUs';
import ViewProfile from './ViewProfile';
import SignIn from './SignIn';
import SignUp from './SignUp';

const Router = (/*{ customers, onDelete, onUpdate, onCreate, customerId }*/) => (
    <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<AboutUs />} />
        <Route path="/contact" element={<ContactUs />} />
        <Route path="/profile" element={<ViewProfile /*customerId={customerId}*/ />} />
        <Route path="/signin" element={<SignIn /*customers={customers} onDelete={onDelete}*/ />} />
        <Route path="/signup" element={<SignUp /*customers={customers} onCreate={onCreate}*/ />} />
    </Routes>
);

export default Router;
