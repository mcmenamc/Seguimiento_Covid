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

        public DataTable GetTables(int table)
        {
            string query = "";
            string message = "";

            switch (table)
            {
                case 0:
                    query = @"SELECT
                    Profesores.RegistroEmpleado AS 'Registro Empleado',
                    CONCAT(Profesores.Nombre + ' ', Profesores.Paterno + ' ', Profesores.Materno) AS 'Nombre Completo',
                    Profesores.Genero,
                    Profesores.Categoria,
                    Profesores.Correo,
                    Profesores.Celular,
                    EdoCivil.Nombre AS 'Estado Civil'
                    FROM Profesores INNER JOIN EdoCivil ON (EdoCivil.Id_EdoCivil = Profesores.Id_EdoCivil)";
                    break;
                case 1:
                    query = "SELECT * FROM Alumnos";
                    break;
                default:
                    query = "";
                    break;
            }
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            return bl.QueryDataTable(query, ref message, listaParametros);
        }

        public DataTable GetProfesoresContagiados(ref string message, int cuatrimestre, int programa)
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
                MAX(GrupoCuatrimestres.Turno) AS 'Turno',
                MIN(ProgramaEducativos.Programa) as 'programa',
                MIN(Cuatrimestres.Periodo) as 'periodo'
                FROM PositivoProfesores
                INNER JOIN Profesores ON(Profesores.Id_Profesor = PositivoProfesores.Id_Profesor)
                INNER JOIN ProfesoresGrupos ON(Profesores.Id_Profesor = ProfesoresGrupos.Id_Profesor)
                INNER JOIN GrupoCuatrimestres ON(GrupoCuatrimestres.Id_Cuatrimestre = ProfesoresGrupos.Id_GrupoCuatrimestre)
                INNER JOIN Cuatrimestres ON(Cuatrimestres.Id_Cuatrimestre = GrupoCuatrimestres.Id_Cuatrimestre)
                INNER JOIN ProgramaEducativos ON(ProgramaEducativos.Id_programaEducativo = GrupoCuatrimestres.Id_programaEducativo)
                WHERE ProgramaEducativos.Id_programaEducativo = @programa AND Cuatrimestres.Id_Cuatrimestre = @cuatri
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
        public DataTable GetProfesor(int id, Boolean flag)
        {
            DataTable result = new DataTable();
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@id", id));
            string query = "";
            string message = "";
            if (flag)
                query = "SELECT * FROM Profesores WHERE Id_Profesor = @id ";
            else
                query = "SELECT * FROM Profesores WHERE RegistroEmpleado = @id ";
            return bl.QueryDataTable(query, ref message, listParameter);
        }

        public Boolean DeleteProfesor(int id)
        {
            string message = "";
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("id", id));
            string query = "DELETE FROM Profesores WHERE Id_Profesor = @id";
            return bl.modification(query, ref message, listParameter);

        }
        public DataTable GetAlumnosContagiados(int educativo, int cuatri)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@educativo", educativo));
            listParameter.Add(new SqlParameter("@cuatri", cuatri));
            string message = "";
            string query = @"SELECT
            MAX(Alumnos.Id_Alumno) AS 'Id_Profesor',
            MAX(PositivoAlumnos.Id_Alumno) AS Id_PositivoProfesor,
            CONCAT(MAX(Alumnos.Nombre) + ' ', MAX(Alumnos.Paterno) + ' ', MAX(Alumnos.Materno)) AS 'Nombre Completo',
            MAX(Alumnos.Genero) AS Genero,
            MAX(Alumnos.Correo) AS Correo,
            MAX(PositivoAlumnos.FechaContagio) AS  'Fecha de Contagio' ,
            AVG(PositivoAlumnos.NumeroContagios) AS 'Veces Contagiadas',
            MAX(GrupoCuatrimestres.Turno) AS 'Turno',
            MIN(ProgramaEducativos.Programa) as 'programa',
            MIN(Cuatrimestres.Periodo) as 'periodo'
            FROM Alumnos
            INNER JOIN PositivoAlumnos ON(Alumnos.Id_Alumno = PositivoAlumnos.Id_Alumno)
            INNER JOIN AlumnosGrupo ON(AlumnosGrupo.Id_Alumno = Alumnos.Id_Alumno)
            INNER JOIN GrupoCuatrimestres ON(GrupoCuatrimestres.Id_Cuatrimestre = AlumnosGrupo.Id_AlumnoGrupo)
            INNER JOIN Cuatrimestres ON(Cuatrimestres.Id_Cuatrimestre = GrupoCuatrimestres.Id_Cuatrimestre)
            INNER JOIN ProgramaEducativos ON(ProgramaEducativos.Id_programaEducativo = GrupoCuatrimestres.Id_programaEducativo)
            WHERE ProgramaEducativos.Id_programaEducativo = @educativo AND Cuatrimestres.Id_Cuatrimestre = @cuatri
            GROUP BY Alumnos.Id_Alumno";
            return bl.QueryDataTable(query, ref message, listParameter);
        }

        public DataTable GetAlumno(string id)
        {
            DataTable result = new DataTable();
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@id", id));
            string message = "";

            string query = @"SELECT
            Alumnos.Id_Alumno,
            Alumnos.Matricula, 
            Alumnos.Nombre, 
            Alumnos.Paterno,
            Alumnos.Materno,
            Alumnos.Genero,
            Alumnos.Correo,
            Alumnos.Celular,
            EdoCivil.Nombre AS Civil
            FROM Alumnos
            INNER JOIN EdoCivil ON(EdoCivil.Id_EdoCivil = Alumnos.Id_EdoCivil)
            WHERE Matricula = @id";
            return bl.QueryDataTable(query, ref message, listParameter);
        }
        public Boolean CreateAlumno(Alumnos nuevo)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@matricula", nuevo.Matricula));
            listParameter.Add(new SqlParameter("@nombre", nuevo.Nombre));
            listParameter.Add(new SqlParameter("@paterno", nuevo.Paterno));
            listParameter.Add(new SqlParameter("@materno", nuevo.Materno));
            listParameter.Add(new SqlParameter("@genero", nuevo.Genero));
            listParameter.Add(new SqlParameter("@correo", nuevo.Correo));
            listParameter.Add(new SqlParameter("@celular", nuevo.Celular));
            listParameter.Add(new SqlParameter("@id_civil", nuevo.Id_EdoCivil));
            string query = @"
                INSERT INTO Alumnos(Matricula, Nombre, Paterno, Materno, Genero, Correo, Celular, Id_EdoCivil)
                VALUES(@matricula, @nombre, @paterno, @materno, @genero, @correo, @celular, @id_civil)
            ";
            string mensaje = "";
            return bl.modification(query, ref mensaje, listParameter);
        }
        public Boolean DeleteAlumno(string id)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@id", id));
            string query = @"
                DELETE FROM Alumnos WHERE Matricula = @id
            ";
            string mesage = "";
            return bl.modification(query, ref mesage, listParameter);
        }



    }
}
