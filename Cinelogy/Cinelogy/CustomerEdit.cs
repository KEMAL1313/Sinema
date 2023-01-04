using Cinelogy.DataAccessLayer;
using Cinelogy.Model;
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
    public partial class CustomerEdit : Form
    {
        List<CustomerType> customerTypeList = new List<CustomerType>();
        public int id = CustomersForm.id;


        CustomersForm customersForm;
        public CustomerEdit(CustomersForm customersForm1)
        {
            InitializeComponent();
            customersForm = customersForm1;
        }

        private void CustomerEdit_Load(object sender, EventArgs e)
        {
            GetCustomer();
            GetCustomerType();
        }

        public void GetCustomer()
        {
            Context.db().Open();

            string sorgu = "select Customer.Name,Customer.Surname,Customer.Balance,Customer.Email,Customer.Phone,Customer.RegisterDate,Customer.IsStatus as Status,CustomerType.Name as Type,CustomerType.Rate,CustomerType.Id as CId from Customer inner join CustomerType on (Customer.CustomerTypeId=CustomerType.Id) where Customer.Id=" + id;

            SqlCommand sqlCommand = new SqlCommand(sorgu, Context.db());

            SqlDataReader sqlData = sqlCommand.ExecuteReader();

            while (sqlData.Read())
            {
                cNameTxt.Text = sqlData["Name"].ToString();
                cSurnameTxt.Text = sqlData["Surname"].ToString();
                cBalanceNud.Value = Convert.ToInt32(sqlData["Balance"]);
                cEmailTxt.Text = sqlData["Email"].ToString();
                cPhoneTxt.Text = sqlData["Phone"].ToString();
                cRegisterLbl.Text = sqlData["RegisterDate"].ToString();

                customerTypeList.Clear();

                CustomerType customerType = new CustomerType();
                customerType.Name = sqlData["Type"].ToString();
                customerType.Rate = Convert.ToDouble(sqlData["Rate"]);
                customerType.Id = Convert.ToInt32(sqlData["CId"]);
                customerTypeList.Add(customerType);

                cStatusCb.Checked = Convert.ToBoolean(sqlData["Status"]);
            }

            Context.db().Close();
        }

        public void GetCustomerType()
        {
            Context.db().Open();

            string sorgu = "Select * from CustomerType where IsDelete=0 and IsStatus=1";

            SqlCommand sqlCommand=new SqlCommand(sorgu,Context.db());
            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                CustomerType customerType = new CustomerType()
                {
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Name = dataReader["Name"].ToString(),
                    Rate = Convert.ToDouble(dataReader["Rate"]),
                    IsDelete = Convert.ToBoolean(dataReader["IsDelete"]),
                    IsStatus = Convert.ToBoolean(dataReader["IsStatus"])
                };
                customerTypeList.Add(customerType);
            }

            Context.db().Close();

            cTypeCb.Items.Clear();

            cTypeCb.DataSource = customerTypeList;

            cTypeCb.ValueMember = "Id";
            cTypeCb.DisplayMember = "Name";

            cTypeCb.SelectedIndex = 0;
        }

        private void editCustomerBtn_Click(object sender, EventArgs e)
        {
            Context.db().Open();

            SqlCommand sql=new SqlCommand("EditCustomer",Context.db());
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.Add("Id", SqlDbType.Int).Value = id;
            sql.Parameters.Add("Name", SqlDbType.NVarChar,100).Value = cNameTxt.Text;
            sql.Parameters.Add("Surname", SqlDbType.NVarChar,100).Value = cSurnameTxt.Text;
            sql.Parameters.Add("Email", SqlDbType.NVarChar,250).Value = cEmailTxt.Text;
            sql.Parameters.Add("Phone", SqlDbType.NVarChar,14).Value = cPhoneTxt.Text;
            sql.Parameters.Add("Balance", SqlDbType.Float).Value = cBalanceNud.Value;
            sql.Parameters.Add("CustomerTypeId", SqlDbType.Int).Value = Convert.ToInt32(cTypeCb.SelectedValue);
            sql.Parameters.Add("Status", SqlDbType.Bit).Value = cStatusCb.Checked;

            var returnValue = sql.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnValue.Direction = ParameterDirection.ReturnValue;
            sql.ExecuteNonQuery();
            int result = Convert.ToInt32(returnValue.Value);

            if(result == 1)
            {
                MessageBox.Show("Customer Edited Successful");
            }
            else
            {
                MessageBox.Show("Not Found Customer");
            }

            Context.db().Close();

         

        }

        private void CustomerEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            customersForm.GetCustomerList();

        }

    }
}
