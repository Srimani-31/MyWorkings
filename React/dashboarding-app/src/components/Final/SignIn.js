import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import axios from 'axios';

const SignIn = ({onSignIn}) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleSignIn = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post(
        'https://localhost:44311/api/Auth/Login', 
        {
          username,  // Modified to match the expected property name on the server
          password,
        }, 
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      );

      if (response.status === 200) {
        // Handle successful login if needed
        onSignIn(username);

        navigate('/');
      } else {
        // Handle authentication error (e.g., show an error message)
      }
    } catch (error) {
      console.error('Authentication error:', error);
    }
  };

  return (
    <div className="bg-gradient-to-r from-purple-500 via-indigo-500 to-blue-500 min-h-screen flex items-center justify-center">
      <div className="p-8 bg-white border rounded-lg shadow-md w-full sm:w-96">
        <h2 className="text-3xl text-center mb-6 text-gray-800 font-bold">Pro-XY</h2>
        <form onSubmit={handleSignIn} className="space-y-4">
          <div>
            <input
              type="text"
              placeholder="Username"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
              className="w-full px-4 py-2 border rounded-md focus:outline-none focus:border-blue-500"
            />
          </div>

          <div>
            <input
              type="password"
              placeholder="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              className="w-full px-4 py-2 border rounded-md focus:outline-none focus:border-blue-500"
            />
          </div>

          <button 
            type="submit" 
            className="bg-blue-500 text-white px-6 py-2 rounded-md focus:outline-none hover:bg-blue-600 w-full"
          >
            Sign In
          </button>
        </form>

        <div className="text-center mt-3">
          <a href="#" className="text-blue-600">Forgot Password?</a>
        </div>

        <div className="text-center mt-3">
          <Link to="/signup" className="text-blue-600">
            New User? Sign Up
          </Link>
        </div>
      </div>
    </div>
  );
};

export default SignIn;
