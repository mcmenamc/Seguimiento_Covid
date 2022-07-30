using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassCapaNegocio;
using ClassCapaEntidades;

namespace WebApplication.Views
{
    public partial class GrupoCuatrimestre : System.Web.UI.Page
    {
        private LogicaNegocio bl = new LogicaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            toast.Visible = false;
            Datos.Visible = false;
            if (!IsPostBack)
            {
                ShowGridView();

                DataSet catalogues = new DataSet();
                catalogues = bl.GetCatalogos();

                // Turno
                DropDownListTurno.Items.Clear();
                DropDownListTurno.Items.Add("Selecccione un Turno");
                DropDownListTurno.Items.Add("Matutino");
                DropDownListTurno.Items.Add("Vespertino");
                // Modalidad
                DropDownListModalidad.Items.Add("Selecccione una Modalidad");
                DropDownListModalidad.Items.Add("Presencial");
                DropDownListModalidad.Items.Add("Online");
                // Programa educativo
                DropDownListPrograma.Items.Add(new ListItem()
                {
                    Text = "Selecccione un Programa Educativo",
                    Value = "0"
                });
                foreach (DataRow dr in catalogues.Tables[6].Rows)
                {
                    DropDownListPrograma.Items.Add(new ListItem()
                    {
                        Text = dr["Programa"].ToString(),
                        Value = dr["Id_programaEducativo"].ToString()
                    });
                }
                DropDownListCuatrimestre.Items.Add(new ListItem()
                {
                    Text = "Selecccione un Cuatrimestre",
                    Value = "0"
                });
                foreach (DataRow dr in catalogues.Tables[1].Rows)
                {
                    DropDownListCuatrimestre.Items.Add(new ListItem()
                    {
                        Text = dr["Periodo"].ToString(),
                        Value = dr["Id_Cuatrimestre"].ToString()
                    });
                }

                // Grupos
                DropDownListGrupo.Items.Add(new ListItem()
                {
                    Text = "Selecccione un Grado y Grupo",
                    Value = "0"
                });
                foreach (DataRow dr in catalogues.Tables[2].Rows)
                {
                    DropDownListGrupo.Items.Add(new ListItem()
                    {
                        Text = dr["Grado"].ToString() + " " + dr["Letra"].ToString(),
                        Value = dr["Id_Grupo"].ToString()
                    });
                }
            }
        }

        public void ShowGridView()
        {
            GridView1.DataSource = bl.GetTables(3);
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
            if (DropDownListModalidad.SelectedIndex == 0 || DropDownListTurno.SelectedIndex == 0 || DropDownListCuatrimestre.SelectedValue == "0" || DropDownListPrograma.SelectedValue == "0" || DropDownListGrupo.SelectedValue == "0")
            {
                toast.Visible = true;
                Lmessage.Text = "Seleccione las opcones.";
            }
            else
            {
                try
                {
                    result = bl.CreateGrupoCuatrimestre(new ClassCapaEntidades.GrupoCuatrimestre()
                    {
                        Id_Cuatrimestre = Convert.ToInt32(DropDownListCuatrimestre.SelectedValue),
                        Id_Grupo = Convert.ToInt32(DropDownListGrupo.SelectedValue),
                        Id_programaEducativo = Convert.ToInt32(DropDownListPrograma.SelectedValue),
                        Turno = DropDownListTurno.SelectedValue,
                        Modalidad = DropDownListModalidad.SelectedValue

                    });
                    if (result)
                    {
                        toast.Visible = true;
                        Lmessage.Text = "Grupos y Cuatrimestre creado correctamente.";
                    }
                    else
                    {
                        toast.Visible = true;
                        Lmessage.Text = "Error al crear el Grupos y Cuatrimestre .";
                    }
                }
                catch (Exception EX)
                {
                    toast.Visible = true;
                    Lmessage.Text = EX.Message;
                }
            }
        }
        protected void Button5_Click(object Sender, EventArgs e)
        {
            DataTable find = new DataTable();
            try
            {
                find = bl.GetGrado_Cuatrimestre(Convert.ToInt32(buscaid.Text));
                if (find.Rows.Count > 0)
                {
                    Datos.Visible = true;
                    toast.Visible = true;
                    Lmessage.Text = "Cuatrimestre encontrado.";
                    id.Text = find.Rows[0]["Id_GrupoCuatrimestre"].ToString();
                    Turno.Text = find.Rows[0]["Turno"].ToString();
                    Modalidad.Text = find.Rows[0]["Modalidad"].ToString();
                    Periodo.Text = find.Rows[0]["Periodo"].ToString();
                    Programa.Text = find.Rows[0]["Programa"].ToString();
                    Grado.Text = find.Rows[0]["Grado"].ToString();
                    Letra.Text = find.Rows[0]["Letra"].ToString();
                }
                else
                {
                    Datos.Visible = false;
                    toast.Visible = true;
                    Lmessage.Text = "Grupo y Cuatrimestre no encontrado.";
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
            result = bl.DeleteGrupoCuatrimestre(Convert.ToInt32(id.Text));
            if (result)
            {
                toast.Visible = true;
                Lmessage.Text = "Cuatrimestre eliminado correctamente.";
            }
            else
            {
                toast.Visible = true;
                Lmessage.Text = "Error al eliminar el Grupo y Cuatrimestre.";
            }
        }
    }
}