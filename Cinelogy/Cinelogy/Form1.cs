using Cinelogy.ApplicationManagement;
using Cinelogy.DataAccessLayer;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Cinelogy
{
    public partial class Form1 : Form
    {
        string loginMessage = "";
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
        

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Context.db().Open();

            SqlCommand loginControl = new SqlCommand("UserLogin", Context.db());
            loginControl.CommandType = CommandType.StoredProcedure;
            loginControl.Parameters.Add("UserName", SqlDbType.NVarChar, 250).Value = userNameTxt.Text;
            loginControl.Parameters.Add("Password", SqlDbType.NVarChar, 250).Value = passwordTxt.Text;


            var returnValue = loginControl.Parameters.Add("@LoginControl",SqlDbType.Int);
            returnValue.Direction = ParameterDirection.ReturnValue;

            loginControl.ExecuteNonQuery();

            var resualt=returnValue.Value;

            Context.db().Close();
            loginMessage = resualt.ToString() == "0" ? "Login Failed": "Login Success";

            if(resualt.ToString() != "0")
            {
                MessageBox.Show(loginMessage,"Login System",MessageBoxButtons.OK,MessageBoxIcon.Information);
                MainMenu mainMenu = new MainMenu();
               
                //mainMenu.id = Convert.ToInt32(resualt);
                UserProccess.Id= Convert.ToInt32(resualt);

                mainMenu.Show();
                this.Hide();
            
            }
            else
            {
                MessageBox.Show(loginMessage, "Login System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}