interface Props {
   portfolioValue: string;
   onPortfolioDelete: (portfolioValue: string) => void;
}

const CardPortfolio = ({ portfolioValue, onPortfolioDelete }: Props) => {
   return (
      <div className="flex flex-col w-full p-8 space-y-4 text-center rounded-lg shadow-lg md:w-1/3">
         <p className="pt-6 text-xl font-bold">{portfolioValue}</p>
         <span className="mt-1 w-[35px] flex justify-center bg-red-700 rounded-[5px] hover:bg-red-900">
            <button
               className="font-semibold text-white"
               onClick={() => onPortfolioDelete(portfolioValue)}
            >
               X
            </button>
         </span>
      </div>
   );
};

export default CardPortfolio;
