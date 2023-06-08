using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top10Words.DAL.EFCore
{
    public class Top10WordsContextFactory : IDesignTimeDbContextFactory<Top10WordsContext>
    {
        public Top10WordsContextFactory()
        {

        }

        private readonly IConfiguration Configuration;
        private IDbConnection DbConnection { get; set; }
        public Top10WordsContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Top10WordsContext CreateDbContext(string[] args)
        {
            DbConnection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));

            var optionsBuilder = new DbContextOptionsBuilder<Top10WordsContext>();
            optionsBuilder.UseSqlServer(DbConnection.ToString());

            return new Top10WordsContext(optionsBuilder.Options);
        }
    }
}
