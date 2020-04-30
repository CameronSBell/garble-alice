using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TextFilter
{
    public class WordFilterExecutor
    {
        private readonly IWordFilterCollection _wordFilters;
        private readonly string _word;

        public WordFilterExecutor(string word)
        {
            _wordFilters = new WordFilterCollection();
            _word = word;
        }
        public async Task<bool> isWordFilteredOut()
        {

            List<Task<bool>> pendingFilters = StartFilters();

            while (pendingFilters.Count > 0)
            {
                var completedFilter = await Task.WhenAny(pendingFilters);
                pendingFilters.Remove(completedFilter);
                var wordIsToBeRemoved = await completedFilter;

                if (!wordIsToBeRemoved && pendingFilters.Count == 0)
                {
                    return false;
                }

                if (wordIsToBeRemoved)// CHANGE make name better
                {
                    return true;
                }
            }
            return false;
        }

        private List<Task<bool>> StartFilters()
        {
            var pendingFilters = new List<Task<bool>>();

            foreach (var filter in _wordFilters.Filters)
            {
                pendingFilters.Add(Task.Factory.StartNew(() => filter(_word)));
            }
      
            return pendingFilters;
        }
    }
}
