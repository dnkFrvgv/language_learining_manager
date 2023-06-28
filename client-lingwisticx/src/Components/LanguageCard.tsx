import { Card,CardContent,CardActions,Typography, Box, Button} from '@mui/material'
import React from 'react'
import { Language } from '../Models/Language'

interface props{
  language: Language
}
function LanguageCard({language}: props) {
  return (
    <>
    <Card sx={{marginRight:'15px', minWidth: 275, maxWidth: 275 }}>
      <CardContent>
        <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
          Word of the Day
        </Typography>
        <Typography variant="h5" component="div">
          {language.title}
        </Typography>
        <Typography sx={{ mb: 1.5 }} color="text.secondary">
          adjective
        </Typography>
        <Typography variant="body2">
          well meaning and kindly.
          <br />
          {'"a benevolent smile"'}
        </Typography>
      </CardContent>
      <CardActions>
        <Button size="small">See Space</Button>
      </CardActions>
    </Card>
    </>
  )
}

export default LanguageCard