using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_cc
{
    public partial class formFinalizar : Form
    {

        int hora;
        String comentario, matricula, fecha;

        public formFinalizar(String matri, String fech, int hor)
        {
            InitializeComponent();
            matricula = matri;
            fecha = fech;
            hora = hor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comentario = textBox1.Text;
            
            Apartado apartado = new Apartado(comentario, matricula, fecha, hora);
            apartado.agregar_comentario();
            apartado.Show();
            this.Close();
        }
    }
}
