// src/Styles/theme.ts
import { createTheme, Theme } from '@mui/material/styles';

export const getDesignTokens = (mode: 'light' | 'dark'): Theme =>
  createTheme({
    palette: {
      mode,
      primary: {
        main: '#1E88E5',
      },
      secondary: {
        main: '#6D7580',
      },
      error: {
        main: '#D32F2F',
      },
      background: {
        default: mode === 'light' ? '#F4F6F8' : '#121212',
        paper: mode === 'light' ? '#ffffff' : '#1E1E1E',
      },
      text: {
        primary: mode === 'light' ? '#212121' : '#ffffff',
        secondary: mode === 'light' ? '#5A5A5A' : '#B0BEC5',
      },
    },
    typography: {
      fontFamily: ['"Inter"', 'Roboto', 'Arial', 'sans-serif'].join(','),
    },
    components: {
      MuiButton: {
        styleOverrides: {
          root: {
            borderRadius: 6,
          },
        },
      },
    },
  });
