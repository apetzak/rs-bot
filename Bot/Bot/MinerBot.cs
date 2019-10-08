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
namespace Bot
{
    public class MinerBot
    {
        // import this to find mouse cursor position
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        //

        // used to simulate clicks and key presses
        InputSimulator inputSimulator = new InputSimulator();

        // player states
        public bool active = true;
        public int phase = 0; // counter for current phase (including movements)
        public int movementPhase = 0; // counter for movement phase
        public int stillCount = 0; // amount of time player stands still
        public int inventoryCount = 0;
        public bool miningUp = false;
        public bool mining = true;

        // compass coords
        public int X;
        public int Y;

        // iron mine to west varrock bank and back (route)
        private List<int> xDestination = new List<int>() { 100, 74, 52, 26, 26, 146, 126, 108, 90, 64 };
        private List<int> yDestination = new List<int>() { -10, -10, -10, 50, 95, 38, 106, 120, 136, 132 };

        // scalers for mouse movements on 1920x1080 resolution
        private decimal xScale = Convert.ToDecimal(65535) / Convert.ToDecimal(1919);
        private decimal yScale = Convert.ToDecimal(65535) / Convert.ToDecimal(1079);

        // locations of inventory slots
        private Point firstSlot;
        private Point lastSlot;
        private Point nextSlot;

        private Point playerLocation; // player location on minimap

        private string mapColors = "";

        // original destinations: 106 78 58 30 28 152 129 116 93 64
        // (deprecated)           -10 -10 -10 50 103 30 110 122 142 136

        public MinerBot(int xmin, int xmax, int ymin, int ymax)
        {
            Point cc = GetCompassCoords(xmin, xmax, ymin, ymax);
            X = cc.X;
            Y = cc.Y;
            firstSlot = new Point(X + 16, Y + 208);
            lastSlot = new Point(X + 145, Y + 424);
            playerLocation = new Point(X + 81, Y + 64);
            GetInventoryCount();

            for (int i = 0; i < 10; i++)
            {
                xDestination[i] = X + xDestination[i];
                yDestination[i] = Y + yDestination[i];
            }
        }

        public Point GetCompassCoords(int xmin, int xmax, int ymin, int ymax)
        {
            // find location of compass center in given range
            // all calculations are relative to this point
            for (int i = xmin; i < xmax; i++)
                for (int j = ymin; j < ymax; j++)
                    if (GetColorAt(new Point(i, j)).Name == "fff6f5f1") // center of compass
                        return new Point(i, j);
            return new Point();
        }

