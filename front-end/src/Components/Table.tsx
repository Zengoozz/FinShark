// get testIncomeStatementData -- Table ☑

import { testIncomeStatementData } from "../assets/TestData";

interface Props {}
const data = testIncomeStatementData;

type Company = (typeof data)[0];
type Config = {
   label: string;
   render: (company: Company) => string;
};

const Configs = [
   {
      label: "Year",
      render: (company: Company) => company.acceptedDate,
   },
   {
      label: "Cost of revenue",
      render: (company: Company) => company.costOfRevenue.toString(),
   },
];

const Table = (props: Props) => {
   const RenderedRows = data.map((company: Company) => (
      <tr key={company.cik} className="text-left">
         {Configs.map((config: Config) => (
            <td className="p-3">{config.render(company)}</td>
         ))}
      </tr>
   ));

   const RenderedHeaders = Configs.map((config: Config) => (
      <th
         key={config.label}
         className="p-3 text-left"
      >
         {config.label}
      </th>
   ));

   return (
      <table>
         <thead>
            <tr>{RenderedHeaders}</tr>
         </thead>
         <tbody>{RenderedRows}</tbody>
      </table>
   );
};

export default Table;
