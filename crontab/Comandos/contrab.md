# 💻 Registro de Terminal: Monitoreo de Recursos en Segundo Plano

A continuación se documenta el flujo exacto de los comandos ejecutados en la consola de Ubuntu durante la práctica.

### 📝 1. Creación del script de monitoreo (nano)

> **Objetivo:** Crear el archivo `monitoreo_salud.sh` dentro del directorio personal para registrar el estado de la RAM y el almacenamiento.

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ nano ~/monitoreo_salud.sh
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$

### 💻 2. Edición del script de monitoreo (Código Bash)

    > **Objetivo:** Escribir las instrucciones para capturar el estado del sistema. (Nota: Este código se pega dentro de nano. Guarda con Ctrl + O seguido de Enter, y cierra con Ctrl + X).

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
