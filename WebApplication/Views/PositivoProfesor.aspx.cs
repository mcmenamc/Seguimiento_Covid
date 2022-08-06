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
    public partial class PositivoProfesor : System.Web.UI.Page
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
                DropDownListProfesor.Items.Clear();
                DropDownListProfesor.Items.Add("Selecccione un Pofe");
                DataTable profesor = bl.GetTables(0);
                foreach (DataRow dr in profesor.Rows)
                    DropDownListProfesor.Items.Add(new ListItem()
                    {
                        Value = dr["Id_Profesor"].ToString(),
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
            GridView1.DataSource = bl.GetTables(6);
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
            if (DropDownListProfesor.SelectedIndex == 0 || DropDownListRiesgo.SelectedIndex == 0 || DropDownListComprobacion.SelectedIndex == 0)
            {
                toast.Visible = true;
                Lmessage.Text = "Seleccione las opcones.";
            }
            else
            {
                try
                {
                    if (PruebaContagio.HasFile)
                    {
                        string cadenaAleatoria = string.Empty;
                        cadenaAleatoria = Guid.NewGuid().ToString();

                        string nombre = Server.MapPath(Request.ApplicationPath + "Images/Comprobante/" + cadenaAleatoria + PruebaContagio.FileName);
                        PruebaContagio.SaveAs(nombre);

                        result = bl.CreatePositivoProfesor(new ClassCapaEntidades.positivoProfe()
                        {
                            id_nivel_riesgo = Convert.ToInt32(DropDownListRiesgo.SelectedValue),
                            id_profesor = Convert.ToInt32(DropDownListProfesor.SelectedValue),
                            id_comprobacion = Convert.ToInt32(DropDownListComprobacion.SelectedValue),
                            FechaConfirmado = FechaContagio.Text,
                            Antecedentes = TextBoxAntecedentes.Text,
                            NumContaio = Convert.ToInt32(TextBoxNumeroContagio.Text),
                            prueba_covid = cadenaAleatoria + PruebaContagio.FileName,
                        });
                        if (result)
                        {
                            toast.Visible = true;
                            Lmessage.Text = "Positivo Profesor creado correctamente.";
                        }
                        else
                        {
                            toast.Visible = true;
                            Lmessage.Text = "Error al crear el Positivo Profesor.";
                        }
                    }
                    else
                    {
                        toast.Visible = true;
                        Lmessage.Text = "Sube un archivo.";

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
                find = bl.getPositivo_Profe(Convert.ToInt32(buscaid.Text));
                if (find.Rows.Count > 0)
                {
                    Datos.Visible = true;
                    toast.Visible = true;
                    Lmessage.Text = "Profe Positivo encontrado.";
                    id.Text = find.Rows[0]["Id_PositivoProfesor"].ToString();
                    Nombre_Completo.Text = find.Rows[0]["Nombre"].ToString() + " " + find.Rows[0]["Paterno"] + " " + find.Rows[0]["Materno"];
                    Fecha_Contagio.Text = find.Rows[0]["FechaContagio"].ToString();
                    Num_contagio.Text = find.Rows[0]["NumeroContagios"].ToString();
                    NombreRiesgo.Text = find.Rows[0]["Riesgos"].ToString();
                    NomComprobacion.Text = find.Rows[0]["Comprobación"].ToString();
                    Image1.ImageUrl = "../Images/Comprobante/" + find.Rows[0]["PruebaContagio"].ToString();
                }
                else
                {
                    Datos.Visible = false;
                    toast.Visible = true;
                    Lmessage.Text = "Profe Positivo no encontrado.";
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
            result = bl.DeleteProfePositivo(Convert.ToInt32(id.Text));
            if (result)
            {
                toast.Visible = true;
                Lmessage.Text = "Profe Positivo eliminado correctamente.";
            }
            else
            {
                toast.Visible = true;
                Lmessage.Text = "Error al eliminar el Profe Positivo.";
            }
            ShowGridView();
        }
    }
}