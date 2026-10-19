# =============================================
# 🐧 CONFIGURACIÓN EN UBUNTU (Servidor MySQL)
# =============================================

### 🌐 1. Ver la IP del servidor (`hostname`)

> **Objetivo:** Mostrar la dirección IP local de tu máquina Ubuntu en la red actual. Esta IP es la que deberás colocar en tu cadena de conexión en C#.

```bash
hostname -I
```

### 📝 2. Editar la configuración de MySQL (`nano`)

> **Objetivo:** Abrir el archivo de configuración central para asegurar que `bind-address = 0.0.0.0` y `mysql_native_password=ON` estén presentes.

```bash
sudo nano /etc/mysql/mysql.conf.d/mysqld.cnf
```

### ⚙️ 3. Agregar política de autenticación (`sed`)

> **Objetivo:** Insertar automáticamente la línea de política de autenticación nativa justo debajo de la etiqueta `[mysqld]` sin tener que abrir el editor manualmente.

```bash
sudo sed -i '/^\[mysqld\]/a authentication_policy=mysql_native_password' /etc/mysql/mysql.conf.d/mysqld.cnf
```

### 🔍 4. Confirmar cambios en el archivo (`grep`)

> **Objetivo:** Imprimir únicamente las líneas del archivo que contienen la palabra "native_password" para verificar que se guardaron correctamente.

```bash
grep -n "native_password" /etc/mysql/mysql.conf.d/mysqld.cnf
```

### 🔄 5. Reiniciar el servicio MySQL (`systemctl`)

> **Objetivo:** Reiniciar el demonio de MySQL para que el sistema lea y aplique la nueva configuración de red y contraseñas.

```bash
sudo systemctl restart mysql
```

### 📡 6. Comprobar puerto de escucha (`ss`)

> **Objetivo:** Confirmar visualmente que MySQL está escuchando en el puerto 3306 para todas las interfaces de red (`0.0.0.0`).

```bash
sudo ss -tlnp | grep 3306
```

### 🛡️ 7. Abrir puerto en el firewall (`ufw`)

> **Objetivo:** Agregar una regla al cortafuegos de Ubuntu para permitir que el tráfico externo de tu aplicación de C# entre por el puerto 3306.

```bash
sudo ufw allow 3306/tcp
```

### 🔐 8. Confirmar método de autenticación

> **Objetivo:** Ejecutar una consulta directa desde la terminal para comprobar que la política de autenticación antigua ya está activa.

```bash
sudo mysql -e "SHOW VARIABLES LIKE 'authentication_policy';"
```

### 🔑 9. Entrar a MySQL como administrador

> **Objetivo:** Iniciar sesión en la consola interactiva de base de datos con privilegios root.

```bash
sudo mysql
```

---

# =================================
# 🐬 DENTRO DE MYSQL (prompt mysql>)
# ==================================

### 👤 10. Consultar estado del usuario

> **Objetivo:** Ver desde qué host tiene permitido conectarse el usuario actual y qué algoritmo de cifrado usa para su contraseña.

```sql
SELECT user, host, plugin FROM mysql.user WHERE user='fernando-pina';
```

### 🌍 11. Permitir conexiones remotas

> **Objetivo:** Cambiar el acceso restringido de `localhost` al comodín `%` para que el usuario pueda entrar desde cualquier computadora de la red.

```sql
RENAME USER 'fernando-pina'@'localhost' TO 'fernando-pina'@'%';
```

### 🔑 12. Cambiar contraseña a formato nativo

> **Objetivo:** Asignar la contraseña real y forzar el uso del plugin `mysql_native_password` (el único compatible con el conector de C#).

```sql
ALTER USER 'fernando-pina'@'%' IDENTIFIED WITH mysql_native_password BY 'TU_CONTRASEÑA';
```

### ⚡ 13. Aplicar privilegios

> **Objetivo:** Recargar la memoria caché de MySQL para que los cambios de permisos y contraseñas surtan efecto inmediatamente.

```sql
FLUSH PRIVILEGES;
```

### 🚪 14. Salir de MySQL

> **Objetivo:** Cerrar la consola interactiva de base de datos y regresar a la terminal normal de Ubuntu.

```sql
EXIT;
```

---

# =============================================
# 🪟 WINDOWS (PowerShell en la laptop del programa)
# =============================================

### 🔌 15. Probar conexión desde Windows (`Test-NetConnection`)

> **Objetivo:** Escanear el puerto 3306 de la IP del servidor Ubuntu desde PowerShell para confirmar que hay comunicación (debe devolver `TcpTestSucceeded : True`).

```powershell
Test-NetConnection 192.168.1.82 -Port 3306
```

