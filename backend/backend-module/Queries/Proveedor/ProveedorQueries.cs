using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewmodel;

namespace Queries.Proveedor
{
    public class ProveedorQueries : iProveedorQueries
    {
        private readonly string _connectionString;
        public ProveedorQueries(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];

        }

        public async Task<IEnumerable<ProveedorViewModel>> GetAll()
        {
            IEnumerable<ProveedorViewModel> result = new List<ProveedorViewModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<ProveedorViewModel>("[dbo].[USP_Sel_Proveedor]", commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
