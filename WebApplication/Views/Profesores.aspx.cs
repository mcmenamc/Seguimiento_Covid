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
        private LogicaNegocio bl = new LogicaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {

            toast.Visible = false;
            Datos.Visible = false;
            seguimieto.Visible = false;
            if (!IsPostBack)
            {

                TextBox1.Text = "122";
                DropDownListCuatri.Items.Clear();
                DropDownListCuatri.Items.Add(new ListItem()
                {
                    Text = "Seleccione un Cuatrimestre",
                    Value = "0"
                });
                DropDownListPrograma.Items.Clear();
                DropDownListPrograma.Items.Add(new ListItem()
                {
                    Text = "Seleccione un Programa",
                    Value = "0"
                });
                DropDownListGenero.Items.Clear();
                DropDownListEstadoCivil.Items.Clear();
                DropDownListCategoria.Items.Clear();

                DataSet data = bl.GetCatalogos();
                // Cuatrimestres
                foreach (DataRow dr in data.Tables[1].Rows)
                    DropDownListCuatri.Items.Add(new ListItem()
                    {
                        Text = dr[1].ToString(),
                        Value = dr[0].ToString()
                    });

                // Programa Educativo
                foreach (DataRow dr in data.Tables[6].Rows)
                    DropDownListPrograma.Items.Add(new ListItem()
                    {
                        Text = dr[1].ToString(),
                        Value = dr[0].ToString()
                    }); ;


                // Estado civil
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

                // Categoria 
                DropDownListCategoria.Items.Add(new ListItem()
                {
                    Text = "Seleccione una Categoria",
                    Value = "0"
                });
                DropDownListCategoria.Items.Add("Profesor de Tiempo Completo");
                DropDownListCategoria.Items.Add("Profesor por Asignatura");

                ShowGridView();
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;
            ShowGridView();
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            if (DropDownListCuatri.SelectedValue == "0" || DropDownListPrograma.SelectedValue == "0")
            {
                Lmessage.Text = "Seleccione una opción.";
                toast.Visible = true;
            }
            else
            {
                string message = "";
                table = bl.GetProfesoresContagiados(ref message, Convert.ToInt16(DropDownListCuatri.SelectedValue), Convert.ToInt16(DropDownListPrograma.SelectedValue));
                if (table.Rows.Count > 0)
                    toast.Visible = false;
                else
                {
                    toast.Visible = true;
                    Lmessage.Text = "Ningún elemento encontrado.";
                }
            }
            GridView2.DataSource = table;
            GridView2.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Boolean result = false;
            DataTable find = new DataTable();

            if (DropDownListGenero.SelectedValue == "0" || DropDownListCategoria.SelectedValue == "0" || DropDownListEstadoCivil.SelectedValue == "0")
            {
                Lmessage.Text = "Seleccione una opción.";
                toast.Visible = true;
            }
            else
            {
                try
                {
                    find = bl.GetProfesor(Convert.ToInt32(TextBoxRegistro.Text), false);

                    if (find.Rows.Count > 0)
                    {
                        toast.Visible = true;
                        Lmessage.Text = "Profesor ya resgistrado con el mismo número de registro.";
                    }
                    else
                    {
                        result = bl.CreateProfesor(new Profesor()
                        {
                            RegistroEmpleado = Convert.ToInt32(TextBoxRegistro.Text),
                            Nombre = TextBoxNombre.Text,
                            Paterno = TextBoxPaterno.Text,
                            Materno = TextBoxMaterno.Text,
                            Categoria = DropDownListCategoria.SelectedValue,
                            Celular = TextBoxCelular.Text,
                            Correo = TextBoxCorreo.Text,
                            Genero = DropDownListGenero.SelectedValue,
                            Id_EdoCivil = Convert.ToInt32(DropDownListEstadoCivil.SelectedValue)
                        });
                        if (result)
                        {
                            toast.Visible = true;
                            Lmessage.Text = "Profesor creado correctamente.";
                        }
                        else
                        {
                            toast.Visible = true;
                            Lmessage.Text = "Error al crear el profesor.";
                        }
                    }
                }
                catch (Exception EX)
                {
                    toast.Visible = true;
                    Lmessage.Text = EX.Message;
                }
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write(GridView2.SelectedRow.Cells[0].Text);
            Response.Redirect("ProfeContagiado.aspx?id=" + GridView2.SelectedRow.Cells[0].Text);
        }
        private void ShowGridView()
        {
            GridView1.DataSource = bl.GetTables(0);
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(idProfesorE.Text);
                Boolean result = false;
                result = bl.DeleteProfesor(id);
                if (result)
                {
                    toast.Visible = true;
                    Lmessage.Text = "Profesor eliminado correctamente.";
                }
                else
                {
                    toast.Visible = true;
                    Lmessage.Text = "Error al eliminar el profesor.";
                }
            }
            catch (Exception ex)
            {
                toast.Visible = true;
                Lmessage.Text = "Error " + ex.Message;
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataTable find = new DataTable();

            try
            {

                find = bl.GetProfesor(Convert.ToInt32(buscaid.Text), true);
                if (find.Rows.Count > 0)
                {
                    Datos.Visible = true;

                    toast.Visible = true;
                    Lmessage.Text = "Profesor encontrado.";

                    Ncompleto.Text = find.Rows[0]["Nombre"].ToString() + " " + find.Rows[0]["Paterno"].ToString() + " " + find.Rows[0]["Materno"].ToString();
                    Categoria.Text = find.Rows[0]["Categoria"].ToString();
                    Correo.Text = find.Rows[0]["Correo"].ToString();
                    Telefono.Text = find.Rows[0]["Celular"].ToString();
                    idProfesorE.Text = find.Rows[0]["Id_Profesor"].ToString();
                    Genero.Text = find.Rows[0]["Genero"].ToString();
                }
                else
                {
                    Datos.Visible = false;
                    toast.Visible = true;
                    Lmessage.Text = "Profesor no encontrado.";

                }
            }
            catch (Exception ex)
            {
                toast.Visible = true;
                Lmessage.Text = ex.Message;
            }

        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            DataTable find = new DataTable();
            try
            {
                find = bl.GetSeguimientoProfesor(Convert.ToInt32(TextBox1.Text));
                if (find.Rows.Count > 0)
                {
                    seguimieto.Visible = true;
                    toast.Visible = true;
                    Lmessage.Text = "Profesor encontrado.";
                    SCompledo.Text = find.Rows[0]["Nombre Completo"].ToString();
                    Veces_Contagiadas.Text = find.Rows[0]["Veces Contagiadas"].ToString();
                    scorreo.Text = find.Rows[0]["Correo"].ToString();
                    sCelular.Text = find.Rows[0]["Celular"].ToString();
                    scorreo.Text = find.Rows[0]["Correo"].ToString();
                    Image1.ImageUrl = "../Images/Comprobante/" + find.Rows[0]["Comprobante"].ToString();
                    sGenero.Text = find.Rows[0]["Genero"].ToString();
                }
                else
                {
                    seguimieto.Visible = false;
                    toast.Visible = true;
                    Lmessage.Text = "Profesor no encontrado.";
                }
            }
            catch (Exception ex)
            {
                toast.Visible = true;
                Lmessage.Text = ex.Message;
            }

        }
    }
}