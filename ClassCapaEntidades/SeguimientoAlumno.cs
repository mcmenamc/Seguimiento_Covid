using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class SeguimientoAlumno
    {
        public int Id_Seguimiento { get; set; }
        public string FechaSeguimiento { get; set; }
        public string cumunicacion { get; set; }
        public string Reporte { get; set; }
        public string Entrevista { get; set; }
        public int IdMedico { get; set; }
        public int IdPositivoalumno { get; set; }
    }
}