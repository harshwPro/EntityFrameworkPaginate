using System;
using System.Linq.Expressions;

namespace EntityFrameworkPaginate
{
    internal class Sort<T>
    {
        public bool Condition { get; set; }
        public Expression<Func<T, dynamic>> Expression { get; set; }
        public bool ByDescending { get; set; }
    }
}
