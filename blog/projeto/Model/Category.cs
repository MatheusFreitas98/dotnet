using Dapper.Contrib.Extensions;
using Projeto.Model;

namespace Projeto.Category
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<Post> Posts { get; set; }
    }
}