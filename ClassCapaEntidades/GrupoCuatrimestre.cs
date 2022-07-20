using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class GrupoCuatrimestre
    {
        public int Id_GruCuat { get; set; }
        public int F_ProgEd { get; set; }
        public int F_Grupo { get; set; }
        public string Turno { get; set; }
        public string Modalidad { get; set; }
        public string Extra { get; set; }
    }
}
