// copy Configs --BalanceSheet ☑
// get ticker from outletContext --BalanceSheet ☑
// use useState to save the response from API --BalanceSheet ☑
// call the API_Method through UseEffect --BalanceSheet ☑
// render Conditionally if the data exist or not --BalanceSheet ☑
// render data through RatioList --BalanceSheet ☑
// add needed props through table component --BalanceSheet ☑

// add Spinner--LoadingSpinner ☑

import { useOutletContext } from "react-router";
import { CompanyBalanceSheet } from "../../Types/Company";
import { useEffect, useState } from "react";
import { getBalanceSheet } from "../../api";
import RatioList from "../RatioList";
import Spinner from "../Spinner";
import { formatLargeMonetaryNumber } from "../../Helpers/NumberFormatting";

type Props = {};

const config = [
   {
      label: <div className="font-bold">Total Assets</div>,
      render: (company: CompanyBalanceSheet) =>
         formatLargeMonetaryNumber(company.totalAssets),
   },
   {
      label: "Current Assets",
      render: (company: CompanyBalanceSheet) =>
         formatLargeMonetaryNumber(company.totalCurrentAssets),
   },
   {
      label: "Total Cash",
      render: (company: CompanyBalanceSheet) =>
         formatLargeMonetaryNumber(company.cashAndCashEquivalents),
   },
   {
      label: "Property & equipment",
      render: (company: CompanyBalanceSheet) =>
         formatLargeMonetaryNumber(company.propertyPlantEquipmentNet),
   },
   {
      label: "Intangible Assets",
      render: (company: CompanyBalanceSheet) =>
         formatLargeMonetaryNumber(company.intangibleAssets),
   },
   {
      label: "Long Term Debt",
      render: (company: CompanyBalanceSheet) =>
         formatLargeMonetaryNumber(company.longTermDebt),
   },
   {
      label: "Total Debt",
      render: (company: CompanyBalanceSheet) =>
         formatLargeMonetaryNumber(company.otherCurrentLiabilities),
   },
   {
      label: <div className="font-bold">Total Liabilites</div>,
      render: (company: CompanyBalanceSheet) =>
         formatLargeMonetaryNumber(company.totalLiabilities),
   },
   {
      label: "Current Liabilities",
      render: (company: CompanyBalanceSheet) =>
         formatLargeMonetaryNumber(company.totalCurrentLiabilities),
   },
   {
      label: "Long-Term Debt",
      render: (company: CompanyBalanceSheet) =>
         formatLargeMonetaryNumber(company.longTermDebt),
   },
   {
      label: "Long-Term Income Taxes",
      render: (company: CompanyBalanceSheet) =>
         formatLargeMonetaryNumber(company.otherLiabilities),
   },
   {
      label: "Stakeholder's Equity",
      render: (company: CompanyBalanceSheet) =>
         formatLargeMonetaryNumber(company.totalStockholdersEquity),
   },
   {
      label: "Retained Earnings",
      render: (company: CompanyBalanceSheet) =>
         formatLargeMonetaryNumber(company.retainedEarnings),
   },
];

const BalanceSheet = (props: Props) => {
   const ticker = useOutletContext<string>();
   const [companyBalanceSheet, setCompanyBalanceSheet] = useState<CompanyBalanceSheet>();
   useEffect(() => {
      debugger;
      const getCompantBalanceSheet = async () => {
         const response = await getBalanceSheet(ticker);
         setCompanyBalanceSheet(response?.data[0]);
      };
      getCompantBalanceSheet();
      // eslint-disable-next-line react-hooks/exhaustive-deps
   }, []);
   return (
      <>
         {companyBalanceSheet ? (
            <>
               <RatioList
                  data={companyBalanceSheet}
                  config={config}
               />
            </>
         ) : (
            <>
               <Spinner />
            </>
         )}
      </>
   );
};

export default BalanceSheet;
