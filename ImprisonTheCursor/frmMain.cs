using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImprisonTheCursor
{
    public partial class frmMain : Form
    {
        #region Cursor Show Hide
        [DllImport("user32.dll")]
        static extern bool SetSystemCursor(IntPtr hcur, uint id);

        [DllImport("user32.dll")]
        static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 uiAction, UInt32
        uiParam, String pvParam, UInt32 fWinIni);

        [DllImport("user32.dll")]
        public static extern IntPtr CopyIcon(IntPtr pcur);

        private static uint CROSS = 32515;
        private static uint NORMAL = 32512;
        private static uint IBEAM = 32513;
        #endregion

        Form frmArea = null;

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);
        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int ACTIVATOR_HOTKEY_ID = 1;
        const int SHOWAREA_HOTKEY_ID = 2;
        const int SHUTDOWN_HOTKEY_ID = 3;

        bool PrisonActivated = false;
        bool ShowAreaActivated = false;

        Point Center = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);

        int Radius
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(txtRadius.Text.Trim()))
                {
                    int ret = 125;

                    Int32.TryParse(txtRadius.Text, out ret);

                    return ret;
                }
                else
                {
                    return 125;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == ACTIVATOR_HOTKEY_ID)
            {
                PrisonActivated = !PrisonActivated;
            }
            else if (m.Msg == 0x0312 && m.WParam.ToInt32() == SHOWAREA_HOTKEY_ID)
            {
                this.ShowAreaActivated = !this.ShowAreaActivated;
                ShowArea(this.ShowAreaActivated);
            }
            else if (m.Msg == 0x0312 && m.WParam.ToInt32() == SHUTDOWN_HOTKEY_ID)
            {
                Application.Exit();
            }

            base.WndProc(ref m);
        }

        public frmMain()
        {
            InitializeComponent();

            timMouseTracker.Start();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, ACTIVATOR_HOTKEY_ID, 6, 0);

            RegisterHotKey(this.Handle, SHOWAREA_HOTKEY_ID, 7, 0);

            RegisterHotKey(this.Handle, SHUTDOWN_HOTKEY_ID, 6, (int)Keys.F4);

            SetSystemCursor(CopyIcon(LoadCursor(IntPtr.Zero, (int)CROSS)), NORMAL);
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            uint SPI_SETCURSORS = 0x0057;
            SystemParametersInfo(SPI_SETCURSORS, 0, null, 0);
        }

        private void ShowArea(bool pShow = true)
        {
            if (frmArea == null || frmArea.Width != Convert.ToInt32(this.Radius * (140D / 100D)))
            {
                if (frmArea != null)
                {
                    frmArea.Dispose();
                }

                frmArea = new Form();
                frmArea.Width = Convert.ToInt32(this.Radius * (140D / 100D));
                frmArea.Height = frmArea.Width;
                frmArea.BackColor = Color.White;
                frmArea.FormBorderStyle = FormBorderStyle.None;
                frmArea.TopMost = true;
                frmArea.ShowInTaskbar = false;
                frmArea.Opacity = 0.2;

                frmArea.Show();

                frmArea.Top = this.Center.Y - frmArea.Height / 2;
                frmArea.Left = this.Center.X - frmArea.Width / 2;

                int round = Convert.ToInt32(this.Radius * (frmArea.Width / 100D));

                frmArea.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, frmArea.Width, frmArea.Height, round, round));

                frmArea.Refresh();
            }
            else
            {
                frmArea.Show();
            }

            frmArea.Visible = pShow;
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        bool IsInCircle(Point point)
        {
            return Math.Sqrt(Math.Pow(point.X - (Screen.PrimaryScreen.WorkingArea.Width / 2), 2) + Math.Pow(point.Y - (Screen.PrimaryScreen.WorkingArea.Height / 2), 2)) <= this.Radius;
        }

        private void timMouseTracker_Tick(object sender, EventArgs e)
        {
            if (this.PrisonActivated)
            {
                if (!IsInCircle(Cursor.Position))
                {
                    Point newPoint = new Point((this.Center.X + Cursor.Position.X) / 2, (this.Center.Y + Cursor.Position.Y) / 2);

                    Cursor.Position = newPoint;
                }
            }
            else
            {
                //Cursor.Show();
            }
        }
    }
}
