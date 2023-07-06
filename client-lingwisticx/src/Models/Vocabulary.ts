export interface Vocabulary{
  id: string,
  title: string,
  translation: string,
  example: string,
  tags: Tags[]
}

export interface Tags{
  id: string,
  title: string,
}

