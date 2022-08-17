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
    public partial class Termino : Form
    {
        private Timer ti;
        public Termino()
        {
            ti = new Timer();
             ti.Tick +=new EventHandler(eventoTimer);
            InitializeComponent();
            ti.Enabled = true;
        }
        private void eventoTimer(object sender ,EventArgs e)
        {
              DateTime hoy = DateTime.Now;
              lblHora.Text= hoy.ToString("hh:mm:ss tt");
              
        }
         
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                int flag = 0;
                string cadena = "update CONTROL_JORNADA SET  HORA_TERMINO='" + lblHora.Text + "' where USUARIO_CONTROL ='" + txtnombre.Text + "'";
                SqlCommand comando = new SqlCommand(cadena, con);
                flag = comando.ExecuteNonQuery();

                if (flag >= 1)
                {
                    MessageBox.Show("Actualizado");

                }
                else
                {
                    MessageBox.Show("No se encontro usuario");

                }
                con.Close();
                MessageBox.Show("!Que Tenga buen Dia¡");

            }
            catch
            {
                MessageBox.Show("Completa los formularios");
            }
            finally { 
            
            }
        }

  

        public Termino(String text) 
        {
            InitializeComponent();
            txtnombre.Text = text;
            
        }

        private void Termino_Load(object sender, EventArgs e)
        {

        }


    }
}
