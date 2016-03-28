using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Globalization;

namespace BoinTime {
    public partial class Form1 : Form {

        #region Vars

        bool pinned;

        #region user32 Stuff

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        #endregion

        #region Constructor & Form Events

        public Form1() {
            InitializeComponent();
            time();

            pinned = Properties.Settings.Default.pinned;
            btnPin.Text = (pinned) ? "Move" : "Pin";
            this.Location = Properties.Settings.Default.location;
        }

        private void pnlTopBar_MouseDown(object sender, MouseEventArgs e) {
            if (!pinned) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnPin_Click(object sender, EventArgs e) {
            pinned = !pinned;
            Properties.Settings.Default.pinned = pinned;
            btnPin.Text = (btnPin.Text == "Pin") ? "Move" : "Pin";
        }

        private void btnClose_Click(object sender, EventArgs e) {
            btnReallyClose.Visible = !btnReallyClose.Visible;
            btnClose.Text = (btnClose.Text == "Close") ? "Cancel" : "Close";
        }

        private void btnReallyClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            Properties.Settings.Default.location = this.Location;
            Properties.Settings.Default.Save();
        }

        private void Form1_Resize(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
        }

        private void Form1_MouseEnter(object sender, EventArgs e) {
            this.Opacity = 1.0;
        }

        private void Form1_MouseLeave(object sender, EventArgs e) {
            this.Opacity = 0.7;
        }

        #endregion

        #region Timer Stuff

        private void time() {
            DateTime now = DateTime.Now;

            lblMain.Text = now.ToString("h:mm tt", CultureInfo.InvariantCulture);
            lblSec.Text = now.Second.ToString().PadLeft(2, '0');
        }

        private void tmrMain_Tick(object sender, EventArgs e) {
            time();
        }

        #endregion
    }
}
