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




        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
                if (Properties.Settings.Default.F1Size.Width == 0 || Properties.Settings.Default.F1Size.Height == 0)
                {
                    // first start
                    // optional: add default values
                }
                else
                {
                    this.WindowState = Properties.Settings.Default.F1State;

                    // we don't want a minimized window at startup
                    if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;

                    this.Location = Properties.Settings.Default.F1Location;
                    this.Size = Properties.Settings.Default.F1Size;
                }
            
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


        private void Maximise_Click(object sender, EventArgs e)
        {

            if (this.WindowState==FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                this.MinimumSize = this.Size;
                this.MaximumSize = this.Size;
            }
            else
            {
                this.MinimumSize = Properties.Settings.Default.F1Size;
                this.Location = Properties.Settings.Default.F1Location;
                this.WindowState = FormWindowState.Normal;
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.F1State = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                // save location and size if the state is normal
                Properties.Settings.Default.F1Location = this.Location;
                Properties.Settings.Default.F1Size = this.Size;
            }
            else
            {
                // save the RestoreBounds if the form is minimized or maximized!
                Properties.Settings.Default.F1Location = this.RestoreBounds.Location;
                Properties.Settings.Default.F1Size = this.RestoreBounds.Size;
            }

            // don't forget to save the settings
            Properties.Settings.Default.Save();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            
        }

        private Control activeControl;
        private Point previousLocation;

        private void button1_Click(object sender, EventArgs e)
        {
            var textbox = new TextBox();
            textbox.Location = new Point(panel2.Location.X + (panel2.Width - textbox.Width) / 2,panel2.Location.Y + (panel2.Height - textbox.Height) / 2);
            textbox.MouseDown += new MouseEventHandler(textbox_MouseDown);
            textbox.MouseMove += new MouseEventHandler(textbox_MouseMove);
            textbox.MouseUp += new MouseEventHandler(textbox_MouseUp);
            textbox.AppendText("Test");
            textbox.BackColor = Color.Beige;
            textbox.BringToFront();
            //textbox.Anchor = (AnchorStyles.Left | AnchorStyles.Top);

            panel2.Controls.Add(textbox);
        }

        void textbox_MouseDown(object sender, MouseEventArgs e)
        {
            activeControl = sender as Control;
            previousLocation = e.Location;
            Cursor = Cursors.Hand;
        }

        void textbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (activeControl == null || activeControl != sender)
                return;

            var location = activeControl.Location;
            location.Offset(e.Location.X - previousLocation.X, e.Location.Y - previousLocation.Y);
            activeControl.Location = location;
        }

        void textbox_MouseUp(object sender, MouseEventArgs e)
        {
            activeControl = null;
            Cursor = Cursors.Default;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
