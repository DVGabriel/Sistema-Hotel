using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sistema_automatizaciòn_y_control_de_hotel
{
    public partial class SalidaPasajero : Form
    {
        private Timer ti;
        public SalidaPasajero()
        {
            ti = new Timer();
            ti.Tick += new EventHandler(eventoTimer);
            InitializeComponent();
            ti.Enabled = true;
        }

        private void eventoTimer(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            lblHora.Text = hoy.ToString("hh:mm:ss tt");
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                SqlCommand comando = new SqlCommand
                  ("Select  ID_PASAJERO , RUT , NOMBRE , DIRECCION , PAIS , ID_HABITACION,TIPO_HABITACION CANTIDAD,PRECIO,FECHA_ENTRADA,FECHA_SALIDA from PASAJERO , HABITACION , ALOJA where ID_PASAJERO = ID_PASAJERO_ALOJA and ID_HABITACION = ID_HABITACION_ALOJA ", con);
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;
                con.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally{
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                string query = "UPDATE ALOJA SET FECHA_SALIDA= @FECHA_SALIDA , PRECIO=@PRECIO WHERE ID_PASAJERO_ALOJA=@ID_PASAJERO_ALOJA";
                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@FECHA_SALIDA", lblFecha.Text);
                comando.Parameters.AddWithValue("@ID_PASAJERO_ALOJA", txtId.Text);
                comando.Parameters.AddWithValue("@PRECIO", comboPre.Text);
                comando.ExecuteNonQuery();

                MessageBox.Show("Actualizado");
                con.Close();

            }
            catch
            {
                MessageBox.Show("No se encontro registro");
            }
            finally { 
           
            }
        }

        private void SalidaPasajero_Load(object sender, EventArgs e)
        {

        }

       

     
    }
}
 