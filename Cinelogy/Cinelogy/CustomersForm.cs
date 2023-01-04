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
    public partial class CustomersForm : Form
    {
        public static int id = 0;
      
        public CustomersForm()
        {
            InitializeComponent();
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            GetCustomerList();
        }
        public void GetCustomerList()
        {
            Context.db().Open();

            string sorgu = "select Customer.Id, Customer.Name,Customer.Surname,CustomerType.Name as Type, Customer.Phone,Customer.Balance from Customer inner join CustomerType on(Customer.CustomerTypeId=CustomerType.Id) where Customer.IsDelete=0";

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, Context.db());

            DataTable dt = new DataTable();
            sqlData.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            Context.db().Close();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            
            Context.db().Open();

            string sorgu = "select Customer.Name,Customer.Surname,Customer.Balance,Customer.Email,Customer.Phone,Customer.RegisterDate,Customer.IsStatus as Status,CustomerType.Name as Type,CustomerType.Rate from Customer inner join CustomerType on (Customer.CustomerTypeId=CustomerType.Id) where Customer.Id=" + id;
            
            SqlCommand sqlCommand = new SqlCommand(sorgu, Context.db());

            SqlDataReader sqlData = sqlCommand.ExecuteReader();

            while (sqlData.Read())
            {
                cNameLbl.Text = sqlData["Name"].ToString();
                cSurnameLbl.Text = sqlData["Surname"].ToString();
                cBalanceLbl.Text = sqlData["Balance"].ToString()+" TL";
                cEmailLbl.Text = sqlData["Email"].ToString();
                cPhoneLbl.Text = sqlData["Phone"].ToString();
                cRegisterLbl.Text = sqlData["RegisterDate"].ToString();
                cTypeLbl.Text = sqlData["Type"].ToString();
                cRateLbl.Text = sqlData["Rate"].ToString()+" %";

                cStatusLbl.Text= sqlData["Status"].ToString()=="True"?"Active":"Passive";
                panel3.BackColor= sqlData["Status"].ToString() == "True" ? Color.Green : Color.Red;
            }
            Context.db().Close();
        }

        private void customerDeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult deleteDialog = new DialogResult();

            deleteDialog=MessageBox.Show("Delete Customer?", 
                                        "Delete Customer",
                                        MessageBoxButtons.YesNo, 
                                        MessageBoxIcon.Question);

            if (deleteDialog == DialogResult.Yes)
            {
                Context.db().Open();

                SqlCommand deleteControl=new SqlCommand("DeleteCusomer",Context.db());
                deleteControl.CommandType = CommandType.StoredProcedure;
                deleteControl.Parameters.Add("Id",SqlDbType.Int).Value=id;

                var returnValue = deleteControl.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                deleteControl.ExecuteNonQuery();

                int result=Convert.ToInt32(returnValue.Value);


                Context.db().Close();

                if (result == 1)
                {
                    MessageBox.Show("Customer Deletion Successful",
                               "Delete Customer",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                    GetCustomerList();
                }
                else
                {
                    MessageBox.Show("Customer Not Found",
                               "Delete Customer",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Customer Deletion Canceled",
                                "Delete Customer",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerEdit customerEdit = new CustomerEdit(this);
             
            customerEdit.ShowDialog();
           
        }

      
    }
}
