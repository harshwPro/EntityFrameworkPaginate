using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFrameworkPaginate
{
    /// <summary>
    /// Stores and processes your conditional filters.
    /// </summary>
    /// <typeparam name="T">Type of Entity for which the filters are applicable.</typeparam>
    public class Filters<T>
    {
        private readonly List<Filter<T>> _filterList;
        public Filters()
        {
            _filterList = new List<Filter<T>>();
        }

        /// <summary>
        /// Adds a conditional filter for your query.
        /// </summary>
        /// <param name="condition">The condition on which the the given filter will run.</param>
        /// <param name="expression">Filter expression.</param>
        public void Add(bool condition, Expression<Func<T, bool>> expression)
        {
            _filterList.Add(new Filter<T>
            {
                Condition = condition,
                Expression = expression
            });
        }

        internal bool IsValid()
        {
            return _filterList.Any(f => f.Condition);
        }

        internal List<Filter<T>> Get()
        {
            return _filterList.Where(f => f.Condition).ToList();
        }
    }
}