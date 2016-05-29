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
using MySql.Data.MySqlClient;
namespace Sistema_cc
{
    public partial class Apartado : Form
    {
        MySqlConnectionStringBuilder b = new MySqlConnectionStringBuilder();
        MySqlConnection conn;
        MySqlCommand cmd;

        String coment;

        SqlConnection con = new SqlConnection();
        int[] computadoras = new int[5];
        PictureBox[] compus = new PictureBox[16];
        PictureBox[] compus2 = new PictureBox[16];
        String nombre, matricula, matriculaGlobal, fecha, fechaGlobal;
        int horaglobal;
        int hora;
        String horas = "";

        public Apartado(String comentario, String matricula, String fecha2, int hora)
        {
            InitializeComponent();

            coment = comentario;
            matriculaGlobal = matricula;
            horaglobal = hora;
            fechaGlobal = fecha2;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            dateTimePicker1.MinDate = DateTime.Today;

            //Guarda los imagebox en un arreglo
            compus[0] = pc1;
            compus[1] = pc2;
            compus[2] = pc3;
            compus[3] = pc4;
            compus[4] = pc5;
            compus[5] = pc6;
            compus[6] = pc7;
            compus[7] = pc8;
            compus[8] = pc9;
            compus[9] = pc10;
            compus[10] = pc11;
            compus[11] = pc12;
            compus[12] = pc13;
            compus[13] = pc14;
            compus[14] = pc15;
            compus[15] = pc16;
            compus2[0] = pcc1;
            compus2[1] = pcc2;
            compus2[2] = pcc3;
            compus2[3] = pcc4;
            compus2[4] = pcc5;
            compus2[5] = pcc6;
            compus2[6] = pcc7;
            compus2[7] = pcc8;
            compus2[8] = pcc9;
            compus2[9] = pcc10;
            compus2[10] = pcc11;
            compus2[11] = pcc12;
            compus2[12] = pcc13;
            compus2[13] = pcc14;
            compus2[14] = pcc15;
            compus2[15] = pcc16;


            //Hace la conexion a la db
            b.Server = "localhost";
            b.UserID = "root";
            b.Password = "root";
            b.Database = "sistemacc";
            try
            {
                conn = new MySqlConnection(b.ToString());
                conn.Open();
                cmd = conn.CreateCommand();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void agregar_comentario()
        {

            cmd.CommandText = "UPDATE scc_apartados SET cumplida = '1', comentarios = '" + coment + "' WHERE fecha_apartado = '" + fechaGlobal + "' AND numhr = " + horaglobal + " AND matricula = '" + matriculaGlobal + "';";
            cmd.ExecuteNonQuery();
            //MessageBox.Show("UPDATE scc_apartados SET cumplida = '1', comentarios = '" + coment + "' WHERE fecha_apartado = '" + fechaGlobal + "' AND numhr = " + horaglobal + " AND matricula = '" + matriculaGlobal + "';");
            MessageBox.Show("Hora finalizada");
        }

        //Busca matricula
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int encontrado = 0;
            //this.AcceptButton =
            matricula = etMatricula.Text;
            cmd.CommandText = "SELECT matricula, nombre, paterno, materno, carrera FROM scc_alumnos WHERE matricula = '" + matricula + "' ;";
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                MessageBox.Show("Alumno encontrado");
                etNombre.Text = Convert.ToString(r[1]);
                etAPaterno.Text = Convert.ToString(r[2]);
                etAMaterno.Text = Convert.ToString(r[3]);
                etCarrera.Text = Convert.ToString(r[4]);
                //etFecha.Text = monthCalendar1.SelectionRange.Start.ToString();

                etFecha.Text = dateTimePicker1.Value.ToShortDateString();
                comboBox1.Enabled = true;
                encontrado = 1;
            }
            r.Close();
            comboBox1.Text = "7 am";

            if (encontrado==0)
            {
                etMatricula.Text = "";
                etNombre.Text = "";
                etAPaterno.Text = "";
                etAMaterno.Text = "";
                etCarrera.Text = "";
                etFecha.Text = "";
                comboBox1.Enabled = false;
                MessageBox.Show("No se encontró el número de control");
            }
            else
            {
                encontrado = 0;
            }
        }

