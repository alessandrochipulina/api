using System;

namespace Api.Entities
{
    public class CarreraResult
    {
        public int id { get; set; }
        public int facultad { get; set; }
        public string nombre_facultad { get; set; }
        public string codigo_facultad { get; set; }
        public DateTime creado_tmstp { get; set; }
        public DateTime actualizado_tmstp { get; set; }
        public int estado { get; set; }
    }
}
