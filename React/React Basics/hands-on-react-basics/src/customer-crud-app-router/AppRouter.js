// import React from 'react';
// import {BrowserRouter as Router, Route} from 'react-router-dom';
// import App from '../App';
// import ListCustomer from './ListCustomer';
// import CreateCustomer from './CreateCustomer';
// import EditCustomer from './EditCustomer';

// function AppRouter(){
//     return(
//         <Router>
//                 <Route exact path="/" component={App}/>
//                 <Route path="/list" component={ListCustomer}/>
//                 <Route path="/create" component={CreateCustomer}/>
//                 <Route path="edit/:id" component={EditCustomer}/> 
//         </Router>
//     )
// }

// export default AppRouter;

// AppRouter.js (Do not use BrowserRouter here)
// import React from 'react';
// import { Route } from 'react-router-dom';
// import App from '../App';
// import ListCustomer from './ListCustomer';
// import CreateCustomer from './CreateCustomer';
// import EditCustomer from './EditCustomer';

// function AppRouter() {
//   return (
//     <>
//       <Route exact path="/" component={App} />
//       <Route path="/list" component={ListCustomer} />
//       <Route path="/create" component={CreateCustomer} />
//       <Route path="edit/:id" component={EditCustomer} />
//     </>
//   );
// }

// export default AppRouter;
import React from 'react';
import { Routes, Route } from 'react-router-dom'; // Import Routes and Route
import App from '../App';
import ListCustomer from './ListCustomer';
import CreateCustomer from './CreateCustomer';
import EditCustomer from './EditCustomer';

function AppRouter() {
  return (
    <Routes> {/* Wrap your routes in a Routes component */}
      <Route path="/" element={<App />} /> {/* Use 'element' prop instead of 'component' */}
      <Route path="/list" element={<ListCustomer />} /> {/* Use 'element' prop instead of 'component' */}
      <Route path="/create" element={<CreateCustomer />} /> {/* Use 'element' prop instead of 'component' */}
      <Route path="/edit/:id" element={<EditCustomer />} /> {/* Use 'element' prop instead of 'component' */}
    </Routes>
  );
}

export default AppRouter;
