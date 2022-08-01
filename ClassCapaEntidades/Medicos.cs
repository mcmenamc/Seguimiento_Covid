using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class Medicos
    {
        public int Id_Medico { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Horariio { get; set; }
        public string Especialidad { get; set; }
        public string Genero { get; set; }
        public int Id_EdoCivil { get; set; }
    }
}
