using System;
using System.Collections.Generic;

namespace BackEnd.ModeloDb;

public partial class Entidad
{
    public long IdEntidad { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}
