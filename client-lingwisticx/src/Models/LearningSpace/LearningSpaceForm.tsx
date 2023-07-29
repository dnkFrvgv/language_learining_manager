import { Close } from '@mui/icons-material'
import { Box, Dialog, TextField, DialogContent, DialogContentText, DialogTitle, IconButton, DialogActions, Button, MenuItem } from '@mui/material'
import React, { useEffect, useRef } from 'react'
import { useContextProvider } from '../../Context/Hook'


import dayjs, { Dayjs } from 'dayjs';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DateField } from '@mui/x-date-pickers/DateField';
import { ILearningSpaceForm } from '../../Interfaces/ILearningSpaceFrom';
import DateInput from '../../Components/DateInput';
import SelectField from '../../Components/Select';

import moment from "moment";
import { Language } from '../Language/Language';

const initialFormValues: ILearningSpaceForm = {
  title: '',
  description: '',
  startDate: '',
  languageId: '' 
}


function LearningSpaceForm() {
  // GET STATE
  const {
    state:{isLearningSpaceFormOpen, AllLanguages }, closeLearningSpaceForm, 
    createLearningSpace,
    getAllLanguages

  
  } = useContextProvider()

  // const AllLanguages: Language[] = [
  //   {title: "English", id: 'ffff'},
  //   {title: "French", id: 'fff22f'},
  //   {title: "German", id: 'fff221f'},
  //   {title: "German1", id: 'fff221f'},
  //   {title: "German2", id: 'fadfaf221f'},
  //   {title: "German3", id: 'fffa221f'},
  //   {title: "German4", id: 'fff2sg21f'},
  //   {title: "German5", id: 'fsff221f'},
  // ]

  
  // UPDATE ALL LANGUAGES
  useEffect(()=>{
    if(AllLanguages.length == 0){
      getAllLanguages();
    }
  }, [])

  // FORM VALUES
  const [values, setValues] = React.useState(initialFormValues);

  const handleSubmit = (e:React.FormEvent<HTMLFormElement>) =>{
    e.preventDefault();

    createLearningSpace(values);
    closeLearningSpaceForm();
  }

  const HandleInputChange = (change: React.ChangeEvent<HTMLInputElement>)=>{
    const {name, value} = change.target;
    
    setValues({
      ...values,
      [name] : value
    })
    
  }

  const HandleDateChange = (date: Date)=>{
    setValues({
      ...values,
      ["startDate"] : moment(date).format('YYYY-MM-DD')
    })
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

      {AllLanguages.length > 0 && <>
        <form onSubmit={handleSubmit}>
          <DialogContent dividers >
            <DialogContentText>Please fill in the fields bellow</DialogContentText>

            <TextField 
              autoFocus
              variant='standard'
              margin='normal'
              name='title'
              label="Title"
              type='text'
              fullWidth
              required
              value={values.title}
              onChange={HandleInputChange}
              // inputRef={titleRef}
              inputProps={{minLenght:2}}
            />

            <TextField 
              variant='standard'
              margin='normal'
              name='description'
              label="Description"
              type='text'
              fullWidth
              value={values.description}
              onChange={HandleInputChange}
              // inputRef={descriptionRef}
              inputProps={{minLenght:2}}
            />

            <TextField
              id="languageId"
              fullWidth
              select
              required
              name='languageId'
              label="Select Language"
              onChange={HandleInputChange}
              variant="standard"
            >
              {AllLanguages.map((option) => (
                <MenuItem key={option.id} value={option.id}>
                  {option.title}
                </MenuItem>
              ))}
            </TextField>            

            <DateInput
              label="Date started studying"
              name="startDate"
              onChange={HandleDateChange}
            />

          </DialogContent>

          <DialogActions sx={{display: "flex", justifyContent:'center'}} >
            <Button variant='contained' type='submit'>Submit</Button>
          </DialogActions>
        </form>
      </>    }

      
    </Dialog>
  )
}

export default LearningSpaceForm