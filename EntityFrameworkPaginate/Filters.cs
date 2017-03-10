using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFrameworkPaginate
{
    public class Filters<T>
    {
        private readonly List<Filter<T>> _filterList;
        public Filters()
        {
            _filterList = new List<Filter<T>>();
        }

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