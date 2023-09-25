// App.js
import React, { useState } from 'react';
import { BrowserRouter as Router } from 'react-router-dom';
import Header from './components/Header';
import Footer from './components/Footer';
import Routers from './components/Router';
import customersData from './components/Customers'; // Import your customer data

function App() {
  const [customers, setCustomers] = useState(customersData);
  // Define the onCreate function
  const onCreate = (newCustomer) => {
    setCustomers((prevCustomersData) => [...prevCustomersData, newCustomer]);
  }
  // Define the onDelete function
  const onDelete = (emailToDelete) => {
    setCustomers((prevCustomers) => prevCustomers.filter((customer) => customer.email !== emailToDelete));
  };

  // Define the onUpdate function
  const onUpdate = (updatedCustomer) => {
    setCustomers((prevCustomers) =>
      prevCustomers.map((customer) =>
        customer.email === updatedCustomer.email ? updatedCustomer : customer
      )
    );
  };

  return (
    <Router>
      <div>
        <Header />
        <div className="container mt-4">
          <Routers customers={customers} onDelete={onDelete} onUpdate={onUpdate} onCreate={onCreate} />
        </div>
        <Footer />
      </div>
    </Router>
  );
}

export default App;
