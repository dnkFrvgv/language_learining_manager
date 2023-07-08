/** @jsxImportSource @emotion/react */
import React from 'react';
import Sidebar from '../Components/Sidebar';
import { css } from '@emotion/react';
import Navbar from '../Components/Navbar';
import { Box, CssBaseline, Paper } from '@mui/material';
import LanguageForm from '../Models/Language/LanguageForm';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import Dashboard from '../Pages/Dashboard';
import LearningSpace from '../Pages/LanguageSpace';
import VocabularySpace from '../Pages/VocabularySpace';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Vocabulary from '../Pages/Vocabulary';
import SpaceStatistics from '../Pages/SpaceStatistics';
import GeneralStatistics from '../Pages/GeneralStatistics';
import PageNotFound from '../Pages/PageNotFound';
import LearningSpaceForm from '../Models/LearningSpace/LearningSpaceForm';

// width: '230px',
const content = css({
  paddingLeft: '230px',
  maxWidth: '100%',
  minHeight: '100vh', 
  backgroundColor: '#f2f2f2'
})

function App() {

  return (
      <main>
        <Sidebar/>
        <div css={content}>
          <Navbar title={'Lingwisticx'}/>
        
          <Routes>
            <Route path="/" Component={Dashboard} />
            <Route path="/dashboard" Component={Dashboard} />
            <Route path="/statistics" Component={GeneralStatistics} />
            <Route path="/learningspace/:language" Component={LearningSpace}/>
            <Route path="/learningspace/:language/vocabulary" Component={Vocabulary} />
            <Route path="/learningspace/:language/statistics" Component={SpaceStatistics} />
            <Route path="test" Component={LearningSpaceForm}/>
            <Route path="*" Component={PageNotFound}/>
          </Routes>
        </div>
        {/* // <CssBaseline/> */}
      </main>
  );
}

export default App;
