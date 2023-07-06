/** @jsxImportSource @emotion/react */
import { FormControl } from '@mui/base';
import { createTheme, css, Grid } from '@mui/material';
import axios from 'axios';
import React from 'react'
import Input from '../../Components/Input';
import Select from '../../Components/Select';
import { Language } from '../Language/Language';


const initialFormValues = {
  // id: 0
  title: '',
  description: '',
  startDate: new Date(),
  languageId: '' 
}



function LearningSpaceForm() {

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

  const [values, setValues] = React.useState(initialFormValues);

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
          <Input 
              label='Description' 
              value={values.description}
              onChange={HandleInputChange}
              name='description'
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
            label='What date you started learning this language?' 
            value={values.startDate.toDateString()}
            onChange={HandleInputChange}
            name='startDate'
          />
        </Grid>

      </Grid>
      </form>
    }   </> 
  
  )
}

export default LearningSpaceForm