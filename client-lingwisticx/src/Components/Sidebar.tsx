/** @jsxImportSource @emotion/react */
import React from 'react'
import { css } from '@emotion/react'


const styles = css({
  display: 'flex',
  flexDirection: 'column',
  position: 'absolute',
  width: '230px',
  height: '100%',
  backgroundColor: 'black'
})


function Sidebar() {
  return (
    <div css={styles}>Sidebar</div>
  )
}

export default Sidebar