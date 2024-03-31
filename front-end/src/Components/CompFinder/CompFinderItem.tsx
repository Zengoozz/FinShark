// pass ticker in props --CompFinder ☑
// render link [reloadDocument] to [companyProfile] type [button] style [inline-flex items-center p-4 rounded-l-lg] --CompFinder ☑

import { Link } from "react-router-dom";

type Props = {
   ticker: string;
};

const CompFinderItem = ({ ticker }: Props) => {
   return (
      <Link
         to={`/company/:${ticker}/company-profile`}
         reloadDocument
         type="button"
         className="inline-flex items-center p-4 rounded-l-lg"
      >
         {ticker}
      </Link>
   );
};

export default CompFinderItem;
