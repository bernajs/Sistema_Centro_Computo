namespace Sistema_cc
{
    partial class Administrador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnFecha = new System.Windows.Forms.Button();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPaterno = new System.Windows.Forms.Label();
            this.lblMaterno = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.etMatricula = new System.Windows.Forms.TextBox();
            this.etNombre = new System.Windows.Forms.TextBox();
            this.etPaterno = new System.Windows.Forms.TextBox();
            this.etMaterno = new System.Windows.Forms.TextBox();
            this.etSexo = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnAtrasF = new System.Windows.Forms.Button();
            this.btnAceptarF = new System.Windows.Forms.Button();
            this.etCarrera = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menúPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAlumno = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(93, 33);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(100, 24);
            this.btnRegistrar.TabIndex = 0;
            this.btnRegistrar.Text = "Registrar alumno";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFecha
            // 
            this.btnFecha.Location = new System.Drawing.Point(93, 79);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(100, 26);
            this.btnFecha.TabIndex = 1;
            this.btnFecha.Text = "Fecha inhabil";
            this.btnFecha.UseVisualStyleBackColor = true;
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Enabled = false;
            this.lblMatricula.Location = new System.Drawing.Point(71, 60);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(50, 13);
            this.lblMatricula.TabIndex = 2;
            this.lblMatricula.Text = "Matricula";
            this.lblMatricula.Visible = false;
            this.lblMatricula.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Enabled = false;
            this.lblNombre.Location = new System.Drawing.Point(77, 86);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.Visible = false;
            // 
            // lblPaterno
            // 
            this.lblPaterno.AutoSize = true;
            this.lblPaterno.Enabled = false;
            this.lblPaterno.Location = new System.Drawing.Point(38, 110);
            this.lblPaterno.Name = "lblPaterno";
            this.lblPaterno.Size = new System.Drawing.Size(83, 13);
            this.lblPaterno.TabIndex = 4;
            this.lblPaterno.Text = "Apellido paterno";
            this.lblPaterno.Visible = false;
            // 
            // lblMaterno
            // 
            this.lblMaterno.AutoSize = true;
            this.lblMaterno.Enabled = false;
            this.lblMaterno.Location = new System.Drawing.Point(36, 134);
            this.lblMaterno.Name = "lblMaterno";
            this.lblMaterno.Size = new System.Drawing.Size(85, 13);
            this.lblMaterno.TabIndex = 5;
            this.lblMaterno.Text = "Apellido materno";
            this.lblMaterno.Visible = false;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Enabled = false;
            this.lblSexo.Location = new System.Drawing.Point(90, 157);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(31, 13);
            this.lblSexo.TabIndex = 6;
            this.lblSexo.Text = "Sexo";
            this.lblSexo.Visible = false;
            // 
            // lblCarrera
            // 
            this.lblCarrera.AutoSize = true;
            this.lblCarrera.Enabled = false;
            this.lblCarrera.Location = new System.Drawing.Point(77, 181);
            this.lblCarrera.Name = "lblCarrera";
            this.lblCarrera.Size = new System.Drawing.Size(41, 13);
            this.lblCarrera.TabIndex = 7;
            this.lblCarrera.Text = "Carrera";
            this.lblCarrera.Visible = false;
            this.lblCarrera.Click += new System.EventHandler(this.label6_Click);
            // 
            // etMatricula
            // 
            this.etMatricula.Enabled = false;
            this.etMatricula.Location = new System.Drawing.Point(127, 57);
            this.etMatricula.Name = "etMatricula";
            this.etMatricula.Size = new System.Drawing.Size(100, 20);
            this.etMatricula.TabIndex = 8;
            this.etMatricula.Visible = false;
            // 
            // etNombre
            // 
            this.etNombre.Enabled = false;
            this.etNombre.Location = new System.Drawing.Point(127, 83);
            this.etNombre.Name = "etNombre";
            this.etNombre.Size = new System.Drawing.Size(100, 20);
            this.etNombre.TabIndex = 9;
            this.etNombre.Visible = false;
            // 
            // etPaterno
            // 
            this.etPaterno.Enabled = false;
            this.etPaterno.Location = new System.Drawing.Point(127, 107);
            this.etPaterno.Name = "etPaterno";
            this.etPaterno.Size = new System.Drawing.Size(100, 20);
            this.etPaterno.TabIndex = 10;
            this.etPaterno.Visible = false;
            // 
            // etMaterno
            // 
            this.etMaterno.Enabled = false;
            this.etMaterno.Location = new System.Drawing.Point(127, 131);
            this.etMaterno.Name = "etMaterno";
            this.etMaterno.Size = new System.Drawing.Size(100, 20);
            this.etMaterno.TabIndex = 11;
            this.etMaterno.Visible = false;
            // 
            // etSexo
            // 
            this.etSexo.Enabled = false;
            this.etSexo.Location = new System.Drawing.Point(127, 154);
            this.etSexo.Name = "etSexo";
            this.etSexo.Size = new System.Drawing.Size(100, 20);
            this.etSexo.TabIndex = 12;
            this.etSexo.Visible = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(185, 205);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Visible = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Enabled = false;
            this.btnAtras.Location = new System.Drawing.Point(80, 205);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 15;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Visible = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(41, 60);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 16;
            this.monthCalendar1.Visible = false;
            // 
            // btnAtrasF
            // 
            this.btnAtrasF.Enabled = false;
            this.btnAtrasF.Location = new System.Drawing.Point(74, 234);
            this.btnAtrasF.Name = "btnAtrasF";
            this.btnAtrasF.Size = new System.Drawing.Size(75, 23);
            this.btnAtrasF.TabIndex = 18;
            this.btnAtrasF.Text = "Atras";
            this.btnAtrasF.UseVisualStyleBackColor = true;
            this.btnAtrasF.Visible = false;
            this.btnAtrasF.Click += new System.EventHandler(this.btnAtrasF_Click);
            // 
            // btnAceptarF
            // 
            this.btnAceptarF.Enabled = false;
            this.btnAceptarF.Location = new System.Drawing.Point(179, 234);
            this.btnAceptarF.Name = "btnAceptarF";
            this.btnAceptarF.Size = new System.Drawing.Size(75, 23);
            this.btnAceptarF.TabIndex = 17;
            this.btnAceptarF.Text = "Aceptar";
            this.btnAceptarF.UseVisualStyleBackColor = true;
            this.btnAceptarF.Visible = false;
            this.btnAceptarF.Click += new System.EventHandler(this.btnAceptarF_Click);
            // 
            // etCarrera
            // 
            this.etCarrera.Items.AddRange(new object[] {
            "Ingeniería en Gestión Empresarial",
            "Ingeniería Industrial",
            "Ingeniería en Sistemas Computacionales",
            "Ingeniería en Innovacion Agrícola"});
            this.etCarrera.Location = new System.Drawing.Point(127, 178);
            this.etCarrera.Name = "etCarrera";
            this.etCarrera.Size = new System.Drawing.Size(165, 21);
            this.etCarrera.TabIndex = 0;
            this.etCarrera.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(317, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menúPrincipalToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // menúPrincipalToolStripMenuItem
            // 
            this.menúPrincipalToolStripMenuItem.Name = "menúPrincipalToolStripMenuItem";
            this.menúPrincipalToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.menúPrincipalToolStripMenuItem.Text = "Menú principal";
            this.menúPrincipalToolStripMenuItem.Click += new System.EventHandler(this.menúPrincipalToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // lblAlumno
            // 
            this.lblAlumno.AutoSize = true;
            this.lblAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumno.Location = new System.Drawing.Point(75, 24);
            this.lblAlumno.Name = "lblAlumno";
            this.lblAlumno.Size = new System.Drawing.Size(175, 25);
            this.lblAlumno.TabIndex = 20;
            this.lblAlumno.Text = "Registrar alumno";
            this.lblAlumno.Visible = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(88, 26);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(141, 25);
            this.lblFecha.TabIndex = 21;
            this.lblFecha.Text = "Fecha inhabil";
            this.lblFecha.Visible = false;
            // 
            // Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 252);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblAlumno);
            this.Controls.Add(this.etCarrera);
            this.Controls.Add(this.btnAtrasF);
            this.Controls.Add(this.btnAceptarF);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.etSexo);
            this.Controls.Add(this.etMaterno);
            this.Controls.Add(this.etPaterno);
            this.Controls.Add(this.etNombre);
            this.Controls.Add(this.etMatricula);
            this.Controls.Add(this.lblCarrera);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.lblMaterno);
            this.Controls.Add(this.lblPaterno);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.btnFecha);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Administrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnFecha;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPaterno;
        private System.Windows.Forms.Label lblMaterno;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblCarrera;
        private System.Windows.Forms.TextBox etMatricula;
        private System.Windows.Forms.TextBox etNombre;
        private System.Windows.Forms.TextBox etPaterno;
        private System.Windows.Forms.TextBox etMaterno;
        private System.Windows.Forms.TextBox etSexo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnAtrasF;
        private System.Windows.Forms.Button btnAceptarF;
        private System.Windows.Forms.ComboBox etCarrera;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menúPrincipalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Label lblAlumno;
        private System.Windows.Forms.Label lblFecha;
    }
}