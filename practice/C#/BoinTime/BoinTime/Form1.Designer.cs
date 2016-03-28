namespace BoinTime {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.btnReallyClose = new boinon.boinon();
            this.btnClose = new boinon.boinon();
            this.btnPin = new boinon.boinon();
            this.lblSec = new BoinTime.LabelAA();
            this.lblMain = new BoinTime.LabelAA();
            this.pnlTopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrMain
            // 
            this.tmrMain.Enabled = true;
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnlTopBar.Controls.Add(this.btnReallyClose);
            this.pnlTopBar.Controls.Add(this.btnClose);
            this.pnlTopBar.Controls.Add(this.btnPin);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(195, 25);
            this.pnlTopBar.TabIndex = 4;
            this.pnlTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopBar_MouseDown);
            this.pnlTopBar.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.pnlTopBar.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // btnReallyClose
            // 
            this.btnReallyClose.activeForeColor = System.Drawing.Color.White;
            this.btnReallyClose.automaticColorChange = false;
            this.btnReallyClose.BackColor = System.Drawing.Color.Transparent;
            this.btnReallyClose.borderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnReallyClose.borderStyleSpecial = false;
            this.btnReallyClose.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReallyClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnReallyClose.Location = new System.Drawing.Point(121, 1);
            this.btnReallyClose.mouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnReallyClose.mouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnReallyClose.Name = "btnReallyClose";
            this.btnReallyClose.Size = new System.Drawing.Size(51, 23);
            this.btnReallyClose.TabIndex = 2;
            this.btnReallyClose.Text = "Close";
            this.btnReallyClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReallyClose.Visible = false;
            this.btnReallyClose.Click += new System.EventHandler(this.btnReallyClose_Click);
            this.btnReallyClose.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btnReallyClose.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.activeForeColor = System.Drawing.Color.White;
            this.btnClose.automaticColorChange = false;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.borderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnClose.borderStyleSpecial = false;
            this.btnClose.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnClose.Location = new System.Drawing.Point(64, 1);
            this.btnClose.mouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnClose.mouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(51, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // btnPin
            // 
            this.btnPin.activeForeColor = System.Drawing.Color.White;
            this.btnPin.automaticColorChange = false;
            this.btnPin.BackColor = System.Drawing.Color.Transparent;
            this.btnPin.borderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnPin.borderStyleSpecial = false;
            this.btnPin.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnPin.Location = new System.Drawing.Point(12, 1);
            this.btnPin.mouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPin.mouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnPin.Name = "btnPin";
            this.btnPin.Size = new System.Drawing.Size(46, 23);
            this.btnPin.TabIndex = 0;
            this.btnPin.Text = "Pin";
            this.btnPin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPin.Click += new System.EventHandler(this.btnPin_Click);
            this.btnPin.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btnPin.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblSec.Location = new System.Drawing.Point(149, 35);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(47, 34);
            this.lblSec.TabIndex = 3;
            this.lblSec.Text = "43";
            this.lblSec.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.lblSec.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // lblMain
            // 
            this.lblMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMain.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblMain.Location = new System.Drawing.Point(0, 30);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(154, 55);
            this.lblMain.TabIndex = 1;
            this.lblMain.Text = "11:35";
            this.lblMain.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblMain.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.lblMain.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(195, 96);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.lblSec);
            this.Controls.Add(this.lblMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.7D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BoinTime";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.pnlTopBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelAA lblMain;
        private LabelAA lblSec;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Panel pnlTopBar;
        private boinon.boinon btnClose;
        private boinon.boinon btnPin;
        private boinon.boinon btnReallyClose;

    }
}

