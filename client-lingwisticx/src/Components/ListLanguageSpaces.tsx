import { Card,CardContent,CardActions,Typography, Box, Button, Grid} from '@mui/material'
import axios from 'axios'
import React from 'react'
import { Language } from '../Models/Language/Language';
import { LearningSpace } from '../Models/LearningSpace/LearningSpace';
import LearningSpaceCard from './LearningSpaceCard'

function ListLearningSpaces() {
  const [learningSpaceList, setlearningSpaceList] = React.useState<LearningSpace[]>();

  // React.useEffect(()=>{
  //   axios.get("http://localhost:5000/api/LearningSpace")
  //     .then(response=>{
  //       if (response.data.length > 0){
  //         setlearningSpaceList(response.data)
  //       }
  //     })
    
  // }, [])



  return (
    <Box sx={{ flexGrow: 1, overflow: 'scroll', display: { xs: 'none', sm: 'flex' }}}>
      
      { 
        learningSpaceList && learningSpaceList.map((space)=> <LearningSpaceCard space={space}/>)
      }

      {
        !learningSpaceList && <>You don't have any Learning Spaces :(</>
      }

    </Box>
  )
}

export default ListLearningSpaces