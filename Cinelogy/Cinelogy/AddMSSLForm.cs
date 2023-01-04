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
    public partial class AddMSSLForm : Form
    {
        SettingsForm SettingsForm;
        string ImageFolder = @"C:\Users\erhan.kaya\source\repos\Cinelogy\Cinelogy\images\Movie\";
        int movieId=0;

        public AddMSSLForm(SettingsForm settingsForm)
        {
            InitializeComponent();
            SettingsForm = settingsForm;
        }

        private void addMSSLDgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            addMovieNameLbl.Text = addMSSLDgw.CurrentRow.Cells[2].Value.ToString();
            addMoviePb.ImageLocation = ImageFolder + addMSSLDgw.CurrentRow.Cells[1].Value.ToString();
            movieId = Convert.ToInt32(addMSSLDgw.CurrentRow.Cells[0].Value);

        }

        private void AddMSSLForm_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            Context.db().Open();

            SqlCommand sqlCommand = new SqlCommand("Select Movie.Id,Movie.Image,Movie.Name,MovieType.Name as Type, Movie.Director, Movie.ReleaseDate" +
                                                   " from Movie" +
                                                   " inner join MovieType" +
                                                   " on(Movie.MovieTypeId=MovieType.Id)" +
                                                   " where Movie.IsDelete=0", Context.db());
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            dt.Columns.Add("Afis", Type.GetType("System.Byte[]"));
            foreach (DataRow row in dt.Rows)
            {
                row["Afis"] = File.ReadAllBytes(ImageFolder + row["Image"].ToString());

            }
            addMSSLDgw.DataSource = dt;
            addMSSLDgw.Columns[0].Visible = false;
            addMSSLDgw.Columns[1].Visible = false;

            Context.db().Close();


            //Salon Get Data Database

            Context.db().Open();

            SqlCommand getDataSalon = new SqlCommand("select Id,Name from Sallon where IsStatus=1 and IsDelete=0", Context.db());
            SqlDataAdapter adapterSalon = new SqlDataAdapter(getDataSalon);
            DataTable dtSalon = new DataTable();
            adapterSalon.Fill(dtSalon);

            addMovieSalonCb.DataSource = dtSalon;
            addMovieSalonCb.ValueMember = "Id";
            addMovieSalonCb.DisplayMember = "Name";

            Context.db().Close();

            //Language Get Data Database

            Context.db().Open();

            SqlCommand getDataLanguage = new SqlCommand("select Id,Name from Language where IsStatus=1 and IsDelete=0", Context.db());
            SqlDataAdapter adapterLanguage = new SqlDataAdapter(getDataLanguage);
            DataTable dtLanguage = new DataTable();
            adapterLanguage.Fill(dtLanguage);

            addMovieLanguageCb.DataSource = dtLanguage;
            addMovieLanguageCb.ValueMember = "Id";
            addMovieLanguageCb.DisplayMember = "Name";

            Context.db().Close();

            //Session Get Data Database

            Context.db().Open();

            SqlCommand getDataSession = new SqlCommand("select Id,SessionTime from MovieSession where IsStatus=1 and IsDelete=0", Context.db());
            SqlDataAdapter adapterSession = new SqlDataAdapter(getDataSession);
            DataTable dtSession = new DataTable();
            adapterSession.Fill(dtSession);

            addMovieSessionCb.DataSource = dtSession;
            addMovieSessionCb.ValueMember = "Id";
            addMovieSessionCb.DisplayMember = "SessionTime";

            Context.db().Close();
        }

        private void unSelectMovieBtn_Click(object sender, EventArgs e)
        {
            UnSelectMovie();

        }
        public void UnSelectMovie()
        {
            addMovieNameLbl.Text = Name;
            movieId = 0;
            addMovieLanguageCb.SelectedIndex = -1;
            addMovieSalonCb.SelectedIndex = -1;
            addMovieLanguageCb.SelectedIndex = -1;
            addMoviePb.Image = null;
            addMoviePriceNud.Value = 0;
            addMovieStatusCb.Checked = false;
            addMovieDateDp.Value = DateTime.Now;
        }

        private void addMovieInCinemaBtn_Click(object sender, EventArgs e)
        {
            Context.db().Open();

            SqlCommand sqlCommand = new SqlCommand("AddMSSL", Context.db());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("MovieId", SqlDbType.Int).Value = movieId;
            sqlCommand.Parameters.Add("SessionId",SqlDbType.Int).Value=Convert.ToInt32(addMovieSessionCb.SelectedValue);
            sqlCommand.Parameters.Add("SalonId", SqlDbType.Int).Value = Convert.ToInt32(addMovieSalonCb.SelectedValue);
            sqlCommand.Parameters.Add("LanguageId", SqlDbType.Int).Value = Convert.ToInt32(addMovieLanguageCb.SelectedValue);
            sqlCommand.Parameters.Add("MovieDate", SqlDbType.Date).Value = Convert.ToDateTime(addMovieDateDp.Value);
            sqlCommand.Parameters.Add("Price", SqlDbType.Float).Value = Convert.ToDouble(addMoviePriceNud.Value);
            sqlCommand.Parameters.Add("Status", SqlDbType.Bit).Value = Convert.ToBoolean(addMovieStatusCb.Checked);

            var ReturnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
            ReturnValue.Direction = ParameterDirection.ReturnValue;
            sqlCommand.ExecuteNonQuery();
            int result = Convert.ToInt32(ReturnValue.Value);


            Context.db().Close();
            DialogResult dialogResult=new DialogResult();
            dialogResult = MessageBox.Show("Ekleme Yapılsın mı?", "Film yayınlama",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (result == 1) MessageBox.Show("Ekleme Başarılı");
                else MessageBox.Show("Ekleme Başarısız");

            }
            else
            {
                MessageBox.Show("İşlem İptal Edildi");
            }


            UnSelectMovie();
        }

        private void AddMSSLForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SettingsForm.GetMoviesInCinemaData();

        }
    }
}
