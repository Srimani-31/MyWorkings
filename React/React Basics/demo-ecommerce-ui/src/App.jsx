import { BrowserRouter as Router } from 'react-router-dom';
import './App.css';
import Header from './components/Header';
import Routers from './components/Router';
import Footer from './components/Footer';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  return (
    <Router>
      <div>
        <Header />
        <div className="container mt-4 main-content">
          <Routers />
        </div>
        <Footer />
      </div>
    </Router>
  );
}

export default App;
