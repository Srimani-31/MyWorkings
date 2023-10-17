import { BrowserRouter as Router } from 'react-router-dom';
import './App.css';
import SignIn from './components/SignIn';
import SignUp from './components/SignUp';
import Home from './components/Home';
import ProductView from './components/ProductView';
import ChooseShippingAddress from './components/ChooseShippingAddress';
import ChoosePaymentMethod from './components/ChoosePaymentMethod';
import Cart from './components/Cart';
import MyOrder from './components/MyOrders';
import OrderedItem from './components/OrderedItem';
import ViewProfile from './components/ViewProfile';
import Header from './components/Header';
import Routers from './components/Router';
import Footer from './components/Footer';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  return (
    <Router>
      <div>
        <Header />
        {/* <SignIn />
        <SignUp />
        <Home />
        <ProductView />
        <ChooseShippingAddress />
        <ChoosePaymentMethod />
        <Cart />
        <MyOrder />
        <OrderedItem />
        <ViewProfile /> */}
        <div className="container mt-4 main-content">
          <Routers />
        </div>
        <Footer />
      </div>
    </Router>
  );
}

export default App;
