import { SyntheticEvent } from "react";
import DeletePortfolio from "./DeletePortfolio";
import { Link } from "react-router-dom";

// Link portfolioName to CompanyPage-- preparing reactRouter ☑

interface Props {
   portfolioValue: string;
   onPortfolioDelete: (e: SyntheticEvent) => void;
}

const PortfolioCard = ({ portfolioValue, onPortfolioDelete }: Props) => {
   return (
      <div className="w-[100px] min-w-[100px] flex flex-col items-center p-8 space-y-4 text-center rounded-lg shadow-lg md:w-1/3">
         <Link to={`/company/${portfolioValue}`} className="pt-6 text-xl font-bold">{portfolioValue}</Link>
         <DeletePortfolio
            portfolioValue={portfolioValue}
            onPortfolioDelete={onPortfolioDelete}
         />
      </div>
   );
};

export default PortfolioCard;
