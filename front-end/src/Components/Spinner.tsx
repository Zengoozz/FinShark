// add Props (isLoading), pass it with default value of true --LoadingSpinner ☑
// add HTML Code --LoadingSpinner ☑
// import CSS file ☑
import "../assets/styles/Spinner.css"

import { ClipLoader } from "react-spinners";

type Props = {
   isLoading?: boolean;
};

const Spinner = ({ isLoading = true }: Props) => {
   return (
      <>
         <div id="loading-spinner">
            <ClipLoader
               color="#36d7b7"
               loading={isLoading}
               size={100}
               aria-label="loading spinner"
               data-testid="loader"
            />
         </div>
      </>
   );
};

export default Spinner;
