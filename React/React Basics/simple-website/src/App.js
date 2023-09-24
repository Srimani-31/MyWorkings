import React from 'react';
import './App.css';
import Header from './components/Header';
import SideNav from './components/SideNav';
import MainContent from './components/MainContent';
import Footer from './components/Footer';

function App() {
  return (
    <div className="App">
      <Header />
      <div className="container-fluid">
        <div className="row">
          <nav className="col-md-2 d-none d-md-block bg-light sidebar">
            <SideNav />
          </nav>
          <MainContent />
        </div>
      </div>
      <Footer />
    </div>
  );
}

export default App;