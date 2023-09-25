import { BrowserRouter as Router } from 'react-router-dom';
import Header from './components/Header';
import Routers from './components/Router';
import Footer from './components/Footer';

function App() {
  return (
    <Router>
        <div>
          <Header />
          <div className="container mt-4">
            <Routers />
          </div>
          <Footer />
        </div>
    </Router>
  );
}

export default App;

