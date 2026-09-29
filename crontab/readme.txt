# 📌 Nombre del proyecto
**Automatización de Monitoreo con Crontab en Ubuntu**

---

## 📖 Descripción
El objetivo de esta práctica es implementar un sistema de monitoreo desatendido que registre la "salud" del equipo (consumo de Memoria RAM y Almacenamiento raíz) mediante scripts de Bash que se ejecutan de forma automática y periódica en segundo plano.

## 🎯 Objetivos de aprendizaje
Familiarizarse con la creación de scripts independientes en la consola de Ubuntu, el manejo de permisos de ejecución (`chmod +x`), y la extracción de métricas del sistema empleando comandos como `free` y `df`. Además, dominar la programación de tareas automatizadas utilizando el demonio `cron` y su tabla de configuración (`crontab`), redirigiendo la salida de datos para la generación de bitácoras (logs) continuas.

## 💻 Material utilizado
- 💻 Laptop con el sistema operativo **Ubuntu Desktop**
- ⚙️ Demonio cron y terminal de comandos (Bash)

---

## 📄 Informe
- 📎 [Informe_contrab.pdf](Informe/Informe_contrab-v2.pdf)

## 📸 Evidencias de la práctica
<table align="center">
  <tr>
    <td align="center">
      <img src="Evidencias/touch_scripts.png" width="280"><br>
      <i>1. Creación de los scripts (touch)</i>
    </td>
    <td align="center">
      <img src="Evidencias/script_ram.png" width="280"><br>
      <i>2. Código de registro_ram.sh</i>
    </td>
    <td align="center">
      <img src="Evidencias/script_disco.png" width="280"><br>
      <i>3. Código de registro_almacenamiento.sh</i>
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="Evidencias/chmod_x.png" width="280"><br>
      <i>4. Asignación de permisos (chmod +x)</i>
    </td>
    <td align="center">
      <img src="Evidencias/crontab_config.png" width="280"><br>
      <i>5. Programación en crontab (cada 2 min)</i>
    </td>
    <td align="center">
      <img src="Evidencias/crontab_l.png" width="280"><br>
      <i>6. Verificación de tareas (crontab -l)</i>
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="Evidencias/git_push.png" width="280"><br>
      <i>7. Subida al repositorio con Git</i>
    </td>
    <td align="center">
      <img src="Evidencias/log_ram.png" width="280"><br>
      <i>8. Salida en historial_ram.log</i>
    </td>
    <td align="center">
      <img src="Evidencias/log_disco.png" width="280"><br>
      <i>9. Salida en historial_almacenamiento.log</i>
    </td>
  </tr>
</table>

---

## 📝 Comandos
- ⌨️ [Comandos.txt](Comandos/Comandos_Monitoreo_Crontab.md)

## 🎥 Video del funcionamiento
- 📄 [Readme](Vídeo/readme.txt)
- ▶️ [Ver video en YouTube](https://youtu.be/TU_ENLACE_AQUI) *(Reemplazar con tu enlace)*

---

## 💡 Conclusiones
La práctica permitió comprobar la utilidad y potencia de `cron` para automatizar procesos en Linux sin necesidad de intervención manual ni consumo de recursos gráficos. Se comprendió la importancia de utilizar la redirección de flujos (`>>`) para crear bitácoras que acumulen datos en lugar de sobrescribirlos. Asimismo, separar la lógica en distintos scripts demostró la importancia de la modularidad; si la lectura del disco falla, el monitoreo de la memoria RAM sigue funcionando de manera independiente, dotando al sistema de una mayor robustez y trazabilidad.

## 📊 Resultados
- 📈 [Resultados_contrab.pdf](Resultados/Resultados_contrab-v2.pdf)
