import { ChangeEvent, SyntheticEvent, useState } from "react";
import { CompanySearch } from "../Types/Company";
import { searchCompanies } from "../api";
import Search from "../Components/Search";
import PortfoliosList from "../Components/Portfolio/PortfoliosList";
import CardList from "../Components/Card/CardList";

interface Props {}

const SearchPage = (props: Props) => {
   const [searchText, setSearchText] = useState<string>("");
   const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
   const [portfolioValues, setPortfolioValues] = useState<string[]>([]);
   const [serverErr, setServerErr] = useState<string | null>(null);

   const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
      // debugger
      setSearchText(e.target.value);
   };

   const onSearchSubmit = async (e: SyntheticEvent) => {
      // debugger;
      e.preventDefault();
      const result = await searchCompanies(searchText);
      if (typeof result === "string") {
         setServerErr(result);
      } else if (Array.isArray(result.data)) {
         setSearchResult(result.data);
      }
   };

   const onPortfolioCreate = (e: any) => {
      e.preventDefault();
      console.log(e.target);
      var exists = portfolioValues.find((value) => value === e.target[0].value);
      if (exists) return;
      const updatedValues = [...portfolioValues, e.target[0].value];
      setPortfolioValues(updatedValues);
   };

   const onPortfolioDelete = (e: any) => {
      e.preventDefault();
      const removed = portfolioValues.filter((value) => {
         return value !== e.target[0].value;
      });
      setPortfolioValues(removed);
   };

   return (
      <>
         <Search
            searchText={searchText}
            handleSearchChange={handleSearchChange}
            onSearchSubmit={onSearchSubmit}
         />

         <PortfoliosList
            portfolioValues={portfolioValues}
            onPortfolioDelete={onPortfolioDelete}
         />
         <CardList
            searchResults={searchResult}
            onPortfolioCreate={onPortfolioCreate}
         />
         {serverErr && <h1>{serverErr}</h1>}
      </>
   );
};

export default SearchPage;
