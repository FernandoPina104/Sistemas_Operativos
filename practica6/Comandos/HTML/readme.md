# ============================================
# 🌐 CÓDIGO PRINCIPAL: index.html (Menú de Navegación)
# ============================================

> 📌 **Objetivo**: Este es el archivo principal (raíz) que el servidor Apache cargará por defecto cuando ingreses a la IP. Su función es servir como un menú central o "Hub". Contiene la estructura básica de HTML5, una hoja de estilos (CSS) incrustada que soporta modo claro/oscuro automáticamente, y una lista de enlaces (etiquetas `<a>`) que conectan hacia los otros 5 proyectos web de la práctica.

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

---

# ============================================
# 🪐 PÁGINA 1: atlas-solar.html (Atlas Solar)
# ============================================

> 📌 **Objetivo**: Página informativa e interactiva sobre el Sistema Solar. Muestra los ocho planetas sobre una regla de distancias al Sol, una ficha con los datos de cada uno (tamaño, día, año, lunas, temperatura y gravedad) y una calculadora que indica cuánto pesaría una persona en cada planeta. Todo el contenido se genera con JavaScript a partir de una lista de datos.

```html
<!doctype html>
<html lang="es">
<head>
    <!-- ⚙️ Configuración básica: codificación de caracteres y diseño adaptable a celulares -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- 🧹 Reinicio mínimo: sin margen del navegador, imágenes ajustables y soporte del atributo hidden -->
    <style>body{margin:0}img{max-width:100%}[hidden]{display:none!important}</style>
    <title>Atlas Solar</title>
    <!-- 🔤 Tipografías de Google Fonts (necesitan Internet; sin conexión se usan fuentes del sistema) -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Syne:wght@600;800&family=IBM+Plex+Sans:wght@400;500&family=IBM+Plex+Mono:wght@400;500&display=swap" rel="stylesheet">
    <style>
        /* Diseño: una sola columna oscura con regla de distancias, selector de planetas, ficha de datos y calculadora de peso */
        /* 🎨 Variables de color y tipografías (esta página usa un tema oscuro fijo) */
        :root{
          --bg:#070b14; --panel:#0e1524; --line:#1f2a40; --fg:#e8ecf5; --muted:#8c98b3; --sun:#ffb547;
          --f-display:"Syne","Arial Black",sans-serif; --f-body:"IBM Plex Sans",system-ui,sans-serif; --f-mono:"IBM Plex Mono",ui-monospace,monospace;
          color-scheme:dark;
        }
        /* 📏 Estilos generales: dimensionado, fondo, color de texto y ancho máximo del contenido */
        *{box-sizing:border-box}
        body{background:var(--bg);color:var(--fg);font-family:var(--f-body);font-size:16px;line-height:1.55;padding-inline:16px;padding-block:32px 56px}
        .wrap{max-width:920px;margin-inline:auto}
        h1{font-family:var(--f-display);font-weight:800;font-size:clamp(2.4rem,9vw,4.6rem);line-height:.95;margin:0 0 12px;text-wrap:balance;letter-spacing:-.02em}
        h1 span{color:var(--sun)}
        .lede{color:var(--muted);max-width:56ch;margin:0 0 32px}
        h2{font-family:var(--f-display);font-weight:600;font-size:1.15rem;margin:0 0 12px;letter-spacing:.01em}
        .label{font-family:var(--f-mono);font-size:.72rem;text-transform:uppercase;letter-spacing:.12em;color:var(--muted)}
        section{margin-block:36px}

        /* 📏 Regla de distancias al Sol (escala logarítmica) */
        .ruler{position:relative;height:84px;margin-inline:8px;border-bottom:1px solid var(--line)}
        .ruler .sun{position:absolute;left:-8px;bottom:-9px;width:18px;height:18px;border-radius:50%;background:var(--sun);box-shadow:0 0 22px 4px rgba(255,181,71,.45)}
        .tick{position:absolute;bottom:0;transform:translateX(-50%);display:flex;flex-direction:column;align-items:center;gap:6px;background:none;border:0;color:var(--muted);cursor:pointer;padding:4px 2px;font:inherit}
        .tick i{display:block;width:1px;height:26px;background:var(--line)}
        .tick b{font-family:var(--f-mono);font-weight:400;font-size:.62rem}
        .tick .dot{width:12px;height:12px;border-radius:50%;margin-bottom:-1px}
        .tick[aria-pressed="true"] b{color:var(--fg)}
        .tick[aria-pressed="true"] i{background:var(--sun)}
        .tick:focus-visible,.pick:focus-visible{outline:2px solid var(--sun);outline-offset:3px}
        .rulernote{display:flex;justify-content:space-between;margin:10px 8px 0}

        /* 🪐 Selector de planetas */
        .picker{display:grid;grid-template-columns:repeat(4,1fr);gap:8px}
        @media(min-width:640px){.picker{grid-template-columns:repeat(8,1fr)}}
        .pick{display:flex;flex-direction:column;align-items:center;gap:8px;padding:14px 4px 10px;background:var(--panel);border:1px solid var(--line);border-radius:10px;color:var(--fg);cursor:pointer;font:inherit;min-width:0}
        .pick .orb{border-radius:50%;flex:none}
        .pick span{font-size:.8rem}
        .pick[aria-pressed="true"]{border-color:var(--sun);background:#16203a}
        .orbbox{height:46px;display:flex;align-items:center}

        /* 📋 Ficha con los datos del planeta elegido */
        .sheet{background:var(--panel);border:1px solid var(--line);border-radius:14px;padding:24px 20px}
        .sheet h3{font-family:var(--f-display);font-weight:800;font-size:2.2rem;line-height:1;margin:0 0 6px}
        .sheet p{margin:0 0 20px;color:var(--muted);max-width:60ch}
        dl{display:grid;grid-template-columns:repeat(auto-fit,minmax(150px,1fr));gap:18px 20px;margin:0}
        dl div{min-width:0;border-top:1px solid var(--line);padding-top:8px}
        dt{font-family:var(--f-mono);font-size:.7rem;text-transform:uppercase;letter-spacing:.1em;color:var(--muted)}
        dd{margin:2px 0 0;font-size:1.1rem;font-variant-numeric:tabular-nums}

        /* ⚖️ Calculadora de peso en cada planeta */
        .calc{display:grid;gap:20px;grid-template-columns:1fr}
        @media(min-width:720px){.calc{grid-template-columns:240px 1fr}}
        .field{display:flex;flex-direction:column;gap:6px}
        input[type=number]{background:var(--bg);border:1px solid var(--line);color:var(--fg);font:inherit;font-family:var(--f-mono);font-size:1.3rem;padding:10px 12px;border-radius:8px;width:100%}
        input[type=number]:focus-visible{outline:2px solid var(--sun);outline-offset:2px}
        .bars{display:grid;gap:8px}
        .row{display:grid;grid-template-columns:78px 1fr 92px;align-items:center;gap:10px;font-size:.9rem}
        .track{height:12px;background:var(--bg);border-radius:6px;overflow:hidden}
        .fill{height:100%;background:var(--sun);border-radius:6px;width:0;transition:width .35s}
        .row output{font-family:var(--f-mono);font-size:.8rem;text-align:right;font-variant-numeric:tabular-nums}
        .row.earth .fill{background:#6fb4ff}
        @media(prefers-reduced-motion:reduce){.fill{transition:none}}
        footer{color:var(--muted);font-size:.8rem;margin-top:40px}
    </style>
</head>
<body>
    <!-- 📝 Contenido visible de la página -->
    <div class="wrap">
      <p class="label">8 planetas · 1 estrella</p>
      <h1>Atlas <span>Solar</span></h1>
      <p class="lede">Elige un planeta para ver su tamaño, su día, su año y cuánto tarda en llegarle la luz del Sol. Abajo puedes calcular cuánto pesarías en cada uno.</p>

      <section aria-labelledby="h-dist">
        <h2 id="h-dist">Distancia al Sol</h2>
        <div class="ruler" id="ruler"><div class="sun" title="Sol"></div></div>
        <div class="rulernote label"><span>Sol</span><span>escala logarítmica, en unidades astronómicas (UA)</span></div>
      </section>

      <section aria-labelledby="h-pick">
        <h2 id="h-pick">Planetas</h2>
        <div class="picker" id="picker"></div>
      </section>

      <section aria-live="polite">
        <div class="sheet" id="sheet"></div>
      </section>

      <section aria-labelledby="h-peso">
        <h2 id="h-peso">¿Cuánto pesarías?</h2>
        <div class="calc">
          <div class="field">
            <label class="label" for="masa">Tu masa en kg</label>
            <input id="masa" type="number" min="1" max="300" value="70" inputmode="decimal">
            <span class="label" style="text-transform:none;letter-spacing:0">Se muestra el peso como kilos-fuerza: lo que marcaría una báscula en cada superficie.</span>
          </div>
          <div class="bars" id="bars"></div>
        </div>
      </section>

      <footer>Valores medios redondeados. El número de lunas sigue cambiando con cada descubrimiento, por eso Júpiter y Saturno aparecen como mínimos.</footer>
    </div>

    <!-- ⚙️ Lógica en JavaScript: datos, cálculos y eventos -->
    <script>
        // 🪐 Datos de los 8 planetas: diámetro (km), distancia (UA), día, año, lunas, temperatura y gravedad (m/s²)
        var P=[
         {n:"Mercurio",c:"#b5a79a",au:0.39,d:4879,dia:"59 días terrestres",anio:"88 días",lunas:"0",t:"167 °C",g:3.70,txt:"El más cercano al Sol y el más pequeño. Casi no tiene atmósfera, así que la diferencia entre el día y la noche supera los 500 °C."},
         {n:"Venus",c:"#e8c27a",au:0.72,d:12104,dia:"243 días terrestres",anio:"225 días",lunas:"0",t:"464 °C",g:8.87,txt:"Gira al revés y tan despacio que su día dura más que su año. Su atmósfera densa lo hace más caliente que Mercurio."},
         {n:"Tierra",c:"#6fb4ff",au:1.00,d:12742,dia:"24 horas",anio:"365,25 días",lunas:"1",t:"15 °C",g:9.81,txt:"El único mundo conocido con agua líquida en superficie y vida. De aquí sale la unidad de distancia: 1 UA."},
         {n:"Marte",c:"#d9674a",au:1.52,d:6779,dia:"24,6 horas",anio:"687 días",lunas:"2",t:"−65 °C",g:3.71,txt:"Su día casi coincide con el nuestro. Tiene el volcán más alto conocido, el Monte Olimpo, de unos 22 km de altura."},
         {n:"Júpiter",c:"#d3b08c",au:5.20,d:139820,dia:"9,9 horas",anio:"11,9 años",lunas:"más de 95",t:"−110 °C",g:24.79,txt:"Más masa que todos los demás planetas juntos. La Gran Mancha Roja es una tormenta mayor que la Tierra."},
         {n:"Saturno",c:"#e6d29b",au:9.54,d:116460,dia:"10,7 horas",anio:"29,5 años",lunas:"más de 270",t:"−140 °C",g:10.44,txt:"Sus anillos son hielo y roca en una capa muy delgada. Su densidad media es menor que la del agua."},
         {n:"Urano",c:"#8fd6e0",au:19.2,d:50724,dia:"17,2 horas",anio:"84 años",lunas:"más de 25",t:"−195 °C",g:8.69,txt:"Gira inclinado unos 98°, casi rodando de lado sobre su órbita. Cada polo pasa 42 años seguidos a oscuras."},
         {n:"Neptuno",c:"#5b7bf0",au:30.1,d:49244,dia:"16,1 horas",anio:"165 años",lunas:"más de 15",t:"−200 °C",g:11.15,txt:"El más lejano. Desde su descubrimiento en 1846 apenas ha completado una vuelta al Sol."}
        ];
        // 📏 Límites de la escala logarítmica y funciones de formato (fmt da formato numérico en español; luz calcula cuánto tarda la luz del Sol)
        var MIN=Math.log(0.3),MAX=Math.log(31);
        function fmt(n,dec){return n.toLocaleString("es-MX",{maximumFractionDigits:dec||0})}
        function luz(au){var m=au*8.317;if(m<60)return fmt(m,1)+" min";return fmt(m/60,1)+" h"}
        var sel=2,ruler=document.getElementById("ruler"),picker=document.getElementById("picker"),sheet=document.getElementById("sheet"),bars=document.getElementById("bars");
        function orbSize(p){return 14+Math.sqrt(p.d/139820)*30}
        // 🧭 Crea las marcas de la regla y los botones de cada planeta
        P.forEach(function(p,i){
          var t=document.createElement("button");t.className="tick";t.type="button";t.setAttribute("aria-label",p.n);
          t.style.left=((Math.log(p.au)-MIN)/(MAX-MIN)*100)+"%";
          t.innerHTML='<span class="dot" style="background:'+p.c+'"></span><i></i><b>'+fmt(p.au,2)+'</b>';
          t.onclick=function(){show(i)};ruler.appendChild(t);p.tick=t;
          var b=document.createElement("button");b.className="pick";b.type="button";
          var s=orbSize(p);
          b.innerHTML='<span class="orbbox"><span class="orb" style="width:'+s+'px;height:'+s+'px;background:'+p.c+'"></span></span><span>'+p.n+'</span>';
          b.onclick=function(){show(i)};picker.appendChild(b);p.pick=b;
        });
        // 📋 Muestra la ficha del planeta seleccionado
        function show(i){
          sel=i;var p=P[i];
          P.forEach(function(q,j){q.tick.setAttribute("aria-pressed",j===i);q.pick.setAttribute("aria-pressed",j===i)});
          sheet.innerHTML='<p class="label">Planeta '+(i+1)+' desde el Sol</p><h3>'+p.n+'</h3><p>'+p.txt+'</p><dl>'+
           dd("Diámetro",fmt(p.d)+" km")+dd("Distancia al Sol",fmt(p.au,2)+" UA ("+fmt(p.au*149.6,0)+" millones de km)")+
           dd("Luz del Sol tarda",luz(p.au))+dd("Duración del día",p.dia)+dd("Duración del año",p.anio)+
           dd("Lunas",p.lunas)+dd("Temperatura media",p.t)+dd("Gravedad en superficie",fmt(p.g,2)+" m/s²")+'</dl>';
        }
        function dd(a,b){return "<div><dt>"+a+"</dt><dd>"+b+"</dd></div>"}
        // ⚖️ Calculadora de peso: peso = masa × gravedad del planeta ÷ 9.81
        var input=document.getElementById("masa");
        P.forEach(function(p){
          var r=document.createElement("div");r.className="row"+(p.n==="Tierra"?" earth":"");
          r.innerHTML='<span>'+p.n+'</span><div class="track"><div class="fill"></div></div><output></output>';
          bars.appendChild(r);p.row=r;
        });
        function calc(){
          var m=parseFloat(input.value);if(!(m>0))m=0;
          P.forEach(function(p){
            var w=m*p.g/9.81;
            p.row.querySelector("output").textContent=fmt(w,1)+" kg";
            p.row.querySelector(".fill").style.width=Math.min(100,w/(m*24.79/9.81||1)*100)+"%";
          });
        }
        // ▶️ Evento: recalcula al escribir la masa; al iniciar muestra la Tierra
        input.addEventListener("input",calc);
        show(2);calc();
    </script>
</body>
</html>
```

