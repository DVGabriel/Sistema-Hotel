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
    public partial class Iniciar_Sesion : Form
    {
           private Timer ti;
        public Iniciar_Sesion()
        {
            ti = new Timer();
             ti.Tick +=new EventHandler(eventoTimer);
            InitializeComponent();
            ti.Enabled = true;
        }
        private void eventoTimer(object sender ,EventArgs e)
        {
              DateTime hoy = DateTime.Now;
              lblhora.Text= hoy.ToString("hh:mm:ss tt");
              lblfecha.Text = DateTime.Now.ToShortDateString();
        }
         

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");
            public void logear(string USUARIO, string CONTRASEÑA) {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT TIPO_USUARIO FROM USUARIO WHERE USUARIO = '" + USUARIO + "' AND CONTRASEÑA = " + CONTRASEÑA, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {

                        if (dt.Rows[0].ItemArray[0].ToString() == "ADMINISTRADOR")
                        {
                            new Menu_Administrador(dt.Rows[0][0].ToString()).Show();
                        }
                        else if (dt.Rows[0].ItemArray[0].ToString() == "RECEPCIONISTA")
                        {
                            new Menu_Recepcionista(dt.Rows[0][0].ToString()).Show();

                        }
                        else if (dt.Rows[0].ItemArray[0].ToString() == "COCINA")
                        {
                            new Menu_Cocinero(dt.Rows[0][0].ToString()).Show();
                        }
                        else if (dt.Rows[0].ItemArray[0].ToString() == "AUXILIAR")
                        {
                            new Menu_Recepcionista(dt.Rows[0][0].ToString()).Show();


                        }

                    }
                    else
                    {
                        MessageBox.Show("Usuario y/o Contraseña Incorrecta");
                    }

                }

                catch
                {
                    MessageBox.Show("Ingresa los datos correcto");
                }
                finally
                {
                    con.Close();

                }
                }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                logear(this.textBox1.Text, this.textBox2.Text);
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                string CADENA = "INSERT INTO CONTROL_JORNADA  (FECHA_SESION,HORA_SESION,USUARIO_CONTROL)  VALUES(@FECHA_SESION,@HORA_SESION,@USUARIO_CONTROL)";
                SqlCommand comando = new SqlCommand(CADENA, con);
                comando.Parameters.AddWithValue("@FECHA_SESION", lblfecha.Text);
                comando.Parameters.AddWithValue("@HORA_SESION", lblhora.Text);
                comando.Parameters.AddWithValue("@USUARIO_CONTROL", textBox1.Text);

                comando.ExecuteNonQuery();

                con.Close();
            }
            catch
            {
            }
            finally { 
            }

        }

        private void Iniciar_Sesion_Load(object sender, EventArgs e)
        {

        }

     
    
  
    }
}
