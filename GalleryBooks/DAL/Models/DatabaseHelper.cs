using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            string connectionString = builder.Build().GetConnectionString("EmpCon");
            return connectionString;
        }
    }
}
