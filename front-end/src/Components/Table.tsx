// get testIncomeStatementData -- Table ☑

// remove all configs and adapt the component to be genric ☑

type Props = {
   configs: any;
   data: any;
};

const Table = ({ configs, data }: Props) => {
   const RenderedRows = data.map((row: any) => (
      <tr
         key={row.cik}
         className="text-left"
      >
         {configs.map((config: any) => (
            <td className="p-3">{config.render(row)}</td>
         ))}
      </tr>
   ));

   const RenderedHeaders = configs.map((config: any) => (
      <th
         key={config.label}
         className="p-4 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
      >
         {config.label}
      </th>
   ));

   return (
      <div className="bg-white shadow rounded-lg p-4 sm:p-6 xl:p-8 ">
         <table className="min-w-full divide-y divide-gray-200 m-5">
            <thead className="bg-gray-50">{RenderedHeaders}</thead>
            <tbody>{RenderedRows}</tbody>
         </table>
      </div>
   );
};

export default Table;
