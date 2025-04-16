import React, { useState, useEffect, useCallback } from "react";
import EditIcon from "@mui/icons-material/Edit";
import PersonAddIcon from "@mui/icons-material/PersonAdd";
import Logo from "../assets/logo.png";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { useTheme } from "@mui/material/styles"; //
import {
  Box,
  Typography,
  TextField,
  Button,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  IconButton,
  MenuItem,
  Select,
  InputLabel,
  FormControl,
  Divider,
} from "@mui/material";
import AddIcon from "@mui/icons-material/Add";
import DeleteIcon from "@mui/icons-material/Delete";
//import '@fontsource/inter';

interface Product {
  numeroParte: string; // Nuevo campo para el número de parte
  descripcion: string;
  cantidad: number;
  precio: number;
  descuento: number; // Descuento en porcentaje
  subtotal: number;
}

interface Totals {
  subtotal: number;
  igv: number;
  total: number;
}

const Facturacion: React.FC = () => {
  const theme = useTheme();
  const isDark = theme.palette.mode === "dark";

  // Lista de productos con precios preestablecidos
  const listaPrecios = [
    {
      codigo: "P001",
      numeroParte: "NP001",
      descripcion: "Producto 1",
      precio: 10.0,
    },
    {
      codigo: "P002",
      numeroParte: "NP002",
      descripcion: "Producto 2",
      precio: 20.0,
    },
    {
      codigo: "P003",
      numeroParte: "NP003",
      descripcion: "Producto 3",
      precio: 30.0,
    },
  ];

  const [productos, setProductos] = useState<Product[]>([]);
  const [totales, setTotales] = useState<Totals>({
    subtotal: 0,
    igv: 0,
    total: 0,
  });
  const [editandoIndex, setEditandoIndex] = useState<number | null>(null);
  const [descripcionTemp, setDescripcionTemp] = useState<string>("");

  const calcularTotales = useCallback((productosActualizados: Product[]) => {
    try {
      const subtotal = productosActualizados.reduce(
        (sum, p) => sum + p.subtotal,
        0
      );
      const igv = subtotal * 0.18;
      const total = subtotal + igv;
      setTotales({ subtotal, igv, total });
    } catch (error) {
      console.error("Error al calcular los totales:", error);
    }
  }, []);

  useEffect(() => {
    calcularTotales(productos);
  }, [productos, calcularTotales]);

  const handleProductoChange = useCallback(
    (index: number, field: keyof Product, value: string | number) => {
      setProductos((prev) =>
        prev.map((producto, i) => {
          if (i !== index) return producto;

          const updated = {
            ...producto,
            [field]:
              field === "cantidad" ||
              field === "precio" ||
              field === "descuento"
                ? Math.max(0, parseFloat(value as string) || 0) // Evitar valores negativos
                : value,
          };

          const subtotal =
            updated.cantidad *
            updated.precio *
            (1 - (updated.descuento || 0) / 100);

          return {
            ...updated,
            subtotal,
          };
        })
      );
    },
    []
  );

  const agregarProducto = useCallback(() => {
    // Simula la selección de un producto de la lista
    const productoSeleccionado = listaPrecios[0]; // Cambiar según la lógica de selección

    setProductos((prev) => [
      ...prev,
      {
        numeroParte: productoSeleccionado.numeroParte,
        descripcion: productoSeleccionado.descripcion,
        cantidad: 1,
        precio: productoSeleccionado.precio,
        descuento: 0,
        subtotal: productoSeleccionado.precio,
      },
    ]);
  }, []);

  const eliminarProducto = useCallback((index: number) => {
    setProductos((prev) => prev.filter((_, i) => i !== index));
  }, []);

  const limpiarFactura = useCallback(() => {
    if (window.confirm("¿Estás seguro de que deseas limpiar la factura?")) {
      setProductos([
        {
          numeroParte: "",
          descripcion: "",
          cantidad: 1,
          precio: 0,
          descuento: 0,
          subtotal: 0,
        },
      ]);
      setTotales({ subtotal: 0, igv: 0, total: 0 });
    }
  }, []);

  const anularFactura = () => {
    if (window.confirm("¿Estás seguro de que deseas anular la factura?")) {
      alert("Factura anulada");
    }
  };

  return (
    <Box
      sx={{
        p: 3,
        backgroundColor: "background.paper",
        borderRadius: 2,
        boxShadow: theme.palette.mode === "dark" ? 1 : 2,
      }}
    >
      <Box sx={{ display: "flex", alignItems: "center", mb: 3 }}>
        <img src={Logo} alt="Logo" style={{ height: 40, marginRight: 16 }} />
        <Typography variant="h5" sx={{ fontWeight: "bold", color: "#1e3a8a" }}>
          Facturación Electrónica
        </Typography>
      </Box>

      {/* Información de la factura */}
      <Paper elevation={2} sx={{ p: 3, mb: 3 }}>
        <Typography variant="subtitle1" sx={{ fontWeight: "bold", mb: 2 }}>
          Información de la Factura
        </Typography>
        <Box
          sx={{
            display: "grid",
            gridTemplateColumns: "repeat(4, 1fr)",
            gap: 2,
          }}
        >
          <FormControl fullWidth size="small">
            <InputLabel>Tipo Documento</InputLabel>
            <Select defaultValue="FACTURA" label="Tipo Documento">
              <MenuItem value="FACTURA">Factura</MenuItem>
              <MenuItem value="BOLETA">Boleta</MenuItem>
            </Select>
          </FormControl>
          <TextField label="Serie" size="small" defaultValue="F001" />
          <TextField label="Correlativo" size="small" defaultValue="0005" />
          <FormControl fullWidth size="small">
            <InputLabel>Moneda</InputLabel>
            <Select defaultValue="Soles" label="Moneda">
              <MenuItem value="Soles">Soles</MenuItem>
              <MenuItem value="Dólares">Dólares</MenuItem>
            </Select>
          </FormControl>
          <TextField
            label="Fecha"
            type="date"
            size="small"
            InputLabelProps={{ shrink: true }}
          />
          <TextField
            label="F. Vencimiento"
            type="date"
            size="small"
            InputLabelProps={{ shrink: true }}
          />
        </Box>
      </Paper>

      {/* Cliente */}
      <Paper elevation={2} sx={{ p: 3, mb: 3 }}>
        <Typography variant="subtitle1" sx={{ fontWeight: "bold", mb: 2 }}>
          Información del Cliente
        </Typography>
        <Box sx={{ display: "grid", gridTemplateColumns: "3fr 1fr", gap: 2 }}>
          <TextField
            label="Cliente"
            size="small"
            placeholder="Buscar cliente por RUC o razón social"
          />
          <Button
            variant="contained"
            size="small"
            startIcon={<PersonAddIcon />}
            sx={{
              backgroundColor: "#1e3a8a",
              "&:hover": { backgroundColor: "#163a6a" },
            }}
          >
            Registrar Cliente
          </Button>
        </Box>
      </Paper>

      {/* Producto */}
      <Paper elevation={2} sx={{ p: 3, mb: 3 }}>
        <Typography variant="subtitle1" sx={{ fontWeight: "bold", mb: 2 }}>
          Productos
        </Typography>
        <Box
          sx={{
            display: "grid",
            gridTemplateColumns: "3fr 1fr",
            gap: 2,
            mb: 3,
          }}
        >
          <TextField
            label="Producto"
            size="small"
            placeholder="Buscar producto por código o descripción"
          />
          <Button
            variant="contained"
            size="small"
            startIcon={<AddShoppingCartIcon />}
            onClick={agregarProducto}
            sx={{
              backgroundColor: "#1e3a8a",
              "&:hover": { backgroundColor: "#163a6a" },
            }}
          >
            Agregar Producto
          </Button>
        </Box>

        {/* Tabla */}
        <TableContainer component={Paper} sx={{ mb: 3 }}>
          <Table size="small">
            <TableHead>
              <TableRow>
                <TableCell>Número de Parte</TableCell>
                <TableCell>Descripción</TableCell>
                <TableCell align="right">Cantidad</TableCell>
                <TableCell align="right">Precio Unitario (S/.)</TableCell>
                <TableCell align="right">Descuento (%)</TableCell>
                <TableCell align="right">Subtotal (S/.)</TableCell>
                <TableCell align="center">Acciones</TableCell>
              </TableRow>
            </TableHead>

            <TableBody>
              {productos.map((producto, index) => {
                const isEditing = editandoIndex === index;

                return (
                  <TableRow key={index}>
                    {/* Número de Parte */}
                    <TableCell>
                      <Typography>{producto.numeroParte}</Typography>
                    </TableCell>

                    {/* Descripción */}
                    <TableCell>
                      {isEditing ? (
                        <TextField
                          fullWidth
                          size="small"
                          value={descripcionTemp}
                          onChange={(e) => setDescripcionTemp(e.target.value)}
                        />
                      ) : (
                        <Typography>
                          {producto.descripcion || <i>Sin descripción</i>}
                        </Typography>
                      )}
                    </TableCell>

                    {/* Cantidad */}
                    <TableCell align="right">
                      <TextField
                        type="number"
                        size="small"
                        inputProps={{ min: 0 }}
                        value={producto.cantidad}
                        onChange={(e) =>
                          handleProductoChange(
                            index,
                            "cantidad",
                            e.target.value
                          )
                        }
                      />
                    </TableCell>

                    {/* Precio Unitario */}
                    <TableCell align="right">
                      <TextField
                        type="number"
                        size="small"
                        inputProps={{ min: 0, step: "0.01" }}
                        value={producto.precio}
                        disabled // El precio unitario no es editable
                      />
                    </TableCell>

                    {/* Descuento */}
                    <TableCell align="right">
                      <TextField
                        type="number"
                        size="small"
                        inputProps={{ min: 0, max: 100, step: "0.1" }}
                        value={producto.descuento}
                        onChange={(e) =>
                          handleProductoChange(
                            index,
                            "descuento",
                            e.target.value
                          )
                        }
                      />
                    </TableCell>

                    {/* Subtotal */}
                    <TableCell align="right">
                      {producto.subtotal.toFixed(2)}
                    </TableCell>

                    {/* Acciones */}
                    <TableCell align="center">
                      {isEditing ? (
                        <>
                          <Button
                            size="small"
                            color="success"
                            onClick={() => {
                              handleProductoChange(
                                index,
                                "descripcion",
                                descripcionTemp
                              );
                              setEditandoIndex(null);
                            }}
                          >
                            Guardar
                          </Button>
                          <Button
                            size="small"
                            onClick={() => setEditandoIndex(null)}
                          >
                            Cancelar
                          </Button>
                        </>
                      ) : (
                        <>
                          <IconButton
                            color="primary"
                            onClick={() => {
                              setEditandoIndex(index);
                              setDescripcionTemp(producto.descripcion);
                            }}
                          >
                            <EditIcon fontSize="small" />
                          </IconButton>
                          <IconButton
                            color="error"
                            onClick={() => eliminarProducto(index)}
                          >
                            <DeleteIcon fontSize="small" />
                          </IconButton>
                        </>
                      )}
                    </TableCell>
                  </TableRow>
                );
              })}
            </TableBody>
          </Table>
        </TableContainer>
      </Paper>

      <Button
        variant="outlined"
        size="small"
        startIcon={<AddIcon />}
        onClick={agregarProducto}
        sx={{ mb: 3 }}
      >
        Agregar Producto
      </Button>

      {/* Totales */}
      <Paper elevation={2} sx={{ p: 3, mb: 3 }}>
        <Typography variant="subtitle1" sx={{ fontWeight: "bold", mb: 2 }}>
          Resumen Financiero
        </Typography>
        <Box
          sx={{
            display: "grid",
            gridTemplateColumns: "repeat(3, 1fr)",
            gap: 2,
          }}
        >
          <TextField
            label="Subtotal (S/.)"
            size="small"
            value={totales.subtotal.toFixed(2)}
            disabled
          />
          <TextField
            label="IGV (18%)"
            size="small"
            value={totales.igv.toFixed(2)}
            disabled
          />
          <TextField
            label="Total (S/.)"
            size="small"
            value={totales.total.toFixed(2)}
            disabled
          />
        </Box>
      </Paper>

      {/* Botones */}
      <Box sx={{ display: "flex", justifyContent: "flex-end", gap: 2 }}>
        <Button
          variant="contained"
          size="small"
          sx={{
            backgroundColor: "#1e3a8a",
            "&:hover": { backgroundColor: "#163a6a" },
          }}
        >
          Guardar
        </Button>
        <Button
          variant="outlined"
          color="secondary"
          size="small"
          onClick={limpiarFactura}
        >
          Limpiar Factura
        </Button>
        <Button
          variant="outlined"
          color="error"
          size="small"
          onClick={anularFactura}
        >
          Anular Factura
        </Button>
        <Button variant="outlined" color="secondary" size="small">
          Cancelar
        </Button>
      </Box>
    </Box>
  );
};

export default Facturacion;
