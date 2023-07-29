/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import Navbar from '../Components/Navbar';
import LearningSpace from '../Pages/LanguageSpace';
import { Route, Routes } from 'react-router-dom';
import Dashboard2 from '../Pages/Dashboard2';
import { useContextProvider } from '../Context/Hook';


// width: '230px',
const content = css({
  // paddingLeft: '230px',
  // maxWidth: '100%',
  // minHeight: '100vh', 
  // backgroundColor: '#f2f2f2'
})

function App() {

  const {state} = useContextProvider();

  return (
      <main>
        <div css={content}>
          {/* <Navbar title={'Lingwisticx'}/> */}
        
          <Routes>
            <Route path="dashboard/*" Component={Dashboard2} />
            <Route path="*" Component={LearningSpace}/>
          </Routes>
        </div>
      </main>
  );
}

export default App;
