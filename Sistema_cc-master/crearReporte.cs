using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Sistema_cc
{
    public partial class crearReporte : Form
    {

        MySqlConnectionStringBuilder b = new MySqlConnectionStringBuilder();
        MySqlConnection conn;
        MySqlCommand cmd;
        String matricula = "";
        List<String> matriculas = new List<String>();

        DataTable dt;
        MySqlDataAdapter da;
        DataSet ds;
        frmReportes rpt;

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

        public crearReporte()
        {
            InitializeComponent();
            conexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable data;
            String nombre="";
            String fecha = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
            String query = string.Format("SELECT scc_apartados.matricula, scc_alumnos.nombre, scc_alumnos.paterno, scc_alumnos.materno, scc_apartados.numequipo, scc_apartados.numhr, scc_apartados.fecha_apartado FROM scc_apartados, scc_alumnos WHERE scc_apartados.fecha_apartado = '{0}' AND scc_apartados.cumplida ='s' AND scc_apartados.matricula = scc_alumnos.matricula;", fecha);

            String query1 = string.Format("SELECT numapartado, matricula, numequipo FROM scc_apartados WHERE fecha_apartado = '{0}' AND cumplida ='s';", fecha);

            cmd.CommandText = query1;
            MySqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                matriculas.Add(r[1].ToString());
            }
            r.Close();
          

            for (int i = 0; i < matriculas.Count; i++)
            {
                cmd.CommandText = string.Format("SELECT nombre, paterno, materno FROM scc_alumnos WHERE matricula='{0}';", matriculas.ElementAt(i));
                MySqlDataReader rm = cmd.ExecuteReader();

                while (rm.Read())
                {
                    nombre = rm[0].ToString() + " " + rm[1].ToString() + " " + rm[2].ToString();
                }
                rm.Close();
            }

            data = tabla(query);

            if (data.Rows.Count==0)
            {
                MessageBox.Show("No se encontró nada");
                dataGridView1.DataSource = null;
            }
            else if (data.Rows.Count>0)
            {
                dataGridView1.DataSource = data;
                CrystalReport1 objrpt = new CrystalReport1();
                objrpt.SetDataSource(data);
                rpt = new frmReportes();
                rpt.crystalReportViewer1.ReportSource = objrpt;
                
                
            }

           // CrystalReport1 objrpt = new CrystalReport1();

            



        }


        public DataTable tabla(String sql)
        {
            dt = new DataTable();
            da = new MySqlDataAdapter();
            ds = new DataSet();

            da.SelectCommand = new MySqlCommand(sql, conn);
            da.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rpt.ShowDialog();
        }
    }
}
