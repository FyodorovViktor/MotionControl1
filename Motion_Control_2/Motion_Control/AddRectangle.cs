using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motion_Control
{
    public partial class AddRectangle : Form
    {
        public AddRectangle()
        {
            InitializeComponent();
        }

        public string X1
        {
            get { return textX1.Text; }
            set { textX1.Text = value; }
        }

        public string X2
        {
            get { return textX2.Text; }
            set { textX2.Text = value; }
        }

        public string X3
        {
            get { return textX3.Text; }
            set { textX3.Text = value; }
        }

        public string X4
        {
            get { return textX4.Text; }
            set { textX4.Text = value; }
        }

        public string Y1
        {
            get { return textY1.Text; }
            set { textY1.Text = value; }
        }

        public string Y2
        {
            get { return textY2.Text; }
            set { textY2.Text = value; }
        }

        public string Y3
        {
            get { return textY3.Text; }
            set { textY3.Text = value; }
        }

        public string Y4
        {
            get { return textY4.Text; }
            set { textY4.Text = value; }
        }

        public string XVelocity
        {
            get { return velocity1.Value.ToString(); }
            set { }
        }

        public string YVelocity
        {
            get { return velocity2.Value.ToString(); }
            set { }
        }

        

        private void AddRectangle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
