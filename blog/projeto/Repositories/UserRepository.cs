
using Dapper;
using Microsoft.Data.SqlClient;
using Projeto.Model;

namespace Projeto.Repositories
{

    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;
        public UserRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public IEnumerable<User> GetWithRoles()
        {
            const string sql = @"SELECT 
                            u.[Name], r.[Name]
                        FROM 
                            [User] u
                        RIGHT JOIN
                            [UserRole] ur
                        ON 
                            ur.UserId = u.Id
                        LEFT JOIN
                            [Role] r
                        ON
                            ur.UserId = r.Id;
            ";

            var users = new List<User>(); // Essa lista será retornada no final da função

            var items = _connection.Query<User, Role, User>(sql, (user, role) =>
            {
                var usr = users.Where(users => users.Id == role.Id).FirstOrDefault(); // Objeto auxiliar

                if (usr == null) // -> Só vai executar na primeira vez, após isso a lista 'users' (fora do escopo) já vai ter um objeto
                {
                    usr = user;
                    usr.Roles = usr.Roles ?? new List<Role>(); // -> Se roles for null, ela vai receber uma lista de Role vazia, senão, recebe ela mesma
                    users.Add(usr); // -> Adiciona o usuário na lista 'users'
                }
                else
                {
                    usr.Roles.Add(role);
                }
                return user;
            }, splitOn: "Id");
            return users;
        }

    }
}