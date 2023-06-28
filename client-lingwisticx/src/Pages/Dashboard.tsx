import { Box, Button, Grid, Paper, Typography } from '@mui/material'
import React from 'react'
import ListLanguageSpaces from '../Components/ListLanguageSpaces'



function Dashboard() {
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
                Language Spaces
              </Typography>

              <Button sx={{ mb:2 }} size="small" variant="contained">Add Space</Button>
            </Box>


            {/* <Paper > */}
            <ListLanguageSpaces/>
            {/* </Paper> */}

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