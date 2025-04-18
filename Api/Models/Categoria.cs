﻿using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Categoria
{
    public int CategoriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? CodigoSunat { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
