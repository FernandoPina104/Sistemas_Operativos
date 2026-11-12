# ==========================================================================================
# 📁 1. INSTALACIÓN Y CREACIÓN DE LA CARPETA
# ==========================================================================================

# 📦 1. Instalar Samba (apt)
# 📌 Objetivo: Actualizar la lista de paquetes del sistema e instalar el servicio de Samba 
# para compartir archivos en red.
sudo apt update && sudo apt install samba -y

# ------------------------------------------------------------------------------------------

# 📁 2. Crear el directorio a compartir (mkdir)
# 📌 Objetivo: Crear el directorio físico donde se guardarán los archivos que vas a compartir.
sudo mkdir -p /srv/samba/compartido

# ------------------------------------------------------------------------------------------

# 👤 3. Asignar propietario (chown)
# 📌 Objetivo: Asignarte como dueño de esa carpeta para que puedas meter, borrar y editar 
# tus propios archivos localmente sin pedir permisos de administrador.
sudo chown -R $USER:$USER /srv/samba/compartido

# ------------------------------------------------------------------------------------------

# 🔑 4. Otorgar permisos totales (chmod)
# 📌 Objetivo: Otorgar permisos totales de lectura, escritura y ejecución a cualquier usuario 
# de la red sobre la carpeta para evitar bloqueos al transferir archivos.
sudo chmod -R 777 /srv/samba/compartido


# ==========================================================================================
# ⚙️ 2. CONFIGURACIÓN Y SEGURIDAD
# ==========================================================================================

# 📝 5. Editar configuración de Samba (nano)
# 📌 Objetivo: Abrir el archivo principal de configuración de Samba en un editor de texto 
# para definir el nombre, la ruta y las reglas de acceso de la carpeta compartida.
sudo nano /etc/samba/smb.conf

# ------------------------------------------------------------------------------------------

# 🔐 6. Crear contraseña de red (smbpasswd)
# 📌 Objetivo: Crear una contraseña exclusiva de red para tu usuario de Ubuntu, necesaria 
# si el sistema del cliente exige autenticación.
sudo smbpasswd -a TU_USUARIO

# ------------------------------------------------------------------------------------------

# 🛡️ 7. Abrir puerto en firewall (ufw)
# 📌 Objetivo: Abrir las reglas del cortafuegos (firewall) de Ubuntu para permitir que 
# el tráfico de Samba pase sin ser bloqueado por seguridad.
sudo ufw allow samba

# ------------------------------------------------------------------------------------------

# 🔄 8. Reiniciar servicio (systemctl)
# 📌 Objetivo: Reiniciar el servicio de Samba para aplicar todos los cambios guardados 
# en la configuración.
sudo systemctl restart smbd


# ==========================================================================================
# 📡 3. VERIFICACIÓN Y CONEXIÓN
# ==========================================================================================

# 🌐 9. Ver IP del servidor (hostname)
# 📌 Objetivo: Mostrar la dirección IP asignada a tu computadora dentro de la red local 
# (necesaria para que el otro equipo sepa a dónde conectarse).
hostname -I

# ------------------------------------------------------------------------------------------

# 🔌 10. Probar conectividad (ping)
# 📌 Objetivo: Enviar paquetes de prueba hacia la otra computadora para comprobar que 
# ambas están en la misma red y pueden verse.
ping -c 4 IP_DEL_SERVIDOR

# ------------------------------------------------------------------------------------------

# 📋 11. Listar recursos compartidos (smbclient)
# 📌 Objetivo: Listar localmente las carpetas que tu equipo está proyectando hacia la red 
# para confirmar que el recurso compartido está activo.
smbclient -L localhost -N

# ------------------------------------------------------------------------------------------

# 🌍 12. Acceder desde el cliente
# 📌 Objetivo: Es la ruta que se escribe en la barra de direcciones del explorador de 
# Archivos (presionando Ctrl + L) desde el equipo cliente para abrir la carpeta remota.
# Nota: Esto se escribe en el navegador de archivos, no en la terminal.
# smb://IP_DEL_SERVIDOR/compartido
