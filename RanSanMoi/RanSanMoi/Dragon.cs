using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanSanMoi
{
    class Dragon
    {
        SolidBrush br;
        Rectangle[] recdragon;
        private int x, y, width, height;
        public Rectangle[] Recdragon
        {
            get
            {
                return recdragon;
            }
        }
        public Dragon()
        {
            br = new SolidBrush(Color.Blue);
            recdragon = new Rectangle[4];
            x = 20;
            y = 20;
            width = 15;
            height = 15;
            for (int i = 0; i < recdragon.Length; i++)
            {
                recdragon[i] = new Rectangle(x, y, width, height);
                x += 10;
            }
        }
        public void DrawDragon(Graphics paper)
        {
            foreach (Rectangle item in recdragon)
            {
                paper.FillEllipse(br, item);
            }
        }
        public void DrawDragonRun()
        {
            for (int i = recdragon.Length - 1; i >= 0; i--)
            {
                recdragon[i] = recdragon[i - 1];
            }
        }
        public void DragonDown()
        {
            DrawDragonRun();
            recdragon[0].Y += 15;
        }
        public void DragonUp()
        {
            DrawDragonRun();
            recdragon[0].Y -= 15;
        }
        public void DragonLeft()
        {
            DrawDragonRun();
            recdragon[0].X -= 15;
        }
        public void DragonRight()
        {
            DrawDragonRun();
            recdragon[0].X += 15;
        }
    }
}
