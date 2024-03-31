// ticker as props --CompFinder ☑
// implement a state for CompanyData --CompFinder ☑
// fetch data using useEffect --CompFinder ☑
// hook useEffect to the ticker --CompFinder ☑
// render the data and the CompFinderItem component --CompFinder ☑
 
import { useEffect, useState } from "react";
import { CompanyCompData } from "../../Types/Company";
import { getComparableData } from "../../api";
import CompFinderItem from "./CompFinderItem";

type Props = {
   ticker: string;
};

const CompFinder = ({ ticker }: Props) => {
   const [companyData, setCompanyData] = useState<CompanyCompData>();
   useEffect(() => {
      const getCompanyData = async () => {
         const response = await getComparableData(ticker);
         setCompanyData(response?.data[0]);
      };
      getCompanyData();
   }, [ticker]);
   return (
      <div className="inline-flex rounded-md shadow-sm m-4">
         {companyData?.peersList.map((comp) => {
            return <CompFinderItem ticker={comp} />;
         })}
      </div>
   );
};

export default CompFinder;
