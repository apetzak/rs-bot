namespace Bot
{
    partial class frmMain
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
            this.lblCoords = new System.Windows.Forms.Label();
            this.lblRgb = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblDist = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCoords
            // 
            this.lblCoords.AutoSize = true;
            this.lblCoords.BackColor = System.Drawing.SystemColors.Window;
            this.lblCoords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCoords.Location = new System.Drawing.Point(12, 32);
            this.lblCoords.MinimumSize = new System.Drawing.Size(110, 20);
            this.lblCoords.Name = "lblCoords";
            this.lblCoords.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblCoords.Size = new System.Drawing.Size(110, 20);
            this.lblCoords.TabIndex = 2;
            this.lblCoords.Text = "0, 0";
            // 
            // lblRgb
            // 
            this.lblRgb.AutoSize = true;
            this.lblRgb.BackColor = System.Drawing.SystemColors.Window;
            this.lblRgb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRgb.Location = new System.Drawing.Point(12, 52);
            this.lblRgb.MinimumSize = new System.Drawing.Size(110, 20);
            this.lblRgb.Name = "lblRgb";
            this.lblRgb.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblRgb.Size = new System.Drawing.Size(110, 20);
            this.lblRgb.TabIndex = 3;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.BackColor = System.Drawing.SystemColors.Window;
            this.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor.Location = new System.Drawing.Point(12, 72);
            this.lblColor.MinimumSize = new System.Drawing.Size(110, 20);
            this.lblColor.Name = "lblColor";
            this.lblColor.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.lblColor.Size = new System.Drawing.Size(110, 20);
            this.lblColor.TabIndex = 4;
            this.lblColor.Text = "Black";
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Location = new System.Drawing.Point(132, 122);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(110, 23);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 122);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(110, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblDist
            // 
            this.lblDist.AutoSize = true;
            this.lblDist.BackColor = System.Drawing.SystemColors.Window;
            this.lblDist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDist.Location = new System.Drawing.Point(12, 12);
            this.lblDist.MinimumSize = new System.Drawing.Size(110, 20);
            this.lblDist.Name = "lblDist";
            this.lblDist.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblDist.Size = new System.Drawing.Size(110, 20);
            this.lblDist.TabIndex = 7;
            this.lblDist.Text = "0, 0";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(13, 174);
            this.lbl1.MinimumSize = new System.Drawing.Size(230, 20);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(230, 20);
            this.lbl1.TabIndex = 8;
            this.lbl1.Text = "Bot1";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(13, 194);
            this.lbl2.MinimumSize = new System.Drawing.Size(230, 20);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(230, 20);
            this.lbl2.TabIndex = 9;
            this.lbl2.Text = "Bot2";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(13, 214);
            this.lbl3.MinimumSize = new System.Drawing.Size(230, 20);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(230, 20);
            this.lbl3.TabIndex = 10;
            this.lbl3.Text = "Bot3";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(13, 234);
            this.lbl4.MinimumSize = new System.Drawing.Size(230, 20);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(230, 20);
            this.lbl4.TabIndex = 11;
            this.lbl4.Text = "Bot4";
            // 
            // btnColor
            // 
            this.btnColor.Enabled = false;
            this.btnColor.Location = new System.Drawing.Point(132, 12);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(30, 30);
            this.btnColor.TabIndex = 12;
            this.btnColor.UseVisualStyleBackColor = true;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.SystemColors.Window;
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTime.Location = new System.Drawing.Point(12, 92);
            this.lblTime.MinimumSize = new System.Drawing.Size(110, 20);
            this.lblTime.Name = "lblTime";
            this.lblTime.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.lblTime.Size = new System.Drawing.Size(110, 20);
            this.lblTime.TabIndex = 13;
            this.lblTime.Text = "0";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 265);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lblDist);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblRgb);
            this.Controls.Add(this.lblCoords);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Botter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCoords;
        private System.Windows.Forms.Label lblRgb;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblDist;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label lblTime;
    }
}

