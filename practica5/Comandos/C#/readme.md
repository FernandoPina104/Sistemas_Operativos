// 🚀 1. Punto de entrada de la aplicación (Program.cs)
// Explicación: Este archivo es el punto de inicio de tu programa. Su única función es configurar los estilos 
// visuales básicos de Windows y lanzar la ventana principal (MainForm) en cuanto el usuario ejecuta la aplicación.

using System;
using System.Windows.Forms;

namespace AgendaApp
{
    internal sealed class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
