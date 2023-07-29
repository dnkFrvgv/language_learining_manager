import { ContextActionType } from "../Context/ActionsType";

export interface DispatchAction {
  type: ContextActionType;
  payload?: any;
}