import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import customersList from './Data';

function ListCustomer() {
  const [customers, setCustomers] = useState(customersList);

  const handleDeleteCustomer = (index) => {
    const updatedCustomers = [...customers];
    updatedCustomers.splice(index, 1);
    setCustomers(updatedCustomers);
  }
  return (
    <div>
      <Link to="/create">Create Customer</Link>
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

                <Link to={`/edit/${index}`}>
                  <button>
                    Edit
                  </button>
                </Link>&nbsp;
                <button onClick={() => handleDeleteCustomer(index)}>
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default ListCustomer
