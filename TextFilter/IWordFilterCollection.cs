using System;
using System.Collections.Generic;

namespace TextFilter
{
    interface IWordFilterCollection
    {
        public List<Func<bool>> Filters { get; }
    }
}
