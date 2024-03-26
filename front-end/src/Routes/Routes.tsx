// CreateBrowserRouter Object   {path, element, children[path,element]}-- preparing reactRouter ☑

// Create NestedRoutes >> children for CompanyPage for CompanyProfile, IncomeStatement -- Dashboard ☑

// Add Route to design-guide -- Table ☑

// Add Route to balance-sheet --BalanceSheet ☑ 

// Add Route to cashflow-statement --CashFlowStatement ☑
import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage";
import SearchPage from "../Pages/SearchPage";
import CompanyPage from "../Pages/CompanyPage";
import CompanyProfile from "../Components/Company/CompanyProfile";
import IncomeStatement from "../Components/Company/IncomeStatement";
import DesignPage from "../Pages/DesignPage";
import BalanceSheet from "../Components/Company/BalanceSheet";
import CashFlowStatement from "../Components/Company/CashFlowStatement";

export const router = createBrowserRouter([
   {
      path: "/",
      element: <App />,
      children: [
         {
            path: "",
            element: <HomePage />,
         },
         {
            path: "search",
            element: <SearchPage />,
         },
         {
            path: "design-guide",
            element: <DesignPage />,
         },
         {
            path: "company/:ticker",
            element: <CompanyPage />,
            children: [
               {
                  path:"company-profile",
                  element:<CompanyProfile />
               },
               {
                  path:"income-statement",
                  element:<IncomeStatement />
               },
               {
                  path:"balance-sheet",
                  element:<BalanceSheet />
               },
               {
                  path:"cash-flow-statement",
                  element:<CashFlowStatement />
               }
            ]
         },
      ],
   },
]);
