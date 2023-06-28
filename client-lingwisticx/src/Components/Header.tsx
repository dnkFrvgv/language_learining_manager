/** @jsxImportSource @emotion/react */
import React from 'react'
import { css } from '@emotion/react'
import { AppBar, Badge, Box, Grid, IconButton, InputBase, Toolbar, Typography } from '@mui/material'
import NotificationsNoneIcon from '@mui/icons-material/NotificationsNone';
import SearchIcon from '@mui/icons-material/Search';
import HeaderSearchBar from './HeaderSearchBar';
import SearchResult from './SearchResult';
import { Language } from '../Models/Language';

const headerStyle = css({
  backgroundColor: '#fff'
})


const pages = [
  "Home", "Pets", "Gallery"
]

interface props{
  title: string
}


function Header({title}:props) {

  const [searchResult, setSearchResult] = React.useState<Language[]>([]);

  return (
    <Box sx={{ flexGrow: 1 }}>

      <AppBar position='static' css={headerStyle}>
        <Toolbar>
          <Grid container>
            <Grid item>
              <Box sx={{ flexGrow: 1,color: "#000", display: { xs: 'none', sm: 'flex' }}}>
                <Typography
                  variant="h6"
                  noWrap
                  component="div"            
                >
                  {title}
                </Typography>

              </Box>
            </Grid>
            <Grid item sm>
              <HeaderSearchBar/>
              <SearchResult results={searchResult} />

            </Grid>

            <Grid item>
            <Box sx={{ flexGrow: 1, color: "#000", display: { xs: 'none', sm: 'block' } }}>

              <IconButton >
                <Badge badgeContent={5} color="secondary">
                  <NotificationsNoneIcon/>
                </Badge>
              </IconButton>
              </Box>
            </Grid>

          </Grid>

          {/* 
            

             */}
        </Toolbar>

      </AppBar>
    </Box>

    )
}

export default Header;