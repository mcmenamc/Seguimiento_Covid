using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class positivoProfe
    {
        public int Id_posProfe { get; set; }
        public string FechaConfirmado { get; set; }
        public string Antecedentes { get; set; }
        public int NumContaio { get; set; }
        public string prueba_covid { get; set; }
        public int id_nivel_riesgo { get; set; }
        public int id_profesor { get; set; }
        public int id_comprobacion { get; set; }
    }
}