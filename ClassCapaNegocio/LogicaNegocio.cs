using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasscCapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace ClassCapaNegocio
{
    public class LogicaNegocio
    {
        private ClassAccesoSQL bl = new ClassAccesoSQL();

        public DataTable queryInsert(string querySql, ref string mensaje, List<SqlParameter> listaParametros)
        {
            return bl.QueryDataTable(querySql, ref mensaje, listaParametros);
        }
    }
}
