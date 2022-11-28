using System;
using System.Linq;
using System.Linq.Expressions;

namespace Vanilla.Data
{
    public static class OrderByHelper
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string orderBy)
        {
            var orderByCols = orderBy.Split(',');

            var query = source;
            var cnt = 0;
            foreach (var sort in orderByCols)
            {
                cnt++;
                query = OrderByHelper.OrderBy(query, sort, cnt);
            }

            return query;
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string column, int cnt)
        {
            if (String.IsNullOrEmpty(column))
            {
                return source;
            }

            var columnSort = column.Split(' ');

            var columnName = columnSort[0];
            bool isAscending = true;
            if (columnSort.Length > 1)
            {
                var columnNameAscDesc = columnSort[1];

                if (columnNameAscDesc.ToLower() == "desc")
                {
                    isAscending = false;
                }
            }

            ParameterExpression parameter = Expression.Parameter(source.ElementType, "");

            MemberExpression property = Expression.Property(parameter, columnName);
            LambdaExpression lambda = Expression.Lambda(property, parameter);

            string methodName = isAscending ? "OrderBy" : "OrderByDescending";

            if (cnt > 1)
            {
                methodName = isAscending ? "ThenBy" : "ThenByDescending";
            }

            Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                  new Type[] { source.ElementType, property.Type },
                                  source.Expression, Expression.Quote(lambda));

            return source.Provider.CreateQuery<T>(methodCallExpression);
        }
    }
}
