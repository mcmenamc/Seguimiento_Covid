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
                    Profesores.Id_Profesor,
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
                case 2:
                    query = @"SELECT 
                    Cuatrimestres.Id_Cuatrimestre AS 'Identificador',
                    Cuatrimestres.Periodo AS 'Periodo',
                    Cuatrimestres.Inicio AS 'Inicio del cuatrimestre',
                    Cuatrimestres.Fin AS 'Fin del Cuatrimestre',
                    Cuatrimestres.Anio AS 'Año del Cuatrimestre'
                    FROM Cuatrimestres";
                    break;
                case 3:
                    query = @"
                    SELECT
                    GrupoCuatrimestres.Id_GrupoCuatrimestre,
                    GrupoCuatrimestres.Turno,
                    GrupoCuatrimestres.Modaliodad,
                    Cuatrimestres.Periodo,
                    ProgramaEducativos.Programa,
                    Carreras.Carrera,
                    Grupos.Grado,
                    Grupos.Letra
                    FROM GrupoCuatrimestres
                    INNER JOIN Cuatrimestres ON(Cuatrimestres.Id_Cuatrimestre = GrupoCuatrimestres.Id_Cuatrimestre)
                    INNER JOIN ProgramaEducativos ON(ProgramaEducativos.Id_programaEducativo = GrupoCuatrimestres.Id_programaEducativo)
                    INNER JOIN Carreras ON(Carreras.Id_Carrera = ProgramaEducativos.Id_Carrera)
                    INNER JOIN Grupos ON(Grupos.Id_Grupo = GrupoCuatrimestres.Id_Grupo)
                    ";
                    break;
                case 4:
                    query = @"
                    SELECT 
                    Medicos.Id_Medicos,
                    Medicos.Nombre,
                    Medicos.Paterno,
                    Medicos.Materno,
                    Medicos.Celular,
                    Medicos.Correo,
                    Medicos.Horario,
                    Medicos.Especialidad,
                    Medicos.Genero,
                    EdoCivil.Nombre AS EdoCivil
                    FROM Medicos
                    INNER JOIN EdoCivil ON(EdoCivil.Id_EdoCivil = Medicos.Id_EdoCivil)
                    ";
                    break;
                case 5:
                    query = @"SELECT
                    Alumnos.Matricula,
                    Alumnos.Paterno,
                    Alumnos.Materno,
                    Alumnos.Nombre,
                    Alumnos.Genero,
                    Alumnos.Correo,
                    Alumnos.Celular,
                    GrupoCuatrimestres.Modaliodad,
                    GrupoCuatrimestres.Turno,
                    Cuatrimestres.Periodo
                    FROM AlumnosGrupo
                    INNER JOIN Alumnos ON(Alumnos.Id_Alumno = AlumnosGrupo.Id_Alumno)
                    INNER JOIN GrupoCuatrimestres ON(GrupoCuatrimestres.Id_GrupoCuatrimestre = AlumnosGrupo.Id_GrupoCuatrimestre)
                    INNER JOIN Cuatrimestres ON(Cuatrimestres.Id_Cuatrimestre = GrupoCuatrimestres.Id_Cuatrimestre)";
                    break;
                case 6:
                    query = @"SELECT
                    PositivoProfesores.Id_PositivoProfesor,
                    Profesores.Nombre,
                    Profesores.Paterno,
                    Profesores.Materno,
                    Profesores.RegistroEmpleado,
                    Comprobaciones.Nombre,
                    NivelRiesgos.Nombre,
                    NivelRiesgos.Descipcion,
                    PositivoProfesores.FechaContagio,
                    PositivoProfesores.Antecedentes,
                    PositivoProfesores.NumeroContagios,
                    PositivoProfesores.PruebaContagio
                    FROM PositivoProfesores
                    INNER JOIN NivelRiesgos ON (NivelRiesgos.Id_NivelRiesgo = PositivoProfesores.Id_NivelRiesgo)
                    INNER JOIN Comprobaciones ON (Comprobaciones.Id_Comprobacion = PositivoProfesores.Id_Comprobacion)
                    INNER JOIN Profesores ON (Profesores.Id_Profesor = PositivoProfesores.Id_Profesor)";
                    break ;
                case 7:
                    query = @"SELECT
                    PositivoAlumnos.Id_PositivoAlumno,
                    Alumnos.Nombre,
                    Alumnos.Paterno,
                    Alumnos.Materno,
                    Alumnos.Matricula,
                    Comprobaciones.Nombre,
                    NivelRiesgos.Nombre,
                    NivelRiesgos.Descipcion,
                    PositivoAlumnos.FechaContagio,
                    PositivoAlumnos.Antecedentes,
                    PositivoAlumnos.NumeroContagios,
                    PositivoAlumnos.PruebaContagio
                    FROM PositivoAlumnos
                    INNER JOIN NivelRiesgos ON (NivelRiesgos.Id_NivelRiesgo = PositivoAlumnos.Id_NivelRiesgo)
                    INNER JOIN Comprobaciones ON (Comprobaciones.Id_Comprobacion = PositivoAlumnos.Id_Comprobacion)
                    INNER JOIN Alumnos ON (Alumnos.Id_Alumno = PositivoAlumnos.Id_Alumno)";
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
        public Boolean CreateCuatrimestre(Cuatrimestre nuevo)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@periodo", nuevo.Periodo));
            listParameter.Add(new SqlParameter("@inicio", nuevo.Inicio));
            listParameter.Add(new SqlParameter("@fin", nuevo.Fin));
            listParameter.Add(new SqlParameter("@anio", nuevo.Anio));
            string message = "";
            string query = @"INSERT INTO Cuatrimestres(Periodo, Inicio, Fin, Anio)
            VALUES (@periodo, @inicio, @fin, @anio)";

            return bl.modification(query, ref query, listParameter);
        }
        public DataTable GetCuatrimestre(int id)
        {
            DataTable result = new DataTable();
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@id", id));
            string message = "";
            string query = @"SELECT 
            Cuatrimestres.Id_Cuatrimestre ,
            Cuatrimestres.Periodo,
            Cuatrimestres.Inicio ,
            Cuatrimestres.Fin,
            Cuatrimestres.Anio
            FROM Cuatrimestres
            WHERE Id_Cuatrimestre = @id";
            return bl.QueryDataTable(query, ref message, listParameter);
        }
        public Boolean DeleteCuatrimestre(int id)
        {

            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@id", id));
            string query = @"
                DELETE FROM Cuatrimestres WHERE Id_Cuatrimestre = @id
            ";
            string mesage = "";
            return bl.modification(query, ref mesage, listParameter);
        }
        public Boolean CreateGrupoCuatrimestre(GrupoCuatrimestre nuevo)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@turno", nuevo.Turno));
            listParameter.Add(new SqlParameter("@modalidad", nuevo.Modalidad));
            listParameter.Add(new SqlParameter("@id_programa", nuevo.Id_programaEducativo));
            listParameter.Add(new SqlParameter("@id_cuatri", nuevo.Id_Cuatrimestre));
            listParameter.Add(new SqlParameter("@id_grupo", nuevo.Id_Grupo));
            string message = "";
            string query = @"INSERT INTO GrupoCuatrimestres(Turno, Modaliodad, Id_programaEducativo, Id_Cuatrimestre, Id_Grupo)
            VALUES (@turno, @modalidad, @id_programa, @id_cuatri, @id_grupo)";
            return bl.modification(query, ref message, listParameter);

        }

        public Boolean CreatePositivoProfesor(positivoProfe nuevo)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@FechaContagio", nuevo.FechaConfirmado));
            listParameter.Add(new SqlParameter("@Antecedentes", nuevo.Antecedentes));
            listParameter.Add(new SqlParameter("@NumeroContagios", nuevo.NumContaio));
            listParameter.Add(new SqlParameter("@PruebaContagio", nuevo.prueba_covid));
            listParameter.Add(new SqlParameter("@Id_NivelRiesgo", nuevo.id_nivel_riesgo));
            listParameter.Add(new SqlParameter("@Id_Profesor", nuevo.id_profesor));
            listParameter.Add(new SqlParameter("@Id_Comprobacion", nuevo.id_comprobacion));
            string message = "";
            string query = @"INSERT INTO PositivoProfesores VALUES(@FechaContagio, @Antecedentes, @NumeroContagios, @PruebaContagio, @Id_NivelRiesgo, @Id_Profesor, @Id_Comprobacion)";
            return bl.modification(query, ref message, listParameter);
        }
        public DataTable GetGrado_Cuatrimestre(int id)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@id", id));
            string query = @"
            SELECT
            GrupoCuatrimestres.Id_GrupoCuatrimestre,
            GrupoCuatrimestres.Turno,
            GrupoCuatrimestres.Modaliodad AS Modalidad,
            Cuatrimestres.Periodo,
            ProgramaEducativos.Programa,
            Grupos.Grado,
            Grupos.Letra
            FROM GrupoCuatrimestres
            INNER JOIN Cuatrimestres ON(Cuatrimestres.Id_Cuatrimestre = GrupoCuatrimestres.Id_Cuatrimestre)
            INNER JOIN ProgramaEducativos ON(ProgramaEducativos.Id_programaEducativo = GrupoCuatrimestres.Id_programaEducativo)
            INNER JOIN Carreras ON(Carreras.Id_Carrera = ProgramaEducativos.Id_Carrera)
            INNER JOIN Grupos ON(Grupos.Id_Grupo = GrupoCuatrimestres.Id_Grupo)
            where GrupoCuatrimestres.Id_GrupoCuatrimestre = @id
            ";
            string messager = "";
            return bl.QueryDataTable(query, ref messager, listParameter);
        }
        public DataTable getPositivo_Profe(int id)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@id", id));
            string query = @"
            SELECT
            PositivoProfesores.Id_PositivoProfesor,
            Profesores.Nombre,
            Profesores.Paterno,
            Profesores.Materno,
            Profesores.RegistroEmpleado,
            Comprobaciones.Nombre AS 'Comprobación',
            NivelRiesgos.Nombre AS 'Riesgos',
            NivelRiesgos.Descipcion,
            PositivoProfesores.FechaContagio,
            PositivoProfesores.Antecedentes,
            PositivoProfesores.NumeroContagios,
            PositivoProfesores.PruebaContagio
            FROM PositivoProfesores
            INNER JOIN NivelRiesgos ON (NivelRiesgos.Id_NivelRiesgo = PositivoProfesores.Id_NivelRiesgo)
            INNER JOIN Comprobaciones ON (Comprobaciones.Id_Comprobacion = PositivoProfesores.Id_Comprobacion)
            INNER JOIN Profesores ON (Profesores.Id_Profesor = PositivoProfesores.Id_Profesor)
            WHERE PositivoProfesores.Id_PositivoProfesor = @id
            ";
            string messager = "";
            return bl.QueryDataTable(query, ref messager, listParameter);
        }
        public Boolean DeleteGrupoCuatrimestre(int id)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@id", id));
            string query = @"
                DELETE FROM GrupoCuatrimestres WHERE Id_GrupoCuatrimestre = @id
            ";
            string mesage = "";
            return bl.modification(query, ref mesage, listParameter);
        }
        public Boolean DeleteProfePositivo(int id)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@id", id));
            string query = @"
                DELETE FROM PositivoProfesores where Id_PositivoProfesor = @id;
            ";
            string mesage = "";
            return bl.modification(query, ref mesage, listParameter);
        }
        public Boolean CreateMedico(Medicos nuevo)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@nombre", nuevo.Nombre));
            listParameter.Add(new SqlParameter("@paterno", nuevo.Paterno));
            listParameter.Add(new SqlParameter("@materno", nuevo.Materno));
            listParameter.Add(new SqlParameter("@correo", nuevo.Correo));
            listParameter.Add(new SqlParameter("@celular", nuevo.Celular));
            listParameter.Add(new SqlParameter("@horario", nuevo.Horariio));
            listParameter.Add(new SqlParameter("@genero", nuevo.Genero));
            listParameter.Add(new SqlParameter("@especialidad", nuevo.Especialidad));
            listParameter.Add(new SqlParameter("@civil", nuevo.Id_EdoCivil));
            string message = "";
            string query = @"INSERT INTO Medicos(Nombre, Paterno, Materno, Correo, Celular, Horario, Genero, Especialidad, Id_EdoCivil)
            VALUES (@nombre, @paterno, @materno, @correo, @celular, @horario, @genero, @especialidad, @civil)";
            return bl.modification(query, ref message, listParameter);
        }
        public DataTable GetMedico(int id)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@id", id));
            string query = @"SELECT 
            Medicos.Id_Medicos,
            Medicos.Nombre,
            Medicos.Paterno,
            Medicos.Materno,
            Medicos.Celular,
            Medicos.Correo,
            Medicos.Horario,
            Medicos.Especialidad,
            Medicos.Genero,
            EdoCivil.Nombre AS EdoCivil
            FROM Medicos
            INNER JOIN EdoCivil ON(EdoCivil.Id_EdoCivil = Medicos.Id_EdoCivil)
            WHERE Id_Medicos = @id
            ";
            string message = "";
            return bl.QueryDataTable(query, ref message, listParameter);
        }

        public Boolean DeleteMedicos(int id)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@id", id));
            string query = @"
            DELETE FROM Medicos WHERE Id_Medicos = @id";
            string message = "";
            return bl.modification(query, ref message, listParameter);
        }

       
    }
}
