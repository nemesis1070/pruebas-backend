using System;
using System.Collections.Generic;

namespace BackEnd.ModeloDb;

public partial class Usuario
{
    public long IdUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Password { get; set; }

    public string? Rol { get; set; }
}
