namespace Cinelogy
{
    partial class TicketDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketDetailForm));
            this.salonNameLbl = new System.Windows.Forms.Label();
            this.seatNumberLbl = new System.Windows.Forms.Label();
            this.customerLbl = new System.Windows.Forms.Label();
            this.movieNamelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // salonNameLbl
            // 
            this.salonNameLbl.AutoSize = true;
            this.salonNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.salonNameLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.salonNameLbl.ForeColor = System.Drawing.Color.Black;
            this.salonNameLbl.Location = new System.Drawing.Point(465, 147);
            this.salonNameLbl.Name = "salonNameLbl";
            this.salonNameLbl.Size = new System.Drawing.Size(54, 23);
            this.salonNameLbl.TabIndex = 0;
            this.salonNameLbl.Text = "Salon";
            // 
            // seatNumberLbl
            // 
            this.seatNumberLbl.AutoSize = true;
            this.seatNumberLbl.BackColor = System.Drawing.Color.Transparent;
            this.seatNumberLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.seatNumberLbl.ForeColor = System.Drawing.Color.Black;
            this.seatNumberLbl.Location = new System.Drawing.Point(465, 170);
            this.seatNumberLbl.Name = "seatNumberLbl";
            this.seatNumberLbl.Size = new System.Drawing.Size(45, 23);
            this.seatNumberLbl.TabIndex = 1;
            this.seatNumberLbl.Text = "Seat";
            // 
            // customerLbl
            // 
            this.customerLbl.AutoSize = true;
            this.customerLbl.BackColor = System.Drawing.Color.Transparent;
            this.customerLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.customerLbl.ForeColor = System.Drawing.Color.Black;
            this.customerLbl.Location = new System.Drawing.Point(465, 193);
            this.customerLbl.Name = "customerLbl";
            this.customerLbl.Size = new System.Drawing.Size(87, 23);
            this.customerLbl.TabIndex = 2;
            this.customerLbl.Text = "Customer";
            // 
            // movieNamelbl
            // 
            this.movieNamelbl.AutoSize = true;
            this.movieNamelbl.BackColor = System.Drawing.Color.Transparent;
            this.movieNamelbl.Font = new System.Drawing.Font("Arial Narrow", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.movieNamelbl.Location = new System.Drawing.Point(332, 238);
            this.movieNamelbl.Name = "movieNamelbl";
            this.movieNamelbl.Size = new System.Drawing.Size(97, 40);
            this.movieNamelbl.TabIndex = 3;
            this.movieNamelbl.Text = "Movie";
            // 
            // TicketDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cinelogy.Properties.Resources.ticket;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(807, 320);
            this.Controls.Add(this.movieNamelbl);
            this.Controls.Add(this.customerLbl);
            this.Controls.Add(this.seatNumberLbl);
            this.Controls.Add(this.salonNameLbl);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TicketDetailForm";
            this.Text = "Ticket Detail";
            this.Load += new System.EventHandler(this.TicketDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label salonNameLbl;
        private Label seatNumberLbl;
        private Label customerLbl;
        private Label movieNamelbl;
    }
}