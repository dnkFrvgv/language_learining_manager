import { TextField } from '@mui/material'
import React from 'react'
import { Language } from '../Models/Language/Language'

interface props{
  label: string,
  options: Language[],
  name: string,
  value: string,
  onChange: any
}

function Select({label, name, value, onChange, options}:props) {
  return (
    <TextField
      id="outlined-select-native"
      select
      fullWidth
      label={label}
      name={name}
      // value={value}
      SelectProps={{
        native: true,
      }}
      onChange={onChange}
        >
          {options.map((option) => (
            <option key={option.id} value={option.id}>
              {option.title}
            </option>
          ))}
        </TextField>
  )
}

export default Select