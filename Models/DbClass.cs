using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyVidly.Models.Context;
using System.IO;

namespace MyVidly.Models
{
    public static class DbContextHelper
    {

        public static DbContextOptions<MyVidlyDbContext> GetDbContextOptions()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            return new DbContextOptionsBuilder<MyVidlyDbContext>()
                  .UseSqlServer(new SqlConnection(configuration.GetConnectionString("local"))).Options;

        }
    }
}
