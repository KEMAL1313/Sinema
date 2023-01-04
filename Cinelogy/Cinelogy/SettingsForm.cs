using Cinelogy.DataAccessLayer;
using Cinelogy.Model;
using System.Data;
using System.Data.SqlClient;

namespace Cinelogy
{
    public partial class SettingsForm : Form
    {
        List<MovieType> movieTypes = new List<MovieType>();
        string addMovieImageName = "";
        string editMovieImageName = "";
        string editSelectImageName = "";

        string addLanguageImageName = "";
        string editLanguageImageName = "";
        string editSelectLanguageImageName = "";

        string ImageFolder = @"C:\Users\erhan.kaya\source\repos\Cinelogy\Cinelogy\images\Movie\";
        string IconFolder = @"C:\Users\erhan.kaya\source\repos\Cinelogy\Cinelogy\images\Language\";
        
        int deleteMovieId = 0;
        int editMovieId = 0;

        int editSalonId = 0;
        int deleteSalonId = 0;

        int editSessionId = 0;
        int deleteSessionId = 0;

        int editLanguageId = 0;
        int deleteLanguageId = 0;


        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            GetData();
            GetMovieType();
            GetSalons();
            GetLanguages();
            GetSessions();
            GetMoviesInCinemaData();

            deleteMovieNameTxt.Enabled = false;
            deleteMovieDirectorTxt.Enabled = false;
            deleteMovieDescriptionRtb.Enabled = false;
            deleteMovieReleaseDate.Enabled = false;
            deleteMovieStatusCb.Enabled = false;
            deleteMovieTypeCb.Enabled = false;
            editMovieTypeCb.SelectedIndex = -1;

            deleteSalonNameTxt.Enabled=false;
            deleteSalonSeatCountNud.Enabled=false;
            deleteSalonStatusCb.Enabled = false;

            deleteSessionStatusCb.Enabled = false;
            deleteSessionTimeDtp.Enabled =false;

            deleteLanguageNameTxt.Enabled = false;
            deleteLanguageStatusCb.Enabled=false;

            addMovieInCinemaBtn.Location = new Point(moviesHeaderPanel.Width - addMovieInCinemaBtn.Width - 25, 25);
        }
        public void GetData()
        {
            Context.db().Open();

            string sorgu = "select Movie.Id,Movie.Image,Movie.Name,MovieType.Name as Type,Director,ReleaseDate,Movie.Description,Movie.IsStatus,MovieType.Id as TypeId from Movie inner join MovieType on(Movie.MovieTypeId=MovieType.Id) where Movie.IsDelete=0";
            SqlCommand sql = new SqlCommand(sorgu, Context.db());

            SqlDataAdapter sqlData = new SqlDataAdapter(sql);

            DataTable table = new DataTable();
            sqlData.Fill(table);

            table.Columns.Add("Afis", Type.GetType("System.Byte[]"));
           
            foreach (DataRow row in table.Rows)
            {
                row["Afis"] = File.ReadAllBytes(ImageFolder + row["Image"].ToString());
            }
            


            moviesDgw.DataSource = table;
            moviesDgw.Columns[0].Visible = false;
            moviesDgw.Columns[1].Visible = false;
            moviesDgw.Columns[6].Visible = false;
            moviesDgw.Columns[7].Visible = false;
            moviesDgw.Columns[8].Visible = false;

            addMoviesDgw.DataSource = table;
            addMoviesDgw.Columns[0].Visible = false;
            addMoviesDgw.Columns[1].Visible = false;
            addMoviesDgw.Columns[6].Visible = false;
            addMoviesDgw.Columns[7].Visible = false;
            addMoviesDgw.Columns[8].Visible = false;

            editMoviesDgw.DataSource = table;
            editMoviesDgw.Columns[0].Visible = false;
            editMoviesDgw.Columns[1].Visible = false;
            editMoviesDgw.Columns[6].Visible = false;
            editMoviesDgw.Columns[7].Visible = false;
            editMoviesDgw.Columns[8].Visible = false;

            deleteMoviesDgw.DataSource = table;
            deleteMoviesDgw.Columns[0].Visible = false;
            deleteMoviesDgw.Columns[1].Visible = false;
            deleteMoviesDgw.Columns[6].Visible = false;
            deleteMoviesDgw.Columns[7].Visible = false;
            deleteMoviesDgw.Columns[8].Visible = false;


            Context.db().Close();


        }

