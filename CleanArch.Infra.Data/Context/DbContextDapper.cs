using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace CleanArch.Infra.Data.Context
{
    public class DbContextDapper : IDisposable
    {
        public IDbConnection Connection { get; }
        public DbContextDapper(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration
                .GetConnectionString("DefaultConnection"));

            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
       
    }
}
