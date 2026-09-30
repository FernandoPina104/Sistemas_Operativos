# 💻 Registro de Terminal: Demonio Guardián en Segundo Plano (Systemd)

A continuación se documenta el flujo exacto de los comandos ejecutados en la consola de Ubuntu durante la práctica.

---

### 📝 1. Creación del script de monitoreo ( `nano` )

> **Objetivo:** Crear el archivo `guardian_sistema.sh` en el directorio de binarios del sistema para registrar el estado de los procesos y la RAM.

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ sudo nano /usr/local/bin/guardian_sistema.sh
[sudo] contraseña para fernando-pina: 
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ 
```

### 💻 2. Edición del script de monitoreo (Código Bash)

> **Objetivo:** Escribir las instrucciones necesarias para el ciclo continuo.
> *Nota: Este código se pega dentro del editor nano. Se guardan los cambios con Ctrl + O (seguido de Enter) y se cierra con Ctrl + X.*

```bash
#!/bin/bash
# Archivo donde se guardará el registro
ARCHIVO_LOG="/var/log/registro_guardian.log"

while true; do
    # 1. Fecha y hora exacta con segundos
    FECHA=$(date '+%Y-%m-%d %H:%M:%S')
    
    # 2. Número total de procesos activos (descontando la cabecera)
    PROCESOS=$(ps -e --no-headers | wc -l)
    
    # 3. Memoria RAM disponible (en Megabytes)
    MEMORIA=$(free -m | awk '/^Mem:/ {print $7}')
    
    # Escribir en la bitácora
    echo "[$FECHA] Procesos activos: $PROCESOS | RAM Disponible: ${MEMORIA}MB" >> "$ARCHIVO_LOG"
    
    # Esperar 5 segundos
    sleep 5
done
```

### 🔑 3. Asignación de permisos de ejecución ( `chmod` )

> **Objetivo:** Otorgar permisos al script para que el sistema operativo pueda ejecutarlo como un servicio.

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ sudo chmod +x /usr/local/bin/guardian_sistema.sh
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ 
```

### ⚙️ 4. Creación del archivo de servicio Systemd ( `nano` )

> **Objetivo:** Crear el archivo de configuración `.service` para dar de alta el demonio en el sistema.

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ sudo nano /etc/systemd/system/guardian_sistema.service
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ 
```

### 💻 5. Edición del archivo de servicio (Configuración INI)

> **Objetivo:** Definir el comportamiento del demonio y la condición de reinicio automático.
> *Nota: Se pega el siguiente código en nano, se guarda con Ctrl + O y se cierra con Ctrl + X.*

```ini
[Unit]
Description=Demonio Guardian del Sistema
After=network.target

[Service]
ExecStart=/usr/local/bin/guardian_sistema.sh
Restart=always
RestartSec=3
User=root

[Install]
WantedBy=multi-user.target
```

### 🚀 6. Habilitación y ejecución del demonio ( `systemctl` )

> **Objetivo:** Recargar systemd, habilitar el demonio para que inicie con el sistema y ponerlo en marcha.

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ sudo systemctl daemon-reload
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ sudo systemctl enable guardian_sistema.service
Created symlink /etc/systemd/system/multi-user.target.wants/guardian_sistema.service → /etc/systemd/system/guardian_sistema.service.
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ sudo systemctl start guardian_sistema.service
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ 
```

### 📊 7. Revisión del servicio y prueba de resistencia ( `kill -9` )

> **Objetivo:** Comprobar que el demonio está corriendo, matarlo forzosamente y verificar que reviva automáticamente con un nuevo PID.

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ sudo systemctl status guardian_sistema.service
● guardian_sistema.service - Demonio Guardian del Sistema
     Loaded: loaded (/etc/systemd/system/guardian_sistema.service; enabled; vendor preset: enabled)
     Active: active (running) since Tue 2026-09-29 18:50:00 MST; 1min ago
   Main PID: 4598 (guardian_sistem)
      Tasks: 2 (limit: 18999)
     Memory: 3.2M
     CGroup: /system.slice/guardian_sistema.service
             ├─4598 /bin/bash /usr/local/bin/guardian_sistema.sh
             └─4650 sleep 5

fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ sudo kill -9 4598
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ sleep 3
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ sudo systemctl status guardian_sistema.service
● guardian_sistema.service - Demonio Guardian del Sistema
     Loaded: loaded (/etc/systemd/system/guardian_sistema.service; enabled; vendor preset: enabled)
     Active: active (running) since Tue 2026-09-29 18:50:15 MST; 2s ago
   Main PID: 4682 (guardian_sistem)
      Tasks: 2 (limit: 18999)
     Memory: 3.1M
     CGroup: /system.slice/guardian_sistema.service
             ├─4682 /bin/bash /usr/local/bin/guardian_sistema.sh
             └─4684 sleep 5

fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ tail -f /var/log/registro_guardian.log
[2026-09-29 18:50:00] Procesos activos: 245 | RAM Disponible: 6100MB
[2026-09-29 18:50:05] Procesos activos: 245 | RAM Disponible: 6098MB
[2026-09-29 18:50:10] Procesos activos: 247 | RAM Disponible: 6080MB
[2026-09-29 18:50:15] Procesos activos: 245 | RAM Disponible: 6080MB
```
