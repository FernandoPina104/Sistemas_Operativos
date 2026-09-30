# 📌 Nombre del proyecto
**Demonio en Ubuntu**

---

## 📖 Descripción
El objetivo de esta práctica es diseñar e implementar un sistema de monitoreo desatendido en segundo plano que registre periódicamente la "salud" del equipo (consumo de Memoria RAM y almacenamiento del disco), guardando los historiales automáticamente en la carpeta personal.

## 🎯 Objetivos de aprendizaje
Familiarizarse con la automatización de tareas en Linux mediante el demonio `cron`. Aprender a estructurar scripts independientes en Bash, redireccionar flujos de salida de comandos como `free` y `df` hacia archivos de texto (`.log`), y aplicar los permisos de ejecución correctos (`chmod +x`). Esto permite entender cómo el sistema puede auditarse a sí mismo de manera programada sin necesidad de intervención manual o interfaz gráfica.

## 💻 Material utilizado
- 💻 Laptop con el sistema operativo **Ubuntu Desktop**

---

## 📄 Informe
- 📎 [Informe.pdf](Informe/Informe_demonio.pdf)

## 📸 Evidencias de la práctica
<table align="center">
  <tr>
    <td align="center">
      <img src="Evidencias/gedit.png" width="280"><br>
      <i>1. Abriendo el editor</i>
    </td>
    <td align="center">
      <img src="Evidencias/editor.png" width="280"><br>
      <i>2. Escribiendo el script</i>
    </td>
    <td align="center">
      <img src="Evidencias/salud_sh.png" width="280"><br>
      <i>3. Archivo del script creado</i>
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="Evidencias/permiso.png" width="280"><br>
      <i>4. Otorgando permisos (chmod)</i>
    </td>
    <td align="center">
      <img src="Evidencias/tiempo.png" width="280"><br>
      <i>5. Configurando intervalo (cron)</i>
    </td>
    <td align="center">
      <img src="Evidencias/registro.png" width="280"><br>
      <i>6. Salida de los logs</i>
    </td>
  </tr>
  <tr>
</table>

---

## 📝 Comandos
- ⌨️ [Comandos.txt](Comandos/demonio_centinela.md)

## 🎥 Video del funcionamiento
- 📄 [Readme](Vídeo/readme.txt)
- ▶️ [Ver video en YouTube](https://youtu.be/TU_ENLACE_AQUI)

---

## 💡 Conclusiones
La práctica permitió comprender el enorme potencial de la automatización en entornos Linux. Se comprobó que, al crear scripts modulares en Bash y combinarlos con el planificador de tareas `crontab`, es posible delegar tareas repetitivas (como el monitoreo de recursos) directamente al sistema operativo para que las ejecute en segundo plano de forma invisible y eficiente. Además, se reforzó la importancia de la gestión de permisos en Linux, ya que sin aplicar `chmod +x`, el sistema por motivos de seguridad impide la ejecución autónoma de cualquier script.

## 📊 Resultados
- 📈 [Resultados.pdf](Resultados/Resultados-demonio.pdf)
