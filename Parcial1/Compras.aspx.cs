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
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //obtengo la fecha y la guardo en la variable tipo string
            string fechaString = GridView1.SelectedRow.Cells[1].Text;

            //declaro una variable para luego intentar convertir
            //la fecha en un datetime para colocarlo en el textbox
            DateTime fecha;

            //intenta convertir y si lo hace lo guarda en la variable "fecha"
            if (DateTime.TryParse(fechaString, out fecha))
            {
                //convierte la fecha a una cadena
                string fechaFormateada = fecha.ToString("yyyy-MM-dd");

                //asigna la fecha al TextBox 
                TextBox1.Text = fechaFormateada;
            }

            TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
            TextBox3.Text = GridView1.SelectedRow.Cells[3].Text;
            TextBox4.Text = GridView1.SelectedRow.Cells[4].Text;
            TextBox5.Text = GridView1.SelectedRow.Cells[5].Text;
            DropDownList1.SelectedValue = GridView1.SelectedRow.Cells[6].Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "")
                {
                    int result = SqlDataSource1.Insert();
                    if (result > 0)
                    {
                        GridView1.DataBind();
                        LabelAviso.Text = "La compra se ha registrado correctamente";

                        StreamWriter streamWriter = new StreamWriter($"{Server.MapPath(".")}/compras.txt", true);
                        streamWriter.WriteLine("Insert compra");
                        streamWriter.WriteLine("Fecha: " + TextBox1.Text);
                        streamWriter.WriteLine("Monto Gravado: " + TextBox2.Text);
                        streamWriter.WriteLine("IVA: " + TextBox3.Text);
                        streamWriter.WriteLine("Nro. Factura: " + TextBox4.Text);
                        streamWriter.WriteLine("Punto de venta: " + TextBox5.Text);
                        streamWriter.WriteLine("Proveedor: " + DropDownList1.SelectedItem.ToString());
                        streamWriter.WriteLine("-----------------------------");
                        streamWriter.Close();

                        TextBox1.Text = string.Empty; TextBox2.Text = string.Empty;
                        TextBox3.Text = string.Empty; TextBox4.Text = string.Empty;
                        TextBox5.Text = string.Empty;

                    }
                    else
                    {
                        LabelAviso.Text = "No se ha agregado la compra.";
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlDataSource1.Update();
            LabelAviso.Text = "Se ha modificado la compra correctamente.";

            string provedor = DropDownList1.SelectedItem.ToString();

            StreamWriter streamWriter = new StreamWriter($"{Server.MapPath(".")}/compras.txt", true);
            streamWriter.WriteLine("Update compra de " + provedor);
            streamWriter.WriteLine("Fecha: " + TextBox1.Text);
            streamWriter.WriteLine("Monto Gravado: " + TextBox2.Text);
            streamWriter.WriteLine("IVA: " + TextBox3.Text);
            streamWriter.WriteLine("Nro. Factura: " + TextBox4.Text);
            streamWriter.WriteLine("Punto de venta: " + TextBox5.Text);
            streamWriter.WriteLine("Proveedor: " + DropDownList1.SelectedItem.ToString());
            streamWriter.WriteLine("-----------------------------");
            streamWriter.Close();


            TextBox1.Text = string.Empty; TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty; TextBox4.Text = string.Empty;
            TextBox5.Text= string.Empty;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlDataSource1.FilterExpression = "idProveedor = " + DropDownList2.SelectedValue;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlDataSource1.FilterExpression = string.Empty;
            SqlDataSource1.FilterParameters.Clear();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            LabelAviso.Text = "Se ha eliminado la compra correctamente.";

            string proveedor = e.Values["razonSocial"].ToString();
            string fecha = e.Values["fecha"].ToString();
            string montoGravado = e.Values["montoGravado"].ToString();

            StreamWriter streamWriter = new StreamWriter($"{Server.MapPath(".")}/compras.txt", true);
            streamWriter.WriteLine("Delete");
            streamWriter.WriteLine("Compra a " + proveedor);
            streamWriter.WriteLine("Fecha: " + fecha);
            streamWriter.WriteLine("Monto: " + montoGravado);
            streamWriter.WriteLine("-----------------------------");
            streamWriter.Close();
        }
    }
}