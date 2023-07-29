import { styled, useTheme, Theme, CSSObject, createTheme, ThemeProvider } from '@mui/material/styles';
import Box from '@mui/material/Box';
import MuiDrawer from '@mui/material/Drawer';
import MuiAppBar, { AppBarProps as MuiAppBarProps } from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import List from '@mui/material/List';
import CssBaseline from '@mui/material/CssBaseline';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import InboxIcon from '@mui/icons-material/MoveToInbox';
import MailIcon from '@mui/icons-material/Mail';
import Sidebar from '../Components/Sidebar';
import { useMemo, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Tooltip } from '@mui/material';
import { Brightness4, Brightness7, Public } from '@mui/icons-material';

const drawerWidth = 240;

interface AppBarProps extends MuiAppBarProps {
  open?: boolean;
}

const AppBar = styled(MuiAppBar, {
  shouldForwardProp: (prop) => prop !== 'open',
})<AppBarProps>(({ theme, open }) => ({
  zIndex: theme.zIndex.drawer + 1,
  transition: theme.transitions.create(['width', 'margin'], {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen,
  }),
  ...(open && {
    marginLeft: drawerWidth,
    width: `calc(100% - ${drawerWidth}px)`,
    transition: theme.transitions.create(['width', 'margin'], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  }),
}));

export default function Dashboard2() {
  const [open, setOpen] = useState(false);
  const [dark, setDark] = useState(true);

  const handleDrawerOpen = () => {
    setOpen(true);
  };

  const darkTheme = useMemo(()=>
    createTheme({
      palette: {
        mode: dark ? 'dark' : 'light'
      }
    })  ,[dark])



  const navigate = useNavigate()

  return (
    <ThemeProvider theme={darkTheme}>

    <Box sx={{ display: 'flex' }}>
      <CssBaseline />
      <AppBar position="fixed" open={open}>
        <Toolbar>
          <IconButton
            color="inherit"
            aria-label="open drawer"
            onClick={handleDrawerOpen}
            edge="start"
            sx={{
              marginRight: 5,
              ...(open && { display: 'none' }),
            }}
          >
            <MenuIcon />
          </IconButton>

          <Tooltip title="Go to home page">
            <IconButton sx={{mr:1}} onClick={()=> navigate('/dashboard')}>
              <Public/>
            </IconButton>
          </Tooltip>

          <Typography variant="h6" noWrap component="div" sx={{flexGrow:1}}>
            Lingwistcx
          </Typography>

          <IconButton onClick={()=>setDark(!dark)} >
            {dark? <Brightness7/> : <Brightness4/>}

          </IconButton>
        </Toolbar>
      </AppBar>

      <Sidebar open={open} setOpen={setOpen}/>

    </Box>
    </ThemeProvider>

  );
}
