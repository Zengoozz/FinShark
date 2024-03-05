// get the ticker from params --use Effect ☑
// use it to getCompanyProfile inside useEffect Hook as once run --use Effect ☑
// set result to state as Company --use Effect ☑
// async function in useEffect must be called after --use Effect ☑
// conditional rendering to see if it actually have value --use Effect ☑

// Add Dashboard -- Dashboard ☑
// Add Sidebar and CompanyDashboard -- Dashboard ☑

import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

import { getCompanyProfile } from "../api";
import { CompanyProfile } from "../Types/Company";

import Sidebar from "../Components/Company/Sidebar";
import CompanyDashboard from "../Components/Company/CompanyDashboard";
import Tile from "../Components/Company/Tile";

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
            <div className="w-full relative flex ct-docs-disable-sidebar-content overflow-x-hidden">
               <Sidebar />
               <CompanyDashboard>
                  <Tile title="Company Profile" subtitle={companyProfile.companyName}/>
               </CompanyDashboard>
            </div>
         ) : (
            <div>No data found!</div>
         )}
      </>
   );
};

export default CompanyPage;
