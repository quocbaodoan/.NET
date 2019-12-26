using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RanSanMoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Dragon dragon = new Dragon();
        Graphics g;
        bool left = false, right = false, up = false, down = false;

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (left == true)
            {
                dragon.DragonLeft();
            }
            if(right == true)
            {
                dragon.DragonRight();
            }
            if (up == true)
            {
                dragon.DragonUp();
            }
            if (down == true)
            {
                dragon.DragonDown();
            }
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            dragon.DrawDragon(g);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left && right == false)
            {
                left = true;
                right = false;
                up = false;
                down = false;
            }
            if (e.KeyData == Keys.Right && left == false)
            {
                left = false;
                right = true;
                up = false;
                down = false;
            }
            if (e.KeyData == Keys.Up && down == false)
            {
                left = false;
                right = false;
                up = true;
                down = false;
            }
            if (e.KeyData == Keys.Down && up == false)
            {
                left = false;
                right = false;
                up = false;
                down = true;
            }
        }
    }
}
