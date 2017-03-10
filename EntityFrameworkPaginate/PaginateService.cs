using System;
using System.Linq;

namespace EntityFrameworkPaginate
{
    public static class PaginateService
    {
        public static Page<T> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            var result = new Page<T>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                RecordCount = query.Count(),
                Results = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsEnumerable()
            };
            result.PageCount = (int)Math.Ceiling((double)result.RecordCount / pageSize);
            return result;
        }

        public static Page<T> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize, Sorts<T> sorts)
        {
            return query.ApplySort(sorts).Paginate(pageNumber, pageSize);
        }

        public static Page<T> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize, Sorts<T> sorts, Filters<T> filters)
        {
            return query.ApplyFilter(filters).Paginate(pageNumber, pageSize, sorts);
        }

        private static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, Filters<T> filters)
        {
            return !filters.IsValid() ? query : filters.Get().Aggregate(query, (current, filter) => current.Where(filter.Expression));
        }

        private static IQueryable<T> ApplySort<T>(this IQueryable<T> query, Sorts<T> sorts)
        {
            if (!sorts.IsValid()) return query;
            var sort = sorts.Get();
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
    }
}