---

# ============================================
# 🍞 PÁGINA 2: masa-madre.html (Pan de Masa Madre)
# ============================================

> 📌 **Objetivo**: Calculadora de receta de pan de masa madre. Con tres deslizables (harina, hidratación y masa madre) calcula los gramos de cada ingrediente con porcentajes del panadero y, con la hora de inicio, arma el horario completo del proceso, desde la autólisis hasta que el pan se enfría.

```html
<!doctype html>
<html lang="es">
<head>
    <!-- ⚙️ Configuración básica: codificación de caracteres y diseño adaptable a celulares -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- 🧹 Reinicio mínimo: sin margen del navegador, imágenes ajustables y soporte del atributo hidden -->
    <style>body{margin:0}img{max-width:100%}[hidden]{display:none!important}</style>
    <title>Pan de Masa Madre</title>
    <!-- 🔤 Tipografías de Google Fonts (necesitan Internet; sin conexión se usan fuentes del sistema) -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Bricolage+Grotesque:opsz,wght@12..96,500;12..96,800&family=Source+Sans+3:wght@400;600&family=JetBrains+Mono:wght@400;500&display=swap" rel="stylesheet">
    <style>
        /* Diseño: la receta (calculadora) a la izquierda y el horario a la derecha; en celulares se apilan */
        /* 🎨 Variables de color y tipografías. Los bloques @media y [data-theme] activan el modo oscuro automático */
        :root{
          --bg:#edf0ea; --card:#f9faf7; --line:#cfd6c9; --fg:#1b2723; --muted:#5d6c65; --accent:#2f5d50; --accent-fg:#ffffff; --soft:#dbe6df;
          --f-display:"Bricolage Grotesque","Arial Black",sans-serif; --f-body:"Source Sans 3",system-ui,sans-serif; --f-mono:"JetBrains Mono",ui-monospace,monospace;
        }
        @media (prefers-color-scheme: dark){:root:not([data-theme="light"]){--bg:#121a17;--card:#1a2420;--line:#2c3a34;--fg:#e7eee9;--muted:#9bb0a5;--accent:#7fc7ad;--accent-fg:#0d1512;--soft:#22322b;color-scheme:dark}}
        :root[data-theme="dark"]{--bg:#121a17;--card:#1a2420;--line:#2c3a34;--fg:#e7eee9;--muted:#9bb0a5;--accent:#7fc7ad;--accent-fg:#0d1512;--soft:#22322b;color-scheme:dark}
        /* 📏 Estilos generales: dimensionado, fondo, color de texto y ancho máximo del contenido */
        *{box-sizing:border-box}
        body{background:var(--bg);color:var(--fg);font-family:var(--f-body);font-size:17px;line-height:1.5;padding-inline:16px;padding-block:32px 56px}
        .wrap{max-width:960px;margin-inline:auto}
        h1{font-family:var(--f-display);font-weight:800;font-size:clamp(2.3rem,8vw,4rem);line-height:1;margin:0 0 10px;letter-spacing:-.02em;text-wrap:balance}
        .lede{color:var(--muted);max-width:58ch;margin:0 0 28px}
        h2{font-family:var(--f-display);font-weight:500;font-size:1.3rem;margin:0 0 16px}
        .label{font-family:var(--f-mono);font-size:.72rem;text-transform:uppercase;letter-spacing:.1em;color:var(--muted)}
        /* 🧱 Cuadrícula de dos columnas y tarjetas */
        .grid{display:grid;gap:20px;grid-template-columns:1fr}
        @media(min-width:800px){.grid{grid-template-columns:1fr 1fr}}
        .card{background:var(--card);border:1px solid var(--line);border-radius:12px;padding:22px 20px;min-width:0}
        /* 🎚️ Controles deslizables (harina, hidratación y masa madre) */
        .ctl{display:grid;grid-template-columns:1fr auto;gap:2px 12px;margin-bottom:18px}
        .ctl label{font-weight:600}
        .ctl output{font-family:var(--f-mono);font-size:.95rem;text-align:right}
        .ctl input[type=range]{grid-column:1/-1;width:100%;accent-color:var(--accent)}
        .ctl small{grid-column:1/-1;color:var(--muted);font-size:.85rem}
        /* 📊 Tabla de ingredientes */
        table{width:100%;border-collapse:collapse;margin-top:6px}
        th{font-family:var(--f-mono);font-weight:500;font-size:.7rem;text-transform:uppercase;letter-spacing:.08em;color:var(--muted);text-align:left;padding:8px 0;border-bottom:1px solid var(--line)}
        td{padding:11px 0;border-bottom:1px solid var(--line);font-variant-numeric:tabular-nums}
        td:nth-child(2),td:nth-child(3),th:nth-child(2),th:nth-child(3){text-align:right;font-family:var(--f-mono)}
        td:nth-child(2){font-weight:500;font-size:1.05rem}
        tr.total td{border-bottom:0;font-weight:600;color:var(--accent)}
        .tablewrap{overflow-x:auto}
        /* 🕒 Hora de inicio y lista del horario */
        input[type=time]{font:inherit;font-family:var(--f-mono);background:var(--bg);color:var(--fg);border:1px solid var(--line);border-radius:8px;padding:8px 10px}
        input:focus-visible{outline:2px solid var(--accent);outline-offset:2px}
        .start{display:flex;align-items:center;gap:12px;flex-wrap:wrap;margin-bottom:12px}
        ol{list-style:none;margin:0;padding:0;display:grid;gap:0}
        li{display:grid;grid-template-columns:76px 1fr;gap:6px 14px;padding:12px 0;border-bottom:1px solid var(--line)}
        li:last-child{border-bottom:0}
        li time{font-family:var(--f-mono);font-size:.95rem;color:var(--accent);font-weight:500;font-variant-numeric:tabular-nums}
        li time small{display:block;color:var(--muted);font-size:.68rem;font-weight:400}
        li b{display:block}
        li span{color:var(--muted);font-size:.92rem}
        .note{margin-top:22px;padding:14px 16px;background:var(--soft);border-radius:10px;font-size:.92rem}
    </style>
</head>
<body>
    <!-- 📝 Contenido visible de la página -->
    <div class="wrap">
      <p class="label">Hogaza de 75 % de hidratación · fermentación en frío</p>
      <h1>Pan de Masa Madre</h1>
      <p class="lede">Elige cuánta harina quieres usar y la receta se ajusta en gramos con porcentajes del panadero. Pon la hora de inicio y el horario completo se calcula solo.</p>

      <div class="grid">
        <div class="card">
          <h2>Receta</h2>
          <div class="ctl">
            <label for="flour">Harina total</label><output id="o-flour"></output>
            <input id="flour" type="range" min="300" max="1000" step="25" value="500">
            <small>Incluye la harina que viene dentro de la masa madre.</small>
          </div>
          <div class="ctl">
            <label for="hyd">Hidratación</label><output id="o-hyd"></output>
            <input id="hyd" type="range" min="60" max="85" step="1" value="75">
            <small>Más agua da miga más abierta y una masa más difícil de manejar.</small>
          </div>
          <div class="ctl">
            <label for="st">Masa madre</label><output id="o-st"></output>
            <input id="st" type="range" min="10" max="30" step="1" value="20">
            <small>Con 100 % de hidratación: mitad harina, mitad agua.</small>
          </div>
          <div class="tablewrap">
            <table>
              <thead><tr><th>Ingrediente</th><th>Añadir</th><th>% panadero</th></tr></thead>
              <tbody id="tbody"></tbody>
            </table>
          </div>
        </div>

        <div class="card">
          <h2>Horario</h2>
          <div class="start"><label for="t0" class="label">Empiezas a las</label><input id="t0" type="time" value="15:00"></div>
          <ol id="plan"></ol>
          <p class="note">Los tiempos de fermentación suponen una cocina a unos 24 °C. Si hace más calor, acorta la fermentación en bloque; si hace frío, alárgala hasta que la masa crezca cerca de un 50 %.</p>
        </div>
      </div>
    </div>

    <!-- ⚙️ Lógica en JavaScript: datos, cálculos y eventos -->
    <script>
        // 🔧 Atajo para buscar elementos por id y formato de gramos
        var $=function(id){return document.getElementById(id)};
        function g(n){return Math.round(n).toLocaleString("es-MX")+" g"}
        // 🧮 Receta con porcentajes del panadero: la masa madre aporta mitad harina y mitad agua; la sal es el 2 %
        function calc(){
          var T=+$("flour").value,H=+$("hyd").value/100,S=+$("st").value/100;
          var starter=T*S, flour=T-starter/2, water=T*H-starter/2, salt=T*0.02;
          var total=flour+water+starter+salt;
          $("o-flour").textContent=g(T);$("o-hyd").textContent=Math.round(H*100)+" %";$("o-st").textContent=Math.round(S*100)+" %";
          $("tbody").innerHTML=
            row("Harina de trigo",flour,flour/T*100)+row("Agua",water,water/T*100)+row("Masa madre activa",starter,S*100)+row("Sal",salt,2)+
            '<tr class="total"><td>Masa total</td><td>'+g(total)+'</td><td>'+Math.round(total/T*100)+' %</td></tr>';
          return {flour:flour,water:water,starter:starter,salt:salt};
        }
        function row(a,b,c){return "<tr><td>"+a+"</td><td>"+g(b)+"</td><td>"+c.toFixed(c%1?1:0).replace(".",",")+" %</td></tr>"}
        // 📅 Pasos del proceso: minutos transcurridos desde la hora de inicio
        var steps=[
         [0,"Autólisis","Mezcla solo la harina y el agua. Tapa y deja reposar una hora."],
         [60,"Añade masa madre y sal","Integra con las manos mojadas hasta que no queden grumos."],
         [90,"Primer pliegue","Estira un lado de la masa y dóblalo hacia el centro. Repite por los cuatro lados."],
         [120,"Segundo pliegue","La masa ya debe sentirse más tensa y elástica."],
         [150,"Tercer pliegue","El último. Después déjala crecer sin tocarla."],
         [330,"Divide y preforma","La masa creció cerca de un 50 % y tiene burbujas en los bordes. Boleo suave y 20 minutos de descanso."],
         [350,"Formado final","Dale tensión y colócala con la costura hacia arriba en un banneton enharinado."],
         [370,"Reposo en frío","Al refrigerador, cubierta, entre 10 y 14 horas."],
         [1090,"Precalienta el horno","Olla de hierro dentro, a 250 °C, durante una hora completa."],
         [1150,"Hornea tapado","Vuelca la masa, haz un corte profundo y hornea 20 minutos con tapa."],
         [1170,"Hornea destapado","Baja a 230 °C y hornea 25 minutos más, hasta que la corteza quede muy oscura."],
         [1195,"Enfría","Espera una hora sobre una rejilla antes de cortarlo. La miga todavía se está asentando."]
        ];
        // 🕒 Convierte los minutos a hora del reloj (marca "día +1" si pasa de medianoche)
        function plan(){
          var v=$("t0").value||"15:00",p=v.split(":"),base=(+p[0])*60+(+p[1]);
          var h="";
          steps.forEach(function(s){
            var m=base+s[0],day=Math.floor(m/1440),mm=((m%1440)+1440)%1440;
            var hh=String(Math.floor(mm/60)).padStart(2,"0"),mi=String(mm%60).padStart(2,"0");
            h+='<li><time>'+hh+':'+mi+(day>0?'<small>día +'+day+'</small>':'<small>hoy</small>')+'</time><div><b>'+s[1]+'</b><span>'+s[2]+'</span></div></li>';
          });
          $("plan").innerHTML=h;
        }
        // ▶️ Eventos: recalcula al mover los deslizables o al cambiar la hora
        ["flour","hyd","st"].forEach(function(id){$(id).addEventListener("input",calc)});
        $("t0").addEventListener("input",plan);
        calc();plan();
    </script>
</body>
</html>
```

