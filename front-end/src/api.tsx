import axios from "axios";
import { CompanySearch } from "./Types/Company";

interface SearchResponse {
  data: CompanySearch[];
}

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
