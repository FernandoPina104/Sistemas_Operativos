# ============================================
# 🌐 CÓDIGO PRINCIPAL: index.html (Menú de Navegación)                                      
# ============================================

> 📌 **Objetivo**: Este es el archivo principal (raíz) que el servidor Apache cargará por defecto 
cuando ingreses a la IP. Su función es servir como un menú central o "Hub".
Contiene la estructura básica de HTML5, una hoja de estilos (CSS) incrustada que soporta 
modo claro/oscuro automáticamente, y una lista de enlaces (etiquetas <a>) que conectan 
hacia los otros 5 proyectos web de la práctica.


```html
<!doctype html>
<html lang="es">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Cinco Páginas</title>
    <style>
        /* 🎨 Variables de color y soporte para Modo Oscuro automático */
        :root {
            --bg: #f5f4f1;
            --fg: #1a1b1e;
            --muted: #64666e;
            --line: #dcdad5;
            --accent: #2447e0;
            color-scheme: light;
        }
        @media (prefers-color-scheme: dark) {
            :root {
                --bg: #131417;
                --fg: #f0f0ee;
                --muted: #9b9da6;
                --line: #2c2e35;
                --accent: #8aa0ff;
                color-scheme: dark;
            }
        }
        
        /* 📏 Estilos generales de la página y tipografía */
        * { box-sizing: border-box; }
        body {
            margin: 0;
            background: var(--bg);
            color: var(--fg);
            font-family: system-ui, -apple-system, "Segoe UI", sans-serif;
            line-height: 1.5;
            padding: 40px 16px;
        }
        main { max-width: 640px; margin-inline: auto; }
        h1 { font-size: clamp(2rem, 8vw, 3rem); line-height: 1.05; margin: 0 0 8px; }
        p { color: var(--muted); margin: 0 0 28px; }
        ul { list-style: none; margin: 0; padding: 0; display: grid; gap: 10px; }
        
        /* 🔗 Estilos para los botones/enlaces del menú interactivo */
        a {
            display: block;
            padding: 16px 18px;
            border: 1px solid var(--line);
            border-radius: 10px;
            color: var(--fg);
            text-decoration: none;
        }
        a:hover, a:focus-visible { border-color: var(--accent); outline: none; }
        a b { display: block; font-size: 1.1rem; }
        a span { color: var(--muted); font-size: .92rem; }
    </style>
</head>
<body>
    <main>
        <!-- 📝 Encabezado y Descripción -->
        <h1>Cinco páginas</h1>
        <p>Cinco proyectos web de temas distintos alojados en Ubuntu con Apache.</p>
        
        <!-- 🧭 Rutas a los 5 archivos HTML secundarios -->
        <ul>
            <li><a href="atlas-solar.html"><b>Atlas Solar</b><span>Los ocho planetas y una calculadora de peso.</span></a></li>
            <li><a href="masa-madre.html"><b>Pan de Masa Madre</b><span>Receta con porcentajes del panadero y horario.</span></a></li>
            <li><a href="teclado-escalas.html"><b>Teclado de Escalas</b><span>Piano con escalas y acordes.</span></a></li>
            <li><a href="plan-10k.html"><b>Plan 10K en Ocho Semanas</b><span>Ritmos y plan de entrenamiento.</span></a></li>
            <li><a href="oaxaca.html"><b>Cuaderno de Oaxaca</b><span>Itinerario de cuatro días.</span></a></li>
        </ul>
    </main>
</body>
</html>
```
