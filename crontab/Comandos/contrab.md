# 💻 Registro de Terminal: Monitoreo de Recursos en Segundo Plano

A continuación se documenta el flujo exacto de los comandos ejecutados en la consola de Ubuntu durante la práctica.

---

### 📝 1. Creación del script de monitoreo (`nano`)

> **Objetivo:** Crear el archivo `monitoreo_salud.sh` dentro del directorio personal para registrar el estado de la RAM y el almacenamiento.

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ nano ~/monitoreo_salud.sh
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$

💻 2. Edición del script de monitoreo (Código Bash)

    Objetivo: Escribir las instrucciones necesarias para capturar y registrar el estado del sistema.

    Nota: Este código se pega dentro del editor nano. Se guardan los cambios con Ctrl + O (seguido de Enter) y se cierra con Ctrl + X.

    #!/bin/bash

# Archivo donde se guardará el registro
ARCHIVO_LOG="$HOME/registro_salud.txt"

# Imprimir una línea de separación y la fecha exacta
echo "========================================" >> $ARCHIVO_LOG
echo "🩺 Reporte de Salud: $(date '+%Y-%m-%d %H:%M:%S')" >> $ARCHIVO_LOG
echo "========================================" >> $ARCHIVO_LOG

# Registrar el uso de la memoria RAM (en Megabytes)
echo "🧠 USO DE MEMORIA RAM:" >> $ARCHIVO_LOG
free -m >> $ARCHIVO_LOG
echo "" >> $ARCHIVO_LOG

# Registrar el uso del almacenamiento (Solo la partición principal '/')
echo "💾 USO DE ALMACENAMIENTO:" >> $ARCHIVO_LOG
df -h / >> $ARCHIVO_LOG
echo -e "\n" >> $ARCHIVO_LOG

🔑 3. Asignación de permisos de ejecución (chmod)

    Objetivo: Otorgar permisos de ejecución al script para que el sistema operativo pueda lanzarlo sin restricciones.

    fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ chmod +x ~/monitoreo_salud.sh
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$

⏱️ 4. Automatización en segundo plano (crontab)

    Objetivo: Abrir el editor de tareas programadas y configurar la ejecución automática del script cada 2 minutos.

    Nota: Dentro del editor nano se agregó la línea */2 * * * * /home/fernando-pina/monitoreo_salud.sh.

    fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ crontab -e
crontab: installing new crontab
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$

📊 5. Revisión de la salud del sistema (cat y tail)

    Objetivo: Leer el archivo de registro generado en segundo plano para verificar el consumo de los componentes del equipo.

    Nota: Se usa cat para ver todo el historial y tail -f para ver la actualización en tiempo real.

    fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ cat ~/registro_salud.txt
========================================
🩺 Reporte de Salud: 2026-09-29 13:28:01
========================================
🧠 USO DE MEMORIA RAM:
               total        used        free      shared  buff/cache   available
Mem:           15935        9250        2130         550        4555        6100
Swap:           2048           0        2048

💾 USO DE ALMACENAMIENTO:
S.ficheros     Tamaño Usados  Disp Uso% Montado en
/dev/nvme0n1p2   250G   185G   53G  78% /


fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ tail -f ~/registro_salud.txt
========================================
🩺 Reporte de Salud: 2026-09-29 13:30:01
========================================
🧠 USO DE MEMORIA RAM:
               total        used        free      shared  buff/cache   available
Mem:           15935        9270        2100         550        4565        6080
Swap:           2048           0        2048

💾 USO DE ALMACENAMIENTO:
S.ficheros     Tamaño Usados  Disp Uso% Montado en
/dev/nvme0n1p2   250G   185G   53G  78% /
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$
