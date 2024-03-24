import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';

const CreateCustomer = ({ onCreate }) => {
  const [customer, setCustomer] = useState({
    email: '',
    name: '',
    gender: '',
    phoneNumber: '',
  });
  const navigate = useNavigate(); // Initialize the navigate function

  const handleChange = (e) => {
    const { name, value } = e.target;
    setCustomer({ ...customer, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Add your logic to create a new customer here
    console.log('Customer created:', customer);
     // add a new customer object into customersData []
     onCreate(customer);

     // Redirect back to the List page using the navigate function
     navigate('/list');
  };

  return (
    <div>
      <h2>Create Customer</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>Email</label>
          <input
            type="email"
            className="form-control"
            name="email"
            value={customer.email}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label>Name</label>
          <input
            type="text"
            className="form-control"
            name="name"
            value={customer.name}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label>Gender</label>
          <input
            type="text"
            className="form-control"
            name="gender"
            value={customer.gender}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label>Phone Number</label>
          <input
            type="tel"
            className="form-control"
            name="phoneNumber"
            value={customer.phoneNumber}
            onChange={handleChange}
            required
          />
        </div>
        <button type="submit" className="btn btn-primary" onClick={handleSubmit}>
          Create Customer
        </button>
      </form>

      {/* "Back to List" button */}
      <Link to="/list" className="btn btn-secondary mt-3">
        Back to List
      </Link>
    </div>
  );
};

export default CreateCustomer;
