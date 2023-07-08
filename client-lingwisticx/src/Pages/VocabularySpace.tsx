import { Grid, Paper } from '@mui/material'
import { Box } from '@mui/system'
import React from 'react'

import Header from '../Components/Header'
import VocabularyTable from '../Components/VocabularyTable'

function VocabularySpace({}) {
  return (  
    <Box>
      {/* <Header title='Vocabulary' subtitle='German'/> */}

      <Grid container >
        <Grid item sm={12} sx={{m: 3}}>
          <VocabularyTable/>

        </Grid>

      </Grid>
    </Box>

    )
}

export default VocabularySpace