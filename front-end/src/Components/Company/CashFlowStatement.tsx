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
import { formatLargeMonetaryNumber } from "../../Helpers/NumberFormatting";

const config = [
   {
      label: "Date",
      render: (company: CompanyCashFlow) => company.date,
   },
   {
      label: "Operating Cashflow",
      render: (company: CompanyCashFlow) =>
         formatLargeMonetaryNumber(company.operatingCashFlow),
   },
   {
      label: "Investing Cashflow",
      render: (company: CompanyCashFlow) =>
         formatLargeMonetaryNumber(company.netCashUsedForInvestingActivites),
   },
   {
      label: "Financing Cashflow",
      render: (company: CompanyCashFlow) =>
         formatLargeMonetaryNumber(company.netCashUsedProvidedByFinancingActivities),
   },
   {
      label: "Cash At End of Period",
      render: (company: CompanyCashFlow) =>
         formatLargeMonetaryNumber(company.cashAtEndOfPeriod),
   },
   {
      label: "CapEX",
      render: (company: CompanyCashFlow) =>
         formatLargeMonetaryNumber(company.capitalExpenditure),
   },
   {
      label: "Issuance Of Stock",
      render: (company: CompanyCashFlow) =>
         formatLargeMonetaryNumber(company.commonStockIssued),
   },
   {
      label: "Free Cash Flow",
      render: (company: CompanyCashFlow) =>
         formatLargeMonetaryNumber(company.freeCashFlow),
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
