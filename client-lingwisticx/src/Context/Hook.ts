import { useContext } from "react";
import { Context } from "./Context";


export const useContextProvider = () =>{
  const context = useContext(Context);
  
  return context;
}