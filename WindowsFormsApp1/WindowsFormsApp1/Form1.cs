using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            float Summe = float.Parse(maskedTextBox1.Text) + float.Parse(maskedTextBox2.Text);
            maskedTextBox3.Text = Summe.ToString();


        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            float Summe = float.Parse(maskedTextBox1.Text) - float.Parse(maskedTextBox2.Text);
            maskedTextBox3.Text = Summe.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float Summe = float.Parse(maskedTextBox1.Text) * float.Parse(maskedTextBox2.Text);
            maskedTextBox3.Text = Summe.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float Summe = float.Parse(maskedTextBox1.Text) / float.Parse(maskedTextBox2.Text);
            maskedTextBox3.Text = Summe.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private bool _Moving = false;
        private Point _Offset;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _Moving = true;
            _Offset = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Moving)
            {
                Point newlocation = this.Location;
                newlocation.X += e.X - _Offset.X;
                newlocation.Y += e.Y - _Offset.Y;
                this.Location = newlocation;
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_Moving)
            {
                _Moving = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
