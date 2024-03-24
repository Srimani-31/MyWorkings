import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const CreateUser = () => {
  const navigate = useNavigate();
  const [user, setUser] = useState({});

  const handleSubmit = (e) => {
    e.preventDefault();

    axios.post('https://localhost:44331/api/users', user)
      .then((response) => {
        console.log('User created:', response.data);
        navigate('/userlist'); // Redirect to the home page after creation
      })
      .catch((error) => {
        console.error('Error creating user:', error);
      });
  };

  return (
    <div className="container mt-5">
      <h2>Create User</h2>
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label htmlFor="username" className="form-label">Username</label>
          <input
            type="text"
            className="form-control"
            id="username"
            placeholder="Enter username"
            value={user.username || ''}
            onChange={(e) => setUser({ ...user, username: e.target.value })}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="fullName" className="form-label">Full Name</label>
          <input
            type="text"
            className="form-control"
            id="fullName"
            placeholder="Enter full name"
            value={user.fullName || ''}
            onChange={(e) => setUser({ ...user, fullName: e.target.value })}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="email" className="form-label">Email</label>
          <input
            type="email"
            className="form-control"
            id="email"
            placeholder="Enter email"
            value={user.email || ''}
            onChange={(e) => setUser({ ...user, email: e.target.value })}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="password" className="form-label">Password</label>
          <input
            type="password"
            className="form-control"
            id="password"
            placeholder="Enter password"
            value={user.password || ''}
            onChange={(e) => setUser({ ...user, password: e.target.value })}
            required
          />
        </div>
        <button type="submit" className="btn btn-primary">Create</button>
      </form>
    </div>
  );
};

export default CreateUser;
