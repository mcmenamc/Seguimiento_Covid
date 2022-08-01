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
        public string Comprobacion { get; set; }
        public string Antecedentes { get; set; }
        public string Riesgo { get; set; }
        public int NumContagio { get; set; }
        public string Extra { get; set; }
        public int F_Alumno { get; set; }
    }
}