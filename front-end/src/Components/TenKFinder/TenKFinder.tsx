// ticker as props --TenK ☑
// implement a state for CompanyData as an array --TenK ☑
// fetch data using useEffect --TenK ☑
// hook useEffect to the ticker --TenK ☑
// render conditionally the data slicing it to 5 or the spinner --TenK ☑
// return TenKFinderItem --TenK ☑

import { useEffect, useState } from "react";
import { CompanyTenK } from "../../Types/Company";
import { getTenK } from "../../api";
import Spinner from "../Spinner";
import TenKFinderItem from "./TenKFinderItem";

type Props = {
   ticker: string;
};

const TenKFinder = ({ ticker }: Props) => {
   const [companyTenKData, setCompanyTenKData] = useState<CompanyTenK[]>();
   useEffect(() => {
      const getCompanyTenKData = async () => {
         const response = await getTenK(ticker);
         setCompanyTenKData(response?.data);
      };
      getCompanyTenKData();
   }, [ticker]);
   return (
      <div className="inline-flex rounded-md shadow-sm m-4">
         {companyTenKData ? (
            companyTenKData.slice(0, 5).map((comp) => {
               return <TenKFinderItem tenK={comp} />;
            })
         ) : (
            <Spinner />
         )}
      </div>
   );
};

export default TenKFinder;
