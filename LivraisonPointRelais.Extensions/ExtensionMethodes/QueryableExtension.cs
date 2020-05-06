using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace LivraisonPointRelais.Extensions.ExtensionMethodes
{
    public static class QueryableExtension
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> items, string orderByQueryString)
        {
            if (!items.Any())
            {
                return items;
            }

            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return items;
            }

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderQueryBuilder =  new StringBuilder();

            foreach (var param in orderParams)
            {
                if (!string.IsNullOrWhiteSpace(param))
                {
                    var sortingCriteria = param.Split(" ")[0];
                    var propertyObject = propertyInfos.FirstOrDefault(p =>
                        p.Name.Equals(sortingCriteria, StringComparison.InvariantCultureIgnoreCase));
                    if (propertyObject != null)
                    {
                        var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
                        orderQueryBuilder.Append($"{propertyObject.Name.ToString()} {sortingOrder}, ");
                    }
                }
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return items.OrderBy(orderQuery);
        }
    }
}
