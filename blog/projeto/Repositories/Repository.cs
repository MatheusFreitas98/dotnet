using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Projeto.Repositories
{
    public class Repository<TModel> where TModel : class
    {
        private readonly SqlConnection _connection;
        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }

        public TModel Get(int id)
        {
            return _connection.Get<TModel>(id);
        }

        public IEnumerable<TModel> GetAll()
        {
            return _connection.GetAll<TModel>();
        }

        public bool Create(TModel model)
        {
            return _connection.Insert<TModel>(model) > 0 ? true : false;
        }

        public bool Update(TModel model)
        {
            return _connection.Update<TModel>(model);
        }

        public bool Delete(TModel model)
        {
            return _connection.Delete<TModel>(model);
        }
    }
}