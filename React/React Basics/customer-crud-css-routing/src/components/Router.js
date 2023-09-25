import React from 'react';
import { Route, Routes } from 'react-router-dom'; // Import Routes

import Home from './Home';
import List from './List';
import CreateCustomer from './CreateCustomer';
import AboutUs from './AboutUs';
import ContactUs from './ContactUs';
import EditCustomer from './EditCustomer';

const Router = ({ customers, onDelete, onUpdate,onCreate }) => (
  <Routes>
    <Route path="/" element={<Home />} />
    <Route path="/list" element={<List customers={customers} onDelete={onDelete} />} />
    <Route path="/create" element={<CreateCustomer  customers={customers} onCreate={onCreate}/>} />
    <Route path="/about" element={<AboutUs />} />
    <Route path="/contact" element={<ContactUs />} />
    <Route
      path="/edit/:email"
      element={<EditCustomer customers={customers} onUpdate={onUpdate} />}
    />
  </Routes>
);

export default Router;
