/** @jsxImportSource @emotion/react */
import React from 'react';
import Sidebar from '../Components/Sidebar';
import { css } from '@emotion/react';
import Navbar from '../Components/Navbar';
import { Box, CssBaseline, Paper } from '@mui/material';
import LanguageForm from '../Models/LanguageForm';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'

// width: '230px',
const content = css({
  paddingLeft: '230px',
  width: '100%',
  backgroundColor: '#f2f2f2'
})

function App() {

  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <Sidebar/>
      <div css={content}>
        <Navbar title={'Dashboard'}/>

      </div>
      <CssBaseline/>
    </LocalizationProvider>
  );
}

export default App;
