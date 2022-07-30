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
        public string Inicio { get; set; }
        public string Fin { get; set; }
        public int Anio { get; set; }
    }
}