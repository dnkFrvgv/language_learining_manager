import { Close } from '@mui/icons-material'
import { Box, Dialog, TextField, DialogContent, DialogContentText, DialogTitle, IconButton, DialogActions, Button } from '@mui/material'
import React, { useEffect, useRef } from 'react'
import { useContextProvider } from '../../Context/Hook'


import dayjs, { Dayjs } from 'dayjs';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DateField } from '@mui/x-date-pickers/DateField';
import { ILearningSpaceForm } from '../../Interfaces/LearningSpaceFrom';


const initialFormValues: ILearningSpaceForm = {
  title: '',
  description: '',
  // startDate: '',
  // languageId: '' 
}


function LearningSpaceForm() {
  // get state
  const {state:{isLearningSpaceFormOpen}, closeLearningSpaceForm, createLearningSpace} = useContextProvider()

  // request languages 
  useEffect(()=>{


  }, [])

  // form values
  const [values, setValues] = React.useState(initialFormValues);

  // fields refs
  const titleRef = useRef()
  const descriptionRef = useRef()


  const handleSubmit = (e:React.FormEvent<HTMLFormElement>) =>{
    e.preventDefault();

    createLearningSpace(values);
  }

  return (
    <Dialog open={isLearningSpaceFormOpen} onClose={closeLearningSpaceForm}> 
      <DialogTitle>Create Learning Space
        <IconButton
          sx={{position: 'absolute', right: 10, top: 15}}
         onClick={closeLearningSpaceForm}>
          <Close/>
        </IconButton>
      </DialogTitle>

      <form onSubmit={handleSubmit}>
        <DialogContent dividers >
          <DialogContentText>Please fill in the fields bellow</DialogContentText>

          <TextField 
            autoFocus
            variant='standard'
            margin='normal'
            id='title'
            label="Title"
            type='text'
            fullWidth
            required
            // onChange={}
            inputRef={titleRef}
            inputProps={{minLenght:2}}
          />

          <TextField 
            variant='standard'
            margin='normal'
            id='description'
            label="Description"
            type='text'
            fullWidth
            inputRef={descriptionRef}
            inputProps={{minLenght:2}}
          />

          {/* <LocalizationProvider dateAdapter={AdapterDayjs}>
            <DemoContainer components={['DateField', 'DateField']}>
              <DateField
                label="Controlled field"
                value={value}
                onChange={(newValue) => setValue(newValue)}
              />
            </DemoContainer>
          </LocalizationProvider> */}
        </DialogContent>

        <DialogActions sx={{display: "flex", justifyContent:'center'}} >
          <Button variant='contained' type='submit'>Submit</Button>
        </DialogActions>
      </form>
      
    </Dialog>
  )
}

export default LearningSpaceForm