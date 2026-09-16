# 💻 Registro de Terminal: Comandos Copiar y Borrar

A continuación se documenta el flujo exacto de los comandos ejecutados en la consola de Ubuntu durante la práctica.

---

### 📁 1. Creación de carpetas principales (`mkdir`)
> **Objetivo:** Crear los directorios base para la práctica.

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos$ mkdir practica1
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos$ mkdir practica2
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos$ sudo ls
[sudo: authenticate] Contraseña:
practica1  practica2
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos$


### 📝 2. Creación de archivo de texto (`gedit`)

> **Objetivo:** Crear un archivo `Readme.txt` dentro de `practica1`.  
> *Nota: Las advertencias mostradas son normales al abrir gedit con permisos de superusuario.*

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1$ sudo gedit Readme.txt

** (gedit:7303): WARNING **: 11:19:54.574: Could not load Peas repository: Typelib file for namespace 'Peas', version '1.0' not found
** (gedit:7303): WARNING **: 11:19:54.574: Could not load PeasGtk repository: Typelib file for namespace 'PeasGtk', version '1.0' not found
(gedit:7303): libgedit-gtksourceview-WARNING **: 11:19:54.922: Failed to load style scheme file '/usr/share/libgedit-gtksourceview-300/styles/Yaru-dark.xml': Error en la línea 3, carácter 1: attribute 'version' invalid for element 'style-scheme'
(gedit:7303): libgedit-gtksourceview-WARNING **: 11:19:54.923: Failed to load style scheme file '/usr/share/libgedit-gtksourceview-300/styles/Yaru.xml': Error en la línea 3, carácter 1: attribute 'version' invalid for element 'style-scheme'
(gedit:7303): dconf-WARNING **: 11:21:01.915: failed to commit changes to dconf: Falló al ejecutar el proceso hijo «dbus-launch» (No existe el archivo o el directorio)
(gedit:7303): dconf-WARNING **: 11:21:01.915: failed to commit changes to dconf: Falló al ejecutar el proceso hijo «dbus-launch» (No existe el archivo o el directorio)
(gedit:7303): dconf-WARNING **: 11:21:01.921: failed to commit changes to dconf: Falló al ejecutar el proceso hijo «dbus-launch» (No existe el archivo o el directorio)
(gedit:7303): dconf-WARNING **: 11:21:01.921: failed to commit changes to dconf: Falló al ejecutar el proceso hijo «dbus-launch» (No existe el archivo o el directorio)

fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1$ ls -l
total 4
-rw-r--r-- 1 root root 76 Sep 15 11:20 Readme.txt
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1$ 
```


### 📋 3. Copiado de archivos (`cp`)

> **Objetivo:** Copiar el archivo `Readme.txt` de `practica1` a `practica2`.

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1$ cp ~/Documentos/practica1/Readme.txt ~/Documentos/practica2/
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1$ cd
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~$ cd Documentos
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos$ cd practica2
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2$ sudo ls
Readme.txt
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2$ 
```


### 🗂️ 4. Creación de subdirectorios (`mkdir`)

> **Objetivo:** Crear las carpetas `vacia` e `info` dentro de `practica2`.

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2$ mkdir vacia
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2$ mkdir info
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2$ sudo ls
Readme.txt  info  vacia
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2$ 
```


### 📝 5. Creación de archivo en subdirectorio (`gedit`)

> **Objetivo:** Crear un archivo `Readme.txt` dentro de la carpeta `info`.  
> *Nota: Las advertencias mostradas son normales al abrir gedit con permisos de superusuario.*

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2/info$ sudo gedit Readme.txt

** (gedit:8234): WARNING **: 11:30:01.257: Could not load Peas repository: Typelib file for namespace 'Peas', version '1.0' not found
** (gedit:8234): WARNING **: 11:30:01.257: Could not load PeasGtk repository: Typelib file for namespace 'PeasGtk', version '1.0' not found
(gedit:8234): libgedit-gtksourceview-WARNING **: 11:30:01.631: Failed to load style scheme file '/usr/share/libgedit-gtksourceview-300/styles/Yaru-dark.xml': Error en la línea 3, carácter 1: attribute 'version' invalid for element 'style-scheme'
(gedit:8234): libgedit-gtksourceview-WARNING **: 11:30:01.632: Failed to load style scheme file '/usr/share/libgedit-gtksourceview-300/styles/Yaru.xml': Error en la línea 3, carácter 1: attribute 'version' invalid for element 'style-scheme'
(gedit:8234): dconf-WARNING **: 11:31:59.977: failed to commit changes to dconf: Falló al ejecutar el proceso hijo «dbus-launch» (No existe el archivo o el directorio)
(gedit:8234): dconf-WARNING **: 11:31:59.978: failed to commit changes to dconf: Falló al ejecutar el proceso hijo «dbus-launch» (No existe el archivo o el directorio)
(gedit:8234): dconf-WARNING **: 11:31:59.983: failed to commit changes to dconf: Falló al ejecutar el proceso hijo «dbus-launch» (No existe el archivo o el directorio)
(gedit:8234): dconf-WARNING **: 11:31:59.983: failed to commit changes to dconf: Falló al ejecutar el proceso hijo «dbus-launch» (No existe el archivo o el directorio)

fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2/info$ sudo ls
Readme.txt
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2/info$ 
```


### 📂 6. Copiado recursivo de carpetas (`cp -r`)

> **Objetivo:** Copiar las carpetas `vacia` e `info` desde `practica2` hacia `practica1`.

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2/vacia$ cp -r ~/Documentos/practica2/vacia ~/Documentos/practica1
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2/vacia$ cd ..
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2$ cd ..
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos$ cd practica1
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1$ sudo ls
Readme.txt  vacia
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1$ cd ..
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos$ cd practica2
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2$ cd info
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2/info$ cp -r ~/Documentos/practica2/info  ~/Documentos/practica1
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2/info$ cd ..
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2$ cd ..
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos$ cd practica1
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1$ sudo ls
Readme.txt  info  vacia
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1$ cd info
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1/info$ sudo ls
Readme.txt
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1/info$ 
```


### 🗑️ 7. Eliminación de archivos y carpetas en `practica1` (`rm` y `rm -r`)

> **Objetivo:** Borrar el archivo `Readme.txt` y la carpeta `info` en `practica1`.

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1$ rm Readme.txt
rm: ¿borrar el regular file 'Readme.txt' protegido contra escritura? (s/n) s
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1$ sudo ls
info  vacia
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1$ rm -r info
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1$ sudo ls
vacia
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica1$ 
```


### 🗑️ 8. Eliminación de archivos y carpetas en `practica2` (`rm` y `rm -r`)

> **Objetivo:** Borrar el archivo `Readme.txt` y la carpeta `info` en `practica2`.

```bash
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2$ rm Readme.txt
rm: ¿borrar el regular file 'Readme.txt' protegido contra escritura? (s/n) s
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2$ sudo ls
info  vacia
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2$ rm -r info
rm: ¿borrar el regular file 'info/Readme.txt' protegido contra escritura? (s/n) s
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2$ sudo ls
vacia
fernando-pina@fernando-pina-Victus-by-HP-Gaming-Laptop-15-fa1xxx:~/Documentos/practica2$ 
```
