/** @jsxImportSource @emotion/react */

import { Box, css, Paper } from '@mui/material'
import React from 'react'

interface props {
  title: string
  subtitle: string

}

function Header({title, subtitle}: props) {
  return (
    <Box >
      <Paper sx={{p:3,}} css={headerStyle}>
        {title}
        
        {subtitle}
      </Paper>
    </Box>

  )
}

const headerStyle = css({
  minHeight: '100px',
})

export default Header