using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class Profesor
    {
        public int ID_Profe { get; set; }
        public int RegistroEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Ap_pat { get; set; }
        public string Ap_Mat { get; set; }
        public int Genero { get; set; }
        public int Categoria { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public int F_EdoCivil { get; set; }
    }
}
