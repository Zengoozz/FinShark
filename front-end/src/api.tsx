import axios from "axios";
import {
   CompanyIncomeStatement,
   CompanyKeyMetrics,
   CompanyProfile,
   CompanySearch,
} from "./Types/Company";


interface SearchResponse {
   data: CompanySearch[];
}
// Create a new method to getCompanyProfile which get CompanyProfile[] --use Effect ☑

// getIncomeStatementMethod CompanyIncomeStatement limit40 --IncomeStatement ☑
export const searchCompanies = async (query: string) => {
   try {
      const data = await axios.get<SearchResponse>(
         `https://financialmodelingprep.com/api/v3/search?query=${query}&limit=10&exchange=NASDAQ&apikey=${process.env["REACT_APP_API_KEY"]}`
      );
      return data;
   } catch (e) {
      if (axios.isAxiosError(e)) {
         console.log("error message: ", e.message);
         return e.message;
      } else {
         console.log("unexpected error: ", e);
         return "Unexpected error has occured.";
      }
   }
};

export const getCompanyProfile = async (query: string) => {
   try {
      const data = await axios.get<CompanyProfile[]>(
         `https://financialmodelingprep.com/api/v3/profile/${query}?apikey=${process.env["REACT_APP_API_KEY"]}`
      );
      return data;
   } catch (e: any) {
      console.log("error message:", e.message);
   }
};

export const getKeyMetrics = async (query: string) => {
   try {
      const data = await axios.get<CompanyKeyMetrics[]>(
         `https://financialmodelingprep.com/api/v3/key-metrics-ttm/${query}?limit=40&apikey=${process.env["REACT_APP_API_KEY"]}`
      );
      return data;
   } catch (e: any) {
      console.log("error message:", e.message);
   }
};

export const getIncomeStatement = async (query: string) => {
   try {
      const data = await axios.get<CompanyIncomeStatement[]>(
         `https://financialmodelingprep.com/api/v3/income-statement/${query}?limit=40&apikey=${process.env["REACT_APP_API_KEY"]}`
      );
      return data;
   } catch (e: any) {
      console.log("error message:", e.message);
   }
};
