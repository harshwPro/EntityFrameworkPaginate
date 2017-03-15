using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFrameworkPaginate
{
    /// <summary>
    /// Stores and processes your conditional sorts.
    /// This sorting is mutually exclusive and the first sort satisfying the condition will be applied.
    /// </summary>
    /// <typeparam name="T">Type of Entity for which the sort is applicable.</typeparam>
    public class Sorts<T>
    {
        private readonly List<dynamic> _sortList;

        public Sorts()
        {
            _sortList = new List<dynamic>();
        }

        /// <summary>
        /// Adds a conditional sort for your query.
        /// </summary>
        /// <typeparam name="TKey">The data type for the sort object.</typeparam>
        /// <param name="condition">The condition on which the the given sort will run.</param>
        /// <param name="expression">Sort expression.</param>
        /// <param name="byDescending">True if sorting is to be done be descending. By default data gets sorted by ascending.</param>
        public void Add<TKey>(bool condition, Expression<Func<T, TKey>> expression, bool byDescending = false)
        {
            Append(condition, expression, byDescending);
        }
        
        private void Append<TKey>(bool condition, Expression<Func<T, TKey>> expression, bool byDescending = false)
        {
            _sortList.Add(new Sort<T, TKey>
            {
                Condition = condition,
                Expression = expression,
                ByDescending = byDescending
            });
        }

        internal bool IsValid()
        {
            return _sortList.Any(s => s.Condition);
        }

        internal dynamic Get()
        {
            return _sortList.First(s => s.Condition);
        }

        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, bool> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, byte> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, char> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, decimal> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, double> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, float> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, int> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, long> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, sbyte> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, short> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, uint> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, ulong> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, ushort> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }

        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, string> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, DateTime> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, TimeSpan> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
        internal static IQueryable<T> ApplySort(IQueryable<T> query, Sort<T, Guid> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }
    }
}