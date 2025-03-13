using System.Data.SqlClient;
using System.Threading.Tasks;
using WebAPI.Model;
using Dapper;

namespace AXA_TEST_CASE.Infrastructure
{
    public class AuthRepo
    {
        private SqlConnection connection;
        public AuthRepo(IConfiguration configuration) 
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public void Dispose()
        {
            if(connection == null)
            {
                connection.Dispose();
                connection = null;
            }
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var accountCount = await connection.ExecuteScalarAsync<int>(
                    "SELECT COUNT(1) FROM [UserAccount] WHERE [Email] = @email", new { email = email }
                );
            if (accountCount > 0) return false;

            var sql = "INSERT INTO [UserAccount] (Email, Password) VALUES (@email,@password)";
            var result = connection.Execute(sql, new { email = email, password = password });

            return result > 0; 
        }

        public async Task<UserAccount> FindUserByEmail(string email)
        {

            var sql = "SELECT * FROM [UserAccount] WHERE [Email] = @email";


            return await connection.QueryFirstOrDefaultAsync<UserAccount>(sql,new { email = email});
        }

    }
}
