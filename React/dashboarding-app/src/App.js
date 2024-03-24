import { useState } from "react";
import { BrowserRouter as Router } from 'react-router-dom';
import Routers from "./components/Final/Router";
import Header from "./components/Final/Header";
import Footer from "./components/Final/Footer";

import Dashboard from "./components/Dashboard";
import StockContext from "./context/StockContext";
import ThemeContext from "./context/ThemeContext";
import ChartsExample from "./components/ChartExample";
import BuildingLayout from "./components/BuildingLayout";
import BuildingDynamicLayout from "./components/Done/BuildingDaynamicLayout";
import DashboardFinal from "./components/DashboardFinal";
import Workspace from "./components/Workspace";
import DashboardForm from "./components/DashboardForm";
import AboutUs from "./components/Final/AboutUs";
import Landing from "./components/Final/Landing";
import Navbar from "./components/Final/Navbar";
function App() {
  const [darkMode, setDarkMode] = useState(false);
  const [stockSymbol, setStockSymbol] = useState("MSFT");
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  return (
    <Router>
      <div className="flex flex-col min-h-screen">
        <Header className="fixed top-0 w-full" />
        <div className="flex-1 container mx-auto mt-20 main-content "> {/* Adjusted padding-top */}
          <Routers />
        </div>
        <Footer />
      </div>
    </Router>
  );
}

export default App;