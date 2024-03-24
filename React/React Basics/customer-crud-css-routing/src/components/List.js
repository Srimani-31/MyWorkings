// List.js
import React, { useState } from 'react';
import { Link } from 'react-router-dom';

const List = ({ customers, onDelete }) => {
  return (
    <div>
      {/* Customer List */}
      <div className="container mt-4">
        <h2>Customer List</h2>
        <table className="table">
          <thead>
            <tr>
              <th>Email</th>
              <th>Name</th>
              <th>Gender</th>
              <th>Phone Number</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {customers.map((customer) => (
              <tr key={customer.email}>
                <td>{customer.email}</td>
                <td>{customer.name}</td>
                <td>{customer.gender}</td>
                <td>{customer.phoneNumber}</td>
                <td>

                  <Link to={`/edit/${customer.email}`} >
                    <button className="btn btn-primary mr-2">
                      Edit
                    </button>
                  </Link>
                  &nbsp;
                  <button
                    onClick={() => onDelete(customer.email)}
                    className="btn btn-danger"
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default List;
