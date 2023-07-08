/** @jsxImportSource @emotion/react */
import React from 'react'
import { css } from '@emotion/react'
import { AppBar, Badge, Box, Button, Grid, IconButton, InputBase, Toolbar, Typography } from '@mui/material'
import NotificationsNoneIcon from '@mui/icons-material/NotificationsNone';
import SearchIcon from '@mui/icons-material/Search';
import axios from 'axios';
import { Language } from '../Models/Language/Language';


const searchInputStyle = css({
  opacity: '0.6',
  padding: "0px 5px",
  width: '100%',
  "&:hover":{
    backgroundColor: '#f2f2f2'
  },
  "& .MuiSvgIcon-root":{
    marginRight: '5px'
  }
})

const resultSearchInputStyle = css({
  position: 'absolute',
})

interface props {
  // setSearch: any
}

function SearchBar({}: props) {
  const [languagesAPIData, setlanguagesAPIData] = React.useState<Language[]>();
  
  
  const [searchResults, setSearchResults] = React.useState<Language[]>([]);
  const [inputValue, setInputValue] = React.useState("");

  React.useEffect(() => {
    axios.get("http://localhost:5000/api/Languages")
      .then(response=>{
        setlanguagesAPIData(response.data)
        console.log(response.data)
      })
    
  }, []);

  const filterData =(text: string)=>{
    if(text == ""){
      setSearchResults([]);
      return
    }
    const result = languagesAPIData && languagesAPIData.filter(
      ({title})=>{
        return title.toLocaleLowerCase().includes(text.toLocaleLowerCase())
      }) 
    
    result && setSearchResults(result);
  }

  const HandleInputChange=(text: string)=>{
    setInputValue(text);
    filterData(text);
  }

  return (
    <Box sx={{ flexGrow: 1, paddingLeft: '10px'}}>
      <Box sx={{ flexGrow: 1,color: "#000", display: { xs: 'none', sm: 'flex' }}}>
      <InputBase 
        placeholder="Search Learning Space"
        value={inputValue}
        onChange={(e)=> HandleInputChange(e.target.value)}
        startAdornment={<SearchIcon/>}
        css={searchInputStyle}
        />

      </Box>

      {searchResults.length > 0 &&
    
        <Box
        sx={{ flexGrow: 1, backgroundColor: "rgba(255, 255, 255, 0.8)", maxHeight: '300px', width: '50%', position: 'absolute', paddingLeft: '10px',color: "#000", display: { xs: 'none', sm: 'block' }}}
        >
          { searchResults.map( (result) => 
            <Box  css={{}}>
                <Button sx={{px:3 }}key={result.id} size="small">
              { result.title }
                </Button>
            </Box>
          ) }

        </Box>
      }
    </Box>
  )
}

export default SearchBar;