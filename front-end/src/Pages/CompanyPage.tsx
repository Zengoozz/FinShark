// get the ticker from params --use Effect ☑
// use it to getCompanyProfile inside useEffect Hook as once run --use Effect ☑
// set result to state as Company --use Effect ☑
// async function in useEffect must be called after --use Effect ☑
// conditional rendering to see if it actually have value --use Effect ☑

import { useEffect, useState } from "react";
import { useParams } from "react-router";
import { getCompanyProfile } from "../api";
import { CompanyProfile } from "../Types/Company";

interface Props {}

const CompanyPage = (props: Props) => {
   const [companyProfile, setCompanyProfile] = useState<CompanyProfile>();
   const { ticker } = useParams();
   useEffect(() => {
      const getCompanyInit = async () => {
         const result = await getCompanyProfile(ticker!);
         setCompanyProfile(result?.data[0]);
      };
      getCompanyInit();
      // eslint-disable-next-line react-hooks/exhaustive-deps
   }, []);
   return (
      <>
         {companyProfile ? (
            <div className="company-profile-container">{companyProfile.companyName}</div>
         ) : (
            <div>No data found!</div>
         )}
      </>
   );
};

export default CompanyPage;
