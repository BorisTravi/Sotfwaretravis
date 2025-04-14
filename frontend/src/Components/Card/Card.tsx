import React, { useState } from "react";
//import logo from "../../assets/logo.png";
import "./Card.css"; // Importa el archivo CSS

const Login = () => {
  const [user, setUser] = useState("");
  const [password, setPassword] = useState("");
  const [userlError, setUserError] = useState("");
  const [passwordError, setPasswordError] = useState("");

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    // Validaciones
    if (!user || !/\S+@\S+\.\S+/.test(user)) {
      setUserError("Ingrese un usuario.");
    } else {
      setUserError("");
    }

    if (!password || password.length < 4 || password.length > 60) {
      setPasswordError("La contraseña debe tener entre 4 y 60 caracteres.");
    } else {
      setPasswordError("");
    }

    // Si no hay errores, proceder con el inicio de sesión
    if (!userlError && !passwordError) {
      console.log("User:", user);
      console.log("Password:", password);
      // Aquí podrías agregar la lógica para autenticar al usuario
    }
  };

  return (
    <div className="login-container">
      <div className="login-card">
        {/* Logo y título */}
       <div className="logo-title">
       { /* <img src={logo} alt="Logo" className="logo" />*/}
          <h1>Travi&Soft</h1>
        </div>

        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <input
              type="text"
              id="email"
              value={user}
              onChange={(e) => setUser(e.target.value)}
              placeholder="Usuario"
              className={userlError ? "input-error" : ""}
            />
            {userlError && <p className="error-message">{userlError}</p>}
          </div>
          <div className="form-group">
            <input
              type="password"
              id="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              placeholder="Contraseña"
              className={passwordError ? "input-error" : ""}
            />
            {passwordError && <p className="error-message">{passwordError}</p>}
          </div>
          <button type="submit" className="login-button">
            Iniciar sesión
          </button>
          <div className="remember-me">
            <label>
              <input type="checkbox" /> Recordarme
            </label>
          </div>
          <div className="signup-link">
            ¿Primera vez aquí? <a href="/signup">Suscríbete ya.</a>
          </div>
        </form>
        <div className="recaptcha-notice">
          Esta página está protegida por Google reCAPTCHA para comprobar que no
          eres un robot. <a href="/info">Más info.</a>
        </div>
      </div>
    </div>
  );
};

export default Login;