        public void GetInventoryCount()
        {
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    int x = firstSlot.X + (i * 42);
                    int y = firstSlot.Y + (j * 36);
                    if (GetColorAt(new Point(x, y)).Name.StartsWith("ff4"))
                    {
                        inventoryCount = j * 4 + i;
                        nextSlot = new Point(x, y);
                        return;
                    }
                }
            }
        }

        public void Update()
        {
            if (!active)
                return;

            if (mining)
                MineOres();
            else
                UpdatePhase();
        }

        public void MineOres()
        {
            if (InventoryIsFull())
                return;

            if (!GetColorAt(nextSlot).Name.StartsWith("ff4"))
            {
                IncrementInventory();

                if (inventoryCount == 28)
                {
                    mining = false;
                    return;
                }
                miningUp = !miningUp;
            }

            CheckFenceLocation(); // check if player is not at mining location

            if (miningUp)
                ClickAt(X - 347, Y + 136);
            else // miningLeft
                ClickAt(X - 430, Y + 225);

            #region try checking for color of ores
            //if (IsRed(GetColorAt(OreBelow)))
            //{
            //    Pickup();
            //    return;
            //}

            //if (!MiningUp && !MiningLeft)
            //{
            //    if (IsRed(GetColorAt(OreUp)))
            //        MineUp();
            //    else if (IsRed(GetColorAt(OreLeft)))
            //        MineLeft();
            //}

            //if (MiningUp)
            //{
            //    if (IsGray(GetColorAt(OreUp)))
            //        MiningUp = false;
            //    else
            //        MineUp();
            //}
            //else if (MiningLeft)
            //{
            //    if (IsGray(GetColorAt(OreLeft)))
            //        MiningLeft = false;
            //    else
            //        MineLeft();
            //}
            #endregion
        }

        public bool InventoryIsFull()
        {
            if (!GetColorAt(lastSlot).Name.StartsWith("ff4"))
            {
                inventoryCount = 28;
                mining = false;
                return true;
            }
            return false;
        }

        public void IncrementInventory()
        {
            inventoryCount++;
            double z = Convert.ToDouble(inventoryCount) / 4;
            if (Math.Floor(z) != z)
            {
                nextSlot.X += 42; // horizontal diff between inv slots
            }
            else
            {
                nextSlot.Y += 36; // vertical diff between inv slots
                nextSlot.X -= (42 * 3);
            }
        }

        public void UpdatePhase()
        {
            if (phase == 0 && GetColorAt(lastSlot).Name.StartsWith("ff4"))
            {
                mining = true;
                return;
            }

            IncrementStillCount();

            if (stillCount > 2) // do next phase if standing still
            {
                if (phase == 5)
                    OpenBank();
                else if (phase == 6)
                    Deposit();
                else if (phase == 7)
                    TakePickaxe();
                else if (phase == 13)
                {
                    mining = true;
                    phase = -1;
                    movementPhase = 0;
                }
                else
                {
                    Move(movementPhase);
                    movementPhase++;
                }
                phase++;
                stillCount = 0;
            }
        }

        public void IncrementStillCount()
        {
            // save color of random points on the map
            // to determine if player is standing still
            string prev = mapColors;
            mapColors = GetColorAt(new Point(X + 60, Y)).Name +
                GetColorAt(new Point(X + 70, Y + 40)).Name +
                GetColorAt(new Point(X + 60, Y + 80)).Name +
                GetColorAt(new Point(X + 30, Y + 50)).Name +
                GetColorAt(new Point(X + 50, Y + 50)).Name +
                GetColorAt(new Point(X + 50, Y + 10)).Name;
            if (prev == mapColors)
                stillCount++;
            else
                stillCount = 0;
        }

        public void ClickAt(int x, int y)
        {
            inputSimulator.Mouse.MoveMouseTo(Convert.ToDouble(x * xScale), Convert.ToDouble(y * yScale));
            inputSimulator.Mouse.LeftButtonClick();
        }

        public void Move(int i)
        {
            ClickAt(xDestination[i], yDestination[i]);
        }

        public bool Pickup()
        {
            // to do: pick up items below player

            //InputSimulator.Mouse.MoveMouseTo(Convert.ToDouble((X - 310) * xScale), Convert.ToDouble((Y + 240) * yScale));
            //Point cursor = new Point();
            //GetCursorPos(ref cursor);

            //Color c = GetColorAt(new Point(X - 515, Y - 5));
            return false;
        }

        public void TurnOnRun()
        {
            // if not yellow click the run button
            if (GetColorAt(new Point(X + 6, Y + 107)).Name != "ffecda67")
                ClickAt(X + 6, Y + 107);
        }

        public void OpenBank()
        {
            TurnOnRun();
            ClickAt(X - 300, Y + 220);
        }

        public void Deposit()
        {
            if (!BankIsOpen()) // sometimes the bank doesn't open when you click
                return;

            ClickAt(X - 117, Y + 293);
        }

        public void TakePickaxe()
        {
            StopIfInventoryIsFull();
            ClickAt(X - 475, Y + 75);
            inventoryCount = 1;
            nextSlot = new Point(firstSlot.X + 42, firstSlot.Y);
        }

        public bool BankIsOpen()
        {
            if (GetColorAt(new Point(X - 252, Y + 6)).Name == "ffff981f")
                return true;
            phase = 4; // keep clicking bank until it opens
            return false;
        }

        public void StopIfInventoryIsFull()
        {
            if (!GetColorAt(lastSlot).Name.StartsWith("ff4"))
                // something went wrong
                active = false;
        }

        public void CheckFenceLocation()
        {
            if (GetColorAt(new Point(X + 100, Y + 75)).Name == "ffeeeeee")
                return;
            // something went wrong
            active = false;
            WalkToMine();
        }

        public void WalkToMine()
        {
            // find the mining symbol on minimap and put bot back in position
            // in case of random events dragging the bot away
            for (int i = 75; i < 100; i++)
            {
                for (int j = 65; j < 85; j++)
                {
                    if (GetColorAt(new Point(X + i, Y + j)).Name == "ff767676")
                    {
                        ClickAt(X + i - 4, Y + j - 8);
                        active = true;
                        return;
                    }
                }
            }
        }

        // get color of pixel at a certain point
        static Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        public static Color GetColorAt(Point location)
        {
            using (Graphics gdest = Graphics.FromImage(screenPixel))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }
            return screenPixel.GetPixel(0, 0);
        }

        //private bool IsRed(Color c)
        //{
        //    if (c.R > 53 && c.R < 71 && c.G > 25 && c.G < 37 && c.B > 15 && c.B < 27)
        //        return true;
        //    return false;
        //}

        //private bool IsGray(Color c)
        //{
        //    if (c.R > 58 && c.R < 73 && c.G > 47 && c.G < 65 && c.B > 45 && c.B < 66)
        //        return true;
        //    return false;
        //}
    }
}
