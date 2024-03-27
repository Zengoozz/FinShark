// copy Configs --CashFlowStatement ☑
// get ticker from outletContext --CashFlowStatement ☑ 
// use useState to save the response from API --CashFlowStatement ☑
// call the API_Method through UseEffect --CashFlowStatement ☑
// render Conditionally if the data exist or not --CashFlowStatement ☑
// render data through table --CashFlowStatement ☑
// add needed props through table component --CashFlowStatement ☑

// add Spinner--LoadingSpinner ☑

import { useOutletContext } from "react-router";
import { CompanyCashFlow } from "../../Types/Company";
import { useEffect, useState } from "react";
import { getCashFlowStatement } from "../../api";
import Table from "../Table";
import Spinner from "../Spinner";

const config = [
   {
      label: "Date",
      render: (company: CompanyCashFlow) => company.date,
   },
   {
      label: "Operating Cashflow",
      render: (company: CompanyCashFlow) => company.operatingCashFlow,
   },
   {
      label: "Property/Machinery Cashflow",
      render: (company: CompanyCashFlow) =>
         company.investmentsInPropertyPlantAndEquipment,
   },
   {
      label: "Other Investing Cashflow",
      render: (company: CompanyCashFlow) => company.otherInvestingActivites,
   },
   {
      label: "Debt Cashflow",
      render: (company: CompanyCashFlow) =>
         company.netCashUsedProvidedByFinancingActivities,
   },
   {
      label: "CapEX",
      render: (company: CompanyCashFlow) => company.capitalExpenditure,
   },
   {
      label: "Free Cash Flow",
      render: (company: CompanyCashFlow) => company.freeCashFlow,
   },
];

const CashFlowStatement = () => {
   const ticker = useOutletContext<string>();
   const [companyCashFlowStatement, setCompanyCashFlowStatement] =
      useState<CompanyCashFlow[]>();
   useEffect(() => {
      const getCompanyCashFlowStatement = async () => {
         const resposne = await getCashFlowStatement(ticker);
         setCompanyCashFlowStatement(resposne?.data);
      };
      getCompanyCashFlowStatement();
      // eslint-disable-next-line react-hooks/exhaustive-deps
   }, []);
   return (
      <>
         {companyCashFlowStatement ? (
            <>
               <Table
                  configs={config}
                  data={companyCashFlowStatement}
               />
            </>
         ) : (
            <Spinner />
         )}
      </>
   );
};

export default CashFlowStatement;