---

# ============================================
# 🎹 PÁGINA 3: teclado-escalas.html (Teclado de Escalas)
# ============================================

> 📌 **Objetivo**: Piano de dos octavas que funciona en el navegador. Al elegir una tónica y una escala ilumina las notas que pertenecen a ella, genera los acordes de la escala y produce sonido con la Web Audio API. Se toca con el mouse, con el dedo o con el teclado de la computadora.

```html
<!doctype html>
<html lang="es">
<head>
    <!-- ⚙️ Configuración básica: codificación de caracteres y diseño adaptable a celulares -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- 🧹 Reinicio mínimo: sin margen del navegador, imágenes ajustables y soporte del atributo hidden -->
    <style>body{margin:0}img{max-width:100%}[hidden]{display:none!important}</style>
    <title>Teclado de Escalas</title>
    <!-- 🔤 Tipografías de Google Fonts (necesitan Internet; sin conexión se usan fuentes del sistema) -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Archivo+Black&family=Archivo:wght@400;600&family=DM+Mono:wght@400;500&display=swap" rel="stylesheet">
    <style>
        /* Diseño: encabezado tipo cartel, controles y un teclado de dos octavas; las notas de la escala se iluminan en amarillo */
        /* 🎨 Variables de color y tipografías. Los bloques @media y [data-theme] activan el modo oscuro automático */
        :root{
          --bg:#f2f1ee; --fg:#14151a; --muted:#5f616b; --line:#d6d4cf; --blue:#2447e0; --blue-fg:#ffffff; --hit:#ffd23f; --hit-fg:#14151a;
          --white-key:#ffffff; --black-key:#16171d; --black-hit:#c99a00; --card:#fbfaf8;
          --f-display:"Archivo Black","Arial Black",sans-serif; --f-body:"Archivo",system-ui,sans-serif; --f-mono:"DM Mono",ui-monospace,monospace;
        }
        @media (prefers-color-scheme: dark){:root:not([data-theme="light"]){--bg:#101116;--fg:#f1f1ee;--muted:#9a9ca6;--line:#2a2c36;--blue:#7d97ff;--blue-fg:#0b0c12;--hit:#ffd23f;--white-key:#e9e8e4;--black-key:#050508;--black-hit:#c99a00;--card:#171821;color-scheme:dark}}
        :root[data-theme="dark"]{--bg:#101116;--fg:#f1f1ee;--muted:#9a9ca6;--line:#2a2c36;--blue:#7d97ff;--blue-fg:#0b0c12;--hit:#ffd23f;--white-key:#e9e8e4;--black-key:#050508;--black-hit:#c99a00;--card:#171821;color-scheme:dark}
        /* 📏 Estilos generales: dimensionado, fondo, color de texto y ancho máximo del contenido */
        *{box-sizing:border-box}
        body{background:var(--bg);color:var(--fg);font-family:var(--f-body);font-size:16px;line-height:1.5;padding-inline:16px;padding-block:32px 56px}
        .wrap{max-width:980px;margin-inline:auto}
        h1{font-family:var(--f-display);font-weight:400;font-size:clamp(2.6rem,10vw,5.4rem);line-height:.92;margin:0 0 14px;text-transform:uppercase;letter-spacing:-.02em}
        h1 em{font-style:normal;color:var(--blue)}
        .lede{max-width:56ch;color:var(--muted);margin:0 0 28px}
        .label{font-family:var(--f-mono);font-size:.72rem;text-transform:uppercase;letter-spacing:.1em;color:var(--muted)}
        /* 🎛️ Botones para elegir tónica y escala */
        .controls{display:grid;gap:18px;margin-bottom:22px}
        .group{display:flex;flex-direction:column;gap:8px}
        .chips{display:flex;flex-wrap:wrap;gap:6px}
        .chip{font:inherit;font-weight:600;font-size:.9rem;padding:8px 12px;border:1.5px solid var(--fg);background:transparent;color:var(--fg);border-radius:999px;cursor:pointer}
        .chip[aria-pressed="true"]{background:var(--blue);border-color:var(--blue);color:var(--blue-fg)}
        .chip:focus-visible,.key:focus-visible,.btn:focus-visible{outline:3px solid var(--blue);outline-offset:2px}
        .readout{display:flex;flex-wrap:wrap;align-items:baseline;gap:6px 18px;margin:0 0 14px}
        .readout strong{font-family:var(--f-display);font-weight:400;font-size:1.7rem}
        .readout span{font-family:var(--f-mono);font-size:.95rem;color:var(--muted)}
        .btn{font:inherit;font-weight:600;padding:10px 18px;border-radius:8px;border:0;background:var(--fg);color:var(--bg);cursor:pointer}

        /* 🎹 Teclado: teclas blancas y negras posicionadas con porcentajes */
        .kbwrap{overflow-x:auto;padding-bottom:6px}
        .kb{position:relative;height:210px;min-width:640px;user-select:none;-webkit-user-select:none;touch-action:manipulation}
        .key{position:absolute;top:0;border:1px solid var(--line);cursor:pointer;padding:0;font:inherit}
        .key.w{background:var(--white-key);height:100%;border-radius:0 0 7px 7px;color:var(--muted);display:flex;align-items:flex-end;justify-content:center;padding-bottom:8px;font-family:var(--f-mono);font-size:.68rem;z-index:1}
        .key.b{background:var(--black-key);height:62%;border-radius:0 0 5px 5px;z-index:2;border-color:var(--black-key)}
        .key.w.in{background:var(--hit);color:var(--hit-fg);border-color:#d9a900}
        .key.b.in{background:var(--black-hit);border-color:var(--black-hit)}
        .key.root::after{content:"";position:absolute;left:50%;transform:translateX(-50%);bottom:30px;width:12px;height:12px;border-radius:50%;background:var(--blue)}
        .key.b.root::after{bottom:14px;background:var(--blue-fg)}
        .key.down{filter:brightness(.88)}

        /* 🎼 Acordes de la escala */
        .chords{margin-top:30px}
        .chordrow{display:grid;grid-template-columns:repeat(auto-fill,minmax(112px,1fr));gap:8px;margin-top:10px}
        .chord{font:inherit;text-align:left;border:1.5px solid var(--line);background:var(--card);color:var(--fg);border-radius:10px;padding:10px 12px;cursor:pointer;min-width:0}
        .chord:hover{border-color:var(--blue)}
        .chord:focus-visible{outline:3px solid var(--blue);outline-offset:2px}
        .chord b{display:block;font-family:var(--f-mono);font-weight:500;font-size:.7rem;color:var(--muted)}
        .chord span{font-weight:600}
        .hint{margin-top:26px;color:var(--muted);font-size:.9rem;max-width:62ch}
    </style>
</head>
<body>
    <!-- 📝 Contenido visible de la página -->
    <div class="wrap">
      <p class="label">2 octavas · sonido en tu navegador</p>
      <h1>Teclado de <em>Escalas</em></h1>
      <p class="lede">Elige una nota y un modo. Las teclas de la escala se iluminan, el círculo azul marca la tónica y puedes tocar con el mouse, el dedo o las teclas de tu computadora.</p>

      <div class="controls">
        <div class="group"><span class="label" id="l-root">Tónica</span><div class="chips" id="roots" role="group" aria-labelledby="l-root"></div></div>
        <div class="group"><span class="label" id="l-scale">Escala</span><div class="chips" id="scales" role="group" aria-labelledby="l-scale"></div></div>
      </div>

      <div class="readout"><strong id="name"></strong><span id="notes"></span><span id="ivs"></span></div>
      <p style="margin:0 0 14px"><button class="btn" id="play" type="button">Tocar la escala</button></p>

      <div class="kbwrap"><div class="kb" id="kb" role="group" aria-label="Teclado"></div></div>

      <div class="chords" id="chords">
        <span class="label">Acordes de la escala (apilando terceras)</span>
        <div class="chordrow" id="chordrow"></div>
      </div>

      <p class="hint">Teclas del teclado de tu computadora: la fila A, S, D, F, G, H, J, K, L toca las notas blancas desde Do; W, E, T, Y, U, O, P tocan las negras entre ellas.</p>
    </div>

    <!-- ⚙️ Lógica en JavaScript: datos, cálculos y eventos -->
    <script>
        // 🎵 Nombres de las 12 notas y escalas disponibles (intervalos en semitonos)
        var NAMES=["Do","Do#","Re","Re#","Mi","Fa","Fa#","Sol","Sol#","La","La#","Si"];
        var SCALES=[
         {n:"Mayor",iv:[0,2,4,5,7,9,11]},
         {n:"Menor natural",iv:[0,2,3,5,7,8,10]},
         {n:"Dórica",iv:[0,2,3,5,7,9,10]},
         {n:"Mixolidia",iv:[0,2,4,5,7,9,10]},
         {n:"Pentatónica menor",iv:[0,3,5,7,10]},
         {n:"Blues",iv:[0,3,5,6,7,10]}
        ];
        // 🎹 Estado inicial y construcción de las 25 teclas del teclado
        var root=0,sc=0,FIRST=48; /* Do central menos una octava: MIDI 48 = C3. Dos octavas + Do final. */
        var COUNT=25,whiteIdx=[0,2,4,5,7,9,11];
        var kb=document.getElementById("kb"),keys=[];
        function isBlack(p){return [1,3,6,8,10].indexOf(p%12)>-1}
        var whites=0;for(var i=0;i<COUNT;i++)if(!isBlack(i))whites++;
        var wpct=100/whites,wi=0;
        for(var i=0;i<COUNT;i++){
          var b=document.createElement("button");b.type="button";b.dataset.i=i;
          var black=isBlack(i);b.className="key "+(black?"b":"w");
          if(black){b.style.left=(wi*wpct-wpct*0.3)+"%";b.style.width=(wpct*0.6)+"%";b.setAttribute("aria-label",NAMES[i%12])}
          else{b.style.left=(wi*wpct)+"%";b.style.width=wpct+"%";b.textContent=NAMES[i%12];wi++}
          kb.appendChild(b);keys.push(b);
        }
        // 🔊 Sonido con la Web Audio API: cada nota mezcla una onda triangular y una senoidal
        var AC=null;
        function ctx(){if(!AC){var C=window.AudioContext||window.webkitAudioContext;if(C)AC=new C()}if(AC&&AC.state==="suspended")AC.resume();return AC}
        function tone(midi,dur,when){
          var c=ctx();if(!c)return;
          var t=c.currentTime+(when||0),f=440*Math.pow(2,(midi-69)/12);
          var o=c.createOscillator(),o2=c.createOscillator(),g=c.createGain();
          o.type="triangle";o2.type="sine";o.frequency.value=f;o2.frequency.value=f*2;
          var g2=c.createGain();g2.gain.value=.25;
          g.gain.setValueAtTime(0,t);g.gain.linearRampToValueAtTime(.28,t+.012);g.gain.exponentialRampToValueAtTime(.0008,t+(dur||.9));
          o.connect(g);o2.connect(g2);g2.connect(g);g.connect(c.destination);
          o.start(t);o2.start(t);o.stop(t+(dur||.9)+.05);o2.stop(t+(dur||.9)+.05);
        }
        // 🖱️ Efecto visual al presionar y evento del mouse o dedo
        function flash(i,ms){var k=keys[i];if(!k)return;k.classList.add("down");setTimeout(function(){k.classList.remove("down")},ms||180)}
        function press(i,when){tone(FIRST+i,.9,when);if(!when)flash(i);else setTimeout(function(){flash(i)},when*1000)}
        kb.addEventListener("pointerdown",function(e){var k=e.target.closest(".key");if(k){e.preventDefault();press(+k.dataset.i)}});
        // ⌨️ Teclas de la computadora asignadas a las notas
        var MAP={a:0,w:1,s:2,e:3,d:4,f:5,t:6,g:7,y:8,h:9,u:10,j:11,k:12,o:13,l:14,p:15};
        document.addEventListener("keydown",function(e){
          if(e.repeat||e.ctrlKey||e.metaKey||e.altKey)return;
          var t=e.target;if(t&&(t.tagName==="INPUT"||t.tagName==="TEXTAREA"))return;
          var i=MAP[e.key.toLowerCase()];if(i!==undefined)press(i);
        });

        // 💡 Ilumina las teclas que pertenecen a la escala y marca la tónica
        function inScale(pc){return SCALES[sc].iv.indexOf(((pc-root)%12+12)%12)>-1}
        function degreeNotes(){return SCALES[sc].iv.map(function(x){return (root+x)%12})}
        function render(){
          keys.forEach(function(k,i){
            var pc=i%12;k.classList.toggle("in",inScale(pc));k.classList.toggle("root",pc===root);
          });
          var s=SCALES[sc];
          document.getElementById("name").textContent=NAMES[root]+" "+s.n.toLowerCase();
          document.getElementById("notes").textContent=degreeNotes().map(function(p){return NAMES[p]}).join(" · ");
          var steps=[];for(var j=0;j<s.iv.length;j++){var d=(j+1<s.iv.length?s.iv[j+1]:12)-s.iv[j];steps.push(d===1?"½":d===2?"1":d===3?"1½":String(d/2))}
          document.getElementById("ivs").textContent="Pasos: "+steps.join(" – ");
          document.querySelectorAll("#roots .chip").forEach(function(c,i){c.setAttribute("aria-pressed",i===root)});
          document.querySelectorAll("#scales .chip").forEach(function(c,i){c.setAttribute("aria-pressed",i===sc)});
          chords();
        }
        // 🎼 Arma los acordes apilando terceras (solo para escalas de 7 notas)
        function chords(){
          var wrap=document.getElementById("chords"),row=document.getElementById("chordrow");
          var s=SCALES[sc];
          if(s.iv.length!==7){wrap.hidden=true;return}
          wrap.hidden=false;
          var notes=degreeNotes(),roman=["I","II","III","IV","V","VI","VII"],html="";
          for(var d=0;d<7;d++){
            var a=notes[d],b=notes[(d+2)%7],c=notes[(d+4)%7];
            var i3=(b-a+12)%12,i5=(c-a+12)%12;
            var q=(i3===4&&i5===7)?"mayor":(i3===3&&i5===7)?"menor":(i3===3&&i5===6)?"disminuido":(i3===4&&i5===8)?"aumentado":"";
            html+='<button type="button" class="chord" data-d="'+d+'"><b>'+roman[d]+'</b><span>'+NAMES[a]+" "+q+'</span></button>';
          }
          row.innerHTML=html;
        }
        // ▶️ Eventos: tocar un acorde, tocar la escala y crear los botones de tónica y escala
        document.getElementById("chordrow").addEventListener("click",function(e){
          var b=e.target.closest(".chord");if(!b)return;
          var d=+b.dataset.d,n=degreeNotes(),pcs=[n[d],n[(d+2)%7],n[(d+4)%7]];
          var prev=-1;
          pcs.forEach(function(pc,k){
            var i=pc;while(i<=prev)i+=12;
            prev=i;press(i,k*.04);
          });
        });
        document.getElementById("play").onclick=function(){
          var n=SCALES[sc].iv.map(function(x){return root+x});n.push(root+12);
          n.forEach(function(i,k){press(i,k*.28)});
        };
        NAMES.forEach(function(nm,i){var b=document.createElement("button");b.type="button";b.className="chip";b.textContent=nm;b.onclick=function(){root=i;render()};document.getElementById("roots").appendChild(b)});
        SCALES.forEach(function(s,i){var b=document.createElement("button");b.type="button";b.className="chip";b.textContent=s.n;b.onclick=function(){sc=i;render()};document.getElementById("scales").appendChild(b)});
        render();
    </script>
</body>
</html>
```

