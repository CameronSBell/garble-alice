using Xunit;

namespace TextFilter.Tests
{
    public class WordFiltersTests
    {
        [Fact]
        public void Filter1ShouldFilterOutWordsWhoseMiddleCharacterIsAVowel()
        {
            var word = "get";
            var wordFilters = new WordFilters();

            var isFilteredOut = wordFilters.Filter1(word);

            Assert.True(isFilteredOut);
        }

        [Fact]
        public void Filter1ShouldNotFilterOurWordsWhichHaveAnEvenNumberOfCharactersAsTheyDontHaveAMiddleCharacter()
        {
            var word = "what";
            var wordFilters = new WordFilters();

            var isFilteredOut = wordFilters.Filter1(word);

            Assert.False(isFilteredOut);
        }

        [Fact]
        public void Filter1ShouldFilterOutMARMALADE()
        {
            var word = "MARMALADE',";
            var wordFilters = new WordFilters();

            var isFilteredOut = wordFilters.Filter1(word);

            Assert.True(isFilteredOut);
        }

        [Fact]
        public void Filter1DoesNotFailIfGivenPunctuationInTheMiddleOfAWord()
        {
            var word = "Alice's";
            var wordFilters = new WordFilters();

            var isFilteredOut = wordFilters.Filter1(word);

            Assert.False(isFilteredOut);
        }

        [Fact]
        public void Filter2ShouldFilterOutWordsLessThan3Characters()
        {
            var word = "th";
            var wordFilters = new WordFilters();

            var isFilteredOut = wordFilters.Filter2(word);

            Assert.True(isFilteredOut);
        }

        [Fact]
        public void Filter2ShouldIgnorePunctuationAtStartAndEndOfWord()
        {
            var word = "'Oh!'";
            var wordFilters = new WordFilters();

            var isFilteredOut = wordFilters.Filter2(word);

            Assert.True(isFilteredOut);
        }

        [Fact]
        public void Filter3ShouldFilterOutWordsWithT()
        {
            var word = "the";
            var wordFilters = new WordFilters();

            var isFilteredOut = wordFilters.Filter3(word);

            Assert.True(isFilteredOut);
        }
    }
}
