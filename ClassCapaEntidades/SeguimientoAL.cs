using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class SeguimientoAL
    {
        public int Id_Seguimiento { get; set; }
        public int F_PositivoAL { get; set; }
        public int F_medico { get; set; }
        public string Fecha { get; set; }
        public string Form_Comunica { get; set; }
        public string Reporte { get; set; }
        public string Entrevista { get; set; }
        public string Extra { get; set; }
    }
}