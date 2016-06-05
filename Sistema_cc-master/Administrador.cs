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
        Apartado ap = new Apartado("", "", "", 0);
        MySqlConnection conn;
        MySqlCommand cmd;
        String matricula, nombre, apaterno, amaterno, sexo, cvcarrera;
        int carrera;
        
        public Administrador()
        {
            InitializeComponent();
            ap.conexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(331, 338);

            monthCalendar1.Enabled = false;
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
            etSexo.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {

            this.Size = new Size(242, 250);

            btnRegistrar.Enabled = true;
            btnRegistrar.Visible = true;
            btnFecha.Enabled = true;
            btnFecha.Visible = true;

            btnAceptar.Enabled = false;
            btnAceptar.Visible = false;
            btnAtras.Enabled = false;
            btnAtras.Visible = false;

            lblMatricula.Enabled = false;
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
            lblCarrera.Visible = false;

            etMatricula.Enabled = false;
            etMatricula.Visible = false;
            etNombre.Enabled = false;
            etNombre.Visible = false;
            etPaterno.Enabled = false;
            etPaterno.Visible = false;
            etMaterno.Enabled = false;
            etMaterno.Visible = false;
            etSexo.Enabled = false;
            etSexo.Visible = false;

            etCarrera.Enabled = false;
            etCarrera.Visible = false;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            matricula = etMatricula.Text;
            apaterno = etPaterno.Text;
            amaterno = etMaterno.Text;
            nombre = etNombre.Text;
            carrera = etCarrera.SelectedIndex;
            sexo = etSexo.Text;

            if (carrera==0)
            {
                cvcarrera = "IGEM";
            }
            else if (carrera==1)
            {
                cvcarrera = "IIND";
            }
            else if (carrera==2)
            {
                cvcarrera = "ISIC";
            }
            else if (carrera==3)
            {
                cvcarrera = "IIAS";
            }
            //
            MessageBox.Show(string.Format("INSERT INTO scc_alumnos(matricula,paterno,materno,nombre,sexo,cvecarrera,carrera,activo2,activo) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','INSCRITO','T');", matricula, apaterno, amaterno, nombre, sexo, cvcarrera, carrera));
            cmd.CommandText = string.Format("INSERT INTO scc_alumnos(matricula,paterno,materno,nombre,sexo,cvecarrera,carrera,activo2,activo) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','INSCRITO','T');", matricula, apaterno, amaterno, nombre, sexo, cvcarrera, carrera);
            cmd.ExecuteNonQuery();
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            btnRegistrar.Visible = false;
            btnRegistrar.Enabled = false;

            btnAceptarF.Enabled = true;
            btnAceptarF.Visible = true;
            btnAtrasF.Enabled = true;
            btnAtrasF.Visible = true;


            btnFecha.Visible = false;
            btnFecha.Enabled = false;

            this.Size = new Size(355, 315);
            monthCalendar1.Enabled = true;
            monthCalendar1.Visible = true;
        }

        private void btnAceptarF_Click(object sender, EventArgs e)
        {

        }

        private void btnAtrasF_Click(object sender, EventArgs e)
        {
            this.Size = new Size(331, 338);
            monthCalendar1.Enabled = false;
            monthCalendar1.Visible = false;
            btnAceptarF.Enabled = false;
            btnAceptarF.Visible = false;
            btnAtrasF.Enabled = false;
            btnAtrasF.Visible = false;
            
            btnRegistrar.Enabled = true;
            btnRegistrar.Visible = true;
            btnFecha.Enabled = true;
            btnFecha.Visible = true;
        }
    }
}
