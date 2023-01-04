using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinelogy
{
    public partial class TicketDetailForm : Form
    {
        public TicketDetailForm()
        {
            InitializeComponent();
        }

        private void TicketDetailForm_Load(object sender, EventArgs e)
        {


            salonNameLbl.Text = TicketSalesForm.salonName;
            seatNumberLbl.Text = TicketSalesForm.deger;
            movieNamelbl.Text = TicketSalesForm.movieName;
            customerLbl.Text = TicketSalesForm.customerName;


        }
    }
}
