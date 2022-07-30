using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassCapaEntidades;
using ClassCapaNegocio;

namespace WebApplication.Views
{
    public partial class Alumnos : System.Web.UI.Page
    {
        private LogicaNegocio bl = new LogicaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            toast.Visible = false;
            Datos.Visible = false;
            if (!IsPostBack)
            {


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

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            if (DropDownListCuatri.SelectedValue == "0" || DropDownListPrograma.SelectedValue == "0")
            {
                Lmessage.Text = "Seleccione una opción.";
                toast.Visible = true;
            }
            else
            {
                table = bl.GetAlumnosContagiados(Convert.ToInt16(DropDownListCuatri.SelectedValue), Convert.ToInt16(DropDownListPrograma.SelectedValue));
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
        public void ShowGridView()
        {
            GridView1.DataSource = bl.GetTables(1);
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
            DataTable find = new DataTable();

            if (DropDownListGenero.SelectedValue == "0" || DropDownListEstadoCivil.SelectedValue == "0")
            {
                Lmessage.Text = "Seleccione una opción.";
                toast.Visible = true;
            }
            else
            {
                try
                {
                    find = bl.GetAlumno(TextBoxMatricula.Text);

                    if (find.Rows.Count > 0)
                    {
                        toast.Visible = true;
                        Lmessage.Text = "Alumno ya resgistrado con la misma matricula.";
                    }
                    else
                    {
                        result = bl.CreateAlumno(new ClassCapaEntidades.Alumnos()
                        {
                            Matricula = TextBoxMatricula.Text,
                            Nombre = TextBoxNombre.Text,
                            Paterno = TextBoxPaterno.Text,
                            Materno = TextBoxMaterno.Text,
                            Celular = TextBoxCelular.Text,
                            Correo = TextBoxCorreo.Text,
                            Genero = DropDownListGenero.SelectedValue,
                            Id_EdoCivil = Convert.ToInt32(DropDownListEstadoCivil.SelectedValue),
                        });
                        if (result)
                        {
                            toast.Visible = true;
                            Lmessage.Text = "Alumno creado correctamente.";
                        }
                        else
                        {
                            toast.Visible = true;
                            Lmessage.Text = "Error al crear el Alumno.";
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
        protected void Button5_Click(object Sender, EventArgs e)
        {
            DataTable find = new DataTable();
            try
            {
                find = bl.GetAlumno(buscaid.Text);
                if (find.Rows.Count > 0)
                {
                    Datos.Visible = true;

                    toast.Visible = true;
                    Lmessage.Text = "Alumno encontrado.";

                    Ncompleto.Text = find.Rows[0]["Nombre"].ToString() + " " + find.Rows[0]["Paterno"].ToString() + " " + find.Rows[0]["Materno"].ToString();
                    Correo.Text = find.Rows[0]["Correo"].ToString();
                    Telefono.Text = find.Rows[0]["Celular"].ToString();
                    MatriculaA.Text = find.Rows[0]["Matricula"].ToString();
                    Genero.Text = find.Rows[0]["Genero"].ToString();
                    Civil.Text = find.Rows[0]["Civil"].ToString();
                }
                else
                {
                    Datos.Visible = false;
                    toast.Visible = true;
                    Lmessage.Text = "Alumno no encontrado.";

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
            result = bl.DeleteAlumno(MatriculaA.Text);
            if (result)
            {
                toast.Visible = true;
                Lmessage.Text = "Alumno eliminado correctamente.";
            }
            else
            {
                toast.Visible = true;
                Lmessage.Text = "Error al eliminar el Alumno.";
            }
        }
    }
}