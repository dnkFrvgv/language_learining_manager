import { Card,CardContent,CardActions,Typography, Box, Button, CardMedia} from '@mui/material'
import React from 'react'
import { LearningSpace } from '../Models/LearningSpace/LearningSpace'

interface props{
  space: LearningSpace
}
function LearningSpaceCard({space}: props) {
  return (
    <>
    <Card sx={{marginRight:'15px', minWidth: 250, maxWidth: 250 }}>
      <CardContent sx={{height: "150px", display: 'flex', flexDirection: 'column', alignItems:"center"}}>

        <Typography variant="h5" component="div">
          {space.title}
        </Typography>
        <Typography sx={{ mb: 1.5 }} color="text.secondary">
          {space.language.title}
        </Typography>
        {/* <Typography variant="body2">

          {space.description}
        </Typography> */}
      </CardContent>
      <CardActions>
        <Button size="small">Go to Space</Button>
      </CardActions>
    </Card>
    </>
  )
}

export default LearningSpaceCard