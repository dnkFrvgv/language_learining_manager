import { Grid, TextField } from '@mui/material'
import { DatePicker } from '@mui/x-date-pickers'
import React from 'react'


const initialFieldValues = {
  title: '',
  startDate: '',
}

function LanguageForm() {

  

  return (
    <form>
      <Grid container>
        <Grid item>
          <TextField 
            required 
            id="standard-basic" 
            label="Language" 
            variant="standard" />

        </Grid>
        <Grid item>

        {/* <DatePicker
          label="Date Started Learning"
          maxDate={new Date()}
          // value={value}
          // onChange={(newValue) => setValue(newValue)}
        /> */}
        </Grid>

      </Grid>

    </form>
  )
}

export default LanguageForm