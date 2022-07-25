using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassCapaNegocio;
using System.Data;
using System.Data.SqlClient;
using ClassCapaEntidades;

namespace WebApplication.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        LogicaNegocio bl = new LogicaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownListCuatri.Items.Clear();
            DropDownListPrograma.Items.Clear();
            DropDownListGenero.Items.Clear();
            DropDownListEstadoCivil.Items.Clear();
            DropDownListCategoria.Items.Clear();

            DataSet data = bl.GetCatalogos();

            // Cuatrimestres
            foreach (DataRow dr in data.Tables[1].Rows)
                DropDownListCuatri.Items.Add(dr[1].ToString());

            // Programa Educativo
            foreach (DataRow dr in data.Tables[6].Rows)
                DropDownListPrograma.Items.Add(dr[1].ToString());

            // Estado civil
            foreach (DataRow dr in data.Tables[0].Rows)
                DropDownListEstadoCivil.Items.Add(dr[1].ToString());

            // Genero 
            DropDownListGenero.Items.Add("Hombre");
            DropDownListGenero.Items.Add("Mujer");
            DropDownListGenero.Items.Add("Otro");

            // Categoria 
            DropDownListCategoria.Items.Add("Profesor de Tiempo Completo");
            DropDownListCategoria.Items.Add("Profesor por Asignatura");




            ShowGridView();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;

            ShowGridView();
        }

        private void ShowGridView()
        {
            DataTable table = new DataTable();
            string mensaje = "";
            table = bl.GetProfesores(ref mensaje);
            GridView1.DataSource = table;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string message = "";
            GridView2.DataSource = bl.GetProfesoresContagiados(ref message, DropDownListCuatri.SelectedValue, DropDownListPrograma.SelectedValue);
            GridView2.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write(bl.CreateProfesor(new Profesor()
            {
                RegistroEmpleado = Convert.ToInt16(TextBoxRegistro.Text),
                Nombre = TextBoxNombre.Text,
                Paterno = TextBoxPaterno.Text,
                Materno = TextBoxMaterno.Text,
                Categoria = DropDownListCategoria.SelectedValue,
                Celular = TextBoxCelular.Text,
                Correo = TextBoxCorreo.Text,
                Genero = DropDownListGenero.SelectedValue,
                Id_EdoCivil = Convert.ToInt16(DropDownListEstadoCivil.SelectedValue)
            }));
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write(GridView2.SelectedRow.Cells[0].Text);
            Response.Redirect("ProfeContagiado.aspx?id=" + GridView2.SelectedRow.Cells[0].Text);
        }
    }
}