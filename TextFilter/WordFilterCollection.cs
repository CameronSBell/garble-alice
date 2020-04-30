using System;
using System.Collections.Generic;

namespace TextFilter
{
    public class WordFilterCollection : IWordFilterCollection
    {
        public List<Func<string, bool>> Filters { get; }

        public WordFilterCollection()
        {
            var filters = new WordFilters();
            Filters = new List<Func<string, bool>>()
            {
                filters.Filter1,
                filters.Filter2,
                filters.Filter3,
            };
        }
    }
}
