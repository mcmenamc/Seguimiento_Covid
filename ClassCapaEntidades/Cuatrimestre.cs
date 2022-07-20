using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class Cuatrimestre
    {
        public int id_Cuatrimestre { get; set; }
        public string Periodo { get; set; }
        public int Anio { get; set; }
        public int Inicio { get; set; }
        public int Fin { get; set; }
        public int Extra { get; set; }
    }
}