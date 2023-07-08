
import { Box, Grid } from '@mui/material'
import React from 'react'
import Header from '../Components/Header'

function LearningSpace() {
  return (
    <Box>
      <Grid container>
        <Grid item xs={12}>
          <Header title="German" subtitle="Learning Space"/>

        </Grid>

        <Grid item xs={8} >
          // stats
        </Grid>

        <Grid item xs={4} >
          // something
        </Grid>

        <Grid item xs={8}>
          //journals
          // writing
          // reading
          // vocabulary
          

        </Grid>
        <Grid item xs={4} >
          // something
        </Grid>
        
        // logtable

        // last 3 journals

      </Grid>
    </Box>

  )
}

export default LearningSpace