        public void GetMoviesInCinemaData()
        {
            Context.db().Open();

            string sorgu = "select" +
                " Movie.Image as Image," +
                " Language.Image as 'LanguageImage'," +
                " MSSL.Id," +
                " Movie.Name as Name," +
                " MovieType.Name as Type," +
                " Sallon.Name as Salon," +
                " MovieSession.SessionTime as 'Session Time'," +
                " MSSL.MovieDate as Date" +
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
                " where MSSL.IsDelete=0";

            SqlCommand sql = new SqlCommand(sorgu, Context.db());

            SqlDataAdapter sqlData = new SqlDataAdapter(sql);

            DataTable table = new DataTable();
            sqlData.Fill(table);

            table.Columns.Add("Afis", Type.GetType("System.Byte[]"));
            table.Columns.Add("Language", Type.GetType("System.Byte[]"));
            

            foreach (DataRow row in table.Rows)
            {
                row["Afis"] = File.ReadAllBytes(ImageFolder + row["Image"].ToString());
                row["Language"] = File.ReadAllBytes(IconFolder + row["LanguageImage"].ToString());

            }


            moviesInCinemaDgw.DataSource = table;
            moviesInCinemaDgw.Columns[0].Visible = false;
            moviesInCinemaDgw.Columns[1].Visible = false;
            moviesInCinemaDgw.Columns[2].Visible = false;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "movieInCinemaEditBtn";
            btn.HeaderText = "Edit";
            btn.Text = "Edit";
            moviesInCinemaDgw.CellClick += MoviesInCinemaDgw_CellClick;
            btn.UseColumnTextForButtonValue = true;
            moviesInCinemaDgw.Columns.Add(btn);

            btn = new DataGridViewButtonColumn();
            btn.Name = "movieInCinemaDeleteBtn";
            btn.HeaderText = "Delete";
            btn.Text = "Delete";
            btn.UseColumnTextForButtonValue = true;
            moviesInCinemaDgw.Columns.Add(btn);


            Context.db().Close();


        }

