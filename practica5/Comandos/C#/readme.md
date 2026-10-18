```csharp
// 🚀 1. Punto de entrada de la aplicación (Program.cs)
// Explicación: Este archivo es el punto de inicio de tu programa. Su única función es configurar los estilos 
// visuales básicos de Windows y lanzar la ventana principal (MainForm) en cuanto el usuario ejecuta la aplicación.

using System;
using System.Windows.Forms;

namespace AgendaApp
{
    internal sealed class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

// =========================================================================================================
// =========================================================================================================

// 🎨 2. Diseño de la Interfaz Gráfica (MainForm.Designer.cs)
// Explicación: Este archivo es el "esqueleto" visual de tu agenda. Aquí se define por código toda la estructura 
// de la ventana: las posiciones, tamaños y colores de los botones, las cajas de texto, las pestañas de 
// navegación y la tabla de datos (DataGridView).

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

// =========================================================================================================
// =========================================================================================================

// 🧠 3. Lógica del Sistema (MainForm.cs)
// Explicación: Este es el "cerebro" o núcleo de la aplicación. Aquí se aloja toda la lógica de programación 
// detrás del diseño, incluyendo la conexión remota a la base de datos MySQL, la detección automática de 
// cambios en tu red (para mantener la IP actualizada), las reglas de validación de los campos y la optimización de fotos.

using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace AgendaApp
{
    public partial class MainForm : Form
    {
        const string BASE_DATOS = "agenda";
        const string USUARIO = "fernando-pina";
        const string CONTRASENA = "Ferxho117104";
        const int PUERTO = 3306;

        MySqlConnection conexionGlobal = new MySqlConnection();
        byte[] fotoActual = new byte[0];
        string archivoServidor = Path.Combine(Application.StartupPath, "servidor.txt");
        string ipOcultaActual = "localhost";

        public MainForm()
        {
            InitializeComponent();

            // 1. Evento de autocompletado por ID
            txtId.Leave += new EventHandler(txtId_Leave);

            // 2. REGLA: CURP de 18 caracteres y en mayúsculas automáticamente
            txtCurp.MaxLength = 18;
            txtCurp.CharacterCasing = CharacterCasing.Upper;

            // 3. REGLA: Teléfonos de máximo 10 dígitos
            txtTelefono.MaxLength = 10;
            txtEmergencia.MaxLength = 10;

            // 4. REGLA: Eventos para que el teclado solo escriba números en estos campos
            txtTelefono.KeyPress += new KeyPressEventHandler(SoloNumeros_KeyPress);
            txtEmergencia.KeyPress += new KeyPressEventHandler(SoloNumeros_KeyPress);
            txtSemestre.KeyPress += new KeyPressEventHandler(SoloNumeros_KeyPress);
            txtSemestre.MaxLength = 2;

            // 5. Estilizar la tabla y controles para mayor interactividad
            PersonalizarTablaYControles();

            // 6. Detectar cambio de red Wi-Fi / Ethernet automáticamente
            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(CambioDeRed_Detectado);
            NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(DisponibilidadRed_Detectada);

            // 7. Conectar en automático al abrir el programa
            this.Shown += (s, e) => ConectarAutomaticamente();
        }

        // =====================================================================
        // SECCIÓN 1: DETECCIÓN AUTOMÁTICA DE RED Y "IP conectada" EN VERDE
        // =====================================================================
        private void CambioDeRed_Detectado(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() => ConectarAutomaticamente()));
            }
        }

        private void DisponibilidadRed_Detectada(object sender, NetworkAvailabilityEventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    if (e.IsAvailable) ConectarAutomaticamente();
                    else MostrarEstadoConexion(false, "Sin Internet");
                }));
            }
        }

        private void MostrarEstadoConexion(bool conectado, string mensajeAlternativo = "")
        {
            if (conectado)
            {
                txtServidor.Text = "IP conectada";
                txtServidor.BackColor = Color.FromArgb(40, 167, 69); // Verde
                txtServidor.ForeColor = Color.White;
            }
            else
            {
                txtServidor.Text = string.IsNullOrEmpty(mensajeAlternativo) ? "Buscando red..." : mensajeAlternativo;
                txtServidor.BackColor = Color.FromArgb(220, 53, 69); // Rojo
                txtServidor.ForeColor = Color.White;
            }
        }

        private async void ConectarAutomaticamente()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                MostrarEstadoConexion(false, "Sin red");
                return;
            }

            MostrarEstadoConexion(false, "Actualizando IP...");

            await Task.Run(() =>
            {
                ipOcultaActual = DetectarMejorIPServidor();
            });

            try
            {
                if (conexionGlobal.State == ConnectionState.Open)
                    conexionGlobal.Close();

                conexionGlobal.ConnectionString = ConstruirCadenaConexion(ipOcultaActual);
                conexionGlobal.Open();

                GuardarServidor(ipOcultaActual);
                MostrarEstadoConexion(true); // Pone "IP conectada" en verde
                CargarTablaSilencioso();
            }
            catch
            {
                MostrarEstadoConexion(false, "Servidor inactivo");
            }
        }

        private string DetectarMejorIPServidor()
        {
            string ipGuardada = LeerServidorGuardado();
            string ipDeMiRedActual = ObtenerIPv4DeRedActiva();

            // 1. Si la IP guardada responde en la red actual, úsala inmediatamente
            if (!string.IsNullOrEmpty(ipGuardada) && ProbarPuertoMySQL(ipGuardada, PUERTO, 350))
            {
                return ipGuardada;
            }

            // 2. Si cambiamos de Wi-Fi/Red y MySQL está en esta computadora, actualizamos a la nueva IP local
            if (!string.IsNullOrEmpty(ipDeMiRedActual) && ProbarPuertoMySQL(ipDeMiRedActual, PUERTO, 350))
            {
                return ipDeMiRedActual;
            }

            // 3. Probar localhost directamente
            if (ProbarPuertoMySQL("127.0.0.1", PUERTO, 300))
            {
                return "127.0.0.1";
            }

            // 4. Si MySQL está en otro equipo de la nueva red Wi-Fi, escanea el segmento actual (ej. 192.168.1.X)
            if (!string.IsNullOrEmpty(ipDeMiRedActual))
            {
                string[] octetos = ipDeMiRedActual.Split('.');
                if (octetos.Length == 4)
                {
                    string prefijo = octetos[0] + "." + octetos[1] + "." + octetos[2] + ".";
                    string ipEncontrada = "";
                    Parallel.For(1, 255, (i, loopState) =>
                    {
                        string ipCandidata = prefijo + i.ToString();
                        if (ProbarPuertoMySQL(ipCandidata, PUERTO, 220))
                        {
                            ipEncontrada = ipCandidata;
                            loopState.Stop();
                        }
                    });
                    if (!string.IsNullOrEmpty(ipEncontrada)) return ipEncontrada;
                }
            }

            return ipGuardada;
        }

        private string ObtenerIPv4DeRedActiva()
        {
            try
            {
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.OperationalStatus == OperationalStatus.Up &&
                        (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                         ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet))
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                return ip.Address.ToString();
                            }
                        }
                    }
                }
            }
            catch { }
            return "";
        }

        private bool ProbarPuertoMySQL(string host, int port, int timeoutMs)
        {
            try
            {
                using (TcpClient tcp = new TcpClient())
                {
                    IAsyncResult ar = tcp.BeginConnect(host, port, null, null);
                    bool conectado = ar.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(timeoutMs));
                    if (conectado && tcp.Connected)
                    {
                        tcp.EndConnect(ar);
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }

        // =====================================================================
        // SECCIÓN 2: MANEJO DE FOTOS OPTIMIZADO (COMPRESIÓN PARA MYSQL BLOB)
        // =====================================================================
        private byte[] OptimizarImagenParaBD(string rutaArchivo)
        {
            // Redimensiona a máximo 400x400px y comprime en JPG para que quepa en cualquier columna BLOB de MySQL
            using (Image imgOriginal = Image.FromFile(rutaArchivo))
            {
                int maxLado = 400;
                int ancho = imgOriginal.Width;
                int alto = imgOriginal.Height;

                if (ancho > maxLado || alto > maxLado)
                {
                    if (ancho > alto)
                    {
                        alto = (int)(alto * ((float)maxLado / ancho));
                        ancho = maxLado;
                    }
                    else
                    {
                        ancho = (int)(ancho * ((float)maxLado / alto));
                        alto = maxLado;
                    }
                }

                using (Bitmap bmpRedimensionado = new Bitmap(imgOriginal, new Size(ancho, alto)))
                using (MemoryStream ms = new MemoryStream())
                {
                    bmpRedimensionado.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
        }

        private Image ImagenDesdeBytes(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            using (Image original = Image.FromStream(ms))
            {
                return new Bitmap(original);
            }
        }

        private void QuitarFoto()
        {
            if (pbFoto.Image != null)
            {
                pbFoto.Image.Dispose();
                pbFoto.Image = null;
            }
            fotoActual = new byte[0];
        }

        private void MostrarFoto(byte[] bytes)
        {
            Image nueva = ImagenDesdeBytes(bytes);
            if (pbFoto.Image != null) pbFoto.Image.Dispose();
            pbFoto.Image = nueva;
            fotoActual = bytes;
        }

        private void btnExaminarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar foto de perfil";
                ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] bytesOptimizados = OptimizarImagenParaBD(ofd.FileName);
                        MostrarFoto(bytesOptimizados);
                        // Cambia automáticamente a la pestaña 2 para que el usuario vea la foto cargada
                        tabControl1.SelectedTab = tabDireccion;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo procesar la imagen: " + ex.Message);
                    }
                }
            }
        }

        private void btnQuitarFoto_Click(object sender, EventArgs e)
        {
            QuitarFoto();
        }

        // =====================================================================
        // SECCIÓN 3: INTERACTIVIDAD DEL MENÚ Y FILTRO EN TIEMPO REAL
        // =====================================================================
        private void PersonalizarTablaYControles()
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 37, 41);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 249);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            // Iluminar cajas de texto al recibir foco
            foreach (Control c in tabPersonales.Controls)
            {
                if (c is TextBox)
                {
                    c.Enter += (s, e) => c.BackColor = Color.FromArgb(232, 240, 254);
                    c.Leave += (s, e) => c.BackColor = Color.White;
                }
            }
            foreach (Control c in tabDireccion.Controls)
            {
                if (c is TextBox)
                {
                    c.Enter += (s, e) => c.BackColor = Color.FromArgb(232, 240, 254);
                    c.Leave += (s, e) => c.BackColor = Color.White;
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            if (dt == null) return;

            string texto = txtBuscar.Text.Trim().Replace("'", "''");
            if (string.IsNullOrEmpty(texto))
            {
                dt.DefaultView.RowFilter = "";
            }
            else
            {
                dt.DefaultView.RowFilter = string.Format(
                    "nombres LIKE '%{0}%' OR apellido_paterno LIKE '%{0}%' OR apellido_materno LIKE '%{0}%' OR curp LIKE '%{0}%' OR telefono LIKE '%{0}%' OR correo LIKE '%{0}%'",
                    texto);
            }
            lblContador.Text = "Total: " + dt.DefaultView.Count;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCamposSinMensaje();
        }

        // =====================================================================
        // SECCIÓN 4: OPERACIONES CRUD Y VALIDACIONES
        // =====================================================================
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private string Capitalizar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return "";
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto.Trim().ToLower());
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            if (conexionGlobal.State != ConnectionState.Open) return;
            if (string.IsNullOrWhiteSpace(txtId.Text)) return;

            int id;
            if (!int.TryParse(txtId.Text.Trim(), out id)) return;

            string query = @"SELECT dp.*, d.direccion, d.correo, d.contacto_emergencia, d.tipo_sangre, d.foto 
                             FROM datos_personales dp 
                             LEFT JOIN direccion d ON dp.id = d.id_datos 
                             WHERE dp.id = @id";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conexionGlobal))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtNombres.Text = reader["nombres"].ToString();
                            txtPaterno.Text = reader["apellido_paterno"].ToString();
                            txtMaterno.Text = reader["apellido_materno"].ToString();
                            txtCurp.Text = reader["curp"].ToString();

                            if (reader["fecha_nacimiento"] != DBNull.Value)
                            {
                                txtFechaNac.Text = Convert.ToDateTime(reader["fecha_nacimiento"]).ToString("dd/MM/yyyy");
                            }
                            else { txtFechaNac.Text = ""; }

                            txtSemestre.Text = reader["semestre"].ToString();
                            txtSexo.Text = reader["sexo"].ToString();
                            txtTelefono.Text = reader["telefono"].ToString();
                            txtDireccion.Text = reader["direccion"].ToString();
                            txtCorreo.Text = reader["correo"].ToString();
                            txtEmergencia.Text = reader["contacto_emergencia"].ToString();
                            txtSangre.Text = reader["tipo_sangre"].ToString();

                            byte[] bytesBD = reader["foto"] as byte[];
                            if (bytesBD != null && bytesBD.Length > 0) { fotoActual = bytesBD; }
                            else { fotoActual = new byte[0]; }
                        }
                    }
                }

                if (fotoActual.Length > 0)
                {
                    try { MostrarFoto(fotoActual); } catch { QuitarFoto(); }
                }
                else
                {
                    QuitarFoto();
                }
            }
            catch { }
        }

        private string LeerServidorGuardado()
        {
            try
            {
                if (File.Exists(archivoServidor))
                {
                    string s = File.ReadAllText(archivoServidor).Trim();
                    if (s.Length > 0) return s;
                }
            }
            catch { }
            return "localhost";
        }

        private void GuardarServidor(string servidor)
        {
            try { File.WriteAllText(archivoServidor, servidor); } catch { }
        }

        private string ConstruirCadenaConexion(string servidor)
        {
            return string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};Connection Timeout=5;SslMode=None;",
                servidor, PUERTO, BASE_DATOS, USUARIO, CONTRASENA);
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            ConectarAutomaticamente();
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conexionGlobal.State == ConnectionState.Open)
                {
                    conexionGlobal.Close();
                    MostrarEstadoConexion(false, "Desconectado");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al desconectar: " + ex.Message); }
        }

        private bool ValidarConexion()
        {
            if (conexionGlobal.State != ConnectionState.Open)
            {
                ConectarAutomaticamente();
                if (conexionGlobal.State != ConnectionState.Open)
                {
                    MessageBox.Show("Intentando conectar con el servidor MySQL. Verifica que el servicio esté activo.");
                    return false;
                }
            }
            return true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

            txtId.Text = Convert.ToString(fila.Cells["id"].Value);
            txtNombres.Text = Convert.ToString(fila.Cells["nombres"].Value);
            txtPaterno.Text = Convert.ToString(fila.Cells["apellido_paterno"].Value);
            txtMaterno.Text = Convert.ToString(fila.Cells["apellido_materno"].Value);
            txtCurp.Text = Convert.ToString(fila.Cells["curp"].Value);

            object fecha = fila.Cells["fecha_nacimiento"].Value;
            if (fecha != null && fecha != DBNull.Value)
            {
                txtFechaNac.Text = Convert.ToDateTime(fecha).ToString("dd/MM/yyyy");
            }
            else { txtFechaNac.Text = ""; }

            txtSemestre.Text = Convert.ToString(fila.Cells["semestre"].Value);
            txtSexo.Text = Convert.ToString(fila.Cells["sexo"].Value);
            txtTelefono.Text = Convert.ToString(fila.Cells["telefono"].Value);
            txtDireccion.Text = Convert.ToString(fila.Cells["direccion"].Value);
            txtCorreo.Text = Convert.ToString(fila.Cells["correo"].Value);
            txtEmergencia.Text = Convert.ToString(fila.Cells["contacto_emergencia"].Value);
            txtSangre.Text = Convert.ToString(fila.Cells["tipo_sangre"].Value);

            byte[] bytesBD = fila.Cells["foto"].Value as byte[];
            if (bytesBD != null && bytesBD.Length > 0)
            {
                try { MostrarFoto(bytesBD); } catch { QuitarFoto(); }
            }
            else { QuitarFoto(); }
        }

        private bool LeerFecha(out object fecha)
        {
            fecha = DBNull.Value;
            if (string.IsNullOrWhiteSpace(txtFechaNac.Text)) return true;

            DateTime d;
            string[] formatos = { "dd/MM/yyyy", "yyyy-MM-dd", "d/M/yyyy" };
            if (DateTime.TryParseExact(txtFechaNac.Text.Trim(), formatos, null, DateTimeStyles.None, out d))
            {
                fecha = d.ToString("yyyy-MM-dd");
                return true;
            }
            MessageBox.Show("Usa el formato DD/MM/AAAA en la fecha de nacimiento (Ej. 01/12/2000).");
            return false;
        }

        private bool LeerSemestre(out int semestre)
        {
            semestre = 0;
            if (string.IsNullOrWhiteSpace(txtSemestre.Text)) return true;
            if (int.TryParse(txtSemestre.Text.Trim(), out semestre)) return true;

            MessageBox.Show("El semestre debe ser un número.");
            return false;
        }

        private bool LeerId(out int id)
        {
            if (int.TryParse(txtId.Text.Trim(), out id)) return true;
            MessageBox.Show("Ingresa o selecciona un ID numérico.");
            return false;
        }

        private bool ValidarNuevasReglas()
        {
            if (!string.IsNullOrWhiteSpace(txtCurp.Text) && txtCurp.Text.Trim().Length != 18)
            {
                MessageBox.Show("La CURP debe tener exactamente 18 caracteres.");
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) && txtTelefono.Text.Trim().Length != 10)
            {
                MessageBox.Show("El teléfono propio debe tener exactamente 10 dígitos.");
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtEmergencia.Text) && txtEmergencia.Text.Trim().Length != 10)
            {
                MessageBox.Show("El teléfono de emergencia debe tener exactamente 10 dígitos.");
                return false;
            }
            return true;
        }

        private void CargarTablaSilencioso()
        {
            if (conexionGlobal.State != ConnectionState.Open) return;

            string query = @"SELECT dp.id, dp.nombres, dp.apellido_paterno, dp.apellido_materno, dp.curp,
                                    dp.fecha_nacimiento, dp.semestre, dp.sexo, dp.telefono,
                                    d.direccion, d.correo, d.contacto_emergencia, d.tipo_sangre, d.foto
                             FROM datos_personales dp
                             LEFT JOIN direccion d ON dp.id = d.id_datos
                             ORDER BY dp.id";
            try
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexionGlobal))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    lblContador.Text = "Total: " + dt.Rows.Count;
                }

                if (dataGridView1.Columns.Contains("foto"))
                {
                    dataGridView1.Columns["foto"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al consultar: " + ex.Message); }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!ValidarConexion()) return;
            CargarTablaSilencioso();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarConexion()) return;

            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("Escribe al menos el nombre.");
                return;
            }

            string sexo = txtSexo.Text.Trim().ToUpper();
            if (sexo != "M" && sexo != "F" && sexo != "")
            {
                MessageBox.Show("El apartado Sexo solo admite 'M', 'F' o dejarlo vacío.");
                return;
            }

            if (!ValidarNuevasReglas()) return;

            object fecha;
            int semestre;
            if (!LeerFecha(out fecha)) return;
            if (!LeerSemestre(out semestre)) return;

            MySqlTransaction tx = null;
            try
            {
                tx = conexionGlobal.BeginTransaction();

                string queryPersona = @"INSERT INTO datos_personales
                    (nombres, apellido_paterno, apellido_materno, curp, fecha_nacimiento, semestre, sexo, telefono)
                    VALUES (@nom, @pat, @mat, @curp, @fNac, @sem, @sex, @tel); SELECT LAST_INSERT_ID();";

                int nuevoId;
                using (MySqlCommand cmd = new MySqlCommand(queryPersona, conexionGlobal, tx))
                {
                    cmd.Parameters.AddWithValue("@nom", Capitalizar(txtNombres.Text));
                    cmd.Parameters.AddWithValue("@pat", Capitalizar(txtPaterno.Text));
                    cmd.Parameters.AddWithValue("@mat", Capitalizar(txtMaterno.Text));
                    cmd.Parameters.AddWithValue("@curp", txtCurp.Text.Trim());
                    cmd.Parameters.AddWithValue("@fNac", fecha);
                    cmd.Parameters.AddWithValue("@sem", semestre);
                    cmd.Parameters.AddWithValue("@sex", sexo);
                    cmd.Parameters.AddWithValue("@tel", txtTelefono.Text.Trim());
                    nuevoId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string queryDir = @"INSERT INTO direccion
                    (id_datos, direccion, correo, contacto_emergencia, tipo_sangre, foto)
                    VALUES (@idDatos, @dir, @cor, @cEm, @tSan, @foto)";

                using (MySqlCommand cmdDir = new MySqlCommand(queryDir, conexionGlobal, tx))
                {
                    cmdDir.Parameters.AddWithValue("@idDatos", nuevoId);
                    cmdDir.Parameters.AddWithValue("@dir", txtDireccion.Text);
                    cmdDir.Parameters.AddWithValue("@cor", txtCorreo.Text);
                    cmdDir.Parameters.AddWithValue("@cEm", txtEmergencia.Text.Trim());
                    cmdDir.Parameters.AddWithValue("@tSan", txtSangre.Text);
                    cmdDir.Parameters.AddWithValue("@foto", fotoActual);
                    cmdDir.ExecuteNonQuery();
                }

                tx.Commit();
                LimpiarYRefrescar("Estudiante agregado correctamente.");
            }
            catch (Exception ex)
            {
                try { if (tx != null) tx.Rollback(); } catch { }
                MessageBox.Show("Error al agregar: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarConexion()) return;

            string sexo = txtSexo.Text.Trim().ToUpper();
            if (sexo != "M" && sexo != "F" && sexo != "")
            {
                MessageBox.Show("El apartado Sexo solo admite 'M', 'F' o dejarlo vacío.");
                return;
            }

            if (!ValidarNuevasReglas()) return;

            int id;
            object fecha;
            int semestre;
            if (!LeerId(out id)) return;
            if (!LeerFecha(out fecha)) return;
            if (!LeerSemestre(out semestre)) return;

            MySqlTransaction tx = null;
            try
            {
                tx = conexionGlobal.BeginTransaction();

                string queryPersona = @"UPDATE datos_personales SET
                    nombres=@nom, apellido_paterno=@pat, apellido_materno=@mat,
                    curp=@curp, fecha_nacimiento=@fNac, semestre=@sem, sexo=@sex, telefono=@tel
                    WHERE id=@id";

                using (MySqlCommand cmd = new MySqlCommand(queryPersona, conexionGlobal, tx))
                {
                    cmd.Parameters.AddWithValue("@nom", Capitalizar(txtNombres.Text));
                    cmd.Parameters.AddWithValue("@pat", Capitalizar(txtPaterno.Text));
                    cmd.Parameters.AddWithValue("@mat", Capitalizar(txtMaterno.Text));
                    cmd.Parameters.AddWithValue("@curp", txtCurp.Text.Trim());
                    cmd.Parameters.AddWithValue("@fNac", fecha);
                    cmd.Parameters.AddWithValue("@sem", semestre);
                    cmd.Parameters.AddWithValue("@sex", sexo);
                    cmd.Parameters.AddWithValue("@tel", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                string queryDir = @"UPDATE direccion SET
                    direccion=@dir, correo=@cor, contacto_emergencia=@cEm, tipo_sangre=@tSan, foto=@foto
                    WHERE id_datos=@id";

                using (MySqlCommand cmdDir = new MySqlCommand(queryDir, conexionGlobal, tx))
                {
                    cmdDir.Parameters.AddWithValue("@dir", txtDireccion.Text);
                    cmdDir.Parameters.AddWithValue("@cor", txtCorreo.Text);
                    cmdDir.Parameters.AddWithValue("@cEm", txtEmergencia.Text.Trim());
                    cmdDir.Parameters.AddWithValue("@tSan", txtSangre.Text);
                    cmdDir.Parameters.AddWithValue("@foto", fotoActual);
                    cmdDir.Parameters.AddWithValue("@id", id);
                    cmdDir.ExecuteNonQuery();
                }

                tx.Commit();
                LimpiarYRefrescar("Registro actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                try { if (tx != null) tx.Rollback(); } catch { }
                MessageBox.Show("Error al editar: " + ex.Message);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (!ValidarConexion()) return;

            int id;
            if (!LeerId(out id)) return;

            if (MessageBox.Show("¿Seguro que deseas borrar el ID " + id + "?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            MySqlTransaction tx = null;
            try
            {
                tx = conexionGlobal.BeginTransaction();

                using (MySqlCommand cmdDir = new MySqlCommand("DELETE FROM direccion WHERE id_datos = @id", conexionGlobal, tx))
                {
                    cmdDir.Parameters.AddWithValue("@id", id);
                    cmdDir.ExecuteNonQuery();
                }
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM datos_personales WHERE id = @id", conexionGlobal, tx))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
                LimpiarYRefrescar("Registro eliminado de ambas tablas.");
            }
            catch (Exception ex)
            {
                try { if (tx != null) tx.Rollback(); } catch { }
                MessageBox.Show("Error al borrar: " + ex.Message);
            }
        }

        private void LimpiarCamposSinMensaje()
        {
            QuitarFoto();
            txtId.Text = ""; txtNombres.Text = ""; txtPaterno.Text = ""; txtMaterno.Text = "";
            txtCurp.Text = ""; txtFechaNac.Text = ""; txtSemestre.Text = ""; txtSexo.Text = "";
            txtTelefono.Text = ""; txtDireccion.Text = ""; txtCorreo.Text = "";
            txtEmergencia.Text = ""; txtSangre.Text = "";
            txtBuscar.Text = "";
        }

        private void LimpiarYRefrescar(string mensaje)
        {
            MessageBox.Show(mensaje);
            LimpiarCamposSinMensaje();
            CargarTablaSilencioso();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            NetworkChange.NetworkAddressChanged -= CambioDeRed_Detectado;
            NetworkChange.NetworkAvailabilityChanged -= DisponibilidadRed_Detectada;
            try
            {
                if (conexionGlobal.State == ConnectionState.Open) conexionGlobal.Close();
            }
            catch { }
            base.OnFormClosing(e);
        }
    }
}
