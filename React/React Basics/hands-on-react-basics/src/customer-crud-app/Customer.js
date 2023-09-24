import React from 'react'
import { useState } from 'react'

function Customer() {
  const [customers, setCustomers] = useState([]);
  const [formData, setFormData] = useState({
    email: '',
    firstName: '',
    lastName: '',
    gender: '',
    phoneNumber: ''
  });

  const handleInputChange = (e) => {
    const {name, value} = e.target; //e.target do ??
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
  const handleDeleteCustomer = (index) => {
    const updatedCustomers = [...customers];
    updatedCustomers.splice(index, 1);
    setCustomers(updatedCustomers);
  }
  return (
    <div>
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
      <div>
        <table className="table table-bordered">
          <thead>
            <tr>
              <th>Email</th>
              <th>First Name</th>
              <th>Last Name</th>
              <th>Gender</th>
              <th>Phone Number</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {customers.map((customer, index) => (
              <tr key={index}>
                <td>{customer.email}</td>
                <td>{customer.firstName}</td>
                <td>{customer.lastName}</td>
                <td>{customer.gender}</td>
                <td>{customer.phoneNumber}</td>
                <td>
                  <button onClick={() => handleDeleteCustomer(index)}>
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  )
}

export default Customer;
