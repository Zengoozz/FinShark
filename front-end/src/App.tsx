import { Outlet } from "react-router";

import "./assets/styles/App.css";

import Navbar from "./Components/Navbar";

// Extract all the logic into searchPage-- preparing reactRouter ☑
// Pass only Navbar and outlet-- preparing reactRouter ☑

function App(): JSX.Element {
   return (
      <>
         <Navbar />
         <Outlet />
      </>
   );
}

export default App;
