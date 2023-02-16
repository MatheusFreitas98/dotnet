using System;
using Microsoft.Data.SqlClient;
using Dapper.Contrib;
using Projeto.Model;
using Dapper.Contrib.Extensions;
using Projeto.Repositories;

var connection = new SqlConnection("Server=localhost,1433;Database=Blog;Integrated Security=true");

namespace Projeto
{
public class Program
{
    static void Main(string[] args)
    {
        
    }
}
    
}
