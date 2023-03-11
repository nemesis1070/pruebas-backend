using System;
using System.Collections.Generic;

namespace BackEnd.ModeloDb;

public partial class Empleado
{
    public long IdEmpleado { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public int? Edad { get; set; }

    public string? Cargo { get; set; }

    public long? IdEntidad { get; set; }

    public virtual Entidad? IdEntidadNavigation { get; set; }
}
