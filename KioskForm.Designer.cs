
namespace NTCSAttendanceKiosk
{
    partial class KioskForm
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
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.PleaseScanCardLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CardTextBox = new System.Windows.Forms.TextBox();
            this.PublicMessagePanel = new System.Windows.Forms.Panel();
            this.PublicMessageLabel = new System.Windows.Forms.Label();
            this.UserMessagePanel = new System.Windows.Forms.Panel();
            this.UserMessageTextBox = new System.Windows.Forms.TextBox();
            this.HelloPanel = new System.Windows.Forms.Panel();
            this.HelloLabel = new System.Windows.Forms.Label();
            this.HideUserMessageTimer = new System.Windows.Forms.Timer(this.components);
            this.PublicMessageMarqueeTimer = new System.Windows.Forms.Timer(this.components);
            this.ClockUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.SecurityTimer = new System.Windows.Forms.Timer(this.components);
            this.SuccesIndicatorPictureBox = new System.Windows.Forms.PictureBox();
            this.ClockLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PublicMessagePanel.SuspendLayout();
            this.UserMessagePanel.SuspendLayout();
            this.HelloPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SuccesIndicatorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.Location = new System.Drawing.Point(429, 185);
            this.WelcomeLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(165, 37);
            this.WelcomeLabel.TabIndex = 0;
            this.WelcomeLabel.Text = "Welcome To";
            this.WelcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PleaseScanCardLabel
            // 
            this.PleaseScanCardLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PleaseScanCardLabel.AutoSize = true;
            this.PleaseScanCardLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PleaseScanCardLabel.Location = new System.Drawing.Point(400, 285);
            this.PleaseScanCardLabel.Name = "PleaseScanCardLabel";
            this.PleaseScanCardLabel.Size = new System.Drawing.Size(223, 37);
            this.PleaseScanCardLabel.TabIndex = 1;
            this.PleaseScanCardLabel.Text = "Please Scan Card";
            this.PleaseScanCardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(176, 226);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(671, 55);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "North Toronto Christian School";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::NTCSAttendanceKiosk.Properties.Resources.NTCSLogo;
            this.pictureBox1.Location = new System.Drawing.Point(429, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // CardTextBox
            // 
            this.CardTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CardTextBox.Location = new System.Drawing.Point(378, 336);
            this.CardTextBox.Name = "CardTextBox";
            this.CardTextBox.Size = new System.Drawing.Size(267, 43);
            this.CardTextBox.TabIndex = 4;
            this.CardTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CardTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CardTextBox_KeyDown);
            // 
            // PublicMessagePanel
            // 
            this.PublicMessagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PublicMessagePanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.PublicMessagePanel.Controls.Add(this.PublicMessageLabel);
            this.PublicMessagePanel.Location = new System.Drawing.Point(0, 661);
            this.PublicMessagePanel.Name = "PublicMessagePanel";
            this.PublicMessagePanel.Size = new System.Drawing.Size(1025, 108);
            this.PublicMessagePanel.TabIndex = 5;
            // 
            // PublicMessageLabel
            // 
            this.PublicMessageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PublicMessageLabel.AutoSize = true;
            this.PublicMessageLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PublicMessageLabel.ForeColor = System.Drawing.Color.White;
            this.PublicMessageLabel.Location = new System.Drawing.Point(615, 19);
            this.PublicMessageLabel.Name = "PublicMessageLabel";
            this.PublicMessageLabel.Size = new System.Drawing.Size(397, 65);
            this.PublicMessageLabel.TabIndex = 0;
            this.PublicMessageLabel.Text = "Public Messages";
            // 
            // UserMessagePanel
            // 
            this.UserMessagePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserMessagePanel.BackColor = System.Drawing.Color.LimeGreen;
            this.UserMessagePanel.Controls.Add(this.UserMessageTextBox);
            this.UserMessagePanel.Controls.Add(this.HelloPanel);
            this.UserMessagePanel.Location = new System.Drawing.Point(350, 403);
            this.UserMessagePanel.Name = "UserMessagePanel";
            this.UserMessagePanel.Size = new System.Drawing.Size(592, 239);
            this.UserMessagePanel.TabIndex = 6;
            this.UserMessagePanel.Visible = false;
            // 
            // UserMessageTextBox
            // 
            this.UserMessageTextBox.BackColor = System.Drawing.Color.LimeGreen;
            this.UserMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserMessageTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserMessageTextBox.Location = new System.Drawing.Point(11, 68);
            this.UserMessageTextBox.Multiline = true;
            this.UserMessageTextBox.Name = "UserMessageTextBox";
            this.UserMessageTextBox.ReadOnly = true;
            this.UserMessageTextBox.Size = new System.Drawing.Size(571, 161);
            this.UserMessageTextBox.TabIndex = 1;
            this.UserMessageTextBox.Text = "User message";
            // 
            // HelloPanel
            // 
            this.HelloPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HelloPanel.BackColor = System.Drawing.Color.ForestGreen;
            this.HelloPanel.Controls.Add(this.HelloLabel);
            this.HelloPanel.Location = new System.Drawing.Point(0, 0);
            this.HelloPanel.Name = "HelloPanel";
            this.HelloPanel.Size = new System.Drawing.Size(592, 62);
            this.HelloPanel.TabIndex = 0;
            // 
            // HelloLabel
            // 
            this.HelloLabel.AutoSize = true;
            this.HelloLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelloLabel.ForeColor = System.Drawing.Color.White;
            this.HelloLabel.Location = new System.Drawing.Point(4, 10);
            this.HelloLabel.Name = "HelloLabel";
            this.HelloLabel.Size = new System.Drawing.Size(86, 37);
            this.HelloLabel.TabIndex = 0;
            this.HelloLabel.Text = "Hello";
            // 
            // HideUserMessageTimer
            // 
            this.HideUserMessageTimer.Interval = 3000;
            this.HideUserMessageTimer.Tick += new System.EventHandler(this.HideUserMessageTimer_Tick);
            // 
            // PublicMessageMarqueeTimer
            // 
            this.PublicMessageMarqueeTimer.Enabled = true;
            this.PublicMessageMarqueeTimer.Interval = 10;
            this.PublicMessageMarqueeTimer.Tick += new System.EventHandler(this.PublicMessageMarqueeTimer_Tick);
            // 
            // ClockUpdateTimer
            // 
            this.ClockUpdateTimer.Enabled = true;
            this.ClockUpdateTimer.Tick += new System.EventHandler(this.ClockUpdateTimer_Tick);
            // 
            // SecurityTimer
            // 
            this.SecurityTimer.Enabled = true;
            this.SecurityTimer.Tick += new System.EventHandler(this.SecurityTimer_Tick);
            // 
            // SuccesIndicatorPictureBox
            // 
            this.SuccesIndicatorPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SuccesIndicatorPictureBox.Image = global::NTCSAttendanceKiosk.Properties.Resources.CheckSign;
            this.SuccesIndicatorPictureBox.Location = new System.Drawing.Point(66, 422);
            this.SuccesIndicatorPictureBox.Name = "SuccesIndicatorPictureBox";
            this.SuccesIndicatorPictureBox.Size = new System.Drawing.Size(200, 200);
            this.SuccesIndicatorPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SuccesIndicatorPictureBox.TabIndex = 7;
            this.SuccesIndicatorPictureBox.TabStop = false;
            this.SuccesIndicatorPictureBox.Visible = false;
            // 
            // ClockLabel
            // 
            this.ClockLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ClockLabel.AutoSize = true;
            this.ClockLabel.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClockLabel.Location = new System.Drawing.Point(320, 422);
            this.ClockLabel.Name = "ClockLabel";
            this.ClockLabel.Size = new System.Drawing.Size(385, 172);
            this.ClockLabel.TabIndex = 8;
            this.ClockLabel.Text = "2021-06-08\r\n17:35:54";
            this.ClockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationLabel.Location = new System.Drawing.Point(12, 9);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(57, 17);
            this.LocationLabel.TabIndex = 9;
            this.LocationLabel.Text = "Location";
            // 
            // KioskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.SuccesIndicatorPictureBox);
            this.Controls.Add(this.UserMessagePanel);
            this.Controls.Add(this.PublicMessagePanel);
            this.Controls.Add(this.CardTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.PleaseScanCardLabel);
            this.Controls.Add(this.WelcomeLabel);
            this.Controls.Add(this.ClockLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::NTCSAttendanceKiosk.Properties.Resources.NTCSIcon;
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "KioskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AtteNTCS Kiosk";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PublicMessagePanel.ResumeLayout(false);
            this.PublicMessagePanel.PerformLayout();
            this.UserMessagePanel.ResumeLayout(false);
            this.UserMessagePanel.PerformLayout();
            this.HelloPanel.ResumeLayout(false);
            this.HelloPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SuccesIndicatorPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Label PleaseScanCardLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox CardTextBox;
        private System.Windows.Forms.Panel PublicMessagePanel;
        private System.Windows.Forms.Panel UserMessagePanel;
        private System.Windows.Forms.Panel HelloPanel;
        private System.Windows.Forms.Timer HideUserMessageTimer;
        private System.Windows.Forms.Timer PublicMessageMarqueeTimer;
        private System.Windows.Forms.Timer ClockUpdateTimer;
        private System.Windows.Forms.Timer SecurityTimer;
        private System.Windows.Forms.TextBox UserMessageTextBox;
        private System.Windows.Forms.Label HelloLabel;
        private System.Windows.Forms.PictureBox SuccesIndicatorPictureBox;
        private System.Windows.Forms.Label ClockLabel;
        private System.Windows.Forms.Label PublicMessageLabel;
        private System.Windows.Forms.Label LocationLabel;
    }
}

