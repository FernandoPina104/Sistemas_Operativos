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