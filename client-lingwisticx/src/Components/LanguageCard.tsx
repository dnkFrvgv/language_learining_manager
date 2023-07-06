import { Card,CardContent,CardActions,Typography, Box, Button} from '@mui/material'
import React from 'react'
import { LearningSpace } from '../Models/LearningSpace/LearningSpace'

interface props{
  space: LearningSpace
}
function LearningSpaceCard({space}: props) {
  return (
    <>
    <Card sx={{marginRight:'15px', minWidth: 275, maxWidth: 275 }}>
      <CardContent>
        <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
          Word of the Day
        </Typography>
        <Typography variant="h5" component="div">
          {space.title}
        </Typography>
        <Typography sx={{ mb: 1.5 }} color="text.secondary">
          adjective
        </Typography>
        <Typography variant="body2">

          {space.description}
        </Typography>
      </CardContent>
      <CardActions>
        <Button size="small">See Space</Button>
      </CardActions>
    </Card>
    </>
  )
}

export default LearningSpaceCard