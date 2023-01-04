using Cinelogy.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinelogy.ApplicationManagement
{
    public class UserProccess
    {
        public static string Name { get; set; }
        public static string Surname { get; set; }
        public static string Image { get; set; }
        public static int Id { get; set; }
        
        public UserProccess()
        {
            UserNameSurame();
        }
        private void UserNameSurame()
        {
            
            Context.db().Open();

            SqlCommand sql = new SqlCommand("select * from Users where Id="+Id,Context.db());

            SqlDataReader reader = sql.ExecuteReader();

            while (reader.Read())
            {
               
                Name = reader["Name"].ToString();
                Surname = reader["Surname"].ToString();
                Image = reader["Image"].ToString();
            }
            Context.db().Close();
          
        }

       
    }
}
