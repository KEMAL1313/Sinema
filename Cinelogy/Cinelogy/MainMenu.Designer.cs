namespace Cinelogy
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.ticketBtn = new System.Windows.Forms.Button();
            this.moviesBtn = new System.Windows.Forms.Button();
            this.customersBtn = new System.Windows.Forms.Button();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.loginUserLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ticketBtn
            // 
            this.ticketBtn.BackgroundImage = global::Cinelogy.Properties.Resources.mainTicket;
            this.ticketBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ticketBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ticketBtn.Location = new System.Drawing.Point(66, 132);
            this.ticketBtn.Name = "ticketBtn";
            this.ticketBtn.Size = new System.Drawing.Size(137, 212);
            this.ticketBtn.TabIndex = 0;
            this.ticketBtn.UseVisualStyleBackColor = true;
            this.ticketBtn.Click += new System.EventHandler(this.ticketBtn_Click);
            // 
            // moviesBtn
            // 
            this.moviesBtn.BackgroundImage = global::Cinelogy.Properties.Resources.mainMovies;
            this.moviesBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.moviesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.moviesBtn.Location = new System.Drawing.Point(223, 132);
            this.moviesBtn.Name = "moviesBtn";
            this.moviesBtn.Size = new System.Drawing.Size(137, 212);
            this.moviesBtn.TabIndex = 1;
            this.moviesBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.moviesBtn.UseVisualStyleBackColor = true;
            // 
            // customersBtn
            // 
            this.customersBtn.BackgroundImage = global::Cinelogy.Properties.Resources.mainCustomer;
            this.customersBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.customersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.customersBtn.Location = new System.Drawing.Point(379, 132);
            this.customersBtn.Name = "customersBtn";
            this.customersBtn.Size = new System.Drawing.Size(137, 212);
            this.customersBtn.TabIndex = 2;
            this.customersBtn.UseVisualStyleBackColor = true;
            this.customersBtn.Click += new System.EventHandler(this.customersBtn_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.BackgroundImage = global::Cinelogy.Properties.Resources.mainSettings1;
            this.settingsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.settingsBtn.Location = new System.Drawing.Point(538, 132);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(137, 212);
            this.settingsBtn.TabIndex = 3;
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // loginUserLbl
            // 
            this.loginUserLbl.AutoSize = true;
            this.loginUserLbl.BackColor = System.Drawing.Color.Transparent;
            this.loginUserLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.loginUserLbl.ForeColor = System.Drawing.Color.White;
            this.loginUserLbl.Location = new System.Drawing.Point(589, 15);
            this.loginUserLbl.Name = "loginUserLbl";
            this.loginUserLbl.Size = new System.Drawing.Size(84, 20);
            this.loginUserLbl.TabIndex = 4;
            this.loginUserLbl.Text = "Login User";
            this.loginUserLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(671, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 62);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cinelogy.Properties.Resources.mainMenuBg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(735, 494);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.loginUserLbl);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.customersBtn);
            this.Controls.Add(this.moviesBtn);
            this.Controls.Add(this.ticketBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cinelogy Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ticketBtn;
        private Button moviesBtn;
        private Button customersBtn;
        private Button settingsBtn;
        private Label loginUserLbl;
        private PictureBox pictureBox1;
    }
}