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
    public partial class Medicos : System.Web.UI.Page
    {
        private LogicaNegocio bl = new LogicaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            toast.Visible = false;
            Datos.Visible = false;
            if (!IsPostBack)
            {


                DropDownListGenero.Items.Clear();
                DropDownListEstadoCivil.Items.Clear();

                DataSet data = bl.GetCatalogos();


                //Estado civil
                DropDownListEstadoCivil.Items.Add(new ListItem()
                {
                    Text = "Seleccione su Estado civil",
                    Value = "0"
                });
                foreach (DataRow dr in data.Tables[0].Rows)
                    DropDownListEstadoCivil.Items.Add(new ListItem()
                    {
                        Text = dr[1].ToString(),
                        Value = dr[0].ToString()
                    });

                // Genero 
                DropDownListGenero.Items.Add(new ListItem()
                {
                    Text = "Seleccione su Genero",
                    Value = "0"
                });
                DropDownListGenero.Items.Add("Hombre");
                DropDownListGenero.Items.Add("Mujer");
                DropDownListGenero.Items.Add("Otro");
            }
            ShowGridView();
        }


        public void ShowGridView()
        {
            GridView1.DataSource = bl.GetTables(4);
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

            if (DropDownListGenero.SelectedValue == "0" || DropDownListEstadoCivil.SelectedValue == "0")
            {
                Lmessage.Text = "Seleccione una opción.";
                toast.Visible = true;
            }
            else
            {
                try
                {
                    result = bl.CreateMedico(new ClassCapaEntidades.Medicos()
                    {
                        Nombre = TextBoxNombre.Text,
                        Paterno = TextBoxPaterno.Text,
                        Materno = TextBoxMaterno.Text,
                        Celular = TextBoxCelular.Text,
                        Correo = TextBoxCorreo.Text,
                        Genero = DropDownListGenero.SelectedValue,
                        Id_EdoCivil = Convert.ToInt32(DropDownListEstadoCivil.SelectedValue),
                        Horariio = TextBoxHorario.Text,
                        Especialidad = TextBoxEspecialidad.Text
                    });
                    if (result)
                    {
                        toast.Visible = true;
                        Lmessage.Text = "Médico creado correctamente.";
                    }
                    else
                    {
                        toast.Visible = true;
                        Lmessage.Text = "Error al crear el Médico.";
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
                find = bl.GetMedico(Convert.ToInt32(buscaid.Text));
                if (find.Rows.Count > 0)
                {
                    Datos.Visible = true;
                    toast.Visible = true;
                    Lmessage.Text = "Médico encontrado.";
                    Ncompleto.Text = find.Rows[0]["Nombre"].ToString() + " " + find.Rows[0]["Paterno"].ToString() + " " + find.Rows[0]["Materno"].ToString();
                    Correo.Text = find.Rows[0]["Correo"].ToString();
                    Telefono.Text = find.Rows[0]["Celular"].ToString();
                    id.Text = find.Rows[0]["Id_Medicos"].ToString();
                    Genero.Text = find.Rows[0]["Genero"].ToString();
                    Civil.Text = find.Rows[0]["EdoCivil"].ToString();
                    Horario.Text = find.Rows[0]["Horario"].ToString();
                }
                else
                {
                    Datos.Visible = false;
                    toast.Visible = true;
                    Lmessage.Text = "Médico no encontrado.";

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
            try
            {
                result = bl.DeleteMedicos(Convert.ToInt32(id.Text));
            }
            catch (Exception Ex) {
                toast.Visible = true;
                Lmessage.Text = "Error" + Ex;
            }
            if (result)
            {
                toast.Visible = true;
                Lmessage.Text = "Médico eliminado correctamente.";
            }
            else
            {
                toast.Visible = true;
                Lmessage.Text = "Error al eliminar el Médico.";
            }
        }
    }
}
