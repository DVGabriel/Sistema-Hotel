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
    public partial class Menu_Cocinero : Form
    {
        public Menu_Cocinero(String NOMBRE)
        {
            InitializeComponent();
        }

        public Menu_Cocinero()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                SqlCommand comando = new SqlCommand("select ID_HABITACION , NOMBRE,CANTIDAD ,DESAYUNO, FECHA_ENTRADA,ESTADO  from HABITACION , PASAJERO , ALOJA where ID_PASAJERO = ID_PASAJERO_ALOJA and ID_HABITACION = ID_HABITACION_ALOJA ", con);
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;
                con.Close();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form final = new Termino();
            final.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                int flag = 0;
                string cadena = "update PASAJERO SET  ESTADO ='" + comboBox1.Text + "' where NOMBRE ='" + textBox1.Text + "'";
                SqlCommand comando = new SqlCommand(cadena, con);
                flag = comando.ExecuteNonQuery();

                if (flag == 1)
                {
                    MessageBox.Show("Actualizado");

                }
                else
                {
                    MessageBox.Show("no se encontro registro");

                }
                con.Close();
            }
            catch
            {
            }
            finally
            {
            }
        }

        private void Menu_Cocinero_Load(object sender, EventArgs e)
        {

        }




    }
}

