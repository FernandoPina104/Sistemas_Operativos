# ==========================================================================================
# 🌐 UBUNTU (Servidor Apache)
# ==========================================================================================

# 📦 1. Instalar Apache (apt)
# 📌 Objetivo: Actualizar la lista de paquetes disponibles en los repositorios de Ubuntu y 
# luego descargar e instalar el servidor web Apache2.

```bash
sudo apt update
sudo apt install apache2

```
# ------------------------------------------------------------------------------------------

# 🚀 2. Iniciar y habilitar Apache (systemctl)
# 📌 Objetivo: Iniciar el servicio de Apache en este momento (--now) y configurarlo para 
# que arranque automáticamente en segundo plano cada vez que se encienda la computadora.

```bash
sudo systemctl enable --now apache2
```
# ------------------------------------------------------------------------------------------

# 📊 3. Ver el estado del servicio (systemctl)
# 📌 Objetivo: Mostrar el estado actual del servicio Apache. El parámetro '--no-pager' 
# hace que el resultado se imprima de golpe en la terminal sin quedarse atorado en una vista.

```bash
sudo systemctl status apache2 --no-pager
```
# ------------------------------------------------------------------------------------------

# 📁 4. Crear la carpeta del sitio web (mkdir)
# 📌 Objetivo: Crear la carpeta 'cinco-paginas' dentro del directorio público por defecto 
# de Apache (/var/www/html/). El parámetro '-p' crea las carpetas padre si no existen.

```bash
sudo mkdir -p /var/www/html/cinco-paginas
```

# ------------------------------------------------------------------------------------------

# 🗜️ 5. Descomprimir el sitio (unzip)
# 📌 Objetivo: Descomprimir un archivo .zip que contiene los archivos de la página web 
# (este paso solo se usa si transferiste tu sitio comprimido por correo o USB).

```bash
unzip sitio.zip
```

# ------------------------------------------------------------------------------------------

# 📋 6. Copiar los archivos al servidor web (cp)
# 📌 Objetivo: Copiar recursivamente (-r) todo el contenido (*) de la carpeta local 'sitio' 
# hacia la carpeta pública de Apache que creamos en el paso anterior.

```bash
sudo cp -r sitio/* /var/www/html/cinco-paginas/
```

# ------------------------------------------------------------------------------------------

# 👤 7. Asignar propietario a Apache (chown)
# 📌 Objetivo: Asignar la propiedad de la carpeta y su contenido (-R) al usuario 'www-data', 
# que es el usuario interno que usa Apache para funcionar y acceder a los archivos.

```bash
sudo chown -R www-data:www-data /var/www/html/cinco-paginas
```

# ------------------------------------------------------------------------------------------

# 🔑 8. Otorgar permisos de lectura y ejecución (chmod)
# 📌 Objetivo: Cambiar los permisos de la carpeta y archivos (-R). El código '755' le da 
# control total al propietario (Apache) y permisos de lectura y ejecución a los visitantes web.

```bash
sudo chmod -R 755 /var/www/html/cinco-paginas
```
# ------------------------------------------------------------------------------------------

# 🔍 9. Verificar archivos en su lugar (ls)
# 📌 Objetivo: Listar los archivos dentro del directorio web con detalles (-l) para 
# confirmar que se copiaron correctamente, están en su lugar y tienen los permisos asignados.

```bash
ls -l /var/www/html/cinco-paginas
```

# ------------------------------------------------------------------------------------------

# 🌍 10. Probar el servidor localmente (curl)
# 📌 Objetivo: Hacer una petición HTTP local rápida para ver los encabezados de respuesta. 
# Sirve para comprobar que Apache está sirviendo la página correctamente en la misma computadora.

```bash
curl -I http://localhost/cinco-paginas/
```
# ------------------------------------------------------------------------------------------

# 🛡️ 11. Abrir el puerto HTTP en el firewall (ufw)
# 📌 Objetivo: Agregar una regla al cortafuegos de Ubuntu (UFW) permitiendo el tráfico 
# entrante por el puerto 80, que es el puerto estándar para el protocolo HTTP (sitios web).

```bash
sudo ufw allow 80/tcp
```

# ------------------------------------------------------------------------------------------

# 📡 12. Ver la IP del servidor (hostname)
# 📌 Objetivo: Mostrar la dirección IP local del servidor Ubuntu. Esta IP es la que 
# tendrás que escribir en el navegador de la laptop con Windows para ver la página en red.

```bash
hostname -I
```

# ------------------------------------------------------------------------------------------

# 🚀 13. Alternativa: Subir archivos por red (scp y mv)
# 📌 Objetivo: 'scp' copia archivos de forma segura por SSH desde otra PC hacia la carpeta 
# personal en el servidor. Luego 'mv' mueve esa carpeta al directorio público de Apache.

```bash
scp -r sitio fernando-pina@IP-DEL-SERVIDOR:~/cinco-paginas
sudo mv ~/cinco-paginas /var/www/html/cinco-paginas
```

# ==========================================================================================
# 🪟 WINDOWS (PowerShell en la laptop cliente)
# ==========================================================================================

# 🔌 14. Probar conexión al puerto 80 (Test-NetConnection)
# 📌 Objetivo: Ejecutar un escaneo de red desde PowerShell para comprobar si la laptop 
# con Windows puede comunicarse con el puerto 80 de la IP del servidor Ubuntu.
# (El resultado debe devolver TcpTestSucceeded : True).

```bash
Test-NetConnection 192.168.1.82 -Port 80
```

# ------------------------------------------------------------------------------------------

# 🌐 15. Acceder a la página web en el navegador
# 📌 Objetivo: Tras confirmar la conexión, ingresar desde el navegador web a la ruta del 
# servidor (asegurándose de usar http:// y no https://) para visualizar el sitio cargado.
# Nota: Esto no es un comando de terminal, es el enlace que va en tu Chrome/Edge.

```bash
 http://192.168.1.82/cinco-paginas/
```
