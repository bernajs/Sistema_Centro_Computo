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
    public partial class Administrador : Form
    {
        Inicio i = new Inicio();
        Apartado a = new Apartado("","","", 0);
        MySqlConnectionStringBuilder b = new MySqlConnectionStringBuilder();
        MySqlConnection conn;
        MySqlCommand cmd;
        String matricula, nombre, apaterno, amaterno, sexo, cvcarrera, carrera;
        String fecha;
        String fechaini, fechafin, anioini, aniofin;
        String periodofinal, periodos;
        String[] pe;
        int carreraIndex = -1, bandera = 0, periodo = 8;

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
        
        public Administrador()
        {
            InitializeComponent();
            conexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(331, 338);

            /*monthCalendar1.Enabled = false;
            monthCalendar1.Visible = false;


            btnRegistrar.Enabled = false;
            btnRegistrar.Visible = false;
            btnFecha.Enabled = false;
            btnFecha.Visible = false;


            btnAceptar.Enabled = true;
            btnAceptar.Visible = true;
            btnAtras.Enabled = true;
            btnAtras.Visible = true;

            lblMatricula.Enabled = true;
            lblMatricula.Visible = true;
            lblNombre.Enabled = true;
            lblNombre.Visible = true;
            lblPaterno.Enabled = true;
            lblPaterno.Visible = true;
            lblMaterno.Enabled = true;
            lblMaterno.Visible = true;
            lblMatricula.Visible = true;
            lblSexo.Enabled = true;
            lblSexo.Visible = true;
            lblCarrera.Enabled = true;
            lblCarrera.Visible = true;
            etCarrera.Enabled = true;
            etCarrera.Visible = true;


            etMatricula.Enabled = true;
            etMatricula.Visible = true;
            etNombre.Enabled = true;
            etNombre.Visible = true;
            etPaterno.Enabled = true;
            etPaterno.Visible = true;
            etMaterno.Enabled = true;
            etMaterno.Visible = true;
            etSexo.Enabled = true;
            etSexo.Visible = true;*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {

            /*btnRegistrar.Enabled = true;
            btnRegistrar.Visible = true;
            btnFecha.Enabled = true;
            btnFecha.Visible = true;

            btnAceptar.Enabled = false;
            btnAceptar.Visible = false;
            btnAtras.Enabled = false;
            btnAtras.Visible = false;*/

            /*lblMatricula.Enabled = false;
            lblMatricula.Visible = false;
            lblNombre.Enabled = false;
            lblNombre.Visible = false;
            lblPaterno.Enabled = false;
            lblPaterno.Visible = false;
            lblMaterno.Enabled = false;
            lblMaterno.Visible = false;
            lblMatricula.Visible = false;
            lblSexo.Enabled = false;
            lblSexo.Visible = false;
            lblCarrera.Enabled = false;
            lblCarrera.Visible = false;*/

            etMatricula.Text = "";
            etNombre.Text = "";
            etPaterno.Text = "";
            etMaterno.Text = "";
            etSexo.Text = "";

            etCarrera.Text = "";

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            matricula = etMatricula.Text;
            apaterno = etPaterno.Text;
            amaterno = etMaterno.Text;
            nombre = etNombre.Text;
            carreraIndex = etCarrera.SelectedIndex;
            sexo = etSexo.Text;
            if (matricula != "" && apaterno != "" && amaterno != "" && nombre != "" && carreraIndex !=-1  && sexo != "")
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea agregar a este alumno?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (carreraIndex == 0)
                    {
                        carrera = "Ingenieria en Gestion Empresarial";
                        cvcarrera = "IGEM";
                    }
                    else if (carreraIndex == 1)
                    {
                        carrera = "Ingenieria Industrial";
                        cvcarrera = "IIND";
                    }
                    else if (carreraIndex == 2)
                    {
                        carrera = "Ingenieria en Sistemas Computacionales";
                        cvcarrera = "ISIC";
                    }
                    else if (carreraIndex == 3)
                    {
                        carrera = "Ingenieria en Innovacion Agricola Sustentable";
                        cvcarrera = "IIAS";
                    }
                    //
                    MessageBox.Show(string.Format("INSERT INTO scc_alumnos(matricula,paterno,materno,nombre,sexo,cvecarrera,carrera,activo2,activo) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','INSCRITO','T');", matricula, apaterno, amaterno, nombre, sexo, cvcarrera, carrera));

                    try
                    {
                        cmd.CommandText = string.Format("INSERT INTO scc_alumnos(matricula,paterno,materno,nombre,sexo,cvecarrera,carrera,activo2,activo) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','INSCRITO','T');", matricula, apaterno, amaterno, nombre, sexo, cvcarrera, carrera);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Alumno agregado correctamente");
                    }
                    catch
                    {
                        MessageBox.Show("Datos incorrectos, por favor vuelva a intentarlo");
                    }
                }
                else
                {
                    MessageBox.Show("Alumno no agregado");
                }
            }
            else
            {
                MessageBox.Show("Por favor llene todos los campos");
            }
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
           /* btnRegistrar.Visible = false;
            btnRegistrar.Enabled = false;

            btnAceptarF.Enabled = true;
            btnAceptarF.Visible = true;
            btnAtrasF.Enabled = true;
            btnAtrasF.Visible = true;


            btnFecha.Visible = false;
            btnFecha.Enabled = false;

            this.Size = new Size(355, 315);
            monthCalendar1.Enabled = true;
            monthCalendar1.Visible = true;*/
        }

        private void btnAceptarF_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea agregar esta fecha?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    fecha = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
                    MessageBox.Show(fecha);
                    //MessageBox.Show(string.Format("INSERT INTO scc_inhabiles VALUES('{0}', '{1}');", fecha, "T"));
                    cmd.CommandText = string.Format("INSERT INTO scc_inhabiles VALUES('{0}', '{1}');", fecha, "T");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fecha agregada correctamente");
                }
                catch (Exception)
                {
                    MessageBox.Show("Esta fecha ya se encuentra agregada");
                }
            }
            else
            {
                MessageBox.Show("Fecha no agregada");
            }
        }

        private void btnAtrasF_Click(object sender, EventArgs e)
        {
            this.Size = new Size(331, 338);
            monthCalendar1.Enabled = false;
            monthCalendar1.Visible = false;
            btnAceptarF.Enabled = false;
            btnAceptarF.Visible = false;
        }

        private void menúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            i.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            a.Show();
            //Application.Exit();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String equipoinhabil = "";
            int numequipoinhabil = 0;
            equipoinhabil = etEquipo.Text;
            DateTime now = DateTime.Now;
            String[] fechar = now.ToString().Substring(0,10).Split('/');
            String fechaC = fechar[2] + "-" + fechar[1] + "-" + fechar[0];
            try
            {
                numequipoinhabil = Convert.ToInt32(equipoinhabil);
                if (numequipoinhabil > 9 && numequipoinhabil < 17)
                {
                    cmd.CommandText = "UPDATE scc_equipos SET activo = 'F' AND fecha ='" + fechaC + "' WHERE numequipo = 'E0" + numequipoinhabil.ToString() + "';";
                    cmd.ExecuteNonQuery();
                }
                else if (numequipoinhabil < 9)
                {
                    MessageBox.Show("UPDATE scc_equipos SET activo = 'F' AND fecha ='" + fechaC + "' WHERE numequipo = 'E0" + numequipoinhabil.ToString() + "';");
                    cmd.CommandText = "UPDATE scc_equipos SET activo = 'F', fecha ='" + fechaC + "' WHERE numequipo = 'E0" + numequipoinhabil.ToString() + "';";
                    cmd.ExecuteNonQuery();
                }
                etEquipo.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, solo ingresa el número de equipo");
                etEquipo.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String equipoinhabil = "";
            String fechaC = "0";
            int numequipoinhabil = 0;
            equipoinhabil = etEquipoHabilitar.Text;
            try
            {
                numequipoinhabil = Convert.ToInt16(equipoinhabil);
                if (numequipoinhabil > 9)
                {
                    cmd.CommandText = "UPDATE scc_equipos SET activo = 'T' AND fecha ='" + fechaC + "' WHERE numequipo = 'E0" + numequipoinhabil.ToString() + "';";
                    cmd.ExecuteNonQuery();
                }
                else if (numequipoinhabil < 9)
                {
                    cmd.CommandText = "UPDATE scc_equipos SET activo = 'T' AND fecha ='"+ fechaC +"' WHERE numequipo = 'E0" + numequipoinhabil.ToString() + "';";
                    cmd.ExecuteNonQuery();
                }
                etEquipoHabilitar.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, solo ingresa el número de equipo");
                etEquipoHabilitar.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthCalendar2.Enabled = true;
            MessageBox.Show("Por favor seleccione el dia de inicio de periodo");
            bandera = 1;
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            periodos = "P000" + periodo;
            pe = comboBox1.Text.ToString().Split('-');
            if (bandera == 1)
            {
                fechaini = fecha = monthCalendar2.SelectionStart.ToString("yyyy-MM-dd");
                anioini = fecha = monthCalendar2.SelectionStart.ToString("yyyy");
                bandera = 2;
                MessageBox.Show("Por favor, selecciona la fecha final del periodo");
            }
            else if (bandera == 2)
            {
                fechafin = fecha = monthCalendar2.SelectionStart.ToString("yyyy-MM-dd");
                aniofin = fecha = monthCalendar2.SelectionStart.ToString("yyyy");
                bandera = 3;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bandera == 3)
            {
                fechafin = fecha = monthCalendar2.SelectionStart.ToString("yyyy-MM-dd");
                aniofin = fecha = monthCalendar2.SelectionStart.ToString("yyyy");
                periodofinal = pe[0].Trim() + " " + anioini + " - " + pe[1].Trim() + " " + aniofin;
                bandera = 3;
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea agregar este periodo?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    cmd.CommandText = "UPDATE scc_periodos SET activo = 'F' WHERE activo = 'T';";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = string.Format("INSERT INTO scc_periodos VALUES('{0}', '{1}', '{2}', '{3}', '{4}');", periodos, periodofinal, fechaini, fechafin, "T");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Periodo agregado correctamente, ahora este periodo será el que este en uso");
                    periodo++;
                    //bandera = 0;
                }
                else
                {
                    bandera = 0;
                    MessageBox.Show("Si desea agregar un periodo vuelva hacer los mismos pasos");
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione el periodo, fecha de inicio y fecha final");
            }
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