---

# ============================================
# 🏃 PÁGINA 4: plan-10k.html (Plan 10K en Ocho Semanas)
# ============================================

> 📌 **Objetivo**: Plan de entrenamiento para correr 10 km en ocho semanas. A partir del tiempo en 5 km estima el ritmo de carrera con la fórmula de Riegel y calcula el ritmo de cada tipo de sesión, la tabla semanal y una gráfica con los kilómetros por semana.

```html
<!doctype html>
<html lang="es">
<head>
    <!-- ⚙️ Configuración básica: codificación de caracteres y diseño adaptable a celulares -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- 🧹 Reinicio mínimo: sin margen del navegador, imágenes ajustables y soporte del atributo hidden -->
    <style>body{margin:0}img{max-width:100%}[hidden]{display:none!important}</style>
    <title>Plan 10K en Ocho Semanas</title>
    <!-- 🔤 Tipografías de Google Fonts (necesitan Internet; sin conexión se usan fuentes del sistema) -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Barlow+Condensed:wght@600;700;800&family=Barlow:wght@400;500;600&family=Roboto+Mono:wght@400;500&display=swap" rel="stylesheet">
    <style>
        /* Diseño: encabezado con carriles, tiempo en 5 km, zonas de ritmo, tabla de 8 semanas y gráfica de kilómetros */
        /* 🎨 Variables de color y tipografías. Los bloques @media y [data-theme] activan el modo oscuro automático */
        :root{
          --bg:#f5f6f7; --card:#ffffff; --fg:#16181b; --muted:#60666d; --line:#dcdfe2; --clay:#c23b22; --clay-fg:#ffffff; --soft:#f7e3de; --lane:#e9ebed;
          --f-display:"Barlow Condensed","Arial Narrow",sans-serif; --f-body:"Barlow",system-ui,sans-serif; --f-mono:"Roboto Mono",ui-monospace,monospace;
        }
        @media (prefers-color-scheme: dark){:root:not([data-theme="light"]){--bg:#111315;--card:#1a1d20;--fg:#eff1f2;--muted:#9aa1a8;--line:#2d3237;--clay:#ff7a5c;--clay-fg:#1a0a06;--soft:#35201b;--lane:#23272b;color-scheme:dark}}
        :root[data-theme="dark"]{--bg:#111315;--card:#1a1d20;--fg:#eff1f2;--muted:#9aa1a8;--line:#2d3237;--clay:#ff7a5c;--clay-fg:#1a0a06;--soft:#35201b;--lane:#23272b;color-scheme:dark}
        /* 📏 Estilos generales: dimensionado, fondo, color de texto y ancho máximo del contenido */
        *{box-sizing:border-box}
        body{background:var(--bg);color:var(--fg);font-family:var(--f-body);font-size:16px;line-height:1.5;padding-inline:16px;padding-block:0 56px}
        .wrap{max-width:980px;margin-inline:auto}
        .lanes{height:34px;margin-inline:-16px;background:repeating-linear-gradient(to bottom,var(--clay) 0 5px,var(--bg) 5px 8px);opacity:.9}
        h1{font-family:var(--f-display);font-weight:800;font-size:clamp(3rem,12vw,6.4rem);line-height:.88;margin:28px 0 12px;text-transform:uppercase;letter-spacing:-.01em}
        h1 em{font-style:normal;color:var(--clay)}
        .lede{max-width:58ch;color:var(--muted);margin:0 0 28px}
        h2{font-family:var(--f-display);font-weight:700;font-size:1.7rem;text-transform:uppercase;margin:0 0 12px;letter-spacing:.01em}
        .label{font-family:var(--f-mono);font-size:.7rem;text-transform:uppercase;letter-spacing:.1em;color:var(--muted)}
        section{margin-block:38px}
        /* ⏱️ Campos de tiempo */
        .inputs{display:flex;flex-wrap:wrap;gap:14px;align-items:end}
        .field{display:flex;flex-direction:column;gap:6px}
        .time{display:flex;align-items:center;gap:6px}
        input[type=number]{width:84px;font:inherit;font-family:var(--f-mono);font-size:1.4rem;padding:8px 10px;background:var(--card);color:var(--fg);border:1.5px solid var(--line);border-radius:8px}
        input:focus-visible{outline:3px solid var(--clay);outline-offset:2px}
        .time span{font-family:var(--f-mono);color:var(--muted)}
        /* 🏃 Tarjetas de ritmos por tipo de sesión */
        .zones{display:grid;gap:10px;grid-template-columns:repeat(auto-fit,minmax(200px,1fr))}
        .zone{background:var(--card);border:1px solid var(--line);border-radius:10px;padding:14px 16px;min-width:0}
        .zone b{display:block;font-family:var(--f-display);font-weight:700;font-size:1.2rem;text-transform:uppercase}
        .zone .pace{font-family:var(--f-mono);font-size:1.25rem;font-variant-numeric:tabular-nums;margin:2px 0}
        .zone small{color:var(--muted)}
        .goal{background:var(--clay);color:var(--clay-fg);border-color:var(--clay)}
        .goal small{color:inherit;opacity:.85}
        /* 📅 Tabla del plan de ocho semanas */
        .tablewrap{overflow-x:auto;background:var(--card);border:1px solid var(--line);border-radius:10px}
        table{width:100%;border-collapse:collapse;min-width:640px}
        th{font-family:var(--f-mono);font-weight:500;font-size:.68rem;text-transform:uppercase;letter-spacing:.08em;color:var(--muted);text-align:left;padding:12px 14px;border-bottom:1px solid var(--line)}
        td{padding:12px 14px;border-bottom:1px solid var(--line);vertical-align:top;font-size:.95rem}
        tr:last-child td{border-bottom:0}
        td.w{font-family:var(--f-display);font-weight:700;font-size:1.3rem;white-space:nowrap}
        td.km{font-family:var(--f-mono);font-variant-numeric:tabular-nums;white-space:nowrap}
        td small{display:block;color:var(--muted)}
        tr.rest td.w::after{content:" · baja carga";font-family:var(--f-mono);font-weight:400;font-size:.68rem;color:var(--muted)}
        tr.race{background:var(--soft)}
        /* 📊 Gráfica de barras de kilómetros por semana */
        .chart{display:grid;grid-template-columns:repeat(8,1fr);gap:8px;align-items:end;height:200px;padding:14px 12px 0;background:var(--card);border:1px solid var(--line);border-radius:10px;background-image:linear-gradient(var(--lane) 1px,transparent 1px);background-size:100% 25%;background-position:0 14px}
        .col{display:flex;flex-direction:column;justify-content:flex-end;align-items:center;gap:4px;height:100%;min-width:0}
        .col i{display:block;width:100%;max-width:44px;background:var(--clay);border-radius:4px 4px 0 0;min-height:2px}
        .col.rest i{opacity:.55}
        .col b{font-family:var(--f-mono);font-weight:500;font-size:.72rem}
        .axis{display:grid;grid-template-columns:repeat(8,1fr);gap:8px;padding:6px 12px 0;text-align:center}
        .axis span{font-family:var(--f-mono);font-size:.68rem;color:var(--muted)}
        .total{margin-top:10px;color:var(--muted);font-size:.9rem}
        .note{font-size:.9rem;color:var(--muted);max-width:66ch}
    </style>
</head>
<body>
    <!-- 📝 Contenido visible de la página -->
    <div class="wrap">
      <div class="lanes" aria-hidden="true"></div>
      <p class="label" style="margin-top:20px">Para quien ya corre 5 km · tres salidas por semana</p>
      <h1>Plan 10K<br><em>en ocho semanas</em></h1>
      <p class="lede">Escribe tu mejor tiempo reciente en 5 km. La página estima tu ritmo de 10 km y calcula a qué velocidad correr cada tipo de sesión.</p>

      <section aria-labelledby="h-in">
        <h2 id="h-in">Tu punto de partida</h2>
        <div class="inputs">
          <div class="field"><span class="label" id="l5">Tiempo en 5 km</span>
            <div class="time" role="group" aria-labelledby="l5">
              <input id="m5" type="number" min="12" max="60" value="28" aria-label="Minutos" inputmode="numeric"><span>min</span>
              <input id="s5" type="number" min="0" max="59" value="30" aria-label="Segundos" inputmode="numeric"><span>s</span>
            </div>
          </div>
        </div>
      </section>

      <section aria-labelledby="h-z">
        <h2 id="h-z">Ritmos por sesión</h2>
        <div class="zones" id="zones"></div>
        <p class="note" style="margin-top:12px">La predicción usa la fórmula de Riegel, T₂ = T₁ × (D₂ ÷ D₁)^1,06. Es una referencia: con poco volumen semanal la mayoría rinde un poco menos en 10 km.</p>
      </section>

      <section aria-labelledby="h-p">
        <h2 id="h-p">Las ocho semanas</h2>
        <div class="tablewrap">
          <table>
            <thead><tr><th>Semana</th><th>Sesión A · calidad</th><th>Sesión B · fácil</th><th>Sesión C · larga</th><th>Total</th></tr></thead>
            <tbody id="plan"></tbody>
          </table>
        </div>
      </section>

      <section aria-labelledby="h-c">
        <h2 id="h-c">Kilómetros por semana</h2>
        <div class="chart" id="chart" role="img" aria-label="Gráfica de barras con los kilómetros de cada semana"></div>
        <div class="axis" id="axis"></div>
        <p class="total" id="total"></p>
      </section>
    </div>

    <!-- ⚙️ Lógica en JavaScript: datos, cálculos y eventos -->
    <script>
        // 🔧 Atajo por id y conversión de segundos a minutos:segundos
        var $=function(id){return document.getElementById(id)};
        function mmss(sec){sec=Math.round(sec);var m=Math.floor(sec/60),s=sec%60;return m+":"+String(s).padStart(2,"0")}
        // 📅 Plan: kilómetros de cada sesión (A calidad, B fácil, C larga) por semana
        var W=[
         {a:4,at:"4 km fáciles + 4 aceleraciones de 20 s",b:4,c:6},
         {a:5,at:"5 km con 4 × 400 m a ritmo de 5K",b:4,c:7},
         {a:5,at:"5 km con 3 × 800 m a ritmo de 5K",b:5,c:8},
         {a:4,at:"4 km fáciles y sueltos",b:4,c:6,rest:1},
         {a:6,at:"6 km con 20 min a ritmo de umbral",b:5,c:9},
         {a:6,at:"6 km con 4 × 1000 m a ritmo de 5K",b:5,c:10},
         {a:6,at:"6 km con 25 min a ritmo de umbral",b:5,c:8},
         {a:4,at:"4 km con 6 aceleraciones de 20 s",b:3,c:10,race:1}
        ];
        // 🧮 Fórmula de Riegel: tiempo 10K = tiempo 5K × 2^1.06; de ahí salen todos los ritmos
        function render(){
          var m=+$("m5").value||0,s=+$("s5").value||0,t5=m*60+s;
          if(t5<=0)return;
          var t10=t5*Math.pow(2,1.06),p10=t10/10,p5=t5/5;
          $("zones").innerHTML=
           zone("Meta 10K",mmss(p10)+" /km","Tiempo estimado: "+mmss(t10).replace(/^(\d+):(\d\d)$/,function(_,a,b){return a+" min "+b+" s"}),1)+
           zone("Fácil",mmss(p10*1.18)+" – "+mmss(p10*1.30)+" /km","Puedes hablar en frases completas.")+
           zone("Umbral",mmss(p10*1.03)+" – "+mmss(p10*1.06)+" /km","Duro pero controlado, frases cortas.")+
           zone("Ritmo de 5K",mmss(p5)+" /km","Para las repeticiones de 400 a 1000 m.");
          var h="",tot=0,max=0;
          W.forEach(function(w,i){var k=w.a+w.b+w.c;tot+=k;if(k>max)max=k});
          W.forEach(function(w,i){
            var k=w.a+w.b+w.c;
            h+='<tr class="'+(w.rest?"rest ":"")+(w.race?"race":"")+'"><td class="w">'+(i+1)+'</td><td>'+w.at+'<small>'+w.a+' km</small></td><td>Fácil<small>'+w.b+' km</small></td><td>'+(w.race?'<b>Carrera de 10 km</b><small>Sal a ritmo de '+mmss(p10*1.02)+' y acelera si te sobra al final</small>':'Largo y fácil<small>'+w.c+' km</small>')+'</td><td class="km">'+k+' km</td></tr>';
          });
          $("plan").innerHTML=h;
          var ch="",ax="";
          W.forEach(function(w,i){
            var k=w.a+w.b+w.c;
            ch+='<div class="col'+(w.rest?" rest":"")+'"><b>'+k+'</b><i style="height:'+(k/max*78)+'%"></i></div>';
            ax+='<span>S'+(i+1)+'</span>';
          });
          $("chart").innerHTML=ch;$("axis").innerHTML=ax;
          $("total").textContent="Volumen total del plan: "+tot+" km. La semana 4 baja la carga para que el cuerpo asimile el trabajo.";
        }
        // ▶️ Tarjeta de ritmo y eventos: recalcula al cambiar el tiempo
        function zone(a,b,c,goal){return '<div class="zone'+(goal?" goal":"")+'"><b>'+a+'</b><div class="pace">'+b+'</div><small>'+c+'</small></div>'}
        $("m5").addEventListener("input",render);$("s5").addEventListener("input",render);
        render();
    </script>
</body>
</html>
```

