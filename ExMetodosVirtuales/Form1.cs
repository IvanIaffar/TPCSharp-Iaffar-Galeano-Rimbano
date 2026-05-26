using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Figuras
{
    public partial class Form1 : Form
    {
        Figura[] figuras;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            figuras = new Figura[3]
            {
                new Circulo(60),
                new Rectangulo(30,50),
                new Cuadrado(45),
            };

        }

        // c.2) Descarta colores con brillo > 0.65 (demasiado claros respecto al fondo blanco)
        private Color GenerarColorContrastante()
        {
            Color color;
            do
            {
                color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            } while (color.GetBrightness() > 0.65f);
            return color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
            for (int i = 0; i < figuras.Length; i++)
            {
                Pen pen = new Pen(GenerarColorContrastante());
                figuras[i].Dibujar(pen, gr, i * 100, 50);
            }

        }
    }
}
