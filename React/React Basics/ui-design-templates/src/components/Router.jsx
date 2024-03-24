import React from 'react';
import { Route, Routes } from 'react-router-dom'; // Import Routes
import LoginForm from './LoginForm';
import RegistrationForm from './RegistrationForm';
import UserList from './UserList';
import CreateUser from './CreateUser';
import EditUser from './EditUser';
import DeleteUser from './DeleteUser';
// import Home from './Home';
// import List from './List';
// import CreateCustomer from './CreateCustomer';
// import AboutUs from './AboutUs';
// import ContactUs from './ContactUs';
// import EditCustomer from './EditCustomer';

const Router = () => (
  <Routes>
    <Route path="/login" element={<LoginForm />} />
    <Route path="/register" element={<RegistrationForm />} />
    <Route path="/userlist" element={<UserList />} />
    <Route path="/createuser" element={<CreateUser />} />
    <Route 
      path="/edituser/:username"
     element={<EditUser />} />
    <Route path="/deleteuser/:username" element={<DeleteUser />} />

    {/* <Route path="/" element={<Home />} />

    {/* <Route path="/" element={<Home />} />
    <Route path="/list" element={<List customers={customers} onDelete={onDelete} />} />
    <Route path="/create" element={<CreateCustomer  customers={customers} onCreate={onCreate}/>} />
    <Route path="/about" element={<AboutUs />} />
    <Route path="/contact" element={<ContactUs />} />
    <Route
      path="/edit/:email"
      element={<EditCustomer customers={customers} onUpdate={onUpdate} />}
    /> */}
  </Routes>
);

export default Router;
