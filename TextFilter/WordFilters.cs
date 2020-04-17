using System;
using System.Text.RegularExpressions;

namespace TextFilter
{
    public class WordFilters
    {
        // CHANGE handle & signs

        public bool Filter1(string word)
        {
            // CHANGE get this to ignore punctuation marks in the middle of a word
            var capturingGroup = ExtractWordFromSurroundingPunctuation(word);
            var isSuccessfullyExtracted = capturingGroup.Success;
            if (!isSuccessfullyExtracted) return false;// CHANGE to something clearer
            var wordWithoutPunctuation = capturingGroup.Value;
            var isOddNumberOfCharacters = (wordWithoutPunctuation.Length % 2) != 0;
            if (isOddNumberOfCharacters)
            {
                char middleCharacter = GetMiddleCharacter(wordWithoutPunctuation);
                bool isMatch = IsAVowel(middleCharacter);
                return isMatch;
            }
            else
            {
                return false;
            }
        }

        private static Group ExtractWordFromSurroundingPunctuation(string word)
        {
            var patternToExtractWord = @"^[\.,:;\?!""'`\(\)]*(?<word>\w+)[\.,:;\?!""'`\(\)]*$";
            var regex = new Regex(patternToExtractWord);
            var match = regex.Match(word);
            var group = match.Groups["word"];
            return group;
        }

        private static bool IsAVowel(char character)
        {
            var pattern = @"[aAeEiIoOuU]";
            var vowelRegex = new Regex(pattern);
            var isMatch = vowelRegex.IsMatch(character.ToString());
            return isMatch;
        }

        private char GetMiddleCharacter(string word)
        {
            var numberOfMiddleCharacter = Convert.ToInt32(Math.Floor((double)(word.Length / 2))) + 1;
            var indexOfMiddleCharacter = numberOfMiddleCharacter - 1;
            var middleCharacter = word[indexOfMiddleCharacter];
            return middleCharacter;
        }

        public bool Filter2(string word)
        {
            // CHANGE want to ignore punctuation that isn't directly attached to a word, e.g. ".,:;?!"
            // CHANGE ignore " or ' when it is at the front of the word
            var pattern = @"^[\.,:;\?!""'`()]*\w{1,2}[\.,:;\?!""'`()]*$";
            var regex = new Regex(pattern);
            var isMatch = regex.IsMatch(word);
            return isMatch;
        }

        public bool Filter3(string word)
        {
            var pattern = @"[tT]";
            var regex = new Regex(pattern);
            var isMatch = regex.IsMatch(word);
            return isMatch;
        }
    }
}