using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using System.Timers;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace Bot
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        int count = 0;
        List<MinerBot> bots = new List<MinerBot>();
        List<int> times = new List<int>();
        InputSimulator InputSimulator = new InputSimulator();
        public bool active = false;
        public Point center;
        public int time;
        public int timeCount = 100;

        public frmMain()
        {
            InitializeComponent();
            t.Interval = 1;
            t.Tick += T_Tick;
            t.Start();
            // change the range below to find your compass
            bots.Add(new MinerBot(936, 1000, 50, 54)); // tl
            //bots.Add(new Bot(1700, 1750, 50, 70)); //tr
            //bots.Add(new Bot(940, 1000, 550, 575)); //bl
            //bots.Add(new Bot(1700, 1750, 550, 575)); //br

            center = new Point(bots[0].X + 210, bots[0].Y + 455);
        }

        private void UpdateLabels()
        {
            Point cursor = new Point();
            GetCursorPos(ref cursor);
            var c = MinerBot.GetColorAt(cursor);

            btnColor.BackColor = c;
            lblColor.Text = c.Name;
            lblCoords.Text = cursor.X + ", " + cursor.Y;
            lblRgb.Text = String.Format("{0}, {1}, {2}, {3}", c.R, c.G, c.B, c.A);

            int i = 0;
            //if (cursor.X < center.X && cursor.Y < center.Y)
            //    i = 0;
            //else if (cursor.X > center.X && cursor.Y < center.Y)
            //    i = 1;
            //else if (cursor.X < center.X && cursor.Y > center.Y)
            //    i = 2;
            //else if (cursor.X > center.X && cursor.Y > center.Y)
            //    i = 3;
            lblDist.Text = (cursor.X - bots[i].X) + ", " + (cursor.Y - bots[i].Y);

            //if (!active)
            //    return;

            timeCount--;
            if (timeCount == 0)
            {
                //lblTime.Text = (++time).ToString();
                lbl1.Text = SetBotInfo(0);
                //lbl2.Text = SetBotInfo(1);
                //lbl3.Text = SetBotInfo(2);
                //lbl4.Text = SetBotInfo(3);
                timeCount = 100;
            }
        }

        private string SetBotInfo(int i)
        {
            MinerBot b = bots[i];
            return String.Format("Bot{0} - {1} / {2} / {3} / {4}",
                (i + 1), b.active, b.inventoryCount, b.phase, b.mining);
        }

        private void T_Tick(object sender, EventArgs e)
        {
            UpdateLabels();

            if (!active)
                return;

            #region junk
            //if (!bots[0].Walking)
            //{
            //    //Point up = new Point(bots[0].CC.X - 359, bots[0].CC.Y + 180);
            //    //Point left = new Point(bots[0].CC.X - 449, bots[0].CC.Y + 212);

            //    if (!bots[0].MiningUp && !bots[0].MiningLeft)
            //    {
            //        if (IsRed(GetColorAt(bots[0].OreUp)))
            //            bots[0].MineUp();
            //        else if (IsRed(GetColorAt(bots[0].OreLeft)))
            //            bots[0].MineLeft();
            //    }

            //    if (count == 10)
            //    {
            //        if (bots[0].MiningUp)
            //        {
            //            if (IsGray(GetColorAt(bots[0].OreUp)))
            //                bots[0].MiningUp = false;
            //            else
            //                bots[0].MineUp();
            //        }
            //        else if (bots[0].MiningLeft)
            //        {
            //            if (IsGray(GetColorAt(bots[0].OreLeft)))
            //                bots[0].MiningLeft = false;
            //            else
            //                bots[0].MineLeft();
            //        }
            //        count = 0;
            //    }

            //    bool invFull = GetColorAt(new Point(bots[0].CC.X + 142, bots[0].CC.Y + 422)).Name == "ff4b423a" ? false : true;
            //    if (invFull)
            //    {
            //        bots[0].Walking = true;
            //        bots[0].MiningUp = bots[0].MiningLeft = false;
            //        count = 0;
            //        return;
            //    }
            //}
            //else if (bots[0].Walking)
            //{
            //    if (count == 0) bots[0].Move(0);
            //    else if (count == 470) bots[0].Move(1);
            //    else if (count == 910) bots[0].Move(2);
            //    else if (count == 1350) bots[0].Move(3);
            //    else if (count == 1730) bots[0].Move(4);
            //    else if (count == 2300) bots[0].ToggleRun();
            //    else if (count == 2360 || count == 2380) bots[0].OpenBank();
            //    else if (count == 2460) bots[0].Deposit();
            //    else if (count == 2560) bots[0].Move(5);
            //    else if (count == 3480) bots[0].Move(6);
            //    else if (count == 4150) bots[0].Move(7);
            //    else if (count == 4880) bots[0].Move(8);
            //    else if (count == 5680) bots[0].Move(9);
            //    else if (count == 6800) { bots[0].ToggleRun(); bots[0].Walking = false; }
            //}
            #endregion

            // update a bot every 5 ticks

            if (count == 0)
                bots[0].Update();
            //else if (count == 5)
            //    bots[1].Update();
            //else if (count == 10)
            //    bots[2].Update();
            //else if (count == 15)
            //    bots[3].Update();   
            else if (count == 20)
                count = -1;

            count++;
            #region copper

            // used this to lvl the bots up to 15 mining

            //if (count == 1)
            //{
            //    InputSimulator.Mouse.MoveMouseTo(500 * (65535 / 1919), 800 * (65535 / 1079));
            //    InputSimulator.Mouse.LeftButtonClick();
            //}
            //else if (count == 50)
            //{
            //    InputSimulator.Mouse.MoveMouseTo(500 * (65535 / 1919), 275 * (65535 / 1079));
            //    InputSimulator.Mouse.LeftButtonClick();
            //}
            //else if (count == 100)
            //{
            //    InputSimulator.Mouse.MoveMouseTo(1250 * (65535 / 1919), 275 * (65535 / 1079));
            //    InputSimulator.Mouse.LeftButtonClick();
            //}
            //else if (count == 150)
            //{
            //    InputSimulator.Mouse.MoveMouseTo(1250 * (65535 / 1919), 800 * (65535 / 1079));
            //    InputSimulator.Mouse.LeftButtonClick();
            //}
            //else if (count == 200)
            //{
            //    count = 0;
            //}
            #endregion
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            active = !active;
        }
    }
}
