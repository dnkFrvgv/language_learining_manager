import { DatePicker, LocalizationProvider } from '@mui/x-date-pickers'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import React from 'react'
import {} from '@mui/x-date-pickers/DatePicker'
import dayjs from 'dayjs';
import { width } from '@mui/system';

interface props {
  label: string,
  name: string,
  // value: Date,
  onChange: any
}
function DateInput({label, onChange, name, }: props) {
  return (
    <LocalizationProvider dateAdapter={AdapterDayjs} >
      {/* <DemoContainer components={['DatePicker']}> */}
        <DatePicker  
        disableFuture

        onChange={onChange}
        // value={dayjs(value)}
        label={label} />
      {/* </DemoContainer> */}
    </LocalizationProvider>
  )
}

export default DateInput