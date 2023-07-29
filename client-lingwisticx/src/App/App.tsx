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
import Dashboard2 from '../Pages/Dashboard2';
import Home from '../Pages/Home';

// width: '230px',
const content = css({
  // paddingLeft: '230px',
  // maxWidth: '100%',
  // minHeight: '100vh', 
  // backgroundColor: '#f2f2f2'
})

function App() {

  return (
      <main>
        {/* <Sidebar/> */}
        <div css={content}>
          <Navbar title={'Lingwisticx'}/>
        
          <Routes>
            <Route path="dashboard/*" Component={Dashboard2} />
            <Route path="*" Component={LearningSpace}/>
          </Routes>
        </div>
        {/* // <CssBaseline/> */}
      </main>
  );
}

export default App;
