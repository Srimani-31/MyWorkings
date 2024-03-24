import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import axios from 'axios';
import './SignUp.css';

const SignUp = () => {
  const [name, setName] = useState('');
  const [userName, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [address, setAddress] = useState('');
  const [phoneNo, setContactNumber] = useState('');
  const [roleId, setRole] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();

    const formData = new FormData();
    formData.append('name', name);
    formData.append('userName', userName);  // Adjusted to match the expected property name on the server
    formData.append('password', password);
    formData.append('phoneNo', phoneNo);  // Adjusted to match the expected property name on the server
    formData.append('address', address);
    formData.append('roleId', roleId);  // Adjusted to match the expected property name on the server

    try {
      const response = await axios.post(
        'https://localhost:44311/api/User/CreateUser',  // Updated endpoint
        formData,
        {
          headers: {
            'Content-Type': 'multipart/form-data',
          },
        }
      );

      if (response.status === 200) {
        console.log(response);
        navigate('/signin');
      } else {
        console.error(response);
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
    <div className="bg-gradient-to-r from-purple-500 via-indigo-500 to-blue-500 min-h-screen flex items-center justify-center">
      <div className="p-8 bg-white border rounded-lg shadow-md w-full sm:w-96">
        <h2 className="text-3xl font-bold text-center mb-6 text-gray-800">Pro-XY</h2>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <input
              type="text"
              placeholder="Name"
              value={name}
              onChange={(e) => setName(e.target.value)}
              className="w-full px-4 py-2 border rounded-md focus:outline-none focus:border-blue-500"
              required
            />
          </div>

          <div>
            <input
              type="text"
              placeholder="Username"
              value={userName}
              onChange={(e) => setUsername(e.target.value)}
              className="w-full px-4 py-2 border rounded-md focus:outline-none focus:border-blue-500"
              required
            />
          </div>

          <div>
            <input
              type="password"
              placeholder="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              className="w-full px-4 py-2 border rounded-md focus:outline-none focus:border-blue-500"
              required
            />
          </div>

          <div>
            <input
              type="text"
              placeholder="Address"
              value={address}
              onChange={(e) => setAddress(e.target.value)}
              className="w-full px-4 py-2 border rounded-md focus:outline-none focus:border-blue-500"
            />
          </div>

          <div>
            <input
              type="tel"
              placeholder="Contact Number"
              value={phoneNo}
              onChange={(e) => setContactNumber(e.target.value)}
              className="w-full px-4 py-2 border rounded-md focus:outline-none focus:border-blue-500"
            />
          </div>

          <div>
            <select
              id="role"
              name="role"
              value={roleId}
              onChange={(e) => setRole(e.target.value)}
              className="w-full px-4 py-2 border rounded-md focus:outline-none focus:border-blue-500"
            >
              <option value="" disabled>Select a role</option>
              <option value="2">CIO</option>
              <option value="3">Data Engineer</option>
              <option value="4">Data Scientist</option>
            </select>
          </div>

          <div className="flex justify-center items-center">
            <button
              type="submit"
              className="bg-blue-500 text-white px-6 py-2 rounded-md focus:outline-none hover:bg-blue-600"
            >
              Submit
            </button>
          </div>

          <div className="text-center mt-3 text-blue-700">
            <Link to="/signin">Already have an account? Sign In</Link>
          </div>
        </form>
      </div>
    </div>
  );
};

export default SignUp;
