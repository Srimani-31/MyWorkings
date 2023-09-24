import React from 'react'
import { useState } from 'react';
import customersList from './Data';

function CreateCustomer() {
  const [customers, setCustomers] = useState(customersList);
  const [formData, setFormData] = useState({
    email: '',
    firstName: '',
    lastName: '',
    gender: '',
    phoneNumber: ''
  });

  const handleInputChange = (e) => {
    const { name, value } = e.target; //e.target do ??
    setFormData({ ...formData, [name]: value })
  }
  const handleAddCustomer = () => {
    if (
      formData.email &&
      formData.firstName &&
      formData.lastName &&
      formData.gender &&
      formData.phoneNumber
    ) {
      setCustomers([...customers, { ...formData }]) // why use ...formData instead formData?
      setFormData({
        email: '',
        firstName: '',
        lastName: '',
        gender: '',
        phoneNumber: ''
      })
    }
  }

  return (
    <>
      <h1>Customer List</h1>
      <div className="form-group">
        <input
          type="text"
          name="email"
          placeholder="enter your email"
          value={formData.email}
          onChange={e => handleInputChange(e)}
        />
        <input
          type="text"
          name="firstName"
          placeholder="enter your firstName"
          value={formData.firstName}
          onChange={e => handleInputChange(e)}
        />
        <input
          type="text"
          name="lastName"
          placeholder="enter your lastName"
          value={formData.lastName}
          onChange={e => handleInputChange(e)}
        />
        <select
          name="gender"
          value={formData.gender}
          onChange={e => handleInputChange(e)}
        >
          <option value="">Select Gender</option>
          <option value="male">Male</option>
          <option value="female">Female</option>
          <option value="other">Other</option>
        </select>
        <input
          type="text"
          name="phoneNumber"
          placeholder="enter your phoneNumber"
          value={formData.phoneNumber}
          onChange={e => handleInputChange(e)}
        />
        <input
          type="submit"
          onClick={() => handleAddCustomer()}
          value="Add Customer"
        />
      </div>
    </>
  )
}

export default CreateCustomer;
