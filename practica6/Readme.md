# 📌 Nombre del proyecto
**Servidor Web Apache: Alojamiento de Cinco Páginas en Ubuntu**

---

## 📖 Descripción
El objetivo de esta práctica es instalar, configurar y administrar un servidor web Apache2 en el sistema operativo Ubuntu Linux. A través de este servidor, se alojaron cinco proyectos web (HTML/CSS/JS) en el directorio público, configurando los permisos adecuados de lectura y ejecución para que sean accesibles desde cualquier dispositivo conectado a la misma red local.

## 🎯 Objetivos de aprendizaje
Familiarizarse con la instalación de servicios de red en Linux y la gestión de su estado mediante `systemctl`. Comprender la estructura de directorios de Apache (`/var/www/html/`). Aprender a transferir archivos al servidor y asignar correctamente la propiedad de los mismos al usuario del sistema web (`www-data`) usando `chown` y `chmod` para evitar errores de acceso. Finalmente, gestionar la seguridad básica abriendo el puerto HTTP (80) en el cortafuegos (`ufw`) y verificando la conexión cliente-servidor.

## 💻 Material utilizado
- 💻 Laptop/Partición con el sistema operativo **Ubuntu Linux** (Servidor Web)
- 💻 Laptop/Partición con el sistema operativo **Windows 10/11** (Cliente)
- ⚙️ Terminal de Ubuntu (apt, systemctl, ufw, chown, chmod)
- 🌐 Archivos fuente de 5 sitios web estáticos (HTML/CSS/JS)

---

## 📄 Informe
- 📎 [Informe.pdf](Informe/Informe_Practica6.pdf)

## 📸 Evidencias de la práctica
<table align="center">
  <tr>
    <td align="center">
      <img src="Evidencias/01_instalar_apache.jpg" width="280"><br>
      <i>1. Instalación de Apache2 (apt install)</i>
    </td>
    <td align="center">
      <img src="Evidencias/02_estado_apache.jpg" width="280"><br>
      <i>2. Verificación del servicio (systemctl status)</i>
    </td>
    <td align="center">
      <img src="Evidencias/03_copiar_archivos.jpg" width="280"><br>
      <i>3. Traslado de archivos a /var/www/html/</i>
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="Evidencias/04_permisos_chown.jpg" width="280"><br>
      <i>4. Asignación de permisos (chown y chmod)</i>
    </td>
    <td align="center">
      <img src="Evidencias/05_ufw_puerto80.jpg" width="280"><br>
      <i>5. Apertura del puerto 80 en Firewall (UFW)</i>
    </td>
    <td align="center">
      <img src="Evidencias/06_ip_servidor.jpg" width="280"><br>
      <i>6. Consulta de IP local (hostname -I)</i>
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="Evidencias/07_test_windows.jpg" width="280"><br>
      <i>7. Conexión exitosa desde Windows (PowerShell)</i>
    </td>
    <td align="center">
      <img src="Evidencias/08_navegador_menu.jpg" width="280"><br>
      <i>8. Menú principal cargando en el cliente web</i>
    </td>
    <td align="center">
      <img src="Evidencias/09_navegador_atlas.jpg" width="280"><br>
      <i>9. Ejecución interactiva del "Atlas Solar"</i>
    </td>
  </tr>
</table>

---

## 📝 Comandos y Código
- ⌨️ [Comandos de Configuración Apache](Comandos/comandos.md)
- 💻 [Código Fuente: Menú y páginas](HTML/readme.md)

## 🎥 Video del funcionamiento
- 📄 [Readme](Video/readme.txt)
- ▶️ [Ver video en YouTube](https://youtu.be/TU_ENLACE_AQUI)

---

## 💡 Conclusiones
La implementación del servidor Apache permitió comprender cómo funciona el alojamiento de sitios web a nivel de sistema operativo. Se comprobó la importancia crítica de la correcta asignación de dueños (`www-data`) y permisos de lectura/ejecución (`755`), ya que sin ellos el servidor bloqueará las peticiones mostrando un error de "Acceso Denegado" (Forbidden 403). Al probar los 5 proyectos desde una computadora externa (Windows) escribiendo la IP del servidor Ubuntu en el navegador, se constató el funcionamiento real de un entorno cliente-servidor a través de la red local.

## 📊 Resultados
- 📈 [Resultados.pdf](Resultados/Resultados_Practica6.pdf)
