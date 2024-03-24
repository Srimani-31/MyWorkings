// import React from 'react';
// import { Link,useNavigate } from 'react-router-dom';

// const Navbar = ({ isAuthenticated, setIsAuthenticated }) => {
//   const navigate = useNavigate();

//   const handleLogout = () => {
//     // Perform logout logic here
//     // For example, clear authentication token or user session
//     setIsAuthenticated(false);
//     // Redirect to the home page or login page after logout
//     navigate('/');
//   };
//   return (
//     <nav className="bg-gray-800 text-white p-4 fixed top-0 w-full z-50">
//       <div className="container mx-auto flex justify-between items-center m-0">
//         <Link to="/" className="flex items-center">
//           <img
//             src="/logo.png"
//             alt="Your Logo"
//             className="rounded-md"
//             style={{ width: '240px', height: '70px' }}
//           />
//         </Link>

//         <div className="hidden lg:flex items-center space-x-4 pr-8">
//           <Link to="/workspace" className="text-white font-bold hover:text-gray-300 transition duration-300">
//             Workspace
//           </Link>
//           <Link to="/about" className="text-white font-bold hover:text-gray-300 transition duration-300">
//             About Us
//           </Link>

//           {isAuthenticated ? (
//             // Render profile and logout links when authenticated
//             <>
//               <Link to="/profile" className="text-white font-bold hover:text-gray-300 transition duration-300">
//                 Profile
//               </Link>
//               <button onClick={handleLogout} className="text-white font-bold hover:text-gray-300 transition duration-300">
//                 Logout
//               </button>
//             </>
//           ) : (
//             // Render Sign In and Sign Up links when not authenticated
//             <>
//               <Link to="/signin" className="text-white font-bold hover:text-gray-300 transition duration-300">
//                 Sign In
//               </Link>
//               <Link to="/signup" className="text-white font-bold hover:text-gray-300 transition duration-300">
//                 Sign Up
//               </Link>
//             </>
//           )}
//         </div>
//       </div>
//     </nav>
//   );
// };

// export default Navbar;

import React, { useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';

const Navbar = ({ token, onSignOut }) => {
  useEffect(() => {
    // Check if the user is authenticated based on the token.
    const isLoggedIn = !!token;

  }, [token]);
  const navigate = useNavigate();

  const handleLogout = () => {
    // Perform logout logic here
    // For example, clear authentication token or user session
    onSignOut();
    navigate('/signin'); // Redirect to the sign-in page or another appropriate destination

  };

  return (
    <nav className="bg-gray-800 text-white p-4 fixed top-0 w-full z-50">
      <div className="container mx-auto flex justify-between items-center m-0">
        <Link to="/" className="flex items-center">
          <img
            src="/logo.png"
            alt="Your Logo"
            className="rounded-md"
            style={{ width: '240px', height: '70px' }}
          />
        </Link>

        <div className="hidden lg:flex items-center space-x-4 pr-8">

          <Link to="/about" className="text-white font-bold hover:text-gray-300 transition duration-300">
            About Us
          </Link>

          {localStorage.getItem('username') === 'jailash' && (
            <Link to="/workspace" className="text-white font-bold hover:text-gray-300 transition duration-300">
              Workspace
            </Link>
          )}
          {token ? (
            // Render profile and logout links when authenticated
            <>

              <Link className="text-white font-bold hover:text-gray-300 transition duration-300">
                Welcome {localStorage.getItem('username')}
              </Link>
              <button onClick={handleLogout} className="text-white font-bold hover:text-gray-300 transition duration-300">
                Logout
              </button>
            </>
          ) : (
            // Render Sign In and Sign Up links when not authenticated
            <>
              <Link to="/signin" className="text-white font-bold hover:text-gray-300 transition duration-300">
                Sign In
              </Link>
              <Link to="/signup" className="text-white font-bold hover:text-gray-300 transition duration-300">
                Sign Up
              </Link>
            </>
          )}
        </div>
      </div>
    </nav>
  );
};

export default Navbar;

