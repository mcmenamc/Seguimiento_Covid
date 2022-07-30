using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassCapaEntidades;
using ClassCapaNegocio;

namespace WebApplication.Views
{
    public partial class Cuatrimestres : System.Web.UI.Page
    {
        private LogicaNegocio bl = new LogicaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            toast.Visible = false;
            Datos.Visible = false;
            if (!IsPostBack)
            {

                ShowGridView();
            }
        }

        public void ShowGridView()
        {
            GridView1.DataSource = bl.GetTables(2);
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;
            ShowGridView();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Boolean result = false;
            try
            {
                result = bl.CreateCuatrimestre(new ClassCapaEntidades.Cuatrimestre()
                {
                    Periodo = Periodo.Text,
                    Inicio = Inicio.Text,
                    Fin = Fin.Text,
                    Anio = Convert.ToInt16(Anno.Text)
                });
                if (result)
                {
                    toast.Visible = true;
                    Lmessage.Text = "Cuatrimestre creado correctamente.";
                }
                else
                {
                    toast.Visible = true;
                    Lmessage.Text = "Error al crear el Cuatrimestre.";
                }
            }
            catch (Exception EX)
            {
                toast.Visible = true;
                Lmessage.Text = EX.Message;
            }
        }
        protected void Button5_Click(object Sender, EventArgs e)
        {
            DataTable find = new DataTable();
            try
            {
                find = bl.GetCuatrimestre(Convert.ToInt32(buscaid.Text));
                if (find.Rows.Count > 0)
                {
                    Datos.Visible = true;
                    toast.Visible = true;
                    Lmessage.Text = "Cuatrimestre encontrado.";
                    periodo2.Text = find.Rows[0]["Periodo"].ToString();
                    inicio2.Text = find.Rows[0]["Inicio"].ToString();
                    fin2.Text = find.Rows[0]["Fin"].ToString();
                    anio.Text = find.Rows[0]["Anio"].ToString();
                    id.Text = find.Rows[0]["Id_Cuatrimestre"].ToString();
                }
                else
                {
                    Datos.Visible = false;
                    toast.Visible = true;
                    Lmessage.Text = "Cuatrimestre no encontrado.";
                }
            }
            catch (Exception ex)
            {
                toast.Visible = true;
                Lmessage.Text = ex.Message;
            }
        }
        protected void Button4_Click(object Sender, EventArgs e)
        {
            Boolean result = false;
            result = bl.DeleteCuatrimestre(Convert.ToInt32(id.Text));
            if (result)
            {
                toast.Visible = true;
                Lmessage.Text = "Cuatrimestre eliminado correctamente.";
            }
            else
            {
                toast.Visible = true;
                Lmessage.Text = "Error al eliminar el Cuatrimestre.";
            }
        }
    }
}