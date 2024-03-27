// copy Configs --IncomeStatement ☑
// get ticker from outletContext --IncomeStatement ☑
// use useState to save the response from API ☑
// call the API_Method through UseEffect --IncomeStatement ☑
// render Conditionally if the data exist or not --IncomeStatement ☑
// render data through table --IncomeStatement ☑
// add needed props through table component --IncomeStatement ☑

// add Spinner--LoadingSpinner ☑

import { useOutletContext } from "react-router";
import { CompanyIncomeStatement } from "../../Types/Company";
import { useEffect, useState } from "react";
import { getIncomeStatement } from "../../api";
import Table from "../Table";
import Spinner from "../Spinner";

interface Props {}

const tableConfigs = [
   {
      label: "Date",
      render: (company: CompanyIncomeStatement) => company.date,
   },
   {
      label: "Revenue",
      render: (company: CompanyIncomeStatement) => company.revenue,
   },
   {
      label: "Cost Of Revenue",
      render: (company: CompanyIncomeStatement) => company.costOfRevenue,
   },
   {
      label: "Depreciation",
      render: (company: CompanyIncomeStatement) => company.depreciationAndAmortization,
   },
   {
      label: "Operating Income",
      render: (company: CompanyIncomeStatement) => company.operatingIncome,
   },
   {
      label: "Income Before Taxes",
      render: (company: CompanyIncomeStatement) => company.incomeBeforeTax,
   },
   {
      label: "Net Income",
      render: (company: CompanyIncomeStatement) => company.netIncome,
   },
   {
      label: "Net Income Ratio",
      render: (company: CompanyIncomeStatement) => company.netIncomeRatio,
   },
   {
      label: "Earnings Per Share",
      render: (company: CompanyIncomeStatement) => company.eps,
   },
   {
      label: "Earnings Per Diluted",
      render: (company: CompanyIncomeStatement) => company.epsdiluted,
   },
   {
      label: "Gross Profit Ratio",
      render: (company: CompanyIncomeStatement) => company.grossProfitRatio,
   },
   {
      label: "Opearting Income Ratio",
      render: (company: CompanyIncomeStatement) => company.operatingIncomeRatio,
   },
   {
      label: "Income Before Taxes Ratio",
      render: (company: CompanyIncomeStatement) => company.incomeBeforeTaxRatio,
   },
];

const IncomeStatement = (props: Props) => {
   const ticker = useOutletContext<string>();
   const [companyIncomeStatement, setCompanyIncomeStatement] =
      useState<CompanyIncomeStatement[]>();

   useEffect(() => {
      const getCompanyIncomeStatement = async () => {
         const response = await getIncomeStatement(ticker);
         setCompanyIncomeStatement(response?.data);
      };
      getCompanyIncomeStatement();
      // eslint-disable-next-line react-hooks/exhaustive-deps
   }, []);

   return (
      <>
         {companyIncomeStatement ? (
            <>
               {" "}
               <Table
                  configs={tableConfigs}
                  data={companyIncomeStatement}
               />
            </>
         ) : (
            <Spinner />
         )}
      </>
   );
};

export default IncomeStatement;
