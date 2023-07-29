import { InitialState, INITIAL_STATE, ThemeType } from "./Context";
import { DispatchAction } from "../Interfaces/DispatchAction"
import { ContextActionType } from "./ActionsType";

export const ContextReducer = (state = INITIAL_STATE, action:DispatchAction): InitialState =>{
  switch (action.type) {
    case ContextActionType.ToggleTheme:
      return { ...state, theme: state.theme == ThemeType.light ? ThemeType.dark: ThemeType.light}

    case ContextActionType.OpenLearningSpaceForm: 
      return { ...state, isLearningSpaceFormOpen: true }

    case ContextActionType.CloseLearningSpaceForm: 
      return { ...state, isLearningSpaceFormOpen: false }
      
    case ContextActionType.CreateLearningSpace:
      return { ...state }
  
    default:
      throw new Error("Invalid Context Action type.");
  }
}