/** @jsxImportSource @emotion/react */
import { FormControl } from '@mui/base';
import { Button, createTheme, css, Grid } from '@mui/material';
import axios from 'axios';
import React from 'react'
import DateInput from '../../Components/DateInput';
import Input from '../../Components/Input';
import Select from '../../Components/Select';
import { Language } from '../Language/Language';
import { DatePicker, LocalizationProvider } from '@mui/x-date-pickers'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import moment from "moment";

const initialFormValues = {
  title: '',
  description: '',
  startDate: '',
  languageId: '' 
}



function LearningSpacff() {

  const [languages, setLanguages] = React.useState<Language[]>();

  React.useEffect(()=>{
    axios.get("http://localhost:5000/api/Languages")
    .then(response=>{
      setLanguages(response.data)
      console.log(response.data)
    })
  
  },[])



  const HandleInputChange = (change: React.ChangeEvent<HTMLInputElement>)=>{
    const {name, value} = change.target;
    
    setValues({
      ...values,
      [name] : value
    })
    
  }

  const HandleDateChange = (change: Date)=>{
    setValues({
      ...values,
      ["startDate"] : moment(change).format('YYYY-MM-DD')
    })
  }


  const [values, setValues] = React.useState(initialFormValues);

  const SendForm=()=>{
    
    axios.post("http://localhost:5000/api/LearningSpace", values)
    .then(response=>{
      console.log(response.data)
      console.log(response.status)
    })
  }

  return (
    <>
    {languages &&
    
      
      <form >


      <Grid container spacing={2}>
        <Grid item xs={6}>

          <Input 
            label="Name of this learning space"
            value={values.title}
            onChange={HandleInputChange}
            name='title'
            />
        </Grid>
        <Grid item xs={6}>
          <DateInput
            label="What day you started learning ?"
            name="startDate"
            // value={}
            onChange={HandleDateChange}
            />
        </Grid>

        <Grid item xs={6}>

        <Select 
          label='What Language are you learning?' 
          value={values.languageId}
          onChange={HandleInputChange}
          name='languageId'
          options={languages}
          />
        </Grid>
        <Grid item xs={6}>
        <Input 
          label='Description' 
          value={values.description}
          onChange={HandleInputChange}
          name='description'
        />
          {/* <Input 
            label='What date you started learning this language?' 
            value={values.startDate.toDateString()}
            onChange={HandleInputChange}
            name='startDate'
          /> */}
        </Grid>

        <Grid>
          <Button onClick={SendForm} size="small">Create</Button>
        </Grid>


      </Grid>
      </form>
    }   </> 
  
  )
}

export default LearningSpacff