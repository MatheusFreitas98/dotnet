using System;
using Microsoft.Data.SqlClient;
using Dapper.Contrib;
using Projeto.Model;
using Dapper.Contrib.Extensions;
using Projeto.Repositories;


User user = new User();
user.Id = 123;
user.Name = "João da Silva";
user.Email = "joaosilva@gmail.com";
user.PasswordHash = "46544165445dfgdfg";
user.Bio = "Desenvolvedor Java";
user.Image = "https://...";
user.Slug = "joao-silva";

var connection = new SqlConnection("Server=localhost,1433;Database=Blog;Integrated Security=true");

GetAllUser();

void GetAllUser()
{
    var items = new Repository<User>(connection).GetAll();

    foreach (var user in items)
        Console.WriteLine(user.Name);
};