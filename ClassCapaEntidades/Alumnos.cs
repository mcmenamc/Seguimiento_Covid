﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class Alumnos
    {
        public int ID_Alumno { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Ap_pat { get; set; }
        public string Ap_mat { get; set; }
        public int Genero { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public int F_EdoCivil { get; set; }
        public int F_Nivel { get; set; }
    }
}