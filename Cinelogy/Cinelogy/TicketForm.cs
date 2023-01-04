using Cinelogy.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinelogy
{
    public partial class TicketForm : Form
    {
        Panel panel;
        PictureBox pictureBox;
        Label label;
        Button button;
        int panelLocationX = 40;
        int panelLocationY = 40;
        int formWidth = 0;
        int addCountMovie = 0;
        string ImageFolder = @"C:\Users\erhan.kaya\source\repos\Cinelogy\Cinelogy\images\Movie\";
        public static int movieId = 0;
        public TicketForm()
        {
            InitializeComponent();
        }

        private void TicketForm_Load(object sender, EventArgs e)
        {
            

            GetMovie();   
        }
        public void GetMovie()
        {
            formWidth = this.Width;
            addCountMovie = (formWidth-(formWidth % 400)-80)/440;
            int countMovie = 0;

            Context.db().Open();

            SqlCommand sqlCommand = new SqlCommand("select MSSL.Id," +
                                                    " Movie.Name as Movie," +
                                                    " Movie.Image as Poster," +
                                                    " Movie.Director," +
                                                    " Sallon.Name as Salon," +
                                                    " MovieSession.SessionTime as Time," +
                                                    " Language.Name as 'Language'," +
                                                    " MovieType.Name as Type" +
                                                    " from MSSL" +
                                                    " inner join Movie" +
                                                    " on(MSSL.MovieId=Movie.Id)" +
                                                    " inner join Sallon" +
                                                    " on(MSSL.SallonId=Sallon.Id)" +
                                                    " inner join MovieSession" +
                                                    " on(MSSL.MovieSessionId=MovieSession.Id)" +
                                                    " inner join Language" +
                                                    " on(MSSL.LanguageId=Language.Id)" +
                                                    " inner join MovieType" +
                                                    " on(Movie.MovieTypeId=MovieType.Id)" +
                                                    " where MSSL.IsStatus=1 and MSSL.IsDelete=0",Context.db());

            SqlDataReader dr = sqlCommand.ExecuteReader();

            while (dr.Read())
            {

                panel = new Panel();
                panel.Name = "Panel-" + dr["Id"];
                panel.Size = new Size(400, 400);
                
                panel.BackColor = Color.Black;
                
                panel.Location = new Point(panelLocationX, panelLocationY);
                if (countMovie == addCountMovie)
                {
                    panelLocationX = 40;
                    panelLocationY += 440;
                }
                else
                {
                    panelLocationX += 440;

                }
                this.Controls.Add(panel);

                countMovie++;

                pictureBox = new PictureBox();
                pictureBox.Location = new Point(10, 80);
                pictureBox.Size = new Size(190, 300);
                pictureBox.BackColor = Color.White;
                pictureBox.ImageLocation = ImageFolder + dr["Poster"];
                pictureBox.SizeMode=PictureBoxSizeMode.StretchImage;
                panel.Controls.Add(pictureBox);

                label = new Label();
                label.Name = dr["Movie"].ToString(); 
                label.Text= dr["Movie"].ToString();
                label.Location = new Point(10, 10);
                label.ForeColor = Color.White;
                label.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
                label.Height = 70;
                label.Width = 360;
                panel.Controls.Add(label);


                label = new Label();
                label.Name = "Director";
                label.Text = "Director";
                label.Location = new Point(210, 80);
                label.ForeColor = Color.LightBlue;
                label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                label.Height = 20;
                label.Width = 180;
                panel.Controls.Add(label);

                label = new Label();
                label.Name = dr["Director"].ToString();
                label.Text = dr["Director"].ToString();
                label.Location = new Point(210, 100);
                label.ForeColor = Color.White;
                label.Font = new Font("Segoe UI", 8F);
                label.Height =20;
                label.Width = 180;
                panel.Controls.Add(label);

                label = new Label();
                label.Name = "Type";
                label.Text = "Type";
                label.Location = new Point(210, 130);
                label.ForeColor = Color.LightBlue;
                label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                label.Height = 20;
                label.Width = 180;
                panel.Controls.Add(label);

                label = new Label();
                label.Name = dr["Type"].ToString();
                label.Text = dr["Type"].ToString();
                label.Location = new Point(210, 150);
                label.ForeColor = Color.White;
                label.Font = new Font("Segoe UI", 8F);
                label.Height = 20;
                label.Width = 180;
                panel.Controls.Add(label);

                label = new Label();
                label.Name = "Language";
                label.Text = "Language";
                label.Location = new Point(210, 180);
                label.ForeColor = Color.LightBlue;
                label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                label.Height = 20;
                label.Width = 180;
                panel.Controls.Add(label);

                label = new Label();
                label.Name = dr["Language"].ToString();
                label.Text = dr["Language"].ToString();
                label.Location = new Point(210, 200);
                label.ForeColor = Color.White;
                label.Font = new Font("Segoe UI", 8F);
                label.Height = 20;
                label.Width = 180;
                panel.Controls.Add(label);


                label = new Label();
                label.Name = "Salon";
                label.Text = "Salon";
                label.Location = new Point(210, 230);
                label.ForeColor = Color.LightBlue;
                label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                label.Height = 20;
                label.Width = 180;
                panel.Controls.Add(label);

                label = new Label();
                label.Name = dr["Salon"].ToString();
                label.Text = dr["Salon"].ToString();
                label.Location = new Point(210, 250);
                label.ForeColor = Color.White;
                label.Font = new Font("Segoe UI", 8F);
                label.Height = 20;
                label.Width = 180;
                panel.Controls.Add(label);

                label = new Label();
                label.Name = "Session";
                label.Text = "Session";
                label.Location = new Point(210, 280);
                label.ForeColor = Color.LightBlue;
                label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                label.Height = 20;
                label.Width = 180;
                panel.Controls.Add(label);

                label = new Label();
                label.Name = dr["Time"].ToString();
                label.Text = dr["Time"].ToString();
                label.Location = new Point(210, 300);
                label.ForeColor = Color.White;
                label.Font = new Font("Segoe UI", 8F);
                label.Height = 20;
                label.Width = 180;
                panel.Controls.Add(label);

                button = new Button();
                button.Name = "movie-" + dr["Id"];
                button.Text = "Ticket Sales";
                button.Location = new Point(210, 330);
                button.Height = 50;
                button.Width = 180;
                button.ForeColor = Color.White;
                button.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                button.BackColor = Color.DarkGoldenrod;
                button.FlatStyle= FlatStyle.Popup;
                button.Click += Button_Click;
                panel.Controls.Add(button);
            }


            Context.db().Close();
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            Button button=(Button)sender;
            movieId = Convert.ToInt32(button.Name.Substring(6));
            TicketSalesForm ticketSalesForm = new TicketSalesForm();
            ticketSalesForm.ShowDialog();
            
        }
    }
}
