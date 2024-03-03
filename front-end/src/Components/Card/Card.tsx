import { SyntheticEvent } from "react";
import { CompanySearch } from "../../Types/Company";
import AddPortfolio from "../Portfolio/AddPortfolio";

interface Props {
   id: string;
   companyModel: CompanySearch;
   onPortfolioCreate: (e: SyntheticEvent) => void;
}
const Card: React.FC<Props> = ({ id, companyModel, onPortfolioCreate }: Props): JSX.Element => {
   let { name, exchangeShortName, symbol, currency, stockExchange } = {
      ...companyModel,
   };
   return (
    <div
      className="flex flex-col items-center justify-between w-full p-6 bg-slate-100 rounded-lg md:flex-row"
      key={id}
      id={id}
    >
      <h2 className="font-bold text-center text-black md:text-left">
        {name} ({symbol})
      </h2>
      <p className="text-black">{currency}</p>
      <p className="font-bold text-black">
        {exchangeShortName} - {stockExchange}
      </p>
      <AddPortfolio
        onPortfolioCreate={onPortfolioCreate}
        symbol={symbol}
      />
    </div>
   );
};

export default Card;
