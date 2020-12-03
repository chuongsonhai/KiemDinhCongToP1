using System;
using System.Collections.Generic;
using System.Text;

namespace Constraint
{
    public class PagingQueryResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
    }
}
