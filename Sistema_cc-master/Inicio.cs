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
using System.IO;

namespace Sistema_cc
{
    public partial class Inicio : Form
    {
        String ruta = "", query = "";
        MySqlConnectionStringBuilder b = new MySqlConnectionStringBuilder();
        MySqlConnection conn;
        MySqlCommand cmd;

        public Inicio()
        {
            InitializeComponent();
        }

        private void apartadoDeHorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Apartado f = new Apartado(".", ",", "-", 1);
            f.Show();
            this.Hide();
        }

         private string[] csvParser(string csv, char separator = ',')
    {
        List <String>parsed = new List<String>();
        string[] temp = csv.Split(separator);
        int counter = 0;
        string data = string.Empty;
        while (counter < temp.Length)
        {
            data = temp[counter].Trim();
            if (data.Trim().StartsWith("\""))
            {
                bool isLast = false;
                while (!isLast && counter < temp.Length)
                {
                    data += separator.ToString() + temp[counter + 1];
                    counter++;
                    isLast = (temp[counter].Trim().EndsWith("\""));
                    query += data;
                }
            }

            parsed.Add(data);
            counter++;
        }

        return parsed.ToArray();
    }

         private void cargarAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
         {


             LoadNewFile();
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
                 MessageBox.Show("no conectó");
                 throw;
             }

             var reader = new StreamReader(File.OpenRead(ruta));
             //var reader = new StreamReader(File.OpenRead(@"C:\Users\luisg\OneDrive\Documentos\Adobe\SCC_ALUMNOS.SCV"));
             List<string> listA = new List<string>();
             List<string> listB = new List<string>();
             int cont = 0, actualizado = 0;
             while (!reader.EndOfStream)
             {
                 if (cont != 0)
                 {
                     var line = reader.ReadLine();
                     //csvParser(line);
                     line = line.Replace("\"", "\'");
                     try
                     {
                         //MessageBox.Show("INSERT INTO scc_alumnos (matricula, paterno, materno, nombre, sexo, cvecarrera, carrera, activo2) values('" + line.Remove(line.Length - 2));
                        // MessageBox.Show("INSERT INTO scc_alumnos (matricula, paterno, materno, nombre, sexo, cvecarrera, carrera, activo2, activo) values(" + line.Remove(line.Length - 2) + ",'T');");
                         cmd.CommandText = "INSERT INTO scc_alumnos (matricula, paterno, materno, nombre, sexo, cvecarrera, carrera, activo2, activo) values(" + line.Remove(line.Length - 2) + ",'T');";
                         cmd.ExecuteNonQuery();
                         // MessageBox.Show(line);
                         cont++;
                     }
                     catch (Exception)
                     {
                         MessageBox.Show("Error al actualizar, verifique que no este registrando un usuario que ya existe");
                         actualizado = 1;
                         break;
                     }
                 }
                 else
                 {
                     var line = reader.ReadLine();
                     //csvParser(line);
                     //MessageBox.Show(line);
                     // cmd.CommandText = "INSERT INTO scc_apartados (matricula, numequipo, numhr, fecha_apartado, numperiodo, fyh, cumplida) values('" + line;
                     //cmd.ExecuteNonQuery();
                     //MessageBox.Show(line);
                     cont++;
                 }
             }
             if (actualizado==0)
             {
                 MessageBox.Show("Base de datos actualizada con exito");
             }
         }

         private void LoadNewFile()
         {
             OpenFileDialog ofd = new OpenFileDialog();
             System.Windows.Forms.DialogResult dr = ofd.ShowDialog();
             if (dr == DialogResult.OK)
             {
                 userSelectedFilePath = ofd.FileName;
             }
         }

         public string userSelectedFilePath
         {
             get
             {
                 return ruta;
             }
             set
             {
                 ruta = value;
             }
         }

         private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
         {
             Administrador admin = new Administrador();
             admin.Show();
             this.Hide();
         }

    }
}


