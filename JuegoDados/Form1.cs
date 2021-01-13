using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace JuegoDados
{
    public partial class Form1 : Form
    { 
        private int dado1;
        private int dado2;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTirar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            btnTirar1.Visible = false;
            btnParar1.Visible = true;
        }

        private void btnTirar2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer2.Start();
            btnTirar2.Visible = false;
            btnParar2.Visible = true;
        }

        public void IniciarJuego()
        {
            fotoDado1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(1.ToString());
            btnTirar1.Visible = true;
            btnParar1.Visible = false;
            winner.Visible = false;
            Sonido("readygo");
        }

        public void Sonido(string NombreSonido)
        {
            Stream sonido = (Stream) Properties.Resources.ResourceManager.GetObject(NombreSonido);
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
            dado1 = rnd.Next(1, 7);
            fotoDado1.Image = (Bitmap) Properties.Resources.ResourceManager.GetObject(dado1.ToString());
            btnParar1.Enabled = false;

            if (!btnParar2.Enabled)
            {
                averigua_ganador();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int dado = rnd.Next(1, 7);
            fotoDado1.Image = (Bitmap) Properties.Resources.ResourceManager.GetObject(dado.ToString());
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int dado = rnd.Next(1, 7);
            fotoDado2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(dado.ToString());
        }

        private void averigua_ganador()
        {
            if (dado1 > dado2)
            {
                winner.Text = "Jugador 1";
            } else if (dado2 > dado1)
            {
                winner.Text = "Jugador 2";
            } else
            {
                winner.Text = "Empate";
            }

            winner.Visible = true;

        }

        private void btnParar2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            timer2.Stop();
            dado2 = rnd.Next(1, 7);
            fotoDado2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(dado2.ToString());
            btnParar2.Enabled = false;

            if (!btnParar1.Enabled)
            {
                averigua_ganador();
            }
        }
    }
}
