import { Card,CardContent,CardActions,Typography, Box, Button, Grid} from '@mui/material'
import axios from 'axios'
import React from 'react'
import { Language } from '../Models/Language';
import LanguageCard from './LanguageCard'

function ListLanguageSpaces() {
  const [languagesList, setlanguagesList] = React.useState<Language[]>();

  React.useEffect(()=>{
    axios.get("http://localhost:5000/api/languages")
      .then(response=>{
        setlanguagesList(response.data)
        console.log(response.data)
      })
    
  }, [])



  return (
    <Box sx={{ flexGrow: 1, overflow: 'scroll', display: { xs: 'none', sm: 'flex' }}}>
      
      { 
        languagesList && languagesList.map((language)=> <LanguageCard language={language}/>)
      }

    </Box>
  )
}

export default ListLanguageSpaces