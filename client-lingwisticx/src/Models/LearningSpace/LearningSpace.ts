import { Language } from "../Language/Language"

export interface LearningSpace {
  id: string,
  title: string,
  description: string,
  startDate: string,
  lastUdpatedDate: string,
  languageId: string
  language: Language
}