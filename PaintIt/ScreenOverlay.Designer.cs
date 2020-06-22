namespace PaintIt
{
    partial class ScreenOverlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbxOverlay = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxOverlay)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxOverlay
            // 
            this.pbxOverlay.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbxOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxOverlay.Location = new System.Drawing.Point(0, 0);
            this.pbxOverlay.Name = "pbxOverlay";
            this.pbxOverlay.Size = new System.Drawing.Size(284, 261);
            this.pbxOverlay.TabIndex = 0;
            this.pbxOverlay.TabStop = false;
            this.pbxOverlay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxOverlay_Paint);
            this.pbxOverlay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxOverlay_MouseDown);
            this.pbxOverlay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxOverlay_MouseMove);
            this.pbxOverlay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxOverlay_MouseUp);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 25;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ScreenOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pbxOverlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenOverlay";
            this.Text = "ScreenOverlay";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScreenOverlay_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxOverlay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxOverlay;
        private System.Windows.Forms.Timer timer;
    }
}