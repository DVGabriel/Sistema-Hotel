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
    public partial class Registrar_pasajero : Form
    {
        public Registrar_pasajero()
        {
            InitializeComponent();
        }

        private void Registrar_Cliente_Load(object sender, EventArgs e)
        {
           
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select isnull(max(cast(ID_PASAJERO  as varchar)),0)+1 from PASAJERO ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtId.Text = dt.Rows[0][0].ToString();

                con.Close();
            }
         
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {



                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");

                string CADENA = "INSERT INTO PASAJERO  (ID_PASAJERO,RUT,NOMBRE,DIRECCION,PAIS,DESAYUNO) VALUES(@ID_PASAJERO,@RUT,@NOMBRE,@DIRECCION,@PAIS,@DESAYUNO) INSERT INTO HABITACION (ID_HABITACION,TIPO_HABITACION,CANTIDAD)  VALUES(@ID_HABITACION,@TIPO_HABITACION,@CANTIDAD) INSERT INTO ALOJA (FECHA_ENTRADA,ID_HABITACION_ALOJA,ID_PASAJERO_ALOJA) VALUES(@FECHA_ENTRADA,@ID_HABITACION_ALOJA,@ID_PASAJERO_ALOJA)";

                con.Open();
                SqlCommand comando = new SqlCommand(CADENA, con);
                comando.Parameters.AddWithValue("@ID_PASAJERO", txtId.Text);
                comando.Parameters.AddWithValue("@ID_PASAJERO_ALOJA", txtId.Text);
                comando.Parameters.AddWithValue("@RUT", txtRut.Text);
                comando.Parameters.AddWithValue("@NOMBRE", txtNombre.Text);
                comando.Parameters.AddWithValue("@DIRECCION", txtDireccion.Text);
                comando.Parameters.AddWithValue("@PAIS", txtPais.Text);
                comando.Parameters.AddWithValue("@ID_HABITACION", txtHabitacion.Text);
                comando.Parameters.AddWithValue("@ID_HABITACION_ALOJA", txtHabitacion.Text);
                comando.Parameters.AddWithValue("@TIPO_HABITACION", comboTipo.Text);
                comando.Parameters.AddWithValue("@CANTIDAD", comboCantidad.Text);
                comando.Parameters.AddWithValue("@FECHA_ENTRADA", txtFechaEn.Text);
                comando.Parameters.AddWithValue("@DESAYUNO", comboDesa.Text);

                comando.ExecuteNonQuery();
                MessageBox.Show("Registro exitoso");
                


                this.txtRut.Clear();
                this.txtNombre.Clear();
                this.txtDireccion.Clear();
                this.txtPais.Clear();
                this.txtHabitacion.Clear();
                this.txtFechaEn.Clear();

                con.Close();

            }

            catch
            {
                
            }
            finally
            {
               
            }
            
        
        }


     

        private void button5_Click_1(object sender, EventArgs e)
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

                int flag = 0;


                string cadena = "Delete from  ALOJA  where ID_PASAJERO_ALOJA='" + txtId.Text + "'";



                SqlCommand comando = new SqlCommand(cadena, con);

                flag = comando.ExecuteNonQuery();

                if (flag >= 1)
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
            finally
            {

            }

        }      

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EKNJVJF\MSSQLSERVER02;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                int flag = 0;
                string cadena = "update PASAJERO SET RUT='" + txtRut.Text + "',NOMBRE='" + txtNombre.Text + "',DIRECCION='" + txtDireccion.Text + "' where ID_PASAJERO ='" + txtId.Text + "'";
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
            finally { 
            }
        }


        private void button1_Click_2(object sender, EventArgs e)
        {
            Form rec = new Menu_Recepcionista();
            rec.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
     
           
        }

            
        }

