import { SyntheticEvent } from "react";
import { CompanySearch } from "../../Types/Company";
import Card from "./Card";

import { v4 as uuidv4 } from "uuid";

interface Props {
  searchResults: CompanySearch[];
  onPortfolioCreate: (e: SyntheticEvent) => void;
}
//#region  HashedStaticData
// const Descr: string =
//   "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Corporis itaque impedit excepturi. Assumenda, quas alias excepturi, accusantium rem consequuntur corporis repellat est ratione blanditiis totam ipsam possimus autem! Voluptas, numquam.";

// const CardsData: CardModel[] = [
//   {
//     CompanyName: "Microsoft",
//     ticker: "MS",
//     Img: "https://source.unsplash.com/3tYZjGSBwbk",
//     Price: 10000000,
//     Desc: Descr,
//   },
//   {
//     CompanyName: "Apple",
//     ticker: "APL",
//     Img: "https://source.unsplash.com/3tYZjGSBwbk",
//     Price: 5000000,
//     Desc: Descr,
//   },
//   {
//     CompanyName: "Oracle",
//     ticker: "ORC",
//     Img: "https://source.unsplash.com/3tYZjGSBwbk",
//     Price: 1000000,
//     Desc: Descr,
//   },
// ];
//#endregion

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
