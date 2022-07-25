using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasscCapaDatos;
using System.Data;
using System.Data.SqlClient;
using ClassCapaEntidades;

namespace ClassCapaNegocio
{
    public class LogicaNegocio
    {
        private ClassAccesoSQL bl = new ClassAccesoSQL();

        public DataTable queryInsert(string querySql, ref string mensaje, List<SqlParameter> listaParametros)
        {
            return bl.QueryDataTable(querySql, ref mensaje, listaParametros);
        }

        public DataTable GetProfesores(ref string message)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            string querySql = @"SELECT
                Profesores.RegistroEmpleado AS 'Registro Empleado',
                CONCAT(Profesores.Nombre + ' ', Profesores.Paterno + ' ', Profesores.Materno) AS 'Nombre Completo',
                Profesores.Genero,
                Profesores.Categoria,
                Profesores.Correo,
                Profesores.Celular,
                EdoCivil.Nombre AS 'Estado Civil'
                FROM Profesores INNER JOIN EdoCivil ON (EdoCivil.Id_EdoCivil = Profesores.Id_EdoCivil)
            ";
            return bl.QueryDataTable(querySql, ref message, listaParametros);
        }

        public DataTable GetProfesoresContagiados(ref string message, string cuatrimestre, string programa)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("cuatri", cuatrimestre));
            listaParametros.Add(new SqlParameter("programa", programa));

            string querySql = @"
                SELECT
                MAX(Profesores.Id_Profesor) AS 'Id_Profesor',
                MAX(PositivoProfesores.Id_PositivoProfesor) AS Id_PositivoProfesor,
                CONCAT(MAX(Profesores.Nombre) + ' ', MAX(Profesores.Paterno) + ' ', MAX(Profesores.Materno)) AS 'Nombre Completo',
                MAX(Profesores.Genero) AS Genero,
                MAX(Profesores.Correo) AS Correo,
                MAX(PositivoProfesores.FechaContagio) AS  'Fecha de Contagio' ,
                AVG(PositivoProfesores.NumeroContagios) AS 'Veces Contagiadas',
                MAX(GrupoCuatrimestres.Turno) AS 'Turno'
                FROM PositivoProfesores
                INNER JOIN Profesores ON(Profesores.Id_Profesor = PositivoProfesores.Id_Profesor)
                INNER JOIN ProfesoresGrupos ON(Profesores.Id_Profesor = ProfesoresGrupos.Id_Profesor)
                INNER JOIN GrupoCuatrimestres ON(GrupoCuatrimestres.Id_Cuatrimestre = ProfesoresGrupos.Id_GrupoCuatrimestre)
                INNER JOIN Cuatrimestres ON(Cuatrimestres.Id_Cuatrimestre = GrupoCuatrimestres.Id_Cuatrimestre)
                INNER JOIN ProgramaEducativos ON(ProgramaEducativos.Id_programaEducativo = GrupoCuatrimestres.Id_programaEducativo)
                WHERE Cuatrimestres.Periodo = @cuatri AND ProgramaEducativos.Programa = @programa
                GROUP BY Profesores.Id_Profesor
            ";
            return bl.QueryDataTable(querySql, ref message, listaParametros);
        }
        public DataSet GetCatalogos()
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();
            string mensaje = "";
            List<string> querys = new List<string>();
            querys.Add("SELECT * FROM EdoCivil");
            querys.Add("SELECT * FROM Cuatrimestres");
            querys.Add("SELECT * FROM Grupos");
            querys.Add("SELECT * FROM Carreras");
            querys.Add("SELECT * FROM NivelRiesgos");
            querys.Add("SELECT * FROM Comprobaciones");
            querys.Add("SELECT * FROM ProgramaEducativos");

            return bl.QueryDataSet(querys, ref mensaje, listParameter);
        }

        public Boolean CreateProfesor(Profesor profesor)
        {
            Boolean result = false;
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@registro", profesor.RegistroEmpleado));
            listParameter.Add(new SqlParameter("@nom", profesor.Nombre));
            listParameter.Add(new SqlParameter("@paterno", profesor.Paterno));
            listParameter.Add(new SqlParameter("@materno", profesor.Materno));
            listParameter.Add(new SqlParameter("@genero", profesor.Genero));
            listParameter.Add(new SqlParameter("@categoria", profesor.Categoria));
            listParameter.Add(new SqlParameter("@correo", profesor.Correo));
            listParameter.Add(new SqlParameter("@celular", profesor.Celular));
            listParameter.Add(new SqlParameter("@id_civil", profesor.Id_EdoCivil));
            string query = @"
                INSERT INTO Profesores(RegistroEmpleado, Nombre, Paterno, Materno, Genero, Categoria, Correo, Celular, Id_EdoCivil)
                VALUES(@registro, @nom, @paterno, @materno, @genero, @categoria, @correo, @celular, @id_civil)
            ";
            string mensaje = "";
            result = bl.modification(query, ref mensaje, listParameter);
            return result;
        }

    }
}
