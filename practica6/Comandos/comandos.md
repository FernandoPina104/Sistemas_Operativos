```bash
# ==========================================================================================
# 🌐 UBUNTU (Servidor Apache)
# ==========================================================================================

# 📌 Explicación: Actualiza la lista de paquetes disponibles en los repositorios de Ubuntu 
# y luego descarga e instala el servidor web Apache2.
sudo apt update
sudo apt install apache2

# 📌 Explicación: Inicia el servicio de Apache en este momento (--now) y además lo configura 
# para que arranque automáticamente en segundo plano cada vez que se encienda la computadora (enable).
sudo systemctl enable --now apache2

# 📌 Explicación: Muestra el estado actual del servicio Apache. El parámetro '--no-pager' 
# hace que el resultado se imprima de golpe en la terminal sin quedarse atorado en una vista de paginación.
sudo systemctl status apache2 --no-pager

# 📌 Explicación: Crea la carpeta 'cinco-paginas' dentro del directorio público por defecto 
# de Apache (/var/www/html/). El parámetro '-p' crea las carpetas padre si no existen y evita errores.
sudo mkdir -p /var/www/html/cinco-paginas

# 📌 Explicación: Descomprime un archivo .zip que contiene los archivos de la página web 
# (este paso solo se usa si trajiste tu sitio comprimido).
unzip sitio.zip

# 📌 Explicación: Copia recursivamente (-r) todo el contenido (*) de tu carpeta local 'sitio' 
# hacia la carpeta pública de Apache que acabamos de crear en el paso anterior.
sudo cp -r sitio/* /var/www/html/cinco-paginas/

# 📌 Explicación: Cambia el propietario de los archivos. Le asigna la propiedad de la carpeta 
# y su contenido (-R) al usuario 'www-data', que es el usuario interno que usa Apache para funcionar.
sudo chown -R www-data:www-data /var/www/html/cinco-paginas

# 📌 Explicación: Cambia los permisos de la carpeta y archivos (-R). El código '755' le da control 
# total al propietario (Apache) y permisos de lectura y ejecución a los demás (los visitantes web).
sudo chmod -R 755 /var/www/html/cinco-paginas

# 📌 Explicación: Lista los archivos dentro del directorio web con detalles (-l) para confirmar 
# que se copiaron bien, que están en su lugar y que tienen los permisos correctos.
ls -l /var/www/html/cinco-paginas

# 📌 Explicación: Hace una petición HTTP local rápida para ver los encabezados de respuesta. 
# Sirve para comprobar que Apache está sirviendo la página correctamente en tu misma computadora.
curl -I http://localhost/cinco-paginas/

# 📌 Explicación: Agrega una regla al cortafuegos de Ubuntu (UFW) permitiendo el tráfico 
# entrante por el puerto 80, que es el puerto estándar para el protocolo HTTP (sitios web).
sudo ufw allow 80/tcp

# 📌 Explicación: Muestra la dirección IP local de tu servidor Ubuntu. Esta es la IP exacta que 
# tendrás que escribir en el navegador de la otra laptop con Windows para ver la página.
hostname -I

# 📌 Explicación: (Alternativa si pasas los archivos por red). 'scp' copia archivos de forma segura 
# por SSH desde otra PC hacia la carpeta personal (~) del usuario 'fernando-pina' en el servidor.
scp -r sitio fernando-pina@IP-DEL-SERVIDOR:~/cinco-paginas

# 📌 Explicación: Mueve (mv) la carpeta que acabamos de recibir por red hacia el 
# directorio público final de Apache para que sea visible en internet/intranet.
sudo mv ~/cinco-paginas /var/www/html/cinco-paginas

# ==========================================================================================
# 🪟 WINDOWS (PowerShell en la laptop cliente)
# ==========================================================================================

# 📌 Explicación: Comando de PowerShell que escanea la red para comprobar si la laptop 
# con Windows puede comunicarse con el puerto 80 de la IP del servidor Ubuntu. 
# Si la comunicación es exitosa, arrojará el mensaje "TcpTestSucceeded : True".
Test-NetConnection 192.168.1.82 -Port 80

# 📌 Explicación: Tras confirmar la conexión en PowerShell, abres cualquier navegador web 
# (Chrome, Edge) y escribes la ruta completa hacia tu servidor web usando su IP.
# Navegador: [http://192.168.1.82/cinco-paginas/](http://192.168.1.82/cinco-paginas/)
```
