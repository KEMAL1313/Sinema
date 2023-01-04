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
    public partial class TicketSalesForm : Form
    {
        public static string deger = "";
        public static string movieName = "";
        public static string salonName = "";
        public static string customerName = "";


        int movieId = TicketForm.movieId;
        PictureBox pictureBox;
        Label label;
        Button button;
        string ImageFolder = @"C:\Users\erhan.kaya\source\repos\Cinelogy\Cinelogy\images\";
        int seatLocationx = 60;
        int seatLocationy = 70;
        List<int> seatList = new List<int>();
        List<int> seatSelectList = new List<int>();
        string oldSeatSelect = "";
        public TicketSalesForm()
        {
            InitializeComponent();
        }

        private void TicketSalesForm_Load(object sender, EventArgs e)
        {
            curtainPb.ImageLocation = ImageFolder + "curtain.png";
            GetSeatList();
            GetSeat();
            
        }

        public void GetSeat()
        {
            Context.db().Open();

            SqlCommand sqlCommand = new SqlCommand("select Sallon.SeatCount as Seat," +
                                                    " Movie.Name as 'Movie',"+
                                                    " Sallon.Name as 'SalonName'," +
                                                    " Movie.Image as Poster" +
                                                    " from MSSL" +
                                                    " inner join Sallon" +
                                                    " on(MSSL.SallonId=Sallon.Id)" +
                                                    " inner join Movie" +
                                                    " on(MSSL.MovieId=Movie.Id)" +
                                                    " where MSSL.IsStatus=1 and MSSL.IsDelete=0 and MSSL.Id=" +movieId, Context.db());

            SqlDataReader dr = sqlCommand.ExecuteReader();

            if (dr.Read())
            {
                movieName = dr["Movie"].ToString();
                salonName = dr["SalonName"].ToString();
                int seatCount = Convert.ToInt32(dr["Seat"]);
                int seatAddCount = 0;
                movieNameLbl.Text = dr["Movie"].ToString();
                moviePb.ImageLocation = ImageFolder + "Movie\\" + dr["Poster"];
                for (int i = 1; i <= seatCount; i++)
                {
                    pictureBox = new PictureBox();
                    pictureBox.Name = "Seat-" + i;
                   
                    pictureBox.ImageLocation = ImageFolder + (seatList.Contains(i)?"seatBusy.png":"seatEmpty.png");
                                        
                    pictureBox.Location = new Point(seatLocationx, seatLocationy);
                    pictureBox.Size = new Size(50, 35);
                    pictureBox.SizeMode=PictureBoxSizeMode.StretchImage;
                    pictureBox.Click += PictureBox_Click;
                    salonSeatPanel.Controls.Add(pictureBox);
                    seatAddCount++;

                    if (seatAddCount == 12)
                    {
                        seatLocationy += 40;
                        seatLocationx = 60;
                        seatAddCount = 0;
                    }
                    else
                    {
                        seatLocationx += 55;
                    }
                }
            }
            Context.db().Close();
        }
        public void GetSeatList()
        {
            seatList.Clear();
            Context.db().Open();

            SqlCommand sqlCommand = new SqlCommand("select * from TicketSold where MSSLId=" + movieId, Context.db());

            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                seatList.Add(Convert.ToInt32(dr["SeatNumber"]));
            }
            Context.db().Close();
        }
        private void PictureBox_Click(object? sender, EventArgs e)
        {
            
            PictureBox pictureBox = (PictureBox)sender;
             
            pictureBox.ImageLocation = ImageFolder + (pictureBox.ImageLocation == ImageFolder + "seatBusy.png" ? "seatBusy.png" : pictureBox.ImageLocation == ImageFolder + "seatEmpty.png" ? "seatSelect.png" : "seatEmpty.png");
            int seatId = Convert.ToInt32(pictureBox.Name.Substring(5));
            if (!seatSelectList.Contains(seatId) && pictureBox.ImageLocation != ImageFolder + "seatBusy.png")
            {
                seatSelectList.Add(seatId);
            }
            else
            {
                seatSelectList.Remove(seatId);
            }
             deger = "";
            foreach (int item in seatSelectList)
            {
                deger += item + ",";
            }
            if(deger.Length>1)
            selectSeatsLbl.Text = deger.Substring(0,deger.Length-1);
            else
                selectSeatsLbl.Text = deger;

        }

      

        private void sellTicketBtn_Click(object sender, EventArgs e)
        {
            if(seatSelectList.Count > 0)
            {
                bool saleStatus = false;
                Context.db().Open();
                foreach (int seat in seatSelectList)
                {
                    

                    SqlCommand sqlCommand = new SqlCommand("SellTicket", Context.db());
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("CustomerNumber", SqlDbType.NVarChar,100).Value = customerNumberTxt.Text;
                    sqlCommand.Parameters.Add("MSSLId", SqlDbType.Int).Value = movieId;
                    sqlCommand.Parameters.Add("SeatNumber", SqlDbType.Int).Value = seat;

                    var ReturnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    ReturnValue.Direction = ParameterDirection.ReturnValue;
                    sqlCommand.ExecuteNonQuery();

                    int result = Convert.ToInt32(ReturnValue.Value);

                    if(result == 1)
                    {
                        saleStatus = true;
                    }
                    else if(result == 2)
                    {
                        MessageBox.Show("Bilinmeyen bir hata oluştu");
                        saleStatus = false;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Not Found Customer");
                        saleStatus = false;
                        break;
                    }

                   

                }
                Context.db().Close();
                if (saleStatus)
                {
                    MessageBox.Show("Biletler Başarılı Bir Şekilde Satıldı");
                   

                

                    Context.db().Open();

                    SqlCommand sqlCommand = new SqlCommand("select * from Customer where CustomerNumber='" + customerNumberTxt.Text + "'", Context.db());

                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    if (dr.Read())
                    {
                        customerName = dr["Name"] + " " + dr["Surname"];
                    }
                 
                    Context.db().Close();

                    TicketDetailForm ticketDetailForm = new TicketDetailForm();
                    ticketDetailForm.ShowDialog();

                    deger = "";
                    seatSelectList.Clear();

                    this.Dispose();
                    TicketSalesForm ticketSalesForm = new TicketSalesForm();
                    ticketSalesForm.ShowDialog();


                }

                
            }
        }
    }
}
