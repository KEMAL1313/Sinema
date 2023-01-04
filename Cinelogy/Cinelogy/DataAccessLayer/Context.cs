using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinelogy.DataAccessLayer
{
    public class Context
    {
        private static SqlConnection database = new SqlConnection(@"Data Source=(localdb)\MsSqlLocalDb; initial Catalog=CinelogyDb; integrated security=true");

        public static SqlConnection db()
        {
            return database;
        }
    }
}
