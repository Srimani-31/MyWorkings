import React from 'react';
 import { Link } from 'react-router-dom'

function CompleteCRUDApp() {
  return (
    <div>
      <h1>Customer CRUD App</h1>
      <Link to="/list">Customer List</Link>
    </div>
  )
}

export default CompleteCRUDApp
