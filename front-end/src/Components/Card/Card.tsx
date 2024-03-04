import { SyntheticEvent } from "react";
import { CompanySearch } from "../../Types/Company";
import AddPortfolio from "../Portfolio/AddPortfolio";
import { Link } from "react-router-dom";
// Link name to companyPage-- preparing reactRouter ☑
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
      <Link to={`/company/${symbol}`} className="font-bold text-center text-black md:text-left">
        {name} ({symbol})
      </Link>
      <p className="mx-5 text-black uppercase">{currency}</p>
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
