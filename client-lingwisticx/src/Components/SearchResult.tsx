import { Language } from '../Models/Language';
/** @jsxImportSource @emotion/react */
import React from 'react'
import { css } from '@emotion/react'

const s = css({
  backgroundColor: "#000",
  position: 'absolute',
})

interface props {
  results: Language[]
}
function SearchResult({results}:props) {
  return (
    <div css={s}>
      { results.map( (result) => <li key={result.id}>{ result.title }</li>) }
    </div>
  )
}

export default SearchResult;