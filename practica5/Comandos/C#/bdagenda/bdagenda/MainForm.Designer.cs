namespace AgendaApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPersonales;
        private System.Windows.Forms.TabPage tabDireccion;

        private System.Windows.Forms.Button btnConectar, btnDesconectar;
        private System.Windows.Forms.Button btnConsultar, btnAgregar, btnEditar, btnBorrar, btnLimpiar;

        private System.Windows.Forms.TextBox txtServidor, txtBuscar;
        private System.Windows.Forms.Label lblServidor, lblBuscar, lblContador;

        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btnExaminarFoto, btnQuitarFoto;
        private System.Windows.Forms.Label lblFoto;

        private System.Windows.Forms.TextBox txtId, txtNombres, txtPaterno, txtMaterno, txtCurp, txtFechaNac, txtSemestre, txtSexo, txtTelefono, txtDireccion, txtCorreo, txtEmergencia, txtSangre;
        private System.Windows.Forms.Label lblId, lblNombres, lblPaterno, lblMaterno, lblCurp, lblFechaNac, lblSemestre, lblSexo, lblTelefono, lblDireccion, lblCorreo, lblEmergencia, lblSangre;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPersonales = new System.Windows.Forms.TabPage();
            this.tabDireccion = new System.Windows.Forms.TabPage();

            this.btnConectar = new System.Windows.Forms.Button();
            this.btnDesconectar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();

            this.txtServidor = new System.Windows.Forms.TextBox();
            this.lblServidor = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblContador = new System.Windows.Forms.Label();

            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.btnExaminarFoto = new System.Windows.Forms.Button();
            this.btnQuitarFoto = new System.Windows.Forms.Button();
            this.lblFoto = new System.Windows.Forms.Label();

            this.txtId = new System.Windows.Forms.TextBox(); this.lblId = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox(); this.lblNombres = new System.Windows.Forms.Label();
            this.txtPaterno = new System.Windows.Forms.TextBox(); this.lblPaterno = new System.Windows.Forms.Label();
            this.txtMaterno = new System.Windows.Forms.TextBox(); this.lblMaterno = new System.Windows.Forms.Label();
            this.txtCurp = new System.Windows.Forms.TextBox(); this.lblCurp = new System.Windows.Forms.Label();
            this.txtFechaNac = new System.Windows.Forms.TextBox(); this.lblFechaNac = new System.Windows.Forms.Label();
            this.txtSemestre = new System.Windows.Forms.TextBox(); this.lblSemestre = new System.Windows.Forms.Label();
            this.txtSexo = new System.Windows.Forms.TextBox(); this.lblSexo = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox(); this.lblTelefono = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox(); this.lblDireccion = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox(); this.lblCorreo = new System.Windows.Forms.Label();
            this.txtEmergencia = new System.Windows.Forms.TextBox(); this.lblEmergencia = new System.Windows.Forms.Label();
            this.txtSangre = new System.Windows.Forms.TextBox(); this.lblSangre = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPersonales.SuspendLayout();
            this.tabDireccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.SuspendLayout();

            // --- TABCONTROL (Ampliado a 150px de alto para que la foto y botones respiren) ---
            this.tabControl1.Controls.Add(this.tabPersonales);
            this.tabControl1.Controls.Add(this.tabDireccion);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Size = new System.Drawing.Size(595, 150);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

            this.tabPersonales.Text = "1. Datos Personales";
            this.tabPersonales.BackColor = System.Drawing.Color.White;
            this.tabDireccion.Text = "2. Dirección, Contacto y Foto";
            this.tabDireccion.BackColor = System.Drawing.Color.White;

            // --- PESTAÑA 1: DATOS PERSONALES ---
            this.lblId.Text = "ID:"; this.lblId.Location = new System.Drawing.Point(10, 18); this.lblId.Size = new System.Drawing.Size(25, 20);
            this.txtId.Location = new System.Drawing.Point(35, 15); this.txtId.Size = new System.Drawing.Size(45, 23);

            this.lblNombres.Text = "Nombres:"; this.lblNombres.Location = new System.Drawing.Point(88, 18); this.lblNombres.Size = new System.Drawing.Size(62, 20);
            this.txtNombres.Location = new System.Drawing.Point(150, 15); this.txtNombres.Size = new System.Drawing.Size(120, 23);

            this.lblPaterno.Text = "Paterno:"; this.lblPaterno.Location = new System.Drawing.Point(278, 18); this.lblPaterno.Size = new System.Drawing.Size(55, 20);
            this.txtPaterno.Location = new System.Drawing.Point(335, 15); this.txtPaterno.Size = new System.Drawing.Size(100, 23);

            this.lblMaterno.Text = "Materno:"; this.lblMaterno.Location = new System.Drawing.Point(442, 18); this.lblMaterno.Size = new System.Drawing.Size(58, 20);
            this.txtMaterno.Location = new System.Drawing.Point(500, 15); this.txtMaterno.Size = new System.Drawing.Size(75, 23);

            this.lblCurp.Text = "CURP:"; this.lblCurp.Location = new System.Drawing.Point(10, 52); this.lblCurp.Size = new System.Drawing.Size(45, 20);
            this.txtCurp.Location = new System.Drawing.Point(60, 49); this.txtCurp.Size = new System.Drawing.Size(135, 23);

            this.lblFechaNac.Text = "Nac (DD/MM/AAAA):"; this.lblFechaNac.Location = new System.Drawing.Point(202, 52); this.lblFechaNac.Size = new System.Drawing.Size(118, 20);
            this.txtFechaNac.Location = new System.Drawing.Point(320, 49); this.txtFechaNac.Size = new System.Drawing.Size(85, 23);

            this.lblSemestre.Text = "Sem:"; this.lblSemestre.Location = new System.Drawing.Point(412, 52); this.lblSemestre.Size = new System.Drawing.Size(35, 20);
            this.txtSemestre.Location = new System.Drawing.Point(448, 49); this.txtSemestre.Size = new System.Drawing.Size(35, 23);

            this.lblSexo.Text = "Sexo:"; this.lblSexo.Location = new System.Drawing.Point(490, 52); this.lblSexo.Size = new System.Drawing.Size(40, 20);
            this.txtSexo.Location = new System.Drawing.Point(535, 49); this.txtSexo.Size = new System.Drawing.Size(40, 23);

            this.lblTelefono.Text = "Tel:"; this.lblTelefono.Location = new System.Drawing.Point(10, 86); this.lblTelefono.Size = new System.Drawing.Size(30, 20);
            this.txtTelefono.Location = new System.Drawing.Point(45, 83); this.txtTelefono.Size = new System.Drawing.Size(110, 23);

            this.tabPersonales.Controls.Add(this.lblId); this.tabPersonales.Controls.Add(this.txtId);
            this.tabPersonales.Controls.Add(this.lblNombres); this.tabPersonales.Controls.Add(this.txtNombres);
            this.tabPersonales.Controls.Add(this.lblPaterno); this.tabPersonales.Controls.Add(this.txtPaterno);
            this.tabPersonales.Controls.Add(this.lblMaterno); this.tabPersonales.Controls.Add(this.txtMaterno);
            this.tabPersonales.Controls.Add(this.lblCurp); this.tabPersonales.Controls.Add(this.txtCurp);
            this.tabPersonales.Controls.Add(this.lblFechaNac); this.tabPersonales.Controls.Add(this.txtFechaNac);
            this.tabPersonales.Controls.Add(this.lblSemestre); this.tabPersonales.Controls.Add(this.txtSemestre);
            this.tabPersonales.Controls.Add(this.lblSexo); this.tabPersonales.Controls.Add(this.txtSexo);
            this.tabPersonales.Controls.Add(this.lblTelefono); this.tabPersonales.Controls.Add(this.txtTelefono);

            // --- PESTAÑA 2: DIRECCIÓN, CONTACTO Y FOTO (Coordenadas corregidas) ---
            this.lblDireccion.Text = "Dirección:"; this.lblDireccion.Location = new System.Drawing.Point(10, 18); this.lblDireccion.Size = new System.Drawing.Size(65, 20);
            this.txtDireccion.Location = new System.Drawing.Point(80, 15); this.txtDireccion.Size = new System.Drawing.Size(190, 23);

            this.lblCorreo.Text = "Correo:"; this.lblCorreo.Location = new System.Drawing.Point(275, 18); this.lblCorreo.Size = new System.Drawing.Size(50, 20);
            this.txtCorreo.Location = new System.Drawing.Point(325, 15); this.txtCorreo.Size = new System.Drawing.Size(145, 23);

            this.lblEmergencia.Text = "C. Emergencia:"; this.lblEmergencia.Location = new System.Drawing.Point(10, 55); this.lblEmergencia.Size = new System.Drawing.Size(90, 20);
            this.txtEmergencia.Location = new System.Drawing.Point(100, 52); this.txtEmergencia.Size = new System.Drawing.Size(120, 23);

            this.lblSangre.Text = "T. Sangre:"; this.lblSangre.Location = new System.Drawing.Point(230, 55); this.lblSangre.Size = new System.Drawing.Size(65, 20);
            this.txtSangre.Location = new System.Drawing.Point(295, 52); this.txtSangre.Size = new System.Drawing.Size(65, 23);

            // Botones de Foto bien posicionados y visibles
            this.btnExaminarFoto.Text = "Subir Foto...";
            this.btnExaminarFoto.Location = new System.Drawing.Point(100, 86);
            this.btnExaminarFoto.Size = new System.Drawing.Size(110, 28);
            this.btnExaminarFoto.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnExaminarFoto.ForeColor = System.Drawing.Color.White;
            this.btnExaminarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminarFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminarFoto.Click += new System.EventHandler(this.btnExaminarFoto_Click);

            this.btnQuitarFoto.Text = "Quitar Foto";
            this.btnQuitarFoto.Location = new System.Drawing.Point(220, 86);
            this.btnQuitarFoto.Size = new System.Drawing.Size(95, 28);
            this.btnQuitarFoto.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnQuitarFoto.ForeColor = System.Drawing.Color.White;
            this.btnQuitarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarFoto.Click += new System.EventHandler(this.btnQuitarFoto_Click);

            this.lblFoto.Text = "Foto (Clic):";
            this.lblFoto.Location = new System.Drawing.Point(485, 6);
            this.lblFoto.Size = new System.Drawing.Size(90, 16);

            this.pbFoto.Location = new System.Drawing.Point(485, 24);
            this.pbFoto.Size = new System.Drawing.Size(90, 90);
            this.pbFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFoto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFoto.Click += new System.EventHandler(this.btnExaminarFoto_Click);

            this.tabDireccion.Controls.Add(this.lblDireccion); this.tabDireccion.Controls.Add(this.txtDireccion);
            this.tabDireccion.Controls.Add(this.lblCorreo); this.tabDireccion.Controls.Add(this.txtCorreo);
            this.tabDireccion.Controls.Add(this.lblEmergencia); this.tabDireccion.Controls.Add(this.txtEmergencia);
            this.tabDireccion.Controls.Add(this.lblSangre); this.tabDireccion.Controls.Add(this.txtSangre);
            this.tabDireccion.Controls.Add(this.btnExaminarFoto);
            this.tabDireccion.Controls.Add(this.btnQuitarFoto);
            this.tabDireccion.Controls.Add(this.lblFoto);
            this.tabDireccion.Controls.Add(this.pbFoto);

            // --- BARRA INTERMEDIA: ESTADO DE RED OCULTO + BUSCADOR INTERACTIVO ---
            this.lblServidor.Text = "Estado Red:";
            this.lblServidor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblServidor.Location = new System.Drawing.Point(12, 172);
            this.lblServidor.Size = new System.Drawing.Size(75, 20);

            this.txtServidor.Location = new System.Drawing.Point(90, 169);
            this.txtServidor.Size = new System.Drawing.Size(130, 23);
            this.txtServidor.ReadOnly = true;
            this.txtServidor.TabStop = false;
            this.txtServidor.Text = "IP conectada";
            this.txtServidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtServidor.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.txtServidor.ForeColor = System.Drawing.Color.White;
            this.txtServidor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.lblBuscar.Text = "Buscar alumno:";
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.Location = new System.Drawing.Point(235, 172);
            this.lblBuscar.Size = new System.Drawing.Size(95, 20);

            this.txtBuscar.Location = new System.Drawing.Point(332, 169);
            this.txtBuscar.Size = new System.Drawing.Size(175, 23);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            this.lblContador.Text = "Total: 0";
            this.lblContador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblContador.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.lblContador.Location = new System.Drawing.Point(518, 172);
            this.lblContador.Size = new System.Drawing.Size(90, 20);

            // --- BOTONES LATERALES DE ACCIÓN ---
            this.btnConectar.Text = "Reconectar";
            this.btnConectar.Location = new System.Drawing.Point(620, 12);
            this.btnConectar.Size = new System.Drawing.Size(75, 26);
            this.btnConectar.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnConectar.ForeColor = System.Drawing.Color.White;
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);

            this.btnDesconectar.Text = "Desconectar";
            this.btnDesconectar.Location = new System.Drawing.Point(700, 12);
            this.btnDesconectar.Size = new System.Drawing.Size(80, 26);
            this.btnDesconectar.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDesconectar.ForeColor = System.Drawing.Color.White;
            this.btnDesconectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);

            this.btnConsultar.Text = "Actualizar Tabla";
            this.btnConsultar.Location = new System.Drawing.Point(620, 44);
            this.btnConsultar.Size = new System.Drawing.Size(160, 26);
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);

            this.btnAgregar.Text = "Agregar Alumno";
            this.btnAgregar.Location = new System.Drawing.Point(620, 74);
            this.btnAgregar.Size = new System.Drawing.Size(160, 26);
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            this.btnEditar.Text = "Guardar Cambios (ID)";
            this.btnEditar.Location = new System.Drawing.Point(620, 104);
            this.btnEditar.Size = new System.Drawing.Size(160, 26);
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnEditar.ForeColor = System.Drawing.Color.Black;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnBorrar.Text = "Borrar por ID";
            this.btnBorrar.Location = new System.Drawing.Point(620, 134);
            this.btnBorrar.Size = new System.Drawing.Size(160, 26);
            this.btnBorrar.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnBorrar.ForeColor = System.Drawing.Color.White;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);

            this.btnLimpiar.Text = "Limpiar Formulario";
            this.btnLimpiar.Location = new System.Drawing.Point(620, 166);
            this.btnLimpiar.Size = new System.Drawing.Size(160, 26);
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(23, 162, 184);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // --- TABLA DE DATOS (DATAGRIDVIEW) ---
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 200);
            this.dataGridView1.Size = new System.Drawing.Size(768, 255);
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // --- FORMULARIO PRINCIPAL ---
            this.ClientSize = new System.Drawing.Size(794, 468);
            this.BackColor = System.Drawing.Color.FromArgb(242, 245, 250);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblServidor); this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.lblBuscar); this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.btnConectar); this.Controls.Add(this.btnDesconectar);
            this.Controls.Add(this.btnConsultar); this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEditar); this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agenda Estudiantil - Panel de Base de Datos";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPersonales.ResumeLayout(false);
            this.tabPersonales.PerformLayout();
            this.tabDireccion.ResumeLayout(false);
            this.tabDireccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}