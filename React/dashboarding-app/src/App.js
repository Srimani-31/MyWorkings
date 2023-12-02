import { useState } from "react";
import Dashboard from "./components/Dashboard";
import StockContext from "./context/StockContext";
import ThemeContext from "./context/ThemeContext";
import ChartsExample from "./components/ChartExample";
import BuildingLayout from "./components/BuildingLayout";
import BuildingDynamicLayout from "./components/BuildingDaynamicLayout";
import DashboardFinal from "./components/DashboardFinal";
function App() {
  const [darkMode, setDarkMode] = useState(false);
  const [stockSymbol, setStockSymbol] = useState("MSFT");

  return (
    // <ThemeContext.Provider value={{ darkMode, setDarkMode }}>
    //   <StockContext.Provider value={{ stockSymbol, setStockSymbol }}>
    //     <Dashboard />
    //   </StockContext.Provider>
    // </ThemeContext.Provider>
    //<BuildingLayout />
    //<BuildingDynamicLayout/>
    <DashboardFinal/>
  );
}

export default App;