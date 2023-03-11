namespace BackEnd.DTO
{
    public class EmpleadoDTO
    {
        public long IdEmpleado { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public int? Edad { get; set; }

        public string? Cargo { get; set; }

        public long? IdEntidad { get; set; }

        public string? NombreEntidad { get; set; }
    }
}
