using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewmodel;

namespace Queries.Categoria
{
    public class CategoriaQueries : iCategoriaQueries
    {
        private readonly string _connectionString; 

        public CategoriaQueries(IConfiguration configuration) 
        {
            _connectionString = configuration["ConnectionStrings:SQL"]; 
        }

        public async Task<IEnumerable<CategoriaViewModel>> GetAll()
        {
            IEnumerable<CategoriaViewModel> result = new List<CategoriaViewModel>();
            using (var connection = new SqlConnection(_connectionString)) 
            {
                result = await connection.QueryAsync<CategoriaViewModel>("USP_Sel_Categoria", commandType: System.Data.CommandType.StoredProcedure);
            }
            return result; 
        }
    }
}
