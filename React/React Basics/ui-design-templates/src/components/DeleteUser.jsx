import React from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';

const DeleteUser = () => {
  const { username } = useParams();
  const navigate = useNavigate();

  const handleDelete = () => {
    axios.delete(`https://localhost:44331/users/${username}`)
      .then(() => {
        console.log('User deleted');
        navigate('/userlist'); // Redirect to the home page after deletion
      })
      .catch((error) => {
        console.error('Error deleting user:', error);
      });
  };

  return (
    <div className="container mt-5">
      <h2>Delete User</h2>
      <p>Are you sure you want to delete this user?</p>
      <button onClick={handleDelete} className="btn btn-danger">Delete</button>
    </div>
  );
};

export default DeleteUser;
