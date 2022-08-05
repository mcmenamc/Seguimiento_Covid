using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassCapaEntidades;
using ClassCapaNegocio;
using System.Data;

namespace WebApplication.Views
{
    public partial class SeguimientoAlumno : System.Web.UI.Page
    {
        private LogicaNegocio bl = new LogicaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            toast.Visible = false;
            Datos.Visible = false;
            if (!IsPostBack)
            {
                ShowGridView();

                DataTable medico = bl.GetTables(4);
                DropDownListMedico.Items.Clear();
                DropDownListMedico.Items.Add("Seleccione el Médico");
                foreach (DataRow dr in medico.Rows)
                {
                    DropDownListMedico.Items.Add(new ListItem()
                    {
                        Text = dr["Nombre"].ToString() + " " + dr["Paterno"].ToString() + " " + dr["Materno"].ToString(),
                        Value = dr["Id_Medicos"].ToString()
                    });
                }
                DropDownListPositivoAlumno.Items.Clear();
                DataTable positvoProfesor = bl.GetTables(7);
                DropDownListPositivoAlumno.Items.Add("Seleccione el Positivo Alumno");
                foreach (DataRow dr in positvoProfesor.Rows)
                {
                    DropDownListPositivoAlumno.Items.Add(new ListItem()
                    {
                        Text = dr["Nombre"].ToString() + " " + dr["Paterno"].ToString() + " " + dr["Materno"].ToString(),
                        Value = dr["Id_PositivoAlumno"].ToString()
                    });
                }
            }
        }
        public void ShowGridView()
        {
            GridView1.DataSource = bl.GetTables(8);
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
            if (DropDownListMedico.SelectedIndex == 0 || DropDownListPositivoAlumno.SelectedIndex == 0)
            {
                toast.Visible = true;
                Lmessage.Text = "Seleccione las opcones.";
            }
            else
            {
                try
                {
                    result = bl.CreateSeguimientoAlumno(new ClassCapaEntidades.SeguimientoAlumno()
                    {
                        cumunicacion = TextBoxComunicacion.Text,
                        IdMedico = Convert.ToInt32(DropDownListMedico.SelectedValue),
                        IdPositivoalumno = Convert.ToInt32(DropDownListPositivoAlumno.SelectedValue),
                        FechaSeguimiento = FechaSeguimiento.Text,
                        Entrevista = TextBoxEntrevista.Text,
                        Reporte = TextBoxReporte.Text,
                    });

                    if (result)
                    {
                        toast.Visible = true;
                        Lmessage.Text = "Seguimiento Alumno creado correctamente.";
                    }
                    else
                    {
                        toast.Visible = true;
                        Lmessage.Text = "Error al crear el Seguimiento Alumno.";
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
                find = bl.GetSeguimientoAlumno(Convert.ToInt32(buscaid.Text));
                if (find.Rows.Count > 0)
                {
                    Datos.Visible = true;
                    toast.Visible = true;
                    Lmessage.Text = "Seguimiento Alumno encontrado.";
                    entrevista.Text = find.Rows[0]["Entrevista"].ToString();
                    fecha.Text = find.Rows[0]["FechaSeguimiento"].ToString();
                    Medico.Text = find.Rows[0]["Nombre Medico"].ToString();
                    pacieente.Text = find.Rows[0]["Nombre Alumno"].ToString();
                    reporte.Text = find.Rows[0]["Reporte"].ToString();
                    id.Text = find.Rows[0]["Id_SeguimientoAlumno"].ToString();
                }
                else
                {
                    Datos.Visible = false;
                    toast.Visible = true;
                    Lmessage.Text = "Seguimiento Alumno no encontrado.";
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
            try
            {
                result = bl.DeleteSeguimientoAlumno(Convert.ToInt32(id.Text));
                if (result)
                {
                    toast.Visible = true;
                    Lmessage.Text = "Seguimiento Alumno Eliminado correctamente.";
                }
                else
                {
                    toast.Visible = true;
                    Lmessage.Text = "Error al eliminar el Seguimiento Alumno.";
                }
            }
            catch (Exception ex)
            {
                toast.Visible = true;
                Lmessage.Text = "Error" + ex.Message;

            }


            ShowGridView();

        }
    }
}