        //Metodo para apartar pc
        public void apartar_pc(int pcnumero)
        {
            int apartado_flag = 0;

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];
            cmd.CommandText = "SELECT numequipo FROM scc_apartados WHERE fecha_apartado = '" + fechaC + "' AND numhr = " + hora + " AND matricula = '" + matricula + "';";
            MySqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                apartado_flag = 1;
                break;
            }
            r.Close();
            if (apartado_flag == 1)
            {
                MessageBox.Show("Ya has apartado un equipo en este día y a esta hora");
            }
            else
            {
                nombre = etNombre.Text;
                DialogResult dialogResult = MessageBox.Show("¿Apartar computadora?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    String periodo = "F-A";
                    int pc = pcnumero;
                    //fecha = dateTimePicker1.Value.ToShortDateString();
                    horas = comboBox1.Text;
                    horas = horas.Remove(2);
                    horas = horas.Trim();
                    hora = Convert.ToInt32(horas);
                    //String[] fechar = fecha.Split('/');
                    cmd.CommandText = "INSERT INTO scc_apartados (matricula, numequipo, numhr, fecha_apartado, numperiodo, fyh, cumplida) values('" + matricula + "', '" + pc + "', " + hora + ",'" + fechar[2] + "-" + fechar[1] + "-" + fechar[0] + "', '" + periodo + "', '" + fecha + "', 's');";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(nombre + " has apartado la pc " + pc);
                    compus[pc - 1].BackColor = Color.Red;
                    compus[pc - 1].Enabled = false;
                }
                else
                {
                    MessageBox.Show("No se ha apartado un equipo");
                }
            }
        }

        //Muestra las computadoras apartadas y las deshabilita
        public void pintar_pc(int hour)
        {
            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];
            hora = hour;
            cmd.CommandText = "SELECT numequipo FROM scc_apartados WHERE fecha_apartado = '" + fechaC + "' AND numhr = " + hora +  ";";
            MySqlDataReader r = cmd.ExecuteReader();
            String valor = "";

            //Pinta todas de blanco
            foreach (var item in compus)
            {
                item.BackColor = Color.White;
                item.Enabled = true;
            }

            //Pinta las apartadas de rojo
            while (r.Read())
            {
                valor = Convert.ToString(r[0]);
                compus[Convert.ToInt64(valor)-1].BackColor = Color.Red;
                compus[Convert.ToInt64(valor)-1].Enabled = false;
            }
            r.Close();
        }

        public void pintar_pc2(int hour)
        {
            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];
            hora = hour;
            cmd.CommandText = "SELECT numequipo FROM scc_apartados WHERE fecha_apartado = '" + fechaC + "' AND numhr = " + hora + ";";
            MySqlDataReader r = cmd.ExecuteReader();
            String valor = "";

            //Pinta todas de blanco
            foreach (var item in compus2)
            {
                item.BackColor = Color.White;
                item.Enabled = false;
            }

            //Pinta las apartadas de rojo
            while (r.Read())
            {
                valor = Convert.ToString(r[0]);
                compus2[Convert.ToInt64(valor) - 1].BackColor = Color.Red;
                compus2[Convert.ToInt64(valor) - 1].Enabled = true;
                //compus2[Convert.ToInt64(valor) - 1].Enabled = false;
            }
            r.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            horas = comboBox1.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            pintar_pc(hora);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            pintar_pc(22);
            etFecha.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void Apartado_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            apartar_pc(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            apartar_pc(2);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            apartar_pc(10);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            apartar_pc(9);
        }

        private void pc3_Click(object sender, EventArgs e)
        {
            apartar_pc(3);
        }

        private void pc4_Click(object sender, EventArgs e)
        {
            apartar_pc(4);
        }

        private void pc5_Click(object sender, EventArgs e)
        {
            apartar_pc(5);
        }

        private void pc6_Click(object sender, EventArgs e)
        {
            apartar_pc(6);
        }

        private void pc7_Click(object sender, EventArgs e)
        {
            apartar_pc(7);
        }

        private void pc8_Click(object sender, EventArgs e)
        {
            apartar_pc(8);
        }

        private void pc11_Click(object sender, EventArgs e)
        {
            apartar_pc(11);
        }

        private void pc12_Click(object sender, EventArgs e)
        {
            apartar_pc(12);
        }

        private void pc13_Click(object sender, EventArgs e)
        {
            apartar_pc(13);
        }

        private void pc14_Click(object sender, EventArgs e)
        {
            apartar_pc(14);
        }

        private void pc15_Click(object sender, EventArgs e)
        {
            apartar_pc(15);
        }

        private void pc16_Click(object sender, EventArgs e)
        {
            apartar_pc(16);
        }

        //Limpia todos los campos
        private void button1_Click(object sender, EventArgs e)
        {
            etMatricula.Text = "";
            etNombre.Text = "";
            etAPaterno.Text = "";
            etAMaterno.Text = "";
            etCarrera.Text = "";
            etFecha.Text = "";
            comboBox1.Enabled = false;
        }

        private void pcc1_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(1);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();
                    
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            pintar_pc2(hora);


        }

        public void obtener_numero_control(int pc)
        {
            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            cmd.CommandText = "SELECT matricula FROM scc_apartados WHERE fecha_apartado = '" + fechaC + "' AND numhr = " + hora + " AND numequipo = " + pc + ";";
            MySqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                matriculaGlobal = Convert.ToString(r[0]);
            }
            r.Close();
        }

        private void pcc2_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(2);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        private void pcc3_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(3);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void pcc4_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(4);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        private void pcc5_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(5);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        private void pcc6_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(6);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        private void pcc7_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(7);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        private void pcc8_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(8);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        private void pcc9_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(9);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        private void pcc10_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(10);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        private void pcc11_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(11);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        private void pcc12_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(12);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        private void pcc13_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(13);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        private void pcc14_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(14);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        private void pcc15_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(15);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        private void pcc16_Click(object sender, EventArgs e)
        {
            horas = comboBox2.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);

            fecha = dateTimePicker1.Value.ToShortDateString();

            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];

            obtener_numero_control(16);
            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    formFinalizar formFin = new formFinalizar(matriculaGlobal, fechaC, hora);
                    formFin.Show();

                }
            }
        }

        

        private void menúPrincipalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Inicio i = new Inicio();
            this.Close();
            i.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
