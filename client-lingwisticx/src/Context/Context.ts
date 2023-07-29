import { createContext } from "react";
import { LearningSpace } from "../Models/LearningSpace/LearningSpace";
import LearningSpacff from "../Models/LearningSpace/form";
import { User } from "../Models/User";
import { ILearningSpaceForm } from "../Interfaces/ILearningSpaceFrom";
import { Language } from "../Models/Language/Language";

export enum ThemeType{
  light='light',
  dark='dark'
}

export const INITIAL_STATE = {
  // currentUser: null,
  AllLanguages: [] as Language[],
  LearningSpaces: [] as LearningSpace[],
  theme: ThemeType.light,
  isLearningSpaceFormOpen: true
}

export type InitialState  = typeof INITIAL_STATE;

export const Context = createContext({
  state: INITIAL_STATE,
  // THEME
  toggleTheme: () => {},
  // LANGUAGE
  getAllLanguages: () => {},
  // LEARNING SPACE
  createLearningSpace: (values: ILearningSpaceForm) => {},
  closeLearningSpaceForm: () => {},
  openLearningSpaceForm: () => {},
});