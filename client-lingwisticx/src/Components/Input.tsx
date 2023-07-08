/** @jsxImportSource @emotion/react */
import { createTheme, css, TextField } from '@mui/material'
import React from 'react'

interface props {
  // css: any
  label: string,
  name: string,
  value: string,
  onChange: any
}

const theme = createTheme();




function Input({label, name, value, onChange}: props) {



  return (
    <TextField
      fullWidth
      // css={inputStyle}
      variant='outlined'
      label={label}
      name={name}
      value={value}
      onChange={onChange}
    />
  )
}

export default Input