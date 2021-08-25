using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Core.Concretes.EntityFramework;
using Dapper;
using Dapper.Contrib.Extensions;
using Z.Dapper.Plus;

namespace Core.DataAccess.Dapper
{

    public class DapperRepositoryBase<T> : IEntityRepository<T> where T : class, new()

    {

    public DapperRepositoryBase()
    {
        DapperPlusManager.Entity<T>().Table($"{typeof(T).Name}s");
    }

    public void Add(T entity)
    {

        using (var connection = new SqlConnection(Db.connection))
        {
            connection.BulkInsert(entity);
        }
    }

    public void Delete(T entity)
    {
        using (var connection = new SqlConnection(Db.connection))
        {
            connection.BulkDelete(entity);
        }
    }

    public T Get(int id)
    {
        using (var connection = new SqlConnection(Db.connection))
        {
            var get= connection.Get<T>(id);
            return get;
        }
    }

    public List<T> GetAll()
    {
        using (var connection = new SqlConnection(Db.connection))
        {
           

            var getall = connection.GetAll<T>().ToList();
            return getall;
        }
    }

    public void Update(T entity)
    {
        using (var connection = new SqlConnection(Db.connection))
        {
            connection.BulkUpdate(entity);
        }
    }


    private IEnumerable<string> GetColumns()
    {
        return typeof(T)
            .GetProperties()
            .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
            .Select(e => e.Name);
    }
    }
}
