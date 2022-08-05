using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassCapaNegocio;
using ClassCapaEntidades;
using System.Data;


namespace WebApplication.Views
{
    public partial class PositivoAlumno : System.Web.UI.Page
    {
        LogicaNegocio bl = new LogicaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            toast.Visible = false;
            Datos.Visible = false;
            if (!IsPostBack)
            {
                ShowGridView();

                DataSet catalogues = new DataSet();
                catalogues = bl.GetCatalogos();

                // Profesor
                DropDownListAlumno.Items.Clear();
                DropDownListAlumno.Items.Add("Selecccione un Alumno");
                DataTable alumno = bl.GetTables(1);
                foreach (DataRow dr in alumno.Rows)
                    DropDownListAlumno.Items.Add(new ListItem()
                    {
                        Value = dr["Id_Alumno"].ToString(),
                        Text = dr["Nombre Completo"].ToString()
                    });

                // Riesgo
                DropDownListRiesgo.Items.Add("Selecccione Riesgo");
                foreach (DataRow dr in catalogues.Tables[4].Rows)
                    DropDownListRiesgo.Items.Add(new ListItem()
                    {
                        Value = dr["Id_NivelRiesgo"].ToString(),
                        Text = dr["Nombre"].ToString(),
                    });
                // Comprobación
                DropDownListComprobacion.Items.Add("Selecccione Comprobacion");
                foreach (DataRow dr in catalogues.Tables[5].Rows)
                    DropDownListComprobacion.Items.Add(new ListItem()
                    {
                        Value = dr["Id_Comprobacion"].ToString(),
                        Text = dr["Nombre"].ToString(),
                    });

            }

        }
        public void ShowGridView()
        {
            GridView1.DataSource = bl.GetTables(7);
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
            if (DropDownListAlumno.SelectedIndex == 0 || DropDownListRiesgo.SelectedIndex == 0 || DropDownListComprobacion.SelectedIndex == 0)
            {
                toast.Visible = true;
                Lmessage.Text = "Seleccione las opcones.";
            }
            else
            {
                try
                {
                    result = bl.CreatePositivoAlumno(new ClassCapaEntidades.PositivoAlumno()
                    {
                        Id_NivelRiesgo = Convert.ToInt32(DropDownListRiesgo.SelectedValue),
                        Id_Alumno = Convert.ToInt32(DropDownListAlumno.SelectedValue),
                        Id_Comprobacion = Convert.ToInt32(DropDownListComprobacion.SelectedValue),
                        FechaConfirmado = FechaContagio.Text,
                        Antecedentes = TextBoxAntecedentes.Text,
                        NumContagio = Convert.ToInt32(TextBoxNumeroContagio.Text),
                        PruebaContagio = PruebaContagio.FileName,
                    });
                    if (result)
                    {
                        toast.Visible = true;
                        Lmessage.Text = "Positivo Alumno creado correctamente.";
                    }
                    else
                    {
                        toast.Visible = true;
                        Lmessage.Text = "Error al crear el Positivo Alumno.";
                    }
                }
                catch (Exception EX)
                {
                    toast.Visible = true;
                    Lmessage.Text = EX.Message;
                }
            }
            ShowGridView();
        }
        protected void Button5_Click(object Sender, EventArgs e)
        {
            DataTable find = new DataTable();
            try
            {
                find = bl.getPositivo_Alumno(Convert.ToInt32(buscaid.Text));
                if (find.Rows.Count > 0)
                {
                    Datos.Visible = true;
                    toast.Visible = true;
                    Lmessage.Text = "Alumno Positivo encontrado.";
                    id.Text = find.Rows[0]["Id_PositivoAlumno"].ToString();
                    Nombre_Completo.Text = find.Rows[0]["Nombre"].ToString() + " " + find.Rows[0]["Paterno"] + " " + find.Rows[0]["Materno"];
                    Fecha_Contagio.Text = find.Rows[0]["FechaContagio"].ToString();
                    Num_contagio.Text = find.Rows[0]["NumeroContagios"].ToString();
                    NombreRiesgo.Text = find.Rows[0]["RIESGO"].ToString();
                    NomComprobacion.Text = find.Rows[0]["Comprobación"].ToString();
                }
                else
                {
                    Datos.Visible = false;
                    toast.Visible = true;
                    Lmessage.Text = "Alumno Positivo no encontrado.";
                }
            }
            catch (Exception ex)
            {
                toast.Visible = true;
                Lmessage.Text = ex.Message;
            }
            ShowGridView();
        }
        protected void Button4_Click(object Sender, EventArgs e)
        {
            Boolean result = false;
            result = bl.DeleteAlumnoPositivo(Convert.ToInt32(id.Text));
            if (result)
            {
                toast.Visible = true;
                Lmessage.Text = "Alumno Positivo eliminado correctamente.";
            }
            else
            {
                toast.Visible = true;
                Lmessage.Text = "Error al eliminar el Alumno Positivo.";
            }
            ShowGridView();
        }
    }
}