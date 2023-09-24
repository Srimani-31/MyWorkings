import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import customers from './Data';
import {Link} from 'react-router-dom'

function EditCustomer() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    email: '',
    firstName: '',
    lastName: '',
    gender: '',
    phoneNumber: ''
  });

  // Fetch the customer data based on the id
  useEffect(() => {
    // const customerToEdit = customers.find((customer) => customer.id === parseInt(id));
    const customerToEdit = customers[id];
    if (customerToEdit) {
      setFormData(customerToEdit);
    }
  }, [id]);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleEditCustomer = () => {
    const customerIndex = customers.findIndex((customer) => customer.id === parseInt(id));

    if (customerIndex >= 0) {
      customers[customerIndex] = { ...formData, id: parseInt(id) };
      // You can save 'customers' to your data source here

      // Redirect to the list page
      navigate.push('/list');
    } else {

      // Handle the case where the customer with the given id is not found
      // You might want to show an error message or handle it in another way
    }
  };


  return (
    <>
      <h1>Edit Customer</h1>
      <div className="form-group">
        <input
          type="text"
          name="email"
          placeholder="Email"
          value={formData.email}
          onChange={(e) => handleInputChange(e)}
        />
        <input
          type="text"
          name="firstName"
          placeholder="First Name"
          value={formData.firstName}
          onChange={(e) => handleInputChange(e)}
        />
        <input
          type="text"
          name="lastName"
          placeholder="Last Name"
          value={formData.lastName}
          onChange={(e) => handleInputChange(e)}
        />
        <select
          name="gender"
          value={formData.gender}
          onChange={(e) => handleInputChange(e)}
        >
          <option value="">Select Gender</option>
          <option value="male">Male</option>
          <option value="female">Female</option>
          <option value="other">Other</option>
        </select>
        <input
          type="text"
          name="phoneNumber"
          placeholder="Phone Number"
          value={formData.phoneNumber}
          onChange={(e) => handleInputChange(e)}
        />
        <button type="button" onClick={() => handleEditCustomer()}>
          Save Changes
        </button>
        <Link to={`/list`}>
          <button>
            Back
          </button>
        </Link>
      </div>
    </>
  );
}

export default EditCustomer;
