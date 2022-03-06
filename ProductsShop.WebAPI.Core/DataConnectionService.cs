using Microsoft.Data.SqlClient;
using System;

namespace ProductsShop.WebAPI.Core
{
    public class DataConnectionService
    {
        public static string SqlConnectionString
        {
            get
            {
                return new SqlConnectionStringBuilder()
                {
                    DataSource = "(localdb)\\MSSQLLocalDB",
                    InitialCatalog = "ProductsShop"
                }
                .ConnectionString;
            }
        }
    }
}
