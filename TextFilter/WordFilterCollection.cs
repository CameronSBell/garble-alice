using System;
using System.Collections.Generic;

namespace TextFilter
{
    public class WordFilterCollection : IWordFilterCollection
    {
        public List<Func<bool>> Filters { get; }

        public WordFilterCollection(string word)
        {
            var filters = new WordFilters();
            Filters = new List<Func<bool>>()
            {
                () => filters.Filter1(word),
                () => filters.Filter2(word),
                () => filters.Filter3(word),
            };
        }
    }
}
