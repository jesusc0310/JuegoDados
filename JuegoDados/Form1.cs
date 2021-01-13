using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace JuegoDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTirar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            btnTirar.Visible = false;
            btnParar.Visible = true;
        }

        public void IniciarJuego()
        {
            pictureBox1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(1.ToString());
            btnTirar.Visible = true;
            btnParar.Visible = false;
            Sonido("readygo");
        }

        public void Sonido(string NombreSonido)
        {
            Stream sonido = (Stream)Properties.Resources.ResourceManager.GetObject(NombreSonido);
            SoundPlayer SonidoCargado = new SoundPlayer(sonido);
            SonidoCargado.Play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniciarJuego();
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            timer1.Stop();
            btnTirar.Visible = true;
            btnParar.Visible = false;
            int dado = rnd.Next(1, 7);
            pictureBox1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(dado.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int dado = rnd.Next(1, 7);
            pictureBox1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(dado.ToString());
        }
    }
}
