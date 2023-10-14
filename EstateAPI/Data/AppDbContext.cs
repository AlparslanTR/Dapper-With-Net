﻿using Microsoft.Data.SqlClient;
using System.Data;

namespace EstateAPI.Data
{
    public class AppDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MsSql");
        }


        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    }
}
