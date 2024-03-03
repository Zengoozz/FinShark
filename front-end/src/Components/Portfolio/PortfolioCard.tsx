import { SyntheticEvent } from "react";
import DeletePortfolio from "./DeletePortfolio";

interface Props {
   portfolioValue: string;
   onPortfolioDelete: (e: SyntheticEvent) => void;
}

const PortfolioCard = ({ portfolioValue, onPortfolioDelete }: Props) => {
   return (
      <div className="w-[100px] min-w-[100px] flex flex-col items-center p-8 space-y-4 text-center rounded-lg shadow-lg md:w-1/3">
         <p className="pt-6 text-xl font-bold">{portfolioValue}</p>
         <DeletePortfolio
            portfolioValue={portfolioValue}
            onPortfolioDelete={onPortfolioDelete}
         />
      </div>
   );
};

export default PortfolioCard;
