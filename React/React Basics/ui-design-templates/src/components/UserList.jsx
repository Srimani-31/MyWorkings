import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
const UserList = () => {
  const [users, setUsers] = useState([]);
  const navigate = useNavigate();
  useEffect(() => {
    // Fetch user data from the ASP.NET Core API
    axios
      .get('https://localhost:44331/users')
      .then((response) => {
        setUsers(response.data);
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
      });
  }, []);

  return (
    <div className="container mt-5">
      <h2>User List</h2>
      <table className="table">
        <thead>
          <tr>
            <th>Username</th>
            <th>Full Name</th>
            <th>Email</th>
            <th>Password</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {users.map((user, username) => (
            <tr key={username}>
              <td>{user.username}</td>
              <td>{user.fullName}</td>
              <td>{user.email}</td>
              <td>{user.password}</td>
              <td>
                <Link to={`/edituser/${user.username}`} >
                  <button className="btn btn-primary mr-2">
                    Edit
                  </button>
                </Link>
                &nbsp;
                <Link to={`/deleteuser/${user.username}`} >
                  <button className="btn btn-danger">
                    Delete
                  </button>
                </Link>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default UserList;

// Create a UserList component
// import useState
// destructure the useState initialise it with empty array
// Start jsx  component
// include table with necessary columns
// map over the UserList render it inside table
// install axios
// import useEffect and axios
// define the required request inside useEffect mounted state
// return response inside then block and set it to the state object
// show error in the catch block for logging purpose and for smooth user experience