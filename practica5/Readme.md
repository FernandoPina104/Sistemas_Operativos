# 📌 Nombre del proyecto
**Agenda Estudiantil: Arquitectura Cliente-Servidor (C# Windows - MySQL Ubuntu)**

---

## 📖 Descripción
El objetivo de esta práctica es diseñar e implementar un sistema distribuido bajo la arquitectura cliente-servidor. Se configuró un servidor de base de datos MySQL alojado en Ubuntu Linux para aceptar conexiones externas, mientras que del lado del cliente, se desarrolló una aplicación de escritorio (Agenda Estudiantil) en Windows utilizando C# para gestionar, consultar y modificar los registros a través de la red local.

## 🎯 Objetivos de aprendizaje
Familiarizarse con la configuración de servicios de red en Linux y la conectividad a bases de datos remotas. Aprender a modificar los archivos de configuración de MySQL (`mysqld.cnf`) para escuchar en la IP `0.0.0.0`, administrar el cortafuegos (`ufw`) abriendo el puerto 3306, y gestionar privilegios de usuarios remotos con autenticación heredada (`mysql_native_password`). Del lado del cliente, comprender cómo establecer cadenas de conexión remotas y ejecutar sentencias SQL desde una interfaz gráfica interactiva en Windows (Windows Forms).

## 💻 Material utilizado
- 💻 Laptop/Partición con el sistema operativo **Ubuntu Linux** (Servidor MySQL)
- 💻 Laptop/Partición con el sistema operativo **Windows 10/11** (Cliente C#)
- ⚙️ Gestor de paquetes y terminal de Ubuntu (UFW, systemctl, nano)
- 🖥️ IDE para C# (Visual Studio / SharpDevelop)

---

## 📄 Informe
- 📎 [Informe.pdf](Informe/Informe_Conexion_Remota_BD.pdf)

## 📸 Evidencias de la práctica
<table align="center">
  <tr>
    <td align="center">
      <img src="Evidencias/c01_ip_ubuntu.jpg" width="280"><br>
      <i>1. Consulta de IP del servidor (hostname -I)</i>
    </td>
    <td align="center">
      <img src="Evidencias/c02_mysqld_cnf.jpg" width="280"><br>
      <i>2. Configuración de bind-address (0.0.0.0)</i>
    </td>
    <td align="center">
      <img src="Evidencias/c03_ufw_3306.jpg" width="280"><br>
      <i>3. Apertura del puerto 3306 en el Firewall (UFW)</i>
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="Evidencias/c04_mysql_privilegios.jpg" width="280"><br>
      <i>4. Asignación de permisos remotos en MySQL (%)</i>
    </td>
    <td align="center">
      <img src="Evidencias/c05_test_windows.jpg" width="280"><br>
      <i>5. Prueba de conexión exitosa desde Windows (PowerShell)</i>
    </td>
    <td align="center">
      <img src="Evidencias/c06_csharp_codigo.jpg" width="280"><br>
      <i>6. Configuración de la cadena de conexión en C#</i>
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="Evidencias/c07_interfaz_agenda.jpg" width="280"><br>
      <i>7. Ejecución de la aplicación en Windows</i>
    </td>
    <td align="center">
      <img src="Evidencias/c08_insertar_dato.jpg" width="280"><br>
      <i>8. Inserción de un nuevo alumno desde la interfaz</i>
    </td>
    <td align="center">
      <img src="Evidencias/c09_verificacion_ubuntu.jpg" width="280"><br>
      <i>9. Verificación de los datos reflejados en el servidor Ubuntu</i>
    </td>
  </tr>
</table>

---

## 📝 Comandos y Código
- ⌨️ [Comandos de Servidor y BD](Comandos/Comandos_Ubuntu_MySQL.md)
- 💻 [Código Fuente C#](Comandos/C%23/Codigo_AgendaApp.md)

## 🎥 Video del funcionamiento
- 📄 [Readme](Vídeo/readme.txt)
- ▶️ [Ver video en YouTube](https://youtu.be/TU_ENLACE_AQUI)

---

## 💡 Conclusiones
La práctica demostró exitosamente la viabilidad y el proceso técnico para separar la lógica de presentación (Windows) del almacenamiento de datos (Ubuntu). Se comprobó que por defecto los motores de bases de datos vienen blindados para conexiones locales (`localhost`), por lo que es imperativo tener conocimientos de administración en Linux para modificar las directivas de red (`bind-address`), abrir puertos en el firewall de manera segura y aplicar métodos de autenticación compatibles. Finalmente, se logró un sistema interactivo y funcional en C# que administra los datos de manera remota, centralizando la información y permitiendo escalabilidad.

## 📊 Resultados
- 📈 [Resultados.pdf](Resultados/Resultados_Conexion_Remota_BD.pdf)
