using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace JuegoDados
{
    public partial class Form1 : Form
    {

        private int winned1;
        private int winned2;
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
            fotoDado2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(1.ToString());
            btnTirar1.Visible = true;
            btnParar1.Visible = false;
            btnParar1.Enabled = true;

            btnTirar2.Visible = true;
            btnParar2.Visible = false;
            btnParar2.Enabled = true;

            btnPlayAgain.Enabled = false;
            btnPlayAgain.Visible = false;
            
            btnReset.Enabled = false;
            btnReset.Visible = false;
            
            winned1 = 0;
            winned2 = 0;
            winner1.Text = "0";
            winner2.Text = "0";
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
            dado1 = rnd.Next(1, 7);
            fotoDado1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(dado1.ToString());
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
            fotoDado1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(dado.ToString());
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
                winned1++;
                winner1.Text = winned1.ToString();
            }
            else if (dado2 > dado1)
            {
                winned2++;
                winner2.Text = winned2.ToString();
            }

            btnPlayAgain.Visible = true;
            btnPlayAgain.Enabled = true;
            btnReset.Visible = true;
            btnReset.Enabled = true;
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

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            btnTirar1.Visible = true;
            btnParar1.Visible = false;
            btnParar1.Enabled = true;

            btnTirar2.Visible = true;
            btnParar2.Visible = false;
            btnParar2.Enabled = true;

            btnReset.Visible = false;
            btnReset.Enabled = false;

            btnPlayAgain.Visible = false;
            btnPlayAgain.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            IniciarJuego();
        }
    }
}
