using Cinelogy.ApplicationManagement;
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
    public partial class MainMenu : Form
    {
        public int id = 0;
        UserProccess UserProccess;
        public MainMenu()
        {
            InitializeComponent();
            
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();//Projeyi komple kapatır
        }

        private void customersBtn_Click(object sender, EventArgs e)
        {
            CustomersForm customersForm = new CustomersForm();
            customersForm.ShowDialog();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            UserProccess = new UserProccess();

            loginUserLbl.Text = UserProccess.Name.ToUpper() +"\n"+ UserProccess.Surname.ToUpper();
            pictureBox1.ImageLocation = "C:\\Users\\erhan.kaya\\source\\repos\\Cinelogy\\Cinelogy\\images\\" + UserProccess.Image;
            pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
         }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();

            settingsForm.ShowDialog();
        }

        private void ticketBtn_Click(object sender, EventArgs e)
        {
            TicketForm ticketForm = new TicketForm();
            ticketForm.ShowDialog();
        }
    }
}
