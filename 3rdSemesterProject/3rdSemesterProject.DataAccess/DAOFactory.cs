using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.DataAccess;

public static class DAOFactory
{
    public static T CreateRepository<T>(string connectionstring) where T : class
    {
        if (typeof(T) == typeof(IOrderDAO)) return new OrderDAO(connectionstring) as T;
        //if (typeof(T) == typeof(IBlogPostDAO)) return new BlogPostDAO(connectionstring) as T;
        throw new ArgumentException($"Unknown type {typeof(T).FullName}");
    }
}
