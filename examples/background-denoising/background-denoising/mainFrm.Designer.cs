namespace mask_wearing
{
    partial class mainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.resLbl = new System.Windows.Forms.Label();
            this.vispShoot = new AForge.Controls.VideoSourcePlayer();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.resWin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.resWin)).BeginInit();
            this.SuspendLayout();
            // 
            // resLbl
            // 
            this.resLbl.AutoSize = true;
            this.resLbl.Font = new System.Drawing.Font("华文宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resLbl.Location = new System.Drawing.Point(12, 480);
            this.resLbl.Name = "resLbl";
            this.resLbl.Size = new System.Drawing.Size(138, 23);
            this.resLbl.TabIndex = 1;
            this.resLbl.Text = "Result: NULL";
            // 
            // vispShoot
            // 
            this.vispShoot.Location = new System.Drawing.Point(0, 0);
            this.vispShoot.Name = "vispShoot";
            this.vispShoot.Size = new System.Drawing.Size(450, 450);
            this.vispShoot.TabIndex = 2;
            this.vispShoot.VideoSource = null;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // resWin
            // 
            this.resWin.Location = new System.Drawing.Point(0, 0);
            this.resWin.Name = "resWin";
            this.resWin.Size = new System.Drawing.Size(450, 450);
            this.resWin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.resWin.TabIndex = 3;
            this.resWin.TabStop = false;
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(451, 428);
            this.Controls.Add(this.resWin);
            this.Controls.Add(this.vispShoot);
            this.Controls.Add(this.resLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "mainFrm";
            this.Text = "example 3 - Background Denoising";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainFrm_FormClosed);
            this.Load += new System.EventHandler(this.mainFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resWin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label resLbl;
        private AForge.Controls.VideoSourcePlayer vispShoot;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox resWin;
    }
}