        private void MoviesInCinemaDgw_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int movieInCinemaId=Convert.ToInt32(moviesDgw.CurrentRow.Cells[0].Value);
                MessageBox.Show(movieInCinemaId.ToString()+" Düzenlenecek Filmin Idsi");
            }
            else if(e.ColumnIndex == 1)
            {
                int movieInCinemaId = Convert.ToInt32(moviesDgw.CurrentRow.Cells[0].Value);
                DialogResult dialogResult = new DialogResult();
                dialogResult = MessageBox.Show("Film Silinsin mi?","Film Silme",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(dialogResult == DialogResult.Yes)
                {
                    Context.db().Open();
                    SqlCommand sqlCommand = new SqlCommand("DeleteMSSL", Context.db());
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("Id", SqlDbType.Int).Value = movieInCinemaId;

                    var ReturnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    ReturnValue.Direction = ParameterDirection.ReturnValue;
                    sqlCommand.ExecuteNonQuery();
                    int result = Convert.ToInt32(ReturnValue.Value);

                    


                    Context.db().Close();
                    if (result == 1)
                    {
                        MessageBox.Show("Silme İşlemi Başarılı", "Film Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetMoviesInCinemaData();
                    }
                    else
                    {
                        MessageBox.Show("Not Found MSSL", "Film Silme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi","Film Silme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

            }
        }

        public void GetSalons()
        {
            Context.db().Open();

            string sorgu = "select Id,Name,SeatCount,IsStatus from Sallon where IsDelete=0";
            SqlCommand sql = new SqlCommand(sorgu, Context.db());

            SqlDataAdapter sqlData = new SqlDataAdapter(sql);

            DataTable table = new DataTable();
            sqlData.Fill(table);

            salonsDgw.DataSource = table;
            salonsDgw.Columns[0].Visible = false;

            addSalonDgw.DataSource = table;
            addSalonDgw.Columns[0].Visible = false;

            editSalonDgw.DataSource = table;
            editSalonDgw.Columns[0].Visible = false;

            deleteSalonDgw.DataSource = table;
            deleteSalonDgw.Columns[0].Visible = false;
            Context.db().Close();

        }
        public void GetSessions()
        {
            Context.db().Open();

            string sorgu = "select Id,SessionTime,IsStatus from MovieSession where IsDelete=0";
            SqlCommand sql = new SqlCommand(sorgu, Context.db());

            SqlDataAdapter sqlData = new SqlDataAdapter(sql);

            DataTable table = new DataTable();
            sqlData.Fill(table);
            sessionDgw.DataSource = table;
            sessionDgw.Columns[0].Visible = false;

            addSessionDgw.DataSource = table;
            addSessionDgw.Columns[0].Visible = false;

            editSessionsDgw.DataSource = table;
            editSessionsDgw.Columns[0].Visible = false;

            deleteSessionsDgw.DataSource = table;
            deleteSessionsDgw.Columns[0].Visible = false;


            Context.db().Close();

        }
        public void GetLanguages()
        {
            string sorgu = "select Id,Image,Name,IsStatus from Language where IsDelete=0";
            SqlCommand sql = new SqlCommand(sorgu, Context.db());

            SqlDataAdapter sqlData = new SqlDataAdapter(sql);

            DataTable table = new DataTable();
            sqlData.Fill(table);

            table.Columns.Add("icon", Type.GetType("System.Byte[]"));

            foreach (DataRow row in table.Rows)
            {
                row["icon"] = File.ReadAllBytes(IconFolder + row["Image"].ToString());
            }

            languagesDgw.DataSource = table;
            languagesDgw.Columns[0].Visible = false;
            languagesDgw.Columns[1].Visible = false;

            addLanguageDgw.DataSource = table;
            addLanguageDgw.Columns[0].Visible = false;
            addLanguageDgw.Columns[1].Visible = false;

            editLanguageDgw.DataSource = table;
            editLanguageDgw.Columns[0].Visible = false;
            editLanguageDgw.Columns[1].Visible = false;

            deleteLanguageDgw.DataSource = table;
            deleteLanguageDgw.Columns[0].Visible = false;
            deleteLanguageDgw.Columns[1].Visible = false;

            Context.db().Close();

        }

        public void GetMovieType()
        {
            Context.db().Open();

            string sorgu = "select Id,Name from MovieType where IsDelete=0 and IsStatus=1";
            SqlCommand sql = new SqlCommand(sorgu, Context.db());

            SqlDataAdapter sqlData = new SqlDataAdapter(sql);

            DataTable table = new DataTable();
            sqlData.Fill(table);

            addMovieMovieTypeCb.DataSource = table;
            addMovieMovieTypeCb.ValueMember = "Id";
            addMovieMovieTypeCb.DisplayMember = "Name";
            editMovieTypeCb.DataSource = table;
            editMovieTypeCb.ValueMember="Id";
            editMovieTypeCb.DisplayMember = "Name";



            Context.db().Close();
        }

        private void addMovieBtn_Click(object sender, EventArgs e)
        {
            Context.db().Open();

            SqlCommand sqlCommand=new SqlCommand("AddMovie",Context.db());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("Name", SqlDbType.NVarChar, 100).Value = addMovieNameTxt.Text;
            sqlCommand.Parameters.Add("Description",SqlDbType.NText).Value=addMovieDescriptinoRtb.Text;
            sqlCommand.Parameters.Add("Director", SqlDbType.NVarChar, 250).Value = addMovieDirectorTxt.Text;
            sqlCommand.Parameters.Add("Image", SqlDbType.NVarChar, 500).Value = addMovieImageName;
            sqlCommand.Parameters.Add("ReleaseDate",SqlDbType.Date).Value=addMovieReleaseDate.Value;
            sqlCommand.Parameters.Add("MovieTypeId",SqlDbType.Int).Value=Convert.ToInt32(addMovieMovieTypeCb.SelectedValue);
            sqlCommand.Parameters.Add("Status", SqlDbType.Bit).Value = addMovieStatusCb.Checked;


            var ReturnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
            ReturnValue.Direction = ParameterDirection.ReturnValue;
            sqlCommand.ExecuteNonQuery();
            int result = Convert.ToInt32(ReturnValue.Value);

            Context.db().Close();

            if(result == 1)
            {
                
                addMovieImagePb.Image.Save(ImageFolder + addMovieImageName);

                MessageBox.Show("Movie Added Successfull","Movie Add",MessageBoxButtons.OK,MessageBoxIcon.Information);
                GetData();
            }
            else
            {
                MessageBox.Show("An error occurred while adding!", "Movie Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addMovieImagePb_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                addMovieImagePb.ImageLocation=openFileDialog.FileName;
                string[] imageName=openFileDialog.FileName.ToString().Split('\\');
                addMovieImageName =Guid.NewGuid().ToString()+"-"+imageName[imageName.Length - 1].ToString();
                
            }
            else
            {
                MessageBox.Show("Picture Selection Process Canceled.");
            }
        }

        private void deleteMoviesDgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteMovieId = Convert.ToInt32(deleteMoviesDgw.CurrentRow.Cells[0].Value);

            deleteMovieNameTxt.Text = deleteMoviesDgw.CurrentRow.Cells[2].Value.ToString();

            deleteMovieTypeCb.Items.Clear();
            deleteMovieTypeCb.Items.Add(deleteMoviesDgw.CurrentRow.Cells[3].Value);
            deleteMovieTypeCb.SelectedIndex = 0;

            deleteMovieDescriptionRtb.Text = deleteMoviesDgw.CurrentRow.Cells[6].Value.ToString();
            deleteMovieDirectorTxt.Text = deleteMoviesDgw.CurrentRow.Cells[4].Value.ToString();
            deleteMoviePb.ImageLocation = ImageFolder + deleteMoviesDgw.CurrentRow.Cells[1].Value.ToString();
            deleteMovieReleaseDate.Value = Convert.ToDateTime(deleteMoviesDgw.CurrentRow.Cells[5].Value);
            deleteMovieStatusCb.Checked = Convert.ToBoolean(deleteMoviesDgw.CurrentRow.Cells[7].Value);

        }

        private void deleteMovieBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Delete '"+ deleteMovieNameTxt.Text +"' Movie ?",
                                            "Delete Movie",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

            if(dialogResult == DialogResult.Yes)
            {
                Context.db().Open();

                SqlCommand sqlCommand = new SqlCommand("DeleteMovie", Context.db());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("Id",SqlDbType.Int).Value=deleteMovieId;

                var ReturnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.ReturnValue;
                sqlCommand.ExecuteNonQuery();

                

                Context.db().Close();

                int result = Convert.ToInt32(ReturnValue.Value);
                if (result == 1)
                {
                    MessageBox.Show(deleteMovieNameTxt.Text + " Movie Deleted",
                                    "Delete Movie",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    GetData();
                    UnselectDeleteMovie();
                }
                else
                {
                    MessageBox.Show("Not Found Movie",
                                    "Delete Movie",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Deletion Canceled",
                                "Delete Movie",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void deleteMovieUnSelectBtn_Click(object sender, EventArgs e)
        {
            UnselectDeleteMovie();

        }
        public void UnselectEditMovie()
        {
            editMovieId = 0;
            editMovieNameTxt.Clear();
            editMovieDirectorTxt.Clear();
            editMovieDescriptionRtb.Clear();
            editMovieReleaseDate.Value = DateTime.Now;
            editMovieStatusCb.Checked = false;
            editMovieTypeCb.SelectedIndex = -1;
            editMoviePb.Image = null;
        }
        public void UnselectDeleteMovie()
        {
            deleteMovieId = 0;
            deleteMovieNameTxt.Clear();
            deleteMovieDirectorTxt.Clear();
            deleteMovieDescriptionRtb.Clear();
            deleteMovieReleaseDate.Value = DateTime.Now;
            deleteMovieStatusCb.Checked = false;
            deleteMovieTypeCb.SelectedIndex = -1;
            deleteMovieTypeCb.Items.Clear();
            deleteMoviePb.Image = null;
        }

        private void editMovieUnSelectBtn_Click(object sender, EventArgs e)
        {
            UnselectEditMovie();
        }
        private void editMovieBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();

            dialogResult = MessageBox.Show("Do you edit the movie?","Edit Movie",
                                            MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                Context.db().Open();

                SqlCommand sqlCommand = new SqlCommand("EditMovie", Context.db());

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("Id", SqlDbType.Int).Value = editMovieId;
                sqlCommand.Parameters.Add("Name", SqlDbType.NVarChar,100).Value = editMovieNameTxt.Text;
                sqlCommand.Parameters.Add("Description", SqlDbType.NText).Value = editMovieDescriptionRtb.Text;
                sqlCommand.Parameters.Add("Director", SqlDbType.NVarChar,250).Value = editMovieDirectorTxt.Text;
                if (editMovieImageName == "")
                {
                    sqlCommand.Parameters.Add("Image", SqlDbType.NVarChar,500).Value = editSelectImageName;
                }
                else
                {
                    sqlCommand.Parameters.Add("Image", SqlDbType.NVarChar,500).Value = editMovieImageName;
                    editMoviePb.Image.Save(ImageFolder + editMovieImageName);
                }
                sqlCommand.Parameters.Add("ReleaseDate", SqlDbType.Date).Value = editMovieReleaseDate.Value;
                sqlCommand.Parameters.Add("MovieTypeId", SqlDbType.Int).Value = Convert.ToInt32(editMovieTypeCb.SelectedValue);
                sqlCommand.Parameters.Add("Status", SqlDbType.Bit).Value = Convert.ToBoolean(editMovieStatusCb.Checked);


                var returnValue = sqlCommand.Parameters.Add("@ReturnVal",SqlDbType.Int);

                returnValue.Direction = ParameterDirection.ReturnValue;

                sqlCommand.ExecuteNonQuery();

                int result = Convert.ToInt32(returnValue.Value);

                if (result==1)
                {
                    MessageBox.Show("Movie Edit Successfull");
                }
                else
                {
                    MessageBox.Show("Not Found Movie","Edit Movie",
                        MessageBoxButtons.OK,MessageBoxIcon.Warning);

                }

                Context.db().Close();
                GetData();
            }
            else
            {
                MessageBox.Show("Editing Canceled","Edit Movie",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void editMoviesDgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editMovieId = Convert.ToInt32(editMoviesDgw.CurrentRow.Cells[0].Value);

            editMovieNameTxt.Text = editMoviesDgw.CurrentRow.Cells[2].Value.ToString();

            editSelectImageName = editMoviesDgw.CurrentRow.Cells[1].Value.ToString();
            

            editMovieTypeCb.SelectedValue= editMoviesDgw.CurrentRow.Cells[8].Value.ToString();

            editMovieDescriptionRtb.Text = editMoviesDgw.CurrentRow.Cells[6].Value.ToString();
            editMovieDirectorTxt.Text = editMoviesDgw.CurrentRow.Cells[4].Value.ToString();
            editMoviePb.ImageLocation = ImageFolder + editMoviesDgw.CurrentRow.Cells[1].Value.ToString();
            editMovieReleaseDate.Value = Convert.ToDateTime(editMoviesDgw.CurrentRow.Cells[5].Value);
            editMovieStatusCb.Checked = Convert.ToBoolean(editMoviesDgw.CurrentRow.Cells[7].Value);
        }

        private void editMoviePb_Click(object sender, EventArgs e)
        {
           OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog()==DialogResult.OK)
            {
                editMoviePb.ImageLocation= openFileDialog.FileName;
                string[] ImageName = openFileDialog.FileName.ToString().Split('\\');
                editMovieImageName = Guid.NewGuid().ToString() + "-" + ImageName[ImageName.Length - 1].ToString();
                
                
            }
            else
            {
                MessageBox.Show("Seçim Başarısız");
                editMovieImageName = "";
            }
        }

        private void addSalonBtn_Click(object sender, EventArgs e)
        {
            Context.db().Open();

            SqlCommand sqlCommand = new SqlCommand("AddSallon", Context.db());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("Name", SqlDbType.NVarChar, 100).Value = addSalonNameTxt.Text;
            sqlCommand.Parameters.Add("SeatCount", SqlDbType.Int).Value = addSalonSeatCountNud.Text;
            sqlCommand.Parameters.Add("Status", SqlDbType.Bit).Value = addSalonStatusCb.Checked;


            var ReturnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
            ReturnValue.Direction = ParameterDirection.ReturnValue;
            sqlCommand.ExecuteNonQuery();
            int result = Convert.ToInt32(ReturnValue.Value);

            Context.db().Close();

            if (result == 1)
            {


                MessageBox.Show("Salon Added Successfull", "Salon Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetSalons();
            }
            else
            {
                MessageBox.Show("An error occurred while adding!", "Salon Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editSalonUnSelectBtn_Click(object sender, EventArgs e)
        {
            editSalonNameTxt.Clear();
            editSalonSeatCountNud.Value = 0;
            editSalonStatusCb.Checked = false;
            editSalonId = 0;
        }
       
        private void editSalonDgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editSalonNameTxt.Text = editSalonDgw.CurrentRow.Cells[1].Value.ToString();
            editSalonSeatCountNud.Value = Convert.ToInt32(editSalonDgw.CurrentRow.Cells[2].Value);
            editSalonStatusCb.Checked = Convert.ToBoolean(editSalonDgw.CurrentRow.Cells[3].Value);
            editSalonId = Convert.ToInt32(editSalonDgw.CurrentRow.Cells[0].Value); 
        }

        private void editSalonBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();

            dialogResult = MessageBox.Show("Do you edit the saoln?", "Edit Salon",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                Context.db().Open();

                SqlCommand sqlCommand = new SqlCommand("EditSallon", Context.db());

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("Id", SqlDbType.Int).Value = editSalonId;
                sqlCommand.Parameters.Add("Name", SqlDbType.NVarChar, 100).Value = editSalonNameTxt.Text;
                sqlCommand.Parameters.Add("SeatCount", SqlDbType.Int).Value = editSalonSeatCountNud.Value;
                sqlCommand.Parameters.Add("Status", SqlDbType.Bit).Value = Convert.ToBoolean(editSalonStatusCb.Checked);


                var returnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);

                returnValue.Direction = ParameterDirection.ReturnValue;

                sqlCommand.ExecuteNonQuery();

                int result = Convert.ToInt32(returnValue.Value);

                if (result == 1)
                {
                    MessageBox.Show("Salon Edit Successfull");
                }
                else
                {
                    MessageBox.Show("Not Found Salon", "Edit Salon",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                Context.db().Close();
                GetSalons();
            }
            else
            {
                MessageBox.Show("Editing Canceled", "Edit Salon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteUnSelectSalonBtn_Click(object sender, EventArgs e)
        {
            UnselectDeleteSalon();
        }
        public void UnselectDeleteSalon()
        {
            deleteSalonNameTxt.Clear();
            deleteSalonSeatCountNud.Value = 0;
            deleteSalonStatusCb.Checked = false;
            deleteSalonId = 0;
        }
        private void deleteSalonDgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            deleteSalonNameTxt.Text = deleteSalonDgw.CurrentRow.Cells[1].Value.ToString();
            deleteSalonSeatCountNud.Value = Convert.ToInt32(deleteSalonDgw.CurrentRow.Cells[2].Value);
            deleteSalonStatusCb.Checked = Convert.ToBoolean(deleteSalonDgw.CurrentRow.Cells[3].Value);
            deleteSalonId = Convert.ToInt32(deleteSalonDgw.CurrentRow.Cells[0].Value);
        }

        private void deleteSalonBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Delete '" + deleteSalonNameTxt.Text + "' Salon ?",
                                            "Delete Salon",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Context.db().Open();

                SqlCommand sqlCommand = new SqlCommand("DeleteSallon", Context.db());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("Id", SqlDbType.Int).Value = deleteSalonId;

                var ReturnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.ReturnValue;
                sqlCommand.ExecuteNonQuery();



                Context.db().Close();

                int result = Convert.ToInt32(ReturnValue.Value);
                if (result == 1)
                {
                    MessageBox.Show(deleteSalonNameTxt.Text + " Salon Deleted",
                                    "Delete Salon",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    GetSalons();
                    UnselectDeleteSalon();
                }
                else
                {
                    MessageBox.Show("Not Found Salon",
                                    "Delete Salon",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Deletion Canceled",
                                "Delete Salon",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void addSessionBtn_Click(object sender, EventArgs e)
        {
            Context.db().Open();

            SqlCommand sqlCommand = new SqlCommand("AddSession", Context.db());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("SessionTime", SqlDbType.Time).Value = addSessionTimeDtp.Value.ToString("HH:mm");
            sqlCommand.Parameters.Add("Status", SqlDbType.Bit).Value = addSessionStatusCb.Checked;


            var ReturnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
            ReturnValue.Direction = ParameterDirection.ReturnValue;
            sqlCommand.ExecuteNonQuery();
            int result = Convert.ToInt32(ReturnValue.Value);

            Context.db().Close();

            if (result == 1)
            {
                MessageBox.Show("Session Added Successfull", "Session Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetSessions();
            }
            else
            {
                MessageBox.Show("An error occurred while adding!", "Session Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editSessionUnSelectBtn_Click(object sender, EventArgs e)
        {
            editSessionStatusCb.Checked = false;
            editSessionTimeDtp.Value=Convert.ToDateTime("00:00");
            editSessionId = 0;
        }

        private void deleteSessionUnSeletcBtn_Click(object sender, EventArgs e)
        {
            UnselectDeleteSession();
        }
        public void UnselectDeleteSession()
        {
            deleteSessionStatusCb.Checked = false;
            deleteSessionTimeDtp.Value = Convert.ToDateTime("00:00");
            deleteSessionId = 0;
        }
        private void editSessionBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();

            dialogResult = MessageBox.Show("Do you edit the session?", "Edit Session",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                Context.db().Open();

                SqlCommand sqlCommand = new SqlCommand("EditSession", Context.db());

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("Id", SqlDbType.Int).Value = editSessionId;
                sqlCommand.Parameters.Add("SessionTime", SqlDbType.Time).Value = editSessionTimeDtp.Value.ToString("HH:mm");
                sqlCommand.Parameters.Add("Status", SqlDbType.Bit).Value = Convert.ToBoolean(editSessionStatusCb.Checked);


                var returnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);

                returnValue.Direction = ParameterDirection.ReturnValue;

                sqlCommand.ExecuteNonQuery();

                int result = Convert.ToInt32(returnValue.Value);

                if (result == 1)
                {
                    MessageBox.Show("Session Edit Successfull");
                }
                else
                {
                    MessageBox.Show("Not Found Session", "Edit Session",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                Context.db().Close();
                GetSessions();
            }
            else
            {
                MessageBox.Show("Editing Canceled", "Edit Session", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void editSessionsDgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string time = editSessionsDgw.CurrentRow.Cells[1].Value.ToString().Substring(0, 5);
            editSessionTimeDtp.Value = Convert.ToDateTime(time);
            editSessionStatusCb.Checked = Convert.ToBoolean(editSessionsDgw.CurrentRow.Cells[2].Value);
            editSessionId = Convert.ToInt32(editSessionsDgw.CurrentRow.Cells[0].Value);
        }

        private void deleteSessionsDgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string time = deleteSessionsDgw.CurrentRow.Cells[1].Value.ToString().Substring(0, 5);
            deleteSessionTimeDtp.Value = Convert.ToDateTime(time);
            deleteSessionStatusCb.Checked = Convert.ToBoolean(deleteSessionsDgw.CurrentRow.Cells[2].Value);
            deleteSessionId = Convert.ToInt32(deleteSessionsDgw.CurrentRow.Cells[0].Value);
        }

        private void deleteSessionBtn_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Delete '" + deleteSessionTimeDtp.Text + "' Session ?",
                                            "Delete Session",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Context.db().Open();

                SqlCommand sqlCommand = new SqlCommand("DeleteSession", Context.db());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("Id", SqlDbType.Int).Value = deleteSessionId;

                var ReturnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.ReturnValue;
                sqlCommand.ExecuteNonQuery();



                Context.db().Close();

                int result = Convert.ToInt32(ReturnValue.Value);
                if (result == 1)
                {
                    MessageBox.Show(deleteSessionTimeDtp.Text + " Session Deleted",
                                    "Delete Session",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    GetSessions();
                    UnselectDeleteSession();
                }
                else
                {
                    MessageBox.Show("Not Found Session",
                                    "Delete Session",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Deletion Canceled",
                                "Delete Session",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void addLanguagePb_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                addLanguagePb.ImageLocation = openFileDialog.FileName;
                string[] imageName = openFileDialog.FileName.ToString().Split('\\');
                addLanguageImageName = Guid.NewGuid().ToString() + "-" + imageName[imageName.Length - 1].ToString();

            }
            else
            {
                MessageBox.Show("Picture Selection Process Canceled.");
            }
        }

        private void addLanguageBtn_Click(object sender, EventArgs e)
        {
            Context.db().Open();

            SqlCommand sqlCommand = new SqlCommand("AddLanguage", Context.db());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("Name", SqlDbType.NVarChar, 100).Value = addLanguageNameTxt.Text;
            sqlCommand.Parameters.Add("Image", SqlDbType.NVarChar, 500).Value = addLanguageImageName;
            sqlCommand.Parameters.Add("Status", SqlDbType.Bit).Value = addLanguageStatusCb.Checked;


            var ReturnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
            ReturnValue.Direction = ParameterDirection.ReturnValue;
            sqlCommand.ExecuteNonQuery();
            int result = Convert.ToInt32(ReturnValue.Value);

            Context.db().Close();

            if (result == 1)
            {

                addLanguagePb.Image.Save(IconFolder + addLanguageImageName);

                MessageBox.Show("Language Added Successfull", "Language Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetLanguages();
            }
            else
            {
                MessageBox.Show("An error occurred while adding!", "Language Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void editLanguageDgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editLanguageId = Convert.ToInt32(editLanguageDgw.CurrentRow.Cells[0].Value);

            editLanguageNameTxt.Text = editLanguageDgw.CurrentRow.Cells[2].Value.ToString();

            editLanguageImageName = editLanguageDgw.CurrentRow.Cells[1].Value.ToString();

            editLanguagePb.ImageLocation = IconFolder + editLanguageDgw.CurrentRow.Cells[1].Value.ToString();
            editLanguageStatusCb.Checked = Convert.ToBoolean(editLanguageDgw.CurrentRow.Cells[3].Value);

        }

        private void deleteLanguageDgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteLanguageId = Convert.ToInt32(deleteLanguageDgw.CurrentRow.Cells[0].Value);

            deleteLanguageNameTxt.Text = deleteLanguageDgw.CurrentRow.Cells[2].Value.ToString();

            deleteLanguagePb.ImageLocation = IconFolder + deleteLanguageDgw.CurrentRow.Cells[1].Value.ToString();
            deleteLanguageStatusCb.Checked = Convert.ToBoolean(deleteLanguageDgw.CurrentRow.Cells[3].Value);

        }

        private void editUnSelectLanguageBtn_Click(object sender, EventArgs e)
        {
            editLanguageStatusCb.Checked = false;
            editLanguageNameTxt.Clear();
            editLanguageId = 0;
            editLanguagePb.Image = null;
        }

        private void deleteUnSelectLanguageBtn_Click(object sender, EventArgs e)
        {
            UnSelectDeletelanguage();
        }
        public void UnSelectDeletelanguage()
        {
            deleteLanguageStatusCb.Checked = false;
            deleteLanguageNameTxt.Clear();
            deleteLanguageId = 0;
            deleteLanguagePb.Image = null;
        }

        private void editLanguageBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();

            dialogResult = MessageBox.Show("Do you edit the language?", "Edit Language",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                Context.db().Open();

                SqlCommand sqlCommand = new SqlCommand("EditLanguage", Context.db());

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("Id", SqlDbType.Int).Value = editLanguageId;
                sqlCommand.Parameters.Add("Name", SqlDbType.NVarChar, 100).Value = editLanguageNameTxt.Text;
                if (editLanguageImageName == "")
                {
                    sqlCommand.Parameters.Add("Image", SqlDbType.NVarChar, 500).Value = editSelectLanguageImageName;
                }
                else
                {
                    sqlCommand.Parameters.Add("Image", SqlDbType.NVarChar, 500).Value = editLanguageImageName;
                    editLanguagePb.Image.Save(IconFolder + editLanguageImageName);
                }
                sqlCommand.Parameters.Add("Status", SqlDbType.Bit).Value = Convert.ToBoolean(editLanguageStatusCb.Checked);


                var returnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);

                returnValue.Direction = ParameterDirection.ReturnValue;

                sqlCommand.ExecuteNonQuery();

                int result = Convert.ToInt32(returnValue.Value);

                if (result == 1)
                {
                    MessageBox.Show("Language Edit Successfull");
                }
                else
                {
                    MessageBox.Show("Not Found Language", "Edit Language",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                Context.db().Close();
                GetLanguages();
            }
            else
            {
                MessageBox.Show("Editing Canceled", "Edit Language", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void editLanguagePb_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                editLanguagePb.ImageLocation = openFileDialog.FileName;
                string[] imageName = openFileDialog.FileName.ToString().Split('\\');
                editLanguageImageName = Guid.NewGuid().ToString() + "-" + imageName[imageName.Length - 1].ToString();

            }
            else
            {
                MessageBox.Show("Picture Selection Process Canceled.");
            }
        }

        private void deleteLanguageBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Delete '" + deleteLanguageNameTxt.Text + "' Language ?",
                                            "Delete Language",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Context.db().Open();

                SqlCommand sqlCommand = new SqlCommand("DeleteLanguage", Context.db());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("Id", SqlDbType.Int).Value = deleteLanguageId;

                var ReturnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.ReturnValue;

                sqlCommand.ExecuteNonQuery();



                Context.db().Close();

                int result = Convert.ToInt32(ReturnValue.Value);
                if (result == 1)
                {
                    MessageBox.Show(deleteLanguageNameTxt.Text + " Language Deleted",
                                    "Delete Language",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    GetLanguages();
                    UnSelectDeletelanguage();
                }
                else
                {
                    MessageBox.Show("Not Found Language",
                                    "Delete Language",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Deletion Canceled",
                                "Delete Language",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void addMovieInCinemaBtn_Click(object sender, EventArgs e)
        {
            AddMSSLForm addMSSLForm = new AddMSSLForm(this);
            addMSSLForm.ShowDialog();
        }

        private void label47_Click(object sender, EventArgs e)
        {

        }
    }
}
