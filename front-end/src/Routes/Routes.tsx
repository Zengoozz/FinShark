// CreateBrowserRouter Object   {path, element, children[path,element]}-- preparing reactRouter ☑

// Create NestedRoutes >> children for CompanyPage for CompanyProfile, IncomeStatement -- Dashboard ☑
import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage";
import SearchPage from "../Pages/SearchPage";
import CompanyPage from "../Pages/CompanyPage";
import CompanyProfile from "../Components/Company/CompanyProfile";
import IncomeStatement from "../Components/Company/IncomeStatement";

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
               }
            ]
         },
      ],
   },
]);
