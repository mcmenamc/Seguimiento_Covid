using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class GrupoCuatrimestre
    {
        public int Id_GrupoCuatrimestre { get; set; }
        public string Turno { get; set; }
        public string Modalidad { get; set; }
        public int Id_programaEducativo { get; set; }
        public int Id_Grupo { get; set; }
        public int Id_Cuatrimestre { get; set; }

    }
}
