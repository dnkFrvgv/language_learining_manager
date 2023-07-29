import { AddCircle, OpenInBrowser } from '@mui/icons-material'
import { IconButton } from '@mui/material'
import { useContextProvider } from '../../Context/Hook'
import LearningSpaceForm from '../../Models/LearningSpace/LearningSpaceForm'

function Main() {

  const {openLearningSpaceForm} = useContextProvider()

  return (
    <div>
      <IconButton title='Add Learning Space' onClick={openLearningSpaceForm}>
        <AddCircle/>
      </IconButton>

      Add Learning Space
      <LearningSpaceForm/>
    </div>
  )
}

export default Main