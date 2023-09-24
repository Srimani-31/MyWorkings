import React, { useState } from 'react';

function CustomerForm() {
  // Define state variables for form fields
  const [customerName, setCustomerName] = useState('');
  const [customerEmail, setCustomerEmail] = useState('');
  const [customerPhoneNumber, setCustomerPhoneNumber] = useState('');

  // Function to handle form submission
  const handleSubmit = (e) => {
    e.preventDefault();

    // Do something with the form data, e.g., send it to an API or save it to state
    const formData = {
      name: customerName,
      email: customerEmail,
      phoneNumber: customerPhoneNumber,
    };

    console.log('Form Data:', formData);

    // Reset form fields
    setCustomerName('');
    setCustomerEmail('');
    setCustomerPhoneNumber('');
  };

  return (


    <div id="form">
      <h2>Add Customer</h2>
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label htmlFor="customerName" className="form-label">
            Name
          </label>
          <input
            type="text"
            className="form-control"
            id="customerName"
            placeholder="Enter customer name"
            value={customerName}
            onChange={(e) => setCustomerName(e.target.value)}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="customerEmail" className="form-label">
            Email
          </label>
          <input
            type="email"
            className="form-control"
            id="customerEmail"
            placeholder="Enter customer email"
            value={customerEmail}
            onChange={(e) => setCustomerEmail(e.target.value)}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="customerPhoneNumber" className="form-label">
            Phone Number
          </label>
          <input
            type="tel"
            className="form-control"
            id="customerPhoneNumber"
            placeholder="Enter customer phone number"
            value={customerPhoneNumber}
            onChange={(e) => setCustomerPhoneNumber(e.target.value)}
            required
          />
        </div>
        <button type="submit" className="btn btn-primary">
          Add Customer
        </button>
      </form>
    </div>

  );
}

export default CustomerForm;
