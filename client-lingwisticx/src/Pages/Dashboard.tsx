import { Box, Button, Grid, Paper, Typography } from '@mui/material'
import React from 'react'
import ListLearningSpaces from '../Components/ListLanguageSpaces'

import { useNavigate } from 'react-router-dom';
import LearningSpaceForm from '../Models/LearningSpace/LearningSpaceForm';

function Dashboard() {
  const navigate = useNavigate();

  const ShowForm = ()=>{
    navigate('/test');
  }

  return (

    <Box >
      <Grid container>

        <Grid item xs={7}>
          <Paper sx={{ mt: 3,mx: 3, p:3 }}>
            // top content 
          </Paper>
        </Grid>

        <Grid item xs={12} >
          <Box sx={{ pt:2, px:3 }}>
            <Box sx={{display: {sm:'flex'}, justifyContent:'space-between'}}>
              <Typography
                variant="h6"
                noWrap
                component="div"    
                sx={{ pb:2 }}        
              >
                Learning Spaces
              </Typography>

              <Button onClick={ShowForm} sx={{ mb:2 }} size="small" variant="contained">Add Space</Button>
            </Box>


            <ListLearningSpaces/>
            <Paper sx={{width: '60%', p: 3 }}> 
              <LearningSpaceForm/>
            </Paper>

          </Box>


        </Grid>

        <Grid item xs={12}>
          <Paper sx={{ mt: 3, mx: 3, p:3 }}>
          // table with last progress logs or just statistic meh
          </Paper>

        </Grid>

      </Grid>
      






    
    </Box>

  )
}

export default Dashboard