using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace boinon {
    [ToolboxItem(true)] // Clever hack to stop defaulting to AutoSize true
    public partial class boinon : Label {

        #region vars and properties

        #region vars

        // PUBLIC
        public Color trueBackColor; // Actual BackColor Placeholder

        // PRIVATE
        private Color ac; // Active ForeColor
        private Color fcHolder; // Forecolor Placeholder

        private Color moc; // Mouse Over Color
        private Color mdc; // Mouse Down Color
        private bool aCC; // Automatic Color Change

        private Color bc; // Border Color
        private int bw; // Border Width
        private bool bas; // Border AutoSize
        private bool bs; // Boinder Style
        private bool bsHolder; // Placeholder for Boinder Style

        private bool rbmd; // Remove Border On MouseDown
        private bool rbmo; // Remove Border On MouseOver

        private bool boinEnabled; // Color Change Enabled

        #endregion

        #region Properties

        // PROPERTIES
        [Description("Color the ForeColor will change to on MouseDown")]
        public Color activeForeColor {
            get {
                return ac;
            }
            set {
                ac = value;
            }
        }

        [Description("Automatically change the BackColor of the control on MouseEnter and MouseDown")]
        [DefaultValue(true)]
        public bool automaticColorChange {
            get {
                return aCC;
            }
            set {
                aCC = value;
            }
        }

        [Description("(Only if automaticColorChange is false) Control's BackColor on MouseEnter")]
        public Color mouseOverColor {
            get {
                return moc;
            }
            set {
                moc = value;
            }
        }

        [Description("(Only if automaticColorChange is false) Control's BackColor on MouseDown")]
        public Color mouseDownColor {
            get {
                return mdc;
            }
            set {
                mdc = value;
            }
        }

        [Description("(Only works with borderStyleSpecial) Color of control's border")]
        public Color borderColor {
            get {
                return bc;
            }
            set {
                bc = value;
            }
        }

        [Description("(Only works with borderStyleSpecial) Width of control's border")]
        [DefaultValue(2)]
        public int borderWidth {
            get {
                return bw;
            }
            set {
                bw = value;
            }
        }

        [Description("(Only works with borderStyleSpecial) AutoScale control's border; corresponds with height")]
        [DefaultValue(false)]
        public bool borderAutoScale {
            get {
                return bas;
            }
            set {
                bas = value;
            }
        }

        [Description("Use this control's customizable border")]
        [DefaultValue(true)]
        public bool borderStyleSpecial {
            get {
                return bs;
            }
            set {
                bs = value;
                this.bsHolder = value;
            }
        }

        [Description("(Only works with borderStyleSpecial)")]
        [DefaultValue(true)]
        public bool removeBorderSpecialOnMouseDown {
            get {
                return rbmd;
            } set {
                rbmd = value;
            }
        }

        [Description("(Only works with borderStyleSpecial)")]
        [DefaultValue(false)]
        public bool removeBorderSpecialOnMouseOver {
            get {
                return rbmo;
            }
            set {
                rbmo = value;
            }
        }

        [Description("Toggle all color changing")]
        [DefaultValue(true)]
        public bool boinonEnabled {
            get {
                return boinEnabled;
            }
            set {
                boinEnabled = value;
                this.BackColorChanged -= boinon_BackColorChanged;
                this.ForeColorChanged -= boinon_ForeColorChanged;
                if (value == false) {
                    this.BackColorChanged += boinon_BackColorChanged;
                    this.ForeColorChanged += boinon_ForeColorChanged;
                }
                    
            }
        }

        #endregion

        #endregion

        public boinon() { // Constructor, setting defaults
            InitializeComponent();

            this.AutoSize = false;
            this.Width = 75;
            this.Height = 23;

            this.TextAlign = ContentAlignment.MiddleCenter;

            this.BackColor = Color.FromArgb(255, 140, 140, 140);
            trueBackColor = this.BackColor;

            this.activeForeColor = Color.FromArgb(255, 235, 235, 235);
            this.ForeColor = Color.FromArgb(255, 20, 20, 20);
            this.fcHolder = this.ForeColor;

            this.mouseOverColor = Color.White;
            this.mouseDownColor = Color.Black;

            this.automaticColorChange = true;

            this.borderColor = Color.FromArgb(255, 160, 160, 160);
            this.borderWidth = 2;
            this.borderAutoScale = false;
            this.borderStyleSpecial = true;
            this.removeBorderSpecialOnMouseDown = true;
            this.removeBorderSpecialOnMouseOver = false;

            this.boinEnabled = true;
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            if (bs) { // Drawing the special border
                Pen p = new Pen(bc); // borderColor Pen
                if (bas) // AutoScale Mode
                    bw = Convert.ToInt32(this.Height * 0.09); // Border width is 9% of the boinon's height
                p.Width = bw; // Setting penWidth to borderWidth
                Rectangle r = this.ClientRectangle;
                // Next, we adjust the rectangle to fit correctly
                r.Width -= bw;
                r.Height -= bw;
                r.X += (bw / 2);
                r.Y += (bw / 2);
                e.Graphics.DrawRectangle(p, r); // Rectangle (border) is drawn
            }
        }

        private Color newColor(bool brighter, int amount) { // Automatic relative color changing
            int[] i = new int[3]; // Array containing R,G, and B values
            if (brighter) { // Adding (can be negative) amount to the RGB values of the BackColor
                i[0] = trueBackColor.R + amount;
                i[1] = trueBackColor.G + amount;
                i[2] = trueBackColor.B + amount;
                for (int x = 0; x < 3; x++) {
                    if (i[x] > 255) { // Check greater than max
                        i[x] = 255; // Set to max
                    } else if (i[x] < 0) { // Check less than min
                        i[x] = 0; // Set to min
                    }
                }
            }
            return Color.FromArgb(trueBackColor.A, i[0], i[1], i[2]);
        }

        private void changeBC(bool over, int amount) {
            this.BackColorChanged -= boinon_BackColorChanged; // Stop the BackColorChanged Event Handler
            if (aCC) // Automatic color change
                this.BackColor = newColor(over, amount); // Over corresponds with newColor's Brighter bool
            else if (over) // Static Color MouseOver
                this.BackColor = moc;
            else // Static Color MouseDown
                this.BackColor = mdc;
            this.BackColorChanged += boinon_BackColorChanged; // Reset the BackColorChanged Event Handler
        }

        private void boinon_BackColorChanged(object sender, EventArgs e) {
            trueBackColor = this.BackColor; // Sets the placeholder
        }

        private void boinon_ForeColorChanged(object sender, EventArgs e) {
            fcHolder = this.ForeColor;
        }

        protected override void OnMouseEnter(EventArgs e) {
            base.OnMouseEnter(e);
            if (boinEnabled) {
                bsHolder = bs;
                fcHolder = this.ForeColor;
                if (rbmo) // Hide border
                    this.bs = false;
                changeBC(true, 20); // Lighter color by 20
            }
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
            if (boinEnabled) {
                if (rbmd) // Hide border
                    this.bs = false;
                this.ForeColorChanged -= boinon_ForeColorChanged;
                this.ForeColor = ac; // Switch to active ForeColor
                this.ForeColorChanged += boinon_ForeColorChanged;
                changeBC(false, -40); // Darker color by 40
            }
        }

        private void reset() {
            bs = bsHolder; // Reset Border
            this.ForeColorChanged -= boinon_ForeColorChanged;
            this.ForeColor = fcHolder; // Reset ForeColor
            this.ForeColorChanged += boinon_ForeColorChanged;
            this.BackColorChanged -= boinon_BackColorChanged; // Stop BackColorChanged Event
            this.BackColor = trueBackColor; // Reset BackColor
            this.BackColorChanged += boinon_BackColorChanged; // Reset BackColorChanged Event
            this.Invalidate(); // Repaint
            this.Update();
        }

        protected override void OnMouseLeave(EventArgs e) {
            base.OnMouseLeave(e);
            if (boinEnabled)
                reset();
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            if (boinEnabled)
                reset();
        }
    }
}
