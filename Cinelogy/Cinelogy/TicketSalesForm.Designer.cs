namespace Cinelogy
{
    partial class TicketSalesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketSalesForm));
            this.CustomerTicketSalesPanel = new System.Windows.Forms.Panel();
            this.sellTicketBtn = new System.Windows.Forms.Button();
            this.customerNumberTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectSeatsLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.movieSessionLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.movieSalonLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.movieLanguageLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.movieDirectorLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.moviePb = new System.Windows.Forms.PictureBox();
            this.movieNameLbl = new System.Windows.Forms.Label();
            this.salonSeatPanel = new System.Windows.Forms.Panel();
            this.curtainPb = new System.Windows.Forms.PictureBox();
            this.CustomerTicketSalesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moviePb)).BeginInit();
            this.salonSeatPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.curtainPb)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerTicketSalesPanel
            // 
            this.CustomerTicketSalesPanel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CustomerTicketSalesPanel.Controls.Add(this.sellTicketBtn);
            this.CustomerTicketSalesPanel.Controls.Add(this.customerNumberTxt);
            this.CustomerTicketSalesPanel.Controls.Add(this.label2);
            this.CustomerTicketSalesPanel.Controls.Add(this.selectSeatsLbl);
            this.CustomerTicketSalesPanel.Controls.Add(this.label4);
            this.CustomerTicketSalesPanel.Controls.Add(this.movieSessionLbl);
            this.CustomerTicketSalesPanel.Controls.Add(this.label7);
            this.CustomerTicketSalesPanel.Controls.Add(this.movieSalonLbl);
            this.CustomerTicketSalesPanel.Controls.Add(this.label5);
            this.CustomerTicketSalesPanel.Controls.Add(this.movieLanguageLbl);
            this.CustomerTicketSalesPanel.Controls.Add(this.label3);
            this.CustomerTicketSalesPanel.Controls.Add(this.movieDirectorLbl);
            this.CustomerTicketSalesPanel.Controls.Add(this.label1);
            this.CustomerTicketSalesPanel.Controls.Add(this.moviePb);
            this.CustomerTicketSalesPanel.Controls.Add(this.movieNameLbl);
            this.CustomerTicketSalesPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.CustomerTicketSalesPanel.Location = new System.Drawing.Point(0, 0);
            this.CustomerTicketSalesPanel.Name = "CustomerTicketSalesPanel";
            this.CustomerTicketSalesPanel.Size = new System.Drawing.Size(400, 600);
            this.CustomerTicketSalesPanel.TabIndex = 0;
            // 
            // sellTicketBtn
            // 
            this.sellTicketBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.sellTicketBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sellTicketBtn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sellTicketBtn.ForeColor = System.Drawing.Color.White;
            this.sellTicketBtn.Location = new System.Drawing.Point(33, 449);
            this.sellTicketBtn.Name = "sellTicketBtn";
            this.sellTicketBtn.Size = new System.Drawing.Size(341, 75);
            this.sellTicketBtn.TabIndex = 14;
            this.sellTicketBtn.Text = "Sell Ticket";
            this.sellTicketBtn.UseVisualStyleBackColor = false;
            this.sellTicketBtn.Click += new System.EventHandler(this.sellTicketBtn_Click);
            // 
            // customerNumberTxt
            // 
            this.customerNumberTxt.Location = new System.Drawing.Point(33, 394);
            this.customerNumberTxt.Name = "customerNumberTxt";
            this.customerNumberTxt.Size = new System.Drawing.Size(206, 27);
            this.customerNumberTxt.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(30, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 28);
            this.label2.TabIndex = 12;
            this.label2.Text = "Customer Number";
            // 
            // selectSeatsLbl
            // 
            this.selectSeatsLbl.AutoSize = true;
            this.selectSeatsLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectSeatsLbl.Location = new System.Drawing.Point(33, 314);
            this.selectSeatsLbl.Name = "selectSeatsLbl";
            this.selectSeatsLbl.Size = new System.Drawing.Size(58, 28);
            this.selectSeatsLbl.TabIndex = 11;
            this.selectSeatsLbl.Text = "Seats";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(33, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "Select Seats";
            // 
            // movieSessionLbl
            // 
            this.movieSessionLbl.AutoSize = true;
            this.movieSessionLbl.Location = new System.Drawing.Point(207, 238);
            this.movieSessionLbl.Name = "movieSessionLbl";
            this.movieSessionLbl.Size = new System.Drawing.Size(58, 20);
            this.movieSessionLbl.TabIndex = 9;
            this.movieSessionLbl.Text = "Session";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(207, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Session";
            // 
            // movieSalonLbl
            // 
            this.movieSalonLbl.AutoSize = true;
            this.movieSalonLbl.Location = new System.Drawing.Point(207, 190);
            this.movieSalonLbl.Name = "movieSalonLbl";
            this.movieSalonLbl.Size = new System.Drawing.Size(46, 20);
            this.movieSalonLbl.TabIndex = 7;
            this.movieSalonLbl.Text = "Salon";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(207, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Salon";
            // 
            // movieLanguageLbl
            // 
            this.movieLanguageLbl.AutoSize = true;
            this.movieLanguageLbl.Location = new System.Drawing.Point(207, 141);
            this.movieLanguageLbl.Name = "movieLanguageLbl";
            this.movieLanguageLbl.Size = new System.Drawing.Size(74, 20);
            this.movieLanguageLbl.TabIndex = 5;
            this.movieLanguageLbl.Text = "Language";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(207, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Language";
            // 
            // movieDirectorLbl
            // 
            this.movieDirectorLbl.AutoSize = true;
            this.movieDirectorLbl.Location = new System.Drawing.Point(207, 91);
            this.movieDirectorLbl.Name = "movieDirectorLbl";
            this.movieDirectorLbl.Size = new System.Drawing.Size(63, 20);
            this.movieDirectorLbl.TabIndex = 3;
            this.movieDirectorLbl.Text = "Director";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(207, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Director";
            // 
            // moviePb
            // 
            this.moviePb.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.moviePb.Location = new System.Drawing.Point(30, 71);
            this.moviePb.Name = "moviePb";
            this.moviePb.Size = new System.Drawing.Size(156, 187);
            this.moviePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.moviePb.TabIndex = 1;
            this.moviePb.TabStop = false;
            // 
            // movieNameLbl
            // 
            this.movieNameLbl.AutoSize = true;
            this.movieNameLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.movieNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.movieNameLbl.Location = new System.Drawing.Point(23, 29);
            this.movieNameLbl.Name = "movieNameLbl";
            this.movieNameLbl.Size = new System.Drawing.Size(71, 28);
            this.movieNameLbl.TabIndex = 0;
            this.movieNameLbl.Text = "Movie";
            // 
            // salonSeatPanel
            // 
            this.salonSeatPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(143)))));
            this.salonSeatPanel.Controls.Add(this.curtainPb);
            this.salonSeatPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salonSeatPanel.Location = new System.Drawing.Point(400, 0);
            this.salonSeatPanel.Name = "salonSeatPanel";
            this.salonSeatPanel.Size = new System.Drawing.Size(800, 600);
            this.salonSeatPanel.TabIndex = 1;
            // 
            // curtainPb
            // 
            this.curtainPb.Location = new System.Drawing.Point(250, 10);
            this.curtainPb.Name = "curtainPb";
            this.curtainPb.Size = new System.Drawing.Size(300, 25);
            this.curtainPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.curtainPb.TabIndex = 0;
            this.curtainPb.TabStop = false;
            // 
            // TicketSalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.salonSeatPanel);
            this.Controls.Add(this.CustomerTicketSalesPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TicketSalesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticket Sales";
            this.Load += new System.EventHandler(this.TicketSalesForm_Load);
            this.CustomerTicketSalesPanel.ResumeLayout(false);
            this.CustomerTicketSalesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moviePb)).EndInit();
            this.salonSeatPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.curtainPb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel CustomerTicketSalesPanel;
        private Panel salonSeatPanel;
        private PictureBox curtainPb;
        private Button button1;
        private Label movieNameLbl;
        private PictureBox moviePb;
        private Label movieDirectorLbl;
        private Label label1;
        private Label selectSeatsLbl;
        private Label label4;
        private Label movieSessionLbl;
        private Label label7;
        private Label movieSalonLbl;
        private Label label5;
        private Label movieLanguageLbl;
        private Label label3;
        private TextBox customerNumberTxt;
        private Label label2;
        private Button sellTicketBtn;
    }
}