---

# ============================================
# 🌄 PÁGINA 5: oaxaca.html (Cuaderno de Oaxaca)
# ============================================

> 📌 **Objetivo**: Itinerario de viaje de cuatro días por Oaxaca. Cada día aparece en una pestaña con sus paradas, que se marcan como visitadas con una casilla; el avance se guarda en el navegador con `localStorage`. Incluye al final una guía con datos útiles.

```html
<!doctype html>
<html lang="es">
<head>
    <!-- ⚙️ Configuración básica: codificación de caracteres y diseño adaptable a celulares -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- 🧹 Reinicio mínimo: sin margen del navegador, imágenes ajustables y soporte del atributo hidden -->
    <style>body{margin:0}img{max-width:100%}[hidden]{display:none!important}</style>
    <title>Cuaderno de Oaxaca</title>
    <!-- 🔤 Tipografías de Google Fonts (necesitan Internet; sin conexión se usan fuentes del sistema) -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Rozha+One&family=Figtree:wght@400;500;600&family=Fragment+Mono&display=swap" rel="stylesheet">
    <style>
        /* Diseño: título con franja tejida, pestañas por día, lista de paradas marcables y guía final */
        /* 🎨 Variables de color y tipografías. Los bloques @media y [data-theme] activan el modo oscuro automático */
        :root{
          --bg:#f7f3f5; --card:#ffffff; --fg:#241a26; --muted:#6d5f71; --line:#e3d9e4; --marigold:#d96b00; --marigold-fg:#ffffff; --rose:#c61f67; --teal:#0f7f86; --soft:#fbe9d6;
          --f-display:"Rozha One","Georgia",serif; --f-body:"Figtree",system-ui,sans-serif; --f-mono:"Fragment Mono",ui-monospace,monospace;
        }
        @media (prefers-color-scheme: dark){:root:not([data-theme="light"]){--bg:#17101b;--card:#21172a;--fg:#f6eef6;--muted:#b6a5ba;--line:#37283f;--marigold:#ff9b21;--marigold-fg:#1a0e00;--rose:#ff6aa6;--teal:#4cc9d1;--soft:#3a2418;color-scheme:dark}}
        :root[data-theme="dark"]{--bg:#17101b;--card:#21172a;--fg:#f6eef6;--muted:#b6a5ba;--line:#37283f;--marigold:#ff9b21;--marigold-fg:#1a0e00;--rose:#ff6aa6;--teal:#4cc9d1;--soft:#3a2418;color-scheme:dark}
        /* 📏 Estilos generales: dimensionado, fondo, color de texto y ancho máximo del contenido */
        *{box-sizing:border-box}
        body{background:var(--bg);color:var(--fg);font-family:var(--f-body);font-size:16px;line-height:1.55;padding-inline:16px;padding-block:0 56px}
        .wrap{max-width:900px;margin-inline:auto}
        .band{height:26px;margin-inline:-16px;background:
          repeating-linear-gradient(90deg,var(--marigold) 0 28px,var(--rose) 28px 44px,var(--teal) 44px 60px,var(--fg) 60px 66px,var(--marigold) 66px 80px)}
        h1{font-family:var(--f-display);font-weight:400;font-size:clamp(2.8rem,11vw,5.6rem);line-height:.95;margin:30px 0 12px;text-wrap:balance}
        h1 em{font-style:normal;color:var(--rose)}
        .lede{max-width:58ch;color:var(--muted);margin:0 0 26px}
        .label{font-family:var(--f-mono);font-size:.72rem;text-transform:uppercase;letter-spacing:.1em;color:var(--muted)}
        /* 📑 Pestañas de los días */
        .tabs{display:flex;gap:6px;flex-wrap:wrap;margin-bottom:18px}
        .tab{font:inherit;font-weight:600;border:1.5px solid var(--fg);background:transparent;color:var(--fg);border-radius:10px;padding:9px 14px;cursor:pointer;text-align:left}
        .tab small{display:block;font-family:var(--f-mono);font-weight:400;font-size:.66rem;text-transform:uppercase;letter-spacing:.08em;opacity:.8}
        .tab[aria-selected="true"]{background:var(--marigold);border-color:var(--marigold);color:var(--marigold-fg)}
        .tab:focus-visible,.stop input:focus-visible{outline:3px solid var(--teal);outline-offset:2px}
        .dayhead{display:flex;flex-wrap:wrap;justify-content:space-between;align-items:baseline;gap:6px 16px;margin-bottom:6px}
        h2{font-family:var(--f-display);font-weight:400;font-size:2rem;margin:0}
        .progress{font-family:var(--f-mono);font-size:.8rem;color:var(--muted)}
        .day-note{color:var(--muted);max-width:60ch;margin:0 0 14px}
        /* ✅ Lista de paradas con casilla */
        ul{list-style:none;margin:0;padding:0;display:grid;gap:8px}
        .stop{display:grid;grid-template-columns:auto 64px 1fr;gap:6px 12px;align-items:start;background:var(--card);border:1px solid var(--line);border-radius:12px;padding:14px 14px;min-width:0}
        .stop input{width:22px;height:22px;margin:2px 0 0;accent-color:var(--rose)}
        .stop time{font-family:var(--f-mono);font-size:.85rem;color:var(--marigold);padding-top:3px;font-variant-numeric:tabular-nums}
        .stop b{display:block}
        .stop span{color:var(--muted);font-size:.93rem}
        .stop.done{background:var(--soft)}
        .stop.done b{text-decoration:line-through;text-decoration-thickness:1px}
        /* 🧭 Tarjetas de la guía final */
        .guide{margin-top:44px;display:grid;gap:14px;grid-template-columns:repeat(auto-fit,minmax(250px,1fr))}
        .fact{background:var(--card);border:1px solid var(--line);border-radius:12px;padding:16px 18px;min-width:0}
        .fact h3{font-family:var(--f-display);font-weight:400;font-size:1.35rem;margin:0 0 6px}
        .fact p{margin:0;color:var(--muted);font-size:.95rem}
        .moles{display:flex;flex-wrap:wrap;gap:6px;margin-top:10px}
        .moles span{font-size:.8rem;border:1px solid var(--line);border-radius:999px;padding:3px 10px;color:var(--fg)}
        h2.sec{margin:44px 0 6px}
    </style>
</head>
<body>
    <!-- 📝 Contenido visible de la página -->
    <div class="wrap">
      <div class="band" aria-hidden="true"></div>
      <p class="label" style="margin-top:22px">Valles Centrales · cuatro días · a pie y en taxi colectivo</p>
      <h1>Cuaderno de <em>Oaxaca</em></h1>
      <p class="lede">Un itinerario para conocer la ciudad, sus mercados, las ruinas zapotecas y los pueblos artesanos del valle. Marca cada parada cuando la visites.</p>

      <div class="tabs" role="tablist" id="tabs" aria-label="Días del viaje"></div>
      <div id="day" role="tabpanel"></div>

      <h2 class="sec">Para llevar en la cabeza</h2>
      <div class="guide">
        <div class="fact"><h3>Los siete moles</h3><p>La cocina oaxaqueña presume siete moles tradicionales. Prueba al menos tres distintos.</p>
          <div class="moles"><span>negro</span><span>rojo</span><span>coloradito</span><span>amarillo</span><span>verde</span><span>manchamanteles</span><span>chichilo</span></div></div>
        <div class="fact"><h3>Cuándo ir</h3><p>Para Día de Muertos, a finales de octubre y principios de noviembre, hay altares y comparsas por toda la ciudad. En julio se celebra la Guelaguetza, los dos últimos lunes del mes. Reserva con meses de anticipación en ambas fechas.</p></div>
        <div class="fact"><h3>Altura y sol</h3><p>La ciudad está a unos 1,550 m sobre el nivel del mar. Monte Albán, en el cerro, queda unos cuatrocientos metros más arriba: lleva gorra, agua y llega temprano.</p></div>
        <div class="fact"><h3>Mezcal</h3><p>En las palenques se muestra todo el proceso, desde el horno de piedra hasta la destilación. Pregunta por el tipo de agave y bebe despacio, con naranja y sal de gusano si te la ofrecen.</p></div>
      </div>
    </div>

    <!-- ⚙️ Lógica en JavaScript: datos, cálculos y eventos -->
    <script>
        // 🗓️ Itinerario: 4 días con paradas [hora, lugar, descripción]
        var DAYS=[
         {t:"Centro histórico",sub:"Día 1",note:"Un día corto y caminable para tomar el pulso a la ciudad.",stops:[
          ["09:00","Zócalo y Catedral","Desayuna chocolate con pan de yema bajo los portales y mira cómo abre la plaza."],
          ["10:30","Templo de Santo Domingo","Fachada barroca y bóvedas doradas. Pasa por el jardín etnobotánico del ex convento si tienes tiempo."],
          ["12:00","Museo de las Culturas de Oaxaca","Está en el mismo ex convento. Aquí se exhibe el tesoro de la Tumba 7 de Monte Albán."],
          ["14:30","Mercado 20 de Noviembre","Entra al pasillo del humo, elige la carne cruda y que te la asen en el momento."],
          ["19:00","Cena de tlayudas","Tortilla grande, tostada, con asiento, quesillo y tasajo. Mejor compartirla."]]},
         {t:"Monte Albán",sub:"Día 2",note:"Sube por la mañana, cuando hace menos calor y hay menos gente.",stops:[
          ["08:30","Salida hacia Monte Albán","Son unos 9 km desde el centro, por una carretera que sube en curvas. Hay transporte turístico y taxis desde el centro."],
          ["09:30","Ciudad zapoteca","Fundada hacia el 500 a. C. sobre una cima aplanada. Recorre la Gran Plaza, el Juego de Pelota y los Danzantes."],
          ["12:30","Museo de sitio","Cerámica, joyería y las lápidas más antiguas del sitio."],
          ["15:00","Comida en Jalatlaco","Barrio de casas bajas con murales y calles empedradas."],
          ["17:30","Basílica de la Soledad","Patrona de Oaxaca. Cerca hay tiendas de chocolate que muelen cacao frente a ti."]]},
         {t:"Valles Centrales",sub:"Día 3",note:"Contrata un taxi por el día o únete a un recorrido compartido. Son muchas paradas.",stops:[
          ["09:00","Árbol del Tule","Un ahuehuete de más de mil años, con uno de los troncos más anchos del mundo."],
          ["10:00","Teotitlán del Valle","Tapetes de lana teñidos con grana cochinilla, índigo y plantas locales. Pregunta por los tintes naturales."],
          ["12:30","Mitla","Palacios zapotecas decorados con grecas hechas de piezas de piedra encajadas una a una."],
          ["14:30","Hierve el Agua","Cascadas petrificadas por el carbonato de calcio y albercas naturales con vista al valle."],
          ["17:30","Palenque de mezcal","Camino de regreso, en Santiago Matatlán, que se presenta como la capital mundial del mezcal."]]},
         {t:"Sabores y artesanía",sub:"Día 4",note:"Un día para comer, comprar y despedirse con calma.",stops:[
          ["09:00","Clase de cocina","Muchas escuelas empiezan en el Mercado de la Merced y terminan con un mole hecho por ti."],
          ["13:00","Mercado Benito Juárez","Quesillo, chapulines, tejate y pan de yema."],
          ["15:00","Calle Macedonio Alcalá","Peatonal con galerías, tiendas de barro negro de San Bartolo Coyotepec y alebrijes."],
          ["17:30","Paseo en el Cerro del Fortín","Atardecer sobre la ciudad con vista de las torres de Santo Domingo."],
          ["20:00","Cena de despedida","Prueba el mole negro con una copa de mezcal artesanal."]]}
        ];
        // 💾 Estado: día actual y paradas marcadas (se guardan en el navegador con localStorage)
        var cur=0,state={};
        try{state=JSON.parse(localStorage.getItem("oaxaca-checks")||"{}")}catch(e){state={}}
        function save(){try{localStorage.setItem("oaxaca-checks",JSON.stringify(state))}catch(e){}}
        // 📑 Crea las pestañas de cada día
        var tabs=document.getElementById("tabs"),day=document.getElementById("day");
        DAYS.forEach(function(d,i){
          var b=document.createElement("button");b.type="button";b.className="tab";b.setAttribute("role","tab");
          b.innerHTML=d.t+"<small>"+d.sub+"</small>";b.onclick=function(){cur=i;draw()};tabs.appendChild(b);
        });
        // 🖼️ Dibuja la lista del día elegido con su avance
        function draw(){
          var d=DAYS[cur];
          Array.prototype.forEach.call(tabs.children,function(b,i){b.setAttribute("aria-selected",i===cur)});
          var done=d.stops.filter(function(s,j){return state[cur+"-"+j]}).length;
          var h='<div class="dayhead"><h2>'+d.t+'</h2><span class="progress">'+done+' de '+d.stops.length+' paradas</span></div><p class="day-note">'+d.note+'</p><ul>';
          d.stops.forEach(function(s,j){
            var k=cur+"-"+j,c=state[k]?" checked":"";
            h+='<li class="stop'+(state[k]?" done":"")+'"><input type="checkbox" id="c'+k+'" data-k="'+k+'"'+c+' aria-label="Visitado: '+s[1]+'"><time>'+s[0]+'</time><div><b>'+s[1]+'</b><span>'+s[2]+'</span></div></li>';
          });
          day.innerHTML=h+"</ul>";
        }
        // ▶️ Evento: marcar o desmarcar una parada y guardar
        day.addEventListener("change",function(e){var k=e.target.dataset&&e.target.dataset.k;if(!k)return;state[k]=e.target.checked;save();draw();var el=document.getElementById("c"+k);if(el)el.focus()});
        draw();
    </script>
</body>
</html>
```
