namespace Cinelogy
{
    partial class CustomersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomersForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.customerDeleteBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cStatusLbl = new System.Windows.Forms.Label();
            this.cRegisterLbl = new System.Windows.Forms.Label();
            this.cRateLbl = new System.Windows.Forms.Label();
            this.cTypeLbl = new System.Windows.Forms.Label();
            this.cPhoneLbl = new System.Windows.Forms.Label();
            this.cEmailLbl = new System.Windows.Forms.Label();
            this.cBalanceLbl = new System.Windows.Forms.Label();
            this.cSurnameLbl = new System.Windows.Forms.Label();
            this.cNameLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView1);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.customerDeleteBtn);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.cStatusLbl);
            this.panel3.Controls.Add(this.cRegisterLbl);
            this.panel3.Controls.Add(this.cRateLbl);
            this.panel3.Controls.Add(this.cTypeLbl);
            this.panel3.Controls.Add(this.cPhoneLbl);
            this.panel3.Controls.Add(this.cEmailLbl);
            this.panel3.Controls.Add(this.cBalanceLbl);
            this.panel3.Controls.Add(this.cSurnameLbl);
            this.panel3.Controls.Add(this.cNameLbl);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // customerDeleteBtn
            // 
            this.customerDeleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.customerDeleteBtn, "customerDeleteBtn");
            this.customerDeleteBtn.ForeColor = System.Drawing.Color.White;
            this.customerDeleteBtn.Name = "customerDeleteBtn";
            this.customerDeleteBtn.UseVisualStyleBackColor = false;
            this.customerDeleteBtn.Click += new System.EventHandler(this.customerDeleteBtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cStatusLbl
            // 
            resources.ApplyResources(this.cStatusLbl, "cStatusLbl");
            this.cStatusLbl.ForeColor = System.Drawing.Color.White;
            this.cStatusLbl.Name = "cStatusLbl";
            // 
            // cRegisterLbl
            // 
            resources.ApplyResources(this.cRegisterLbl, "cRegisterLbl");
            this.cRegisterLbl.ForeColor = System.Drawing.Color.White;
            this.cRegisterLbl.Name = "cRegisterLbl";
            // 
            // cRateLbl
            // 
            resources.ApplyResources(this.cRateLbl, "cRateLbl");
            this.cRateLbl.ForeColor = System.Drawing.Color.White;
            this.cRateLbl.Name = "cRateLbl";
            // 
            // cTypeLbl
            // 
            resources.ApplyResources(this.cTypeLbl, "cTypeLbl");
            this.cTypeLbl.ForeColor = System.Drawing.Color.White;
            this.cTypeLbl.Name = "cTypeLbl";
            // 
            // cPhoneLbl
            // 
            resources.ApplyResources(this.cPhoneLbl, "cPhoneLbl");
            this.cPhoneLbl.ForeColor = System.Drawing.Color.White;
            this.cPhoneLbl.Name = "cPhoneLbl";
            // 
            // cEmailLbl
            // 
            resources.ApplyResources(this.cEmailLbl, "cEmailLbl");
            this.cEmailLbl.ForeColor = System.Drawing.Color.White;
            this.cEmailLbl.Name = "cEmailLbl";
            // 
            // cBalanceLbl
            // 
            resources.ApplyResources(this.cBalanceLbl, "cBalanceLbl");
            this.cBalanceLbl.ForeColor = System.Drawing.Color.White;
            this.cBalanceLbl.Name = "cBalanceLbl";
            // 
            // cSurnameLbl
            // 
            resources.ApplyResources(this.cSurnameLbl, "cSurnameLbl");
            this.cSurnameLbl.ForeColor = System.Drawing.Color.White;
            this.cSurnameLbl.Name = "cSurnameLbl";
            // 
            // cNameLbl
            // 
            resources.ApplyResources(this.cNameLbl, "cNameLbl");
            this.cNameLbl.ForeColor = System.Drawing.Color.White;
            this.cNameLbl.Name = "cNameLbl";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Name = "label10";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // CustomersForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.MinimizeBox = false;
            this.Name = "CustomersForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CustomersForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private Panel panel3;
        private DataGridView dataGridView1;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label cStatusLbl;
        private Label cRegisterLbl;
        private Label cRateLbl;
        private Label cTypeLbl;
        private Label cPhoneLbl;
        private Label cEmailLbl;
        private Label cBalanceLbl;
        private Label cSurnameLbl;
        private Label cNameLbl;
        private Label label9;
        private Label label10;
        private Button customerDeleteBtn;
        private Button button1;
    }
}