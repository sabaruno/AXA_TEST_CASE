using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using WebAPI.DTO;
using WebAPI.Model;

namespace WebAPI.Infrastructure
{
    public class ProductRepo
    {
        private SqlConnection connection;
        public ProductRepo(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public void Dispose()
        {
            if (connection == null)
            {
                connection.Dispose();
                connection = null;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {

            var sql = "SELECT * FROM [Product]";


            return await connection.QueryAsync<Product>(sql);
        }

        public async Task<Product> GetProduct(int Id)
        {

            var sql = "SELECT * FROM [Product] WHERE [ID] = @ID";


            return await connection.QueryFirstOrDefaultAsync<Product>(sql, new { ID = Id });
        }

        public async Task<bool> InsertProduct(ProductRequest req)
        {
            var createdAt = DateTime.Now;

            var sql = "INSERT INTO [Product] (Name, Price, CreatedAt) VALUES (@name,@price,@createdAt)";
            var result = connection.Execute(sql, new { name = req.Name, price = req.Price, createdAt = createdAt });

            return result > 0;
        }

        public async Task<bool> UpdateProduct(ProductRequest req)
        {

            var sql = "UPDATE [Product] SET Name = @name, Price = @price WHERE ID = @id";
            var result = connection.Execute(sql, new { name = req.Name, price = req.Price, id = req.ID });

            return result > 0;
        }
    }
}
