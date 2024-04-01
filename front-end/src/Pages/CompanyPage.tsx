// get the ticker from params --use Effect ☑
// use it to getCompanyProfile inside useEffect Hook as once run --use Effect ☑
// set result to state as Company --use Effect ☑
// async function in useEffect must be called after --use Effect ☑
// conditional rendering to see if it actually have value --use Effect ☑

// Add Dashboard -- Dashboard ☑
// Add Sidebar and CompanyDashboard -- Dashboard ☑

// add more Tiles to companyDashboard (Price,Sector,DCF) --CashFlowStatement ☑

// add Spinner--LoadingSpinner ☑

// add CompFinder --CompFinder ☑

// add tenK --tenK ☑

import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

import { getCompanyProfile } from "../api";
import { CompanyProfile } from "../Types/Company";

import Sidebar from "../Components/Company/Sidebar";
import CompanyDashboard from "../Components/Company/CompanyDashboard";
import Tile from "../Components/Company/Tile";
import Spinner from "../Components/Spinner";
import CompFinder from "../Components/CompFinder/CompFinder";
import TenKFinder from "../Components/TenKFinder/TenKFinder";

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
               <CompanyDashboard ticker={ticker!}>
                  <Tile
                     title="Company Profile"
                     subtitle={companyProfile.companyName}
                  />
                  <Tile
                     title="Price"
                     subtitle={companyProfile.price.toString()}
                  />
                  <Tile
                     title="Sector"
                     subtitle={companyProfile.sector}
                  />
                  <Tile
                     title="MKTCap"
                     subtitle={companyProfile.mktCap.toString()}
                  />
                  <CompFinder ticker={companyProfile.symbol} />
                  <TenKFinder ticker={companyProfile.symbol} />
               </CompanyDashboard>
            </div>
         ) : (
            <Spinner />
         )}
      </>
   );
};

export default CompanyPage;
