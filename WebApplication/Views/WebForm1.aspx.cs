using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassCapaNegocio;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        LogicaNegocio bl = new LogicaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            string mensaje = "";
            List<SqlParameter> parameters = null;
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id", 1));

            table = bl.queryInsert("SELECT * FROM EstadoCivil WHERE Id_Edo = @id", ref mensaje, parameters);
            Label1.Text = mensaje;
            GridView1.DataSource = table;
            GridView1.DataBind();

        }
    }
}