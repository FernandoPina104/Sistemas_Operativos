```bash
# ==========================================================================================
# 📁 1. INSTALACIÓN Y CREACIÓN DE LA CARPETA
# ==========================================================================================

# 📌 Objetivo: Actualiza la lista de paquetes del sistema e instala el servicio de Samba 
# para compartir archivos en red.
sudo apt update && sudo apt install samba -y

# ------------------------------------------------------------------------------------------

# 📌 Objetivo: Crea el directorio físico donde se guardarán los archivos que vas a compartir.
sudo mkdir -p /srv/samba/compartido

# ------------------------------------------------------------------------------------------

# 📌 Objetivo: Te asigna como dueño de esa carpeta para que puedas meter, borrar y editar 
# tus propios archivos localmente sin pedir permisos de administrador.
sudo chown -R $USER:$USER /srv/samba/compartido

# ------------------------------------------------------------------------------------------

# 📌 Objetivo: Otorga permisos totales de lectura, escritura y ejecución a cualquier usuario 
# de la red sobre la carpeta para evitar bloqueos al transferir archivos.
sudo chmod -R 777 /srv/samba/compartido


# ==========================================================================================
# ⚙️ 2. CONFIGURACIÓN Y SEGURIDAD
# ==========================================================================================

# 📌 Objetivo: Abre el archivo principal de configuración de Samba en un editor de texto 
# para definir el nombre, la ruta y las reglas de acceso de la carpeta compartida.
sudo nano /etc/samba/smb.conf

# ------------------------------------------------------------------------------------------

# 📌 Objetivo: Crea una contraseña exclusiva de red para tu usuario de Ubuntu, necesaria 
# si el sistema del cliente exige autenticación. (Cambia TU_USUARIO por el real).
sudo smbpasswd -a TU_USUARIO

# ------------------------------------------------------------------------------------------

# 📌 Objetivo: Abre las reglas del cortafuegos (firewall) de Ubuntu para permitir que 
# el tráfico de Samba pase sin ser bloqueado por seguridad.
sudo ufw allow samba

# ------------------------------------------------------------------------------------------

# 📌 Objetivo: Reinicia el servicio de Samba para aplicar todos los cambios guardados 
# en la configuración.
sudo systemctl restart smbd


# ==========================================================================================
# 📡 3. VERIFICACIÓN Y CONEXIÓN
# ==========================================================================================

# 📌 Objetivo: Muestra la dirección IP asignada a tu computadora dentro de la red local 
# (necesaria para que el otro equipo sepa a dónde conectarse).
hostname -I

# ------------------------------------------------------------------------------------------

# 📌 Objetivo: Envía paquetes de prueba hacia la otra computadora para comprobar que 
# ambas están en la misma red y pueden verse. (Presiona Ctrl+C para detener si no usas -c 4).
ping -c 4 IP_DEL_SERVIDOR

# ------------------------------------------------------------------------------------------

# 📌 Objetivo: Lista localmente las carpetas que tu equipo está proyectando hacia la red 
# para confirmar que el recurso compartido está activo.
smbclient -L localhost -N

# ------------------------------------------------------------------------------------------

# 📌 Objetivo: Es la ruta que se escribe en la barra de direcciones del explorador de 
# Archivos (presionando Ctrl + L en Ubuntu) desde el equipo cliente para abrir la carpeta.
# Nota: Esto NO se ejecuta en la terminal, se escribe en el navegador de archivos.
# smb://IP_DEL_SERVIDOR/compartido
```
