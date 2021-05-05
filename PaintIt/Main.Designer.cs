namespace PaintIt
{
    partial class Main
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
            this.pbxPreview = new System.Windows.Forms.PictureBox();
            this.trackBarThresh = new System.Windows.Forms.TrackBar();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblPixel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radOTSU = new System.Windows.Forms.RadioButton();
            this.radBinInv = new System.Windows.Forms.RadioButton();
            this.radBin = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThresh)).BeginInit();
            this.groupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxPreview
            // 
            this.pbxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxPreview.Location = new System.Drawing.Point(152, 13);
            this.pbxPreview.Name = "pbxPreview";
            this.pbxPreview.Size = new System.Drawing.Size(400, 400);
            this.pbxPreview.TabIndex = 0;
            this.pbxPreview.TabStop = false;
            // 
            // trackBarThresh
            // 
            this.trackBarThresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarThresh.AutoSize = false;
            this.trackBarThresh.Location = new System.Drawing.Point(152, 419);
            this.trackBarThresh.Maximum = 1;
            this.trackBarThresh.Name = "trackBarThresh";
            this.trackBarThresh.Size = new System.Drawing.Size(400, 34);
            this.trackBarThresh.TabIndex = 1;
            this.trackBarThresh.TickFrequency = 5;
            this.trackBarThresh.Scroll += new System.EventHandler(this.trackBarThresh_Scroll);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnDraw);
            this.groupBox.Controls.Add(this.btnBrowse);
            this.groupBox.Location = new System.Drawing.Point(12, 13);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(128, 107);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Functions";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(14, 61);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(100, 25);
            this.btnDraw.TabIndex = 5;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(14, 30);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 25);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPixel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 469);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(564, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblPixel
            // 
            this.lblPixel.Margin = new System.Windows.Forms.Padding(5, 3, 5, 2);
            this.lblPixel.Name = "lblPixel";
            this.lblPixel.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radOTSU);
            this.groupBox1.Controls.Add(this.radBinInv);
            this.groupBox1.Controls.Add(this.radBin);
            this.groupBox1.Location = new System.Drawing.Point(12, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 105);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Threshold";
            // 
            // radOTSU
            // 
            this.radOTSU.AutoSize = true;
            this.radOTSU.Location = new System.Drawing.Point(14, 76);
            this.radOTSU.Name = "radOTSU";
            this.radOTSU.Size = new System.Drawing.Size(55, 17);
            this.radOTSU.TabIndex = 10;
            this.radOTSU.Text = "OTSU";
            this.radOTSU.UseVisualStyleBackColor = true;
            this.radOTSU.CheckedChanged += new System.EventHandler(this.radThresh_CheckedChanged);
            // 
            // radBinInv
            // 
            this.radBinInv.AutoSize = true;
            this.radBinInv.Location = new System.Drawing.Point(15, 53);
            this.radBinInv.Name = "radBinInv";
            this.radBinInv.Size = new System.Drawing.Size(92, 17);
            this.radBinInv.TabIndex = 6;
            this.radBinInv.Text = "Binary Inverse";
            this.radBinInv.UseVisualStyleBackColor = true;
            this.radBinInv.CheckedChanged += new System.EventHandler(this.radThresh_CheckedChanged);
            // 
            // radBin
            // 
            this.radBin.AutoSize = true;
            this.radBin.Checked = true;
            this.radBin.Location = new System.Drawing.Point(15, 30);
            this.radBin.Name = "radBin";
            this.radBin.Size = new System.Drawing.Size(54, 17);
            this.radBin.TabIndex = 5;
            this.radBin.TabStop = true;
            this.radBin.Text = "Binary";
            this.radBin.UseVisualStyleBackColor = true;
            this.radBin.CheckedChanged += new System.EventHandler(this.radThresh_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 491);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.trackBarThresh);
            this.Controls.Add(this.pbxPreview);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Paint-it";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThresh)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxPreview;
        private System.Windows.Forms.TrackBar trackBarThresh;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblPixel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radBinInv;
        private System.Windows.Forms.RadioButton radBin;
        private System.Windows.Forms.RadioButton radOTSU;
    }
}

