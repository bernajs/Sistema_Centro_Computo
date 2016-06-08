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
        DialogResult response;
        int fechahabil = 0;
        String coment;



        SqlConnection con = new SqlConnection();
        int[] computadoras = new int[5];
        PictureBox[] compus = new PictureBox[16];
        PictureBox[] compus2 = new PictureBox[16];
        String nombre, matricula, matriculaGlobal, fecha, fechaGlobal;
        int horaglobal;
        int hora;
        int encontradog = 0;
        String horas = "";


        public void conexion()
        {
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

        private void tabControl1_SelectedIndexchanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                comboBox1.Text = comboBox2.Text;
                pintar_pc(obtener_hora1());
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                comboBox2.Text = comboBox1.Text;
                pintar_pc2(obtener_hora());
            }
        }

        public Apartado(String comentario, String matricula, String fecha2, int hora)
        {
            InitializeComponent();

            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexchanged);

            if (dateTimePicker1.Text.Contains("sábado"))
            {
                dateTimePicker1.Text = dateTimePicker1.Value.AddDays(2).ToString();
            }
            else if (dateTimePicker1.Text.Contains("domingo"))
            {
                dateTimePicker1.Text = dateTimePicker1.Value.AddDays(1).ToString();
            }

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

            conexion();
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
            if (matricula != "" || matricula.Contains(' '))
            {
                cmd.CommandText = "SELECT matricula, nombre, paterno, materno, carrera FROM scc_alumnos WHERE matricula = '" + matricula + "' ;";
                MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    MessageBox.Show("Alumno encontrado");
                    foreach (var item in compus)
                    {
                        item.Enabled = true;
                    }
                    encontradog = 1;
                    etNombre.Text = Convert.ToString(r[1]);
                    etAPaterno.Text = Convert.ToString(r[2]);
                    etAMaterno.Text = Convert.ToString(r[3]);
                    etCarrera.Text = Convert.ToString(r[4]);
                    //etFecha.Text = monthCalendar1.SelectionRange.Start.ToString();

                    etFecha.Text = dateTimePicker1.Value.ToShortDateString();
                    comboBox1.Enabled = true;
                    try
                    {
                        pictureBox1.Image = Image.FromFile(@"E:\Estudiantes\" + matricula + ".jpg");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se encontró su fotografiía, por favor pase a servicios escolares para que se la tomen");
                    }

                    encontrado = 1;
                    //comboBox1.Text = "7 am";
                    //comboBox2.Text = "7 am";
                }
               r.Close();

                if (encontrado == 0)
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
            else
            {
                MessageBox.Show("Por favor ingrese una matrícula");
            }
        }

        //Metodo para apartar pc
        public void apartar_pc(int pcnumero)
        {
            hora = obtener_hora1();
            if (hora != 0 && encontradog != 0 && fechahabil == 0)
            {
                int apartado_flag = 0;
                String fechaC = obtener_fecha();
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
                    DialogResult dialogResult = MessageBox.Show("¿Apartar computadora?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        String periodo = "F-A";
                        int pc = pcnumero;
                        //fecha = dateTimePicker1.Value.ToShortDateString();
                        /* horas = comboBox1.Text;
                         horas = horas.Remove(2);
                         horas = horas.Trim();
                         hora = Convert.ToInt32(horas);*/
                        //MessageBox.Show(hora.ToString());
                        //String[] fechar = fecha.Split('/');
                        cmd.CommandText = "INSERT INTO scc_apartados (matricula, numequipo, numhr, fecha_apartado, numperiodo, fyh, cumplida) values('" + matricula + "', '" + pc + "', " + hora + ",'" + fechaC + "', '" + periodo + "', '" + fecha + "', 's');";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(nombre + " has apartado la pc " + pc);
                        compus[pc - 1].Image = Image.FromFile(@"E:\Estudiantes\" + matricula + ".jpg");
                        // compus[pc - 1].BackColor = Color.Red;
                        compus[pc - 1].Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("No se ha apartado un equipo");
                    }
                }
            }
            else if (encontradog==0)
            {
                MessageBox.Show("Por favor ingresa un numero de matricula");
            }
        }

        //Muestra las computadoras apartadas y las deshabilita
        public void pintar_pc(int hour)
        {
            if (hora != 0)
            {
                List<int> pcapartada = new List<int>();
                int i = 0;
                fecha = dateTimePicker1.Value.ToShortDateString();

                String[] fechar = fecha.Split('/');
                String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];
                hora = hour;
                cmd.CommandText = "SELECT numequipo FROM scc_apartados WHERE fecha_apartado = '" + fechaC + "' AND numhr = " + hora + ";";
                MySqlDataReader r = cmd.ExecuteReader();
                String valor = "";

                //Pinta todas de blanco
                foreach (var item in compus)
                {
                    item.Image = null;
                    item.BackColor = Color.White;
                    item.Enabled = true;
                }

                //Pinta las apartadas de rojo
                while (r.Read())
                {
                    valor = Convert.ToString(r[0]);
                    //compus[Convert.ToInt64(valor)-1].BackColor = Color.Red;
                    compus[Convert.ToInt64(valor) - 1].Enabled = false;
                    pcapartada.Add(Convert.ToInt16(valor) - 1);
                }
                r.Close();

                cmd.CommandText = "SELECT numequipo FROM scc_equipos WHERE activo = 'F';";
                MySqlDataReader rhabil = cmd.ExecuteReader();

                int equipoinhabil = 0;
                while (rhabil.Read())
                {
                    valor = Convert.ToString(rhabil[0]);
                    valor = valor.Replace("E","");
                    equipoinhabil = Convert.ToInt16(valor);
                    compus[equipoinhabil-1].BackColor = Color.DarkGray;
                    compus[equipoinhabil-1].Enabled = false;

                }
                rhabil.Close();

                cmd.CommandText = "SELECT matricula FROM scc_apartados WHERE fecha_apartado = '" + fechaC + "' AND numhr = " + hora + ";";
                MySqlDataReader rr = cmd.ExecuteReader();
                //Pinta las apartadas de rojo
                while (rr.Read())
                {
                    valor = Convert.ToString(rr[0]);

                    try
                    {
                        compus[pcapartada.ElementAt(i)].Image = Image.FromFile(@"E:\Estudiantes\" + valor + ".jpg");
                        i++;
                    }
                    catch (Exception)
                    {
                        compus[pcapartada.ElementAt(i)].BackColor = Color.Red;
                        compus[pcapartada.ElementAt(i)].Enabled = false;
                        i++;
                    }
                }
                i = 0;
                rr.Close();
                pcapartada.Clear();
            }

        }

        public void pintar_pc2(int hour)
        {
            if (hora != 0)
            {
                List<int> pcapartada = new List<int>();
                int i = 0;
                fecha = dateTimePicker1.Value.ToShortDateString();

                String[] fechar = fecha.Split('/');
                String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];
                hora = hour;
                cmd.CommandText = "SELECT numequipo, matricula FROM scc_apartados WHERE fecha_apartado = '" + fechaC + "' AND numhr = " + hora + ";";
                MySqlDataReader r = cmd.ExecuteReader();
                String valor = "";

                //Pinta todas de blanco
                foreach (var item in compus2)
                {
                    item.Image = null;
                    item.BackColor = Color.White;
                    item.Enabled = false;
                }

                //Pinta las apartadas de rojo
                while (r.Read())
                {
                    valor = Convert.ToString(r[0]);
                    //compus[Convert.ToInt64(valor)-1].BackColor = Color.Red;
                    compus2[Convert.ToInt64(valor) - 1].Enabled = true;
                    pcapartada.Add(Convert.ToInt16(valor) - 1);
                }
                r.Close();

                cmd.CommandText = "SELECT matricula FROM scc_apartados WHERE fecha_apartado = '" + fechaC + "' AND numhr = " + hora + ";";
                MySqlDataReader rr = cmd.ExecuteReader();
                //Pinta las apartadas de rojo
                while (rr.Read())
                {
                    valor = Convert.ToString(rr[0]);
                    try
                    {
                        compus2[pcapartada.ElementAt(i)].Image = Image.FromFile(@"E:\Estudiantes\" + valor + ".jpg");
                        i++;
                    }
                    catch (Exception)
                    {
                        compus2[pcapartada.ElementAt(i)].BackColor = Color.Red;
                        compus2[pcapartada.ElementAt(i)].Enabled = true;
                        i++;
                    }
                }
                i = 0;
                rr.Close();
                pcapartada.Clear();
            }
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
            String fechaC = obtener_fecha();
            int bandera = 0;
            DateTime fechaini, fechafin;
            String[] fechas = new String[2];
            cmd.CommandText = "SELECT concat(fechaini,' ',fechafin) FROM scc_periodos WHERE activo = 'T';";
            MySqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                fechas = r[0].ToString().Split(' ');
            }
            r.Close();

            fechaini = DateTime.ParseExact(fechas[0], "yyyy-MM-dd", null);
            fechafin = Convert.ToDateTime(fechas[1]);
            String fechar = dateTimePicker1.Value.ToShortDateString();
            if (Convert.ToDateTime(fechar) <= fechaini || Convert.ToDateTime(fechar) >= fechafin)
            {
                fechahabil = 1;
                MessageBox.Show("Esta fecha se encuentra dentro de las vacaciones...");
            }
            else if (dateTimePicker1.Text.Contains("sábado"))
            {
                MessageBox.Show("Lo siento, los sábados no se abre el centro de cómputo");
                fechahabil = 1;
            }
            else if (dateTimePicker1.Text.Contains("domingo"))
            {
                MessageBox.Show("Lo siento, los domingos no se abre el centro de cómputo");
                fechahabil = 1;
            }
            else
            {
                fechahabil = 0;
            }


            pintar_pc(22);
            etFecha.Text = dateTimePicker1.Value.ToShortDateString();

            cmd.CommandText = "SELECT activo FROM scc_inhabiles WHERE dia = '" + fechaC + "';";
            MySqlDataReader rr = cmd.ExecuteReader();
            //Pinta las apartadas de rojo
            while (rr.Read())
            {
                bandera = 1;
            }
            if (bandera==1)
            {
                foreach (var item in compus)
                {
                    item.BackColor = Color.White;
                    item.Enabled = false;
                }
                MessageBox.Show("Lo siento, esta fecha es inhabil");
            }
            rr.Close();

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
            pictureBox1.Image = null;
            comboBox1.Enabled = false;
            encontradog = 0;
        }

        public int obtener_hora()
        {
            try
            {
                horas = comboBox2.Text;
                horas = horas.Remove(2);
                horas = horas.Trim();
                hora = Convert.ToInt32(horas);
                return hora;
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, selecciona una hora");
                return 0;
            }
        }

        public int obtener_hora1()
        {
            horas = comboBox1.Text;
            if (horas != "")
            {
                horas = horas.Remove(2);
                horas = horas.Trim();
                hora = Convert.ToInt32(horas);
                return hora;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una hora");
                return 0;
            }

           /* horas = comboBox1.Text;
            horas = horas.Remove(2);
            horas = horas.Trim();
            hora = Convert.ToInt32(horas);
            return hora;*/
        }

        public String obtener_fecha()
        {
            fecha = dateTimePicker1.Value.ToShortDateString();
            String[] fechar = fecha.Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];
            return fechaC;
        }

        private void pcc1_Click(object sender, EventArgs e)
        {
            cancela_hora(1);
        }



        public void cancela_hora(int equipo)
        {
            hora = obtener_hora();
            fecha = obtener_fecha();

            response = CustomMsgBox.Show("¿Qué desea hacer con la hora apartada?", "MSG", "Finalizar", "Cancelar", "Salir");
            if (response == DialogResult.Yes)
            {
             //   MessageBox.Show("Entro a Finalizar");
                obtener_numero_control(equipo);


                DialogResult dialogResult = MessageBox.Show("¿Desea finalizar hora?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    DialogResult dialogResult1 = MessageBox.Show("¿Desea agregar un comentario?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        formFinalizar formFin = new formFinalizar(matriculaGlobal, fecha, hora);
                        formFin.Show();
                    }
                    cmd.CommandText = "DELETE FROM scc_apartados WHERE fecha_apartado = '" + fecha + "' AND numhr = " + hora + " AND numequipo =" + equipo + ";";
                    cmd.ExecuteNonQuery();
                    pintar_pc(22);
                }
            }
            else if (response == DialogResult.No)
            {
                obtener_numero_control(equipo);

                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea cancelar la hora?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    //MessageBox.Show("DELETE FROM scc_apartados WHERE fecha_apartado = '" + fecha + "' AND numhr = " + hora + "AND numequipo =" + equipo + ";");
                    cmd.CommandText = "DELETE FROM scc_apartados WHERE fecha_apartado = '" + fecha + "' AND numhr = " + hora + " AND numequipo =" + equipo + ";";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Hora cancelada");
                }

            }
            else if (response == DialogResult.OK)
            {
                //MessageBox.Show("nel prro");
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
            fecha = obtener_fecha();
            cmd.CommandText = "SELECT matricula FROM scc_apartados WHERE fecha_apartado = '" + fecha + "' AND numhr = " + hora + " AND numequipo = " + pc + ";";
            MySqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                matriculaGlobal = Convert.ToString(r[0]);
            }
            r.Close();
        }

        private void pcc2_Click(object sender, EventArgs e)
        {
            cancela_hora(2);
        }

        private void pcc3_Click(object sender, EventArgs e)
        {
            cancela_hora(3);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void pcc4_Click(object sender, EventArgs e)
        {
            cancela_hora(4);
        }

        private void pcc5_Click(object sender, EventArgs e)
        {
            cancela_hora(5);
        }

        private void pcc6_Click(object sender, EventArgs e)
        {
            cancela_hora(6);
        }

        private void pcc7_Click(object sender, EventArgs e)
        {
            cancela_hora(7);
        }

        private void pcc8_Click(object sender, EventArgs e)
        {
            cancela_hora(8);
        }

        private void pcc9_Click(object sender, EventArgs e)
        {
            cancela_hora(9);
        }

        private void pcc10_Click(object sender, EventArgs e)
        {
            cancela_hora(10);
        }

        private void pcc11_Click(object sender, EventArgs e)
        {
            cancela_hora(11);
        }

        private void pcc12_Click(object sender, EventArgs e)
        {
            cancela_hora(12);
        }

        private void pcc13_Click(object sender, EventArgs e)
        {
            cancela_hora(13);
        }

        private void pcc14_Click(object sender, EventArgs e)
        {
            cancela_hora(14);
        }

        private void pcc15_Click(object sender, EventArgs e)
        {
            cancela_hora(15);
        }

        private void pcc16_Click(object sender, EventArgs e)
        {
            cancela_hora(16);
        }

        private void menúPrincipalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Inicio i = new Inicio();
            this.Close();
            i.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrador ad = new Administrador();
            //Application.Exit();
            ad.Show();
            this.Close();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
