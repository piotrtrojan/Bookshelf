using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Bookshelf.Contract;
using Bookshelf.Contract.Enum;

namespace Bookshelf.Utils.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplySortingAndPaging<T>(this IQueryable<T> queryable, BasePagedAndSortedQuery pagingDetails)
        {
            var ordered = pagingDetails.Order == OrderEnum.Asc ?
                queryable.OrderBy(pagingDetails.OrderBy) :
                queryable.OrderByDescending(pagingDetails.OrderBy);
            
            return ordered
                .Skip((pagingDetails.Page - 1) * pagingDetails.Limit)
                .Take(pagingDetails.Limit);
        }

        public static int GetTotalResults<T>(this IQueryable<T> queryable)
        {
            return queryable.Count();
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering, params object[] values)
        {
            return OrderByInternal<T>(source, ordering, true, values);
        }

        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string ordering, params object[] values)
        {
            return OrderByInternal<T>(source, ordering, false, values);
        }

        internal static IQueryable<T> OrderByInternal<T>(this IQueryable<T> source, string ordering, bool ascending, params object[] values)
        {
            var type = typeof(T);
            var property = type.GetProperty(ordering, BindingFlags.IgnoreCase |  BindingFlags.Public | BindingFlags.Instance);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = ascending ? 
                Expression.Call(typeof(Queryable), "OrderBy", new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp)) : 
                Expression.Call(typeof(Queryable), "OrderByDescending", new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);
        }
    }
}
