using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1
{
    public partial class Proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text != "" && TextBox2.Text != "")
                {
                    int result = SqlDataSource1.Insert();
                    if (result > 0)
                    {
                        GridView1.DataBind();
                        LabelAviso.Text = "El proveedor se ha registrado correctamente";
                        
                        StreamWriter streamWriter = new StreamWriter($"{Server.MapPath(".")}/proveedores.txt", true);
                        streamWriter.WriteLine("Insert");
                        streamWriter.WriteLine("Proveedor: " + TextBox1.Text);
                        streamWriter.WriteLine("CUIL: " + TextBox2.Text);
                        streamWriter.WriteLine("-----------------------------");
                        streamWriter.Close();

                        TextBox1.Text = "";
                        TextBox2.Text = "";

                    } else
                    {
                        LabelAviso.Text = "No se ha agregado el proveedor";
                    }
                    
                }
                else
                {
                    LabelAviso.Text = "Complete todos los campos.";
                }
            } 
            catch (SqlException)
            {
                LabelAviso.Text = "Ocurrio un error.";
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            LabelAviso.Text = "Se ha modificado el proveedor correctamente.";

            string valorAntes = e.OldValues["razonSocial"].ToString();
            string valorDespues = e.NewValues["razonSocial"].ToString();

            string valorAntesCuit = e.OldValues["cuit"].ToString();
            string valorDespuesCuit = e.NewValues["cuit"].ToString();

            StreamWriter streamWriter = new StreamWriter($"{Server.MapPath(".")}/proveedores.txt", true);
            streamWriter.WriteLine("Update a: " + valorAntes);
            if (valorAntes != valorDespues)
            {
                streamWriter.WriteLine("Nombre antes: " + valorAntes);
                streamWriter.WriteLine("Nombre despues: " + valorDespues);
            }
            if (valorAntesCuit != valorDespuesCuit)
            {
                streamWriter.WriteLine("Cuit antes: " + valorAntesCuit);
                streamWriter.WriteLine("Cuit despues: " + valorDespuesCuit);
            }
            streamWriter.WriteLine("-----------------------------");
            streamWriter.Close();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            LabelAviso.Text = "Se ha eliminado el proveedor correctamente.";

            string valorEliminado = e.Values["razonSocial"].ToString();


            StreamWriter streamWriter = new StreamWriter($"{Server.MapPath(".")}/proveedores.txt", true);
            streamWriter.WriteLine("Delete");
            streamWriter.WriteLine("Proveedor: " + valorEliminado);
            streamWriter.WriteLine("-----------------------------");
            streamWriter.Close();
        }
    }
}