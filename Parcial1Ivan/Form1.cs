using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Parcial1Ivan
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> _CargaImg;

        public Form1()
        {
            InitializeComponent();
        }

        private void cargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string Filename = "C:\\lenna.png";

            _CargaImg = new Image<Bgr, byte>(Filename);


            if (_CargaImg == null)
            {
                MessageBox.Show("Imagen no cargada");
                return;
            }

            imageBox1.Image = _CargaImg;
            imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.PanAndZoom;
        }

        private void rojoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DenseHistogram hist = new DenseHistogram(256, new RangeF(0, 255));
            hist.Calculate(new Image<Gray, byte>[] { _CargaImg[2] }, false, null);

            Mat m = new Mat();
            hist.CopyTo(m);

            histogramBox1.AddHistogram("Histograma Rojo", Color.Red, m, 256, new float[] { 0, 255 });
            histogramBox1.Refresh();
        }

        private void salidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
