using System;
using Microsoft.Data.SqlClient;
using Dapper.Contrib;
using Projeto.Model;
using Dapper.Contrib.Extensions;

var connection = new SqlConnection("Server=localhost,1433;Database=Blog;Integrated Security=true");

using (connection)
{
    ReadUsers(connection);
}

static void ReadUsers(SqlConnection connection)
{
    var users = connection.GetAll<User>();

    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
}
// static void InsertUser()
// {
//     using (var connection = new SqlConnection(connectionString))
//     {
//         User user = new User();

//         var rows = connection.Insert<User>(user);

//         Console.WriteLine(rows);

//     }
// }


