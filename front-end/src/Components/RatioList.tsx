import { TestDataCompany } from "../assets/TestData";

type Props = {};

const data = TestDataCompany[0];

type Company = typeof data;

const Configs = [
   {
      label: "Company Name",
      render: (company: Company) => company.companyName,
   },
   {
      label: "DCF",
      render: (company: Company) => company.dcf,
      subTitle: "This is the value of an investment today based on future cash flows",
   },
];

const RatioList = (props: Props) => {
   const renderedTile = Configs.map((tile) => {
      return (
         <li className="py-3 sm:py-4">
            <div className="flex items-center space-x-4">
               <div className="flex-1 min-w-0">
                  <p className="text-sm font-medium text-gray-900 truncate">
                     {tile.label}
                  </p>
                  <p className="text-sm text-gray-500 truncate">
                     {/* <a
                        href="/cdn-cgi/l/email-protection"
                        className="__cf_email__"
                        data-cfemail="17727a767e7b57607e7973646372653974787a"
                     > */}
                        {tile.subTitle && tile.subTitle}
                     {/* </a> */}
                  </p>
                  <div className="inline-flex items-center text-base font-semibold text-gray-900">
                     {tile.render(data)}
                  </div>
               </div>
            </div>
         </li>
      );
   });
   return (
      <div className="bg-white shadow rounded-lg mb-4 p-4 sm:p-6 h-full">
         <ul className="divide-y divide-gray-200">{renderedTile}</ul>
      </div>
   );
};

export default RatioList;
