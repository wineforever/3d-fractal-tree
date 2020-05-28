namespace _3d_fractal_tree
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
            this.renderWin = new Wineforever.Coordinate.client();
            this.Tips = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // renderWin
            // 
            this.renderWin._BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.renderWin._KeepTrack = false;
            this.renderWin._Relative = true;
            this.renderWin._RenderMod = "3d";
            this.renderWin._ShowCoordinate = true;
            this.renderWin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.renderWin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderWin.Location = new System.Drawing.Point(0, 0);
            this.renderWin.Name = "renderWin";
            this.renderWin.Size = new System.Drawing.Size(662, 509);
            this.renderWin.TabIndex = 0;
            // 
            // Tips
            // 
            this.Tips.AutoSize = true;
            this.Tips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Tips.Location = new System.Drawing.Point(13, 485);
            this.Tips.Name = "Tips";
            this.Tips.Size = new System.Drawing.Size(401, 12);
            this.Tips.TabIndex = 1;
            this.Tips.Text = "提示:按住鼠标左键拖动视角,按住鼠标右键拖动坐标系,鼠标滚轮调节视距.";
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 509);
            this.Controls.Add(this.Tips);
            this.Controls.Add(this.renderWin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "mainFrm";
            this.Text = "example 1 - 3D Fractal Tree";
            this.Load += new System.EventHandler(this.mainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Wineforever.Coordinate.client renderWin;
        private System.Windows.Forms.Label Tips;
    }
}

