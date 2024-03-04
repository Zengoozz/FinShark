import { SyntheticEvent } from "react";

import Card from "./Card";
import { CompanySearch } from "../../Types/Company";

import { v4 as uuidv4 } from "uuid";

interface Props {
  searchResults: CompanySearch[];
  onPortfolioCreate: (e: SyntheticEvent) => void;
}

const CardList: React.FC<Props> = ({ searchResults, onPortfolioCreate }: Props): JSX.Element => {
  return (
    <div>
      {searchResults.length > 0 ? (
        <div className="mt-10">
          {searchResults.map((card) => (
            <Card id={card.symbol} key={uuidv4()} companyModel={card} onPortfolioCreate={onPortfolioCreate} />
          ))}
        </div>
      ) : (
        <h1 className="mb-3 mt-3 text-xl font-semibold text-center md:text-xl">
          No Results!
        </h1>
      )}
    </div>
  );
};

export default CardList;
