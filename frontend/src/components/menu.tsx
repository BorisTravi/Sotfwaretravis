import React, { useState } from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import Drawer from '@mui/material/Drawer';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Divider from '@mui/material/Divider';
import Avatar from '@mui/material/Avatar';
import LogoutIcon from '@mui/icons-material/Logout';
import DashboardIcon from '@mui/icons-material/Dashboard';
import MenuBookIcon from '@mui/icons-material/MenuBook';
import TableChartIcon from '@mui/icons-material/TableChart';
import AccountBalanceIcon from '@mui/icons-material/AccountBalance';
import SettingsIcon from '@mui/icons-material/Settings';
import MenuIcon from '@mui/icons-material/Menu';

const drawerWidth = 250;

const Menu = () => {
  const [open, setOpen] = useState(false);
  const [selected, setSelected] = useState('Dashboard'); // Estado para rastrear la pestaña activa

  const toggleDrawer = () => {
    setOpen(!open);
  };

  const handleSelection = (item: string) => {
    setSelected(item);
  };

  return (
    <Box sx={{ display: 'flex' }}>
      {/* AppBar */}
      <AppBar
        position="fixed"
        sx={{
          zIndex: (theme) => theme.zIndex.drawer + 1,
          backgroundColor: '#1e3a8a', // Azul oscuro
        }}
      >
        <Toolbar>
          <Button color="inherit" onClick={toggleDrawer} sx={{ minWidth: 'auto' }}>
            <MenuIcon />
          </Button>
          <Typography variant="h6" noWrap component="div" sx={{ ml: 2 }}>
            Facturacion y Control de Ventas
          </Typography>
        </Toolbar>
      </AppBar>

      {/* Drawer */}
      <Drawer
        variant="persistent"
        anchor="left"
        open={open}
        sx={{
          width: drawerWidth,
          flexShrink: 0,
          '& .MuiDrawer-paper': {
            width: drawerWidth,
            boxSizing: 'border-box',
            backgroundColor: '#e5e7eb', // Gris claro
          },
        }}
      >
        <Box sx={{ display: 'flex', flexDirection: 'column', height: '100%' }}>
          <Typography variant="h6" sx={{ p: 2, textAlign: 'center', color: '#1e3a8a' }}>
            bitepoint
          </Typography>
          <Divider />
          <List>
            <ListItem disablePadding>
              <ListItemButton
                onClick={() => handleSelection('Dashboard')}
                sx={{
                  backgroundColor: selected === 'Dashboard' ? 'rgba(30, 58, 138, 0.2)' : 'transparent',
                }}
              >
                <ListItemIcon>
                  <DashboardIcon sx={{ color: '#1e3a8a' }} />
                </ListItemIcon>
                <ListItemText primary="Dashboard" sx={{ color: '#1e3a8a' }} />
              </ListItemButton>
            </ListItem>
            <ListItem disablePadding>
              <ListItemButton
                onClick={() => handleSelection('Menu')}
                sx={{
                  backgroundColor: selected === 'Menu' ? 'rgba(30, 58, 138, 0.2)' : 'transparent',
                }}
              >
                <ListItemIcon>
                  <MenuBookIcon sx={{ color: '#1e3a8a' }} />
                </ListItemIcon>
                <ListItemText primary="Menu" sx={{ color: '#1e3a8a' }} />
              </ListItemButton>
            </ListItem>
            <ListItem disablePadding>
              <ListItemButton
                onClick={() => handleSelection('Table')}
                sx={{
                  backgroundColor: selected === 'Table' ? 'rgba(30, 58, 138, 0.2)' : 'transparent',
                }}
              >
                <ListItemIcon>
                  <TableChartIcon sx={{ color: '#1e3a8a' }} />
                </ListItemIcon>
                <ListItemText primary="Table" sx={{ color: '#1e3a8a' }} />
              </ListItemButton>
            </ListItem>
            <ListItem disablePadding>
              <ListItemButton
                onClick={() => handleSelection('Accounting')}
                sx={{
                  backgroundColor: selected === 'Accounting' ? 'rgba(30, 58, 138, 0.2)' : 'transparent',
                }}
              >
                <ListItemIcon>
                  <AccountBalanceIcon sx={{ color: '#1e3a8a' }} />
                </ListItemIcon>
                <ListItemText primary="Accounting" sx={{ color: '#1e3a8a' }} />
              </ListItemButton>
            </ListItem>
            <ListItem disablePadding>
              <ListItemButton
                onClick={() => handleSelection('Settings')}
                sx={{
                  backgroundColor: selected === 'Settings' ? 'rgba(30, 58, 138, 0.2)' : 'transparent',
                }}
              >
                <ListItemIcon>
                  <SettingsIcon sx={{ color: '#1e3a8a' }} />
                </ListItemIcon>
                <ListItemText primary="Settings" sx={{ color: '#1e3a8a' }} />
              </ListItemButton>
            </ListItem>
          </List>
          <Divider />
          <Box sx={{ mt: 'auto', p: 2 }}>
            <Box sx={{ display: 'flex', alignItems: 'center', mb: 2 }}>
              <Avatar sx={{ mr: 2, backgroundColor: '#1e3a8a' }}>BT</Avatar>
              <Box>
                <Typography variant="body1" sx={{ color: '#1e3a8a' }}>
                  Boris travi
                </Typography>
                <Typography variant="body2" color="textSecondary">
                    Administrador
                </Typography>
              </Box>
            </Box>
            <ListItem disablePadding>
              <ListItemButton>
                <ListItemIcon>
                  <LogoutIcon sx={{ color: '#1e3a8a' }} />
                </ListItemIcon>
                <ListItemText primary="Logout" sx={{ color: '#1e3a8a' }} />
              </ListItemButton>
            </ListItem>
          </Box>
        </Box>
      </Drawer>

      {/* Main Content */}
      <Box
        component="main"
        sx={{
          flexGrow: 1,
          p: 3,
          ml: open ? `${drawerWidth}px` : 0,
          transition: (theme) =>
            theme.transitions.create('margin', {
              easing: theme.transitions.easing.sharp,
              duration: theme.transitions.duration.leavingScreen,
            }),
        }}
      >
        <Toolbar />
        <Typography paragraph>
          Aquí va el contenido principal de tu aplicación.
        </Typography>
      </Box>
    </Box>
  );
};

export default Menu;