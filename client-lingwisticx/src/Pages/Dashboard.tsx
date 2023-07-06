import { Box, Button, Grid, Paper, Typography } from '@mui/material'
import React from 'react'
import LearningSpaceForm from '../Models/LearningSpace/LearningSpaceForm';
import ListLanguageSpaces from '../Components/ListLanguageSpaces'
import { Language } from '../Models/Language/Language';



function Dashboard() {

  const [languages, setlanguages] = React.useState<Language[]>([]);

  // React.useEffect(()=>{
  //   axios.get("http://localhost:5000/api/Languages")
  //   .then(response=>{
  //     setlanguagesAPIData(response.data)
  //     console.log(response.data)
  //   })
  // }, [])

  return (

    <Box>
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
                Learing Spaces
              </Typography>

              <Button sx={{ mb:2 }} size="small" variant="contained">Add Space</Button>
            </Box>


            <Paper sx={{width: '70%', p: 3 }}>
            {/* <ListLanguageSpaces/> */}
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