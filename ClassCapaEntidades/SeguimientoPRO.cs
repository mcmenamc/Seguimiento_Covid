using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class SeguimientoPRO
    {
        public int id_Segui { get; set; }
        public int F_positivoProfe { get; set; }
        public int F_medico { get; set; }
        public string Fecha { get; set; }
        public string Reporte { get; set; }
        public string Entrevista { get; set; }
        public string extra { get; set; }
    }
}