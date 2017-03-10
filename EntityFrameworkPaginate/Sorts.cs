using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFrameworkPaginate
{
    public class Sorts<T>
    {
        private readonly List<Sort<T>> _sortList;

        public Sorts()
        {
            _sortList = new List<Sort<T>>();
        }

        public void Add(bool condition, Expression<Func<T, dynamic>> expression, bool byDescending = false)
        {
            _sortList.Add(new Sort<T>
            {
                Condition = condition,
                Expression = expression,
                ByDescending = byDescending
            });
        }

        public void Add(bool condition, string sortProperty, bool byDescending = false)
        {
            Add(condition, GetExpression(sortProperty), byDescending);
        }

        internal bool IsValid()
        {
            return _sortList.Any(s => s.Condition);
        }

        internal Sort<T> Get()
        {
            return _sortList.First(s => s.Condition);
        }

        private Expression<Func<T, dynamic>> GetExpression(string sortProperty)
        {
            var parent = Expression.Parameter(typeof(T), "parent");
            var sortOn = Expression.Property(parent, sortProperty);
            return Expression.Lambda<Func<T, dynamic>>(sortOn, parent);
        }
    }
}