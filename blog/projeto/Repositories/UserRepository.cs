
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

        public IEnumerable<User> GetAllWithRoles()
        {
            const string sql = @"SELECT 
                                    [User].*,
                                    [Role].Id as [RoleId], [Role].Name, [Role].Slug
                                FROM 
                                    [User] [user]
                                LEFT JOIN 
                                    [UserRole] [userRole]
                                ON 
                                    [user].[Id] = [userRole].[UserId]
                                LEFT JOIN
                                    [Role] [role]
                                ON
                                    [userRole].[RoleId] = [Role].Id
            ";

            var users = new List<User>(); // Essa lista será retornada no final da função

            var items = _connection.Query<User, Role, User>(sql, (user, role) =>
            {
                var usr = users.Where(users => users.Id == user.Id).FirstOrDefault(); // Objeto auxiliar

                if (usr == null) // -> Só vai executar na primeira vez, após isso a lista 'users' (fora do escopo) já vai ter um objeto
                {
                    usr = user;
                    if (role != null) usr.Roles.Add(role);                    
                    users.Add(usr); // -> Adiciona o usuário na lista 'users'
                }
                else
                {
                    usr.Roles.Add(role);
                }
                return user;
            }, splitOn: "RoleId");
            return users;
        }

    }
}