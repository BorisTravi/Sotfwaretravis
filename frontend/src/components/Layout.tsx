// src/components/Layout.tsx
import React from "react";
import { Outlet, Link, useLocation } from "react-router-dom";
import { useColorMode } from "../Context/ThemeContext";
import {
  AppBar,
  Toolbar,
  Typography,
  Box,
  Drawer,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  Divider,
  Avatar,
  IconButton,
  Tooltip,
  useTheme,
} from "@mui/material";
import LightModeIcon from "@mui/icons-material/LightMode";
import DarkModeIcon from "@mui/icons-material/DarkMode";
import LogoutIcon from "@mui/icons-material/Logout";
import HomeIcon from "@mui/icons-material/Home";
import InventoryIcon from "@mui/icons-material/Inventory";
import PeopleIcon from "@mui/icons-material/People";
import ReceiptIcon from "@mui/icons-material/Receipt";
import SettingsIcon from "@mui/icons-material/Settings";

const drawerWidth = 80;

// Componente reutilizable para los ítems del menú
const MenuItem = ({
  to,
  icon: Icon,
  label,
}: {
  to: string;
  icon: React.ElementType;
  label: string;
}) => {
  const location = useLocation();
  const isSelected = location.pathname === to;

  return (
    <ListItem disablePadding>
      <Tooltip title={label} placement="right">
        <ListItemButton
          component={Link}
          to={to}
          sx={{
            backgroundColor: isSelected
              ? "rgba(30, 58, 138, 0.2)"
              : "transparent",
            justifyContent: "center",
          }}
          aria-label={label}
        >
          <ListItemIcon>
            <Icon sx={{ color: (theme: { palette: { primary: { main: any; }; }; }) => theme.palette.primary.main }} />
          </ListItemIcon>
        </ListItemButton>
      </Tooltip>
    </ListItem>
  );
};

const Layout = () => {
  const { toggleColorMode } = useColorMode();
  const theme = useTheme();

  return (
    <Box sx={{ display: "flex" }}>
      {/* AppBar */}
      <AppBar
        position="fixed"
        sx={{
          zIndex: (theme) => theme.zIndex.drawer + 1,
          backgroundColor: (theme) =>
            theme.palette.mode === "light"
              ? "#1e3a8a"
              : theme.palette.background.paper,
        }}
      >
        <Toolbar sx={{ display: "flex", justifyContent: "space-between" }}>
          <Typography variant="h6" noWrap>
            Facturación y Control de Ventas
          </Typography>
          <Tooltip title="Cambiar tema">
            <IconButton onClick={toggleColorMode} color="inherit">
              {theme.palette.mode === "dark" ? (
                <LightModeIcon />
              ) : (
                <DarkModeIcon />
              )}
            </IconButton>
          </Tooltip>
        </Toolbar>
      </AppBar>

      {/* Drawer */}
      <Drawer
        variant="permanent"
        sx={{
          width: drawerWidth,
          flexShrink: 0,
          "& .MuiDrawer-paper": {
            width: drawerWidth,
            boxSizing: "border-box",
            backgroundColor: (theme) => theme.palette.background.default,
          },
        }}
      >
        <Box sx={{ display: "flex", flexDirection: "column", height: "100%" }}>
          <Typography
            variant="h6"
            sx={{
              p: 2,
              textAlign: "center",
              color: "#1e3a8a",
              fontSize: "1rem",
            }}
          >
            bitepoint
          </Typography>
          <Divider />
          <List>
            {/* Ítems del menú */}
            <MenuItem to="/inicio" icon={HomeIcon} label="Inicio" />
            <MenuItem to="/productos" icon={InventoryIcon} label="Productos" />
            <MenuItem to="/clientes" icon={PeopleIcon} label="Clientes" />
            <MenuItem to="/facturacion" icon={ReceiptIcon} label="Facturación" />
            <MenuItem to="/configuracion" icon={SettingsIcon} label="Configuración" />
          </List>
          <Divider />
          <Box sx={{ mt: "auto", p: 1 }}>
            <Box sx={{ display: "flex", justifyContent: "center", mb: 1 }}>
              <Avatar
                sx={{
                  backgroundColor: (theme) =>
                    theme.palette.mode === "light"
                      ? "#1e3a8a"
                      : theme.palette.primary.main,
                  width: 40,
                  height: 40,
                  fontSize: "0.8rem",
                  color: (theme) =>
                    theme.palette.getContrastText(theme.palette.primary.main),
                }}
              >
                BT
              </Avatar>
            </Box>
            <ListItem disablePadding>
              <ListItemButton sx={{ justifyContent: "center" }} aria-label="Cerrar sesión">
                <ListItemIcon>
                  <LogoutIcon sx={{ color: "#1e3a8a" }} />
                </ListItemIcon>
              </ListItemButton>
            </ListItem>
          </Box>
        </Box>
      </Drawer>

      {/* Contenido principal */}
      <Box
        component="main"
        sx={{
          flexGrow: 1,
          p: 3,
          ml: `${drawerWidth}px`, // dejar espacio del menú
        }}
      >
        <Toolbar />
        <Outlet />
      </Box>
    </Box>
  );
};

export default Layout;
