import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Layout from "./components/Layout";
import Home from "./Pages/Home";
import Cliente from "./Pages/Cliente";
import Productos from "./Pages/Productos";
import Configuracion from "./Pages/Configuracion";
import Facturacion from "./Pages/Facturacion";

import "@fontsource/inter/400.css";
import "@fontsource/inter/600.css";

function App() {
  return (
    <Router>
      <Routes>
        <Route element={<Layout />}>
          <Route path="/" element={<Home />} />
          <Route path="/inicio" element={<Home />} />
          <Route path="/productos" element={<Productos />} />
          <Route path="/clientes" element={<Cliente />} />
          <Route path="/facturacion" element={<Facturacion />} />
          <Route path="/configuracion" element={<Configuracion />} />
        </Route>
      </Routes>
    </Router>
  );
}

export default App;
