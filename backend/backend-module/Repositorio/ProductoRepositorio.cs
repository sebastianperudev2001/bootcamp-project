using Dapper;
using Microsoft.Extensions.Configuration;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    
    
    public class ProductoRepositorio : iProductoRepositorio
    {
        private readonly string _connectionString;


        public ProductoRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<int> Create(Producto producto)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@id", producto.id);
            parameters.Add("@name", producto.name);
            parameters.Add("@precio_unitario", producto.precio_unitario);
            parameters.Add("@categoria", producto.categoria);
            parameters.Add("@proveedor", producto.proveedor);
            parameters.Add("@cantidad", producto.cantidad);


            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[USP_Ins_Producto]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[USP_Delete_Producto]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<int> Update(Producto producto)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@id", producto.id);
            parameters.Add("@name", producto.name);
            parameters.Add("@precio_unitario", producto.precio_unitario);
            parameters.Add("@categoria", producto.categoria);
            parameters.Add("@proveedor", producto.proveedor);
            parameters.Add("@cantidad", producto.cantidad);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[USP_Update_Producto]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
