// import React, { useState } from 'react';
// import { Link } from 'react-router-dom';

// const RegistrationForm = () => {
//   const [username, setUsername] = useState('');
//   const [fullName, setFullName] = useState('');
//   const [email, setEmail] = useState('');
//   const [password, setPassword] = useState('');

//   const handleSubmit = (e) => {
//     e.preventDefault();
//     // Handle registration logic here, such as sending data to a server
//     console.log('Username:', username);
//     console.log('Full Name:', fullName);
//     console.log('Email:', email);
//     console.log('Password:', password);
//   };

//   return (
//     <div className="container mt-5">
//       <div className="row justify-content-center">
//         <div className="col-md-6">
//           <div className="card">
//             <div className="card-body">
//               <h5 className="card-title text-center">Register</h5>
//               <form onSubmit={handleSubmit}>
//                 <div className="mb-3">
//                   <label htmlFor="username" className="form-label">
//                     Username
//                   </label>
//                   <input
//                     type="text"
//                     className="form-control"
//                     id="username"
//                     placeholder="Enter your username"
//                     value={username}
//                     onChange={(e) => setUsername(e.target.value)}
//                     required
//                   />
//                 </div>
//                 <div className="mb-3">
//                   <label htmlFor="fullName" className="form-label">
//                     Full Name
//                   </label>
//                   <input
//                     type="text"
//                     className="form-control"
//                     id="fullName"
//                     placeholder="Enter your full name"
//                     value={fullName}
//                     onChange={(e) => setFullName(e.target.value)}
//                     required
//                   />
//                 </div>
//                 <div className="mb-3">
//                   <label htmlFor="email" className="form-label">
//                     Email
//                   </label>
//                   <input
//                     type="email"
//                     className="form-control"
//                     id="email"
//                     placeholder="Enter your email"
//                     value={email}
//                     onChange={(e) => setEmail(e.target.value)}
//                     required
//                   />
//                 </div>
//                 <div className="mb-3">
//                   <label htmlFor="password" className="form-label">
//                     Password
//                   </label>
//                   <input
//                     type="password"
//                     className="form-control"
//                     id="password"
//                     placeholder="Enter your password"
//                     value={password}
//                     onChange={(e) => setPassword(e.target.value)}
//                     required
//                   />
//                 </div>
//                 <div className="text-center">
//                   <button type="submit" className="btn btn-primary">
//                     Register
//                   </button>
//                 </div>
//               </form>
//               <div className="mt-3 text-center">
//                 Already have an account? <Link to="/login">Login</Link>
//               </div>
//               <div className="mt-3 text-center">
//                 <Link to="/forgot-password">Forgot Password?</Link>
//               </div>
//             </div>
//           </div>
//         </div>
//       </div>
//     </div>
//   );
// };

// export default RegistrationForm;

import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const CreateUser = () => {
  const navigate = useNavigate();
  const [user, setUser] = useState({});

  const handleSubmit = (e) => {
    e.preventDefault();

    axios.post('https://localhost:44331/users', user)
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
