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
    public partial class Registrar_Usuario : Form
    {
        public Registrar_Usuario()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            Form volver = new Menu_Administrador();
            volver.Show();

        }

        private void Registrar_Usuario_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(ID_USUARIO as varchar)),0)+1 from USUARIO", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtID.Text= dt.Rows[0][0].ToString();
            
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                string CADENA = "INSERT INTO USUARIO (ID_USUARIO,NOMBRE,TIPO_USUARIO,USUARIO,CONTRASEÑA)  VALUES(@ID_USUARIO,@NOMBRE,@TIPO_USUARIO,@USUARIO,@CONTRASEÑA)";
                SqlCommand comando = new SqlCommand(CADENA, con);
                comando.Parameters.AddWithValue("@ID_USUARIO", txtID.Text);
                comando.Parameters.AddWithValue("@NOMBRE", txtNombre.Text);
                comando.Parameters.AddWithValue("@USUARIO", txtUsuario.Text);
                comando.Parameters.AddWithValue("@CONTRASEÑA", txtContraseña.Text);
                comando.Parameters.AddWithValue("@TIPO_USUARIO", comboTipoUsuario.Text);

                comando.ExecuteNonQuery();
                MessageBox.Show("Datos registrados");
                con.Close();
            }

            catch
            {
                MessageBox.Show("Completa el Formulario");
            }
            finally
            {
            }
            this.txtID.Clear();
            this.txtNombre.Clear();
            this.txtUsuario.Clear();
            this.txtContraseña.Clear();
            this.txtUsuario.Clear();

     

           
        }


        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                int flag = 0;
                string cadena = "Delete from USUARIO where ID_USUARIO ='" + txtID.Text + "'";
                SqlCommand comando = new SqlCommand(cadena, con);
                flag = comando.ExecuteNonQuery();

                if (flag == 1)
                {

                    MessageBox.Show("Datos Eliminados");
                }
                else
                {
                    MessageBox.Show("No existe ese usuario");

                }
                con.Close();
            }
            catch
            {
            }
            finally { 
            
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                SqlCommand comando = new SqlCommand("select ID_USUARIO , NOMBRE ,TIPO_USUARIO,USUARIO,CONTRASEÑA  from USUARIO  ", con);
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
            finally { 
            
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
          
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                int flag = 0;
                string cadena = "update USUARIO SET NOMBRE='" + txtNombre.Text + "',USUARIO='" +txtUsuario.Text + "',TIPO_USUARIO='" + comboTipoUsuario.Text + "',CONTRASEÑA='" + txtContraseña.Text +  "' WHERE ID_USUARIO='" + txtID.Text + "'";
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
     



    }
}