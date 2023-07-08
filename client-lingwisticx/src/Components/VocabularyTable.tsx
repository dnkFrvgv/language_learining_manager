import { Paper, Table, TableBody } from '@mui/material'
import React from 'react'
import { Vocabulary } from '../Models/Vocabulary'

interface props{
  data: Vocabulary[],
}

function VocabularyTable() {
  return (
    <Paper sx={{width: '100%', p:3}}>
      <Table>
        <TableBody>
          
        </TableBody>
      </Table>

    </Paper>
  )
}

export default VocabularyTable