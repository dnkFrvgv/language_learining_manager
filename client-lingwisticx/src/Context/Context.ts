import { createContext } from "react";
import { LearningSpace } from "../Models/LearningSpace/LearningSpace";
import LearningSpacff from "../Models/LearningSpace/form";
import { User } from "../Models/User";
import { ILearningSpaceForm } from "../Interfaces/LearningSpaceFrom";
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

  // theme
  toggleTheme: () => {},
  // languages

  // requestAllLanguages: () => {},

  // learning space
  createLearningSpace: (values: ILearningSpaceForm) => {},
  closeLearningSpaceForm: () => {},
  openLearningSpaceForm: () => {},
});