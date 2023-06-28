/** @jsxImportSource @emotion/react */
import React from 'react';
import Sidebar from '../Components/Sidebar';
import { css } from '@emotion/react';
import Header from '../Components/Header';
import { CssBaseline } from '@mui/material';

// width: '230px',
const content = css({
  paddingLeft: '230px',
  width: '100%',
})

function App() {

  return (
    <>
      <Sidebar/>
      <div css={content}>
        <Header title={'Dashboard'}/>

        <p>add a new language space</p>
      </div>
      <CssBaseline/>
  </>
  );
}

export default App;
