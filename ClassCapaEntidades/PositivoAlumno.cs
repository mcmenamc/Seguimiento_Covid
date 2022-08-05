using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class PositivoAlumno
    {
        public int ID_posAl { get; set; }
        public string FechaConfirmado { get; set; }
        public string Antecedentes { get; set; }
        public int NumContagio { get; set; }
        public string PruebaContagio { get; set; }
        public string Comprobacion { get; set; }
        public int Id_NivelRiesgo { get; set; }
        public int Id_Alumno { get; set; }
        public int Id_Comprobacion { get; set; }
    }
}