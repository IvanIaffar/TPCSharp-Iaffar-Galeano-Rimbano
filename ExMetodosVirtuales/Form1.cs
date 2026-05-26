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
            int[] tamanios = new int[] { 40, 60, 80, 100, 120 }; // proporciones 1x, 1.5x, 2x, 2.5x, 3x
            figuras = new Figura[]
            {
                new Circulo(tamanios[0]),
                new Rectangulo(tamanios[1], tamanios[1] + 20),
                new Cuadrado(tamanios[2]),
                new TrianguloEquilatero(tamanios[3]),
                new TrianguloIsosceles(tamanios[4], tamanios[4] + 20),
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
                figuras[i].Dibujar(pen, gr, 10 + i * 140, 20);
            }

        }
    }
}
