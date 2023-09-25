import React, { useState } from 'react';
import { Link, useParams, useNavigate } from 'react-router-dom'; // Import useNavigate

const EditCustomer = ({ customers, onUpdate }) => {
  const { email } = useParams();
  const navigate = useNavigate(); // Initialize the navigate function

  // Find the customer data by email
  const customer = customers.find((customer) => customer.email === email);

  const [updatedCustomer, setUpdatedCustomer] = useState({
    email: customer.email,
    name: customer.name,
    gender: customer.gender,
    phoneNumber: customer.phoneNumber,
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUpdatedCustomer({ ...updatedCustomer, [name]: value });
  };

  const handleSave = () => {
    // Update the customer data in the parent component
    onUpdate(updatedCustomer);

    // Redirect back to the List page using the navigate function
    navigate('/list');
  };

  return (
    <div>
      <h2>Edit Customer</h2>
      <form>
        <div className="form-group">
          <label>Email</label>
          <input
            type="email"
            className="form-control"
            name="email"
            value={updatedCustomer.email}
            readOnly
          />
        </div>
        <div className="form-group">
          <label>Name</label>
          <input
            type="text"
            className="form-control"
            name="name"
            value={updatedCustomer.name}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label>Gender</label>
          <input
            type="text"
            className="form-control"
            name="gender"
            value={updatedCustomer.gender}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label>Phone Number</label>
          <input
            type="tel"
            className="form-control"
            name="phoneNumber"
            value={updatedCustomer.phoneNumber}
            onChange={handleChange}
          />
        </div>
        <br></br>
        <button type="button" className="btn btn-primary" onClick={handleSave}>
          Save
        </button>&nbsp;
        <Link to="/list">
            <button  className="btn btn-secondary ml-2">
            Cancel

            </button>
        </Link>
      </form>
    </div>
  );
};

export default EditCustomer;
