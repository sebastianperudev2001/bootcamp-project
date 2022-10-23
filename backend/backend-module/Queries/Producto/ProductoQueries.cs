using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewmodel;

namespace Queries.Producto
{
    public class ProductoQueries : iProductoQueries
    {
        private readonly string _connectionString;
        public ProductoQueries(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];

        }
        public async Task<IEnumerable<ProductoViewModel>> GetAll()
        {
            IEnumerable<ProductoViewModel> result = new List<ProductoViewModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<ProductoViewModel>("[dbo].[USP_Sel_Producto]", commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<ProductoByIdViewModel> GetById(int id)
        {
            var personByIdViewModel = new ProductoByIdViewModel();

            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                personByIdViewModel = await connection.QueryFirstOrDefaultAsync<ProductoByIdViewModel>("[dbo].[USP_Sel_Producto_ById]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return personByIdViewModel;
        }
    }
}
