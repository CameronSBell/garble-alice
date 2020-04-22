using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextFilter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var path = "Alice.txt";// CHANGE to command line argument?
            var fileReader = new FileReader(path);
            var inputText = fileReader.ReadFile();

            // CHANGE don't want to remove punctuation that isn't directly attached to a word, e.g. ".,:;?"
            // but if the punctuation is part of the individual string then it will be removed when that word is filtered out 
            // and the prose will no longer make sense
            var delimiters = new string[] { " ", "\r\n" };
            var listOfWords = inputText.Split(delimiters, StringSplitOptions.None).ToList(); ;// CHANGE to put inside a string splitter class?
            // CHANGE to delimit by other kinds of whitespace?

            var outputTextList = new List<string>();

            foreach (var word in listOfWords)
            {
                var wordFilterExecutor = new WordFilterExecutor(word);
                var isWordFilteredOut = await wordFilterExecutor.isWordFilteredOut();
                if (!isWordFilteredOut) outputTextList.Add(word);
            }

            var outputText = String.Join(" ", outputTextList);
            Console.WriteLine(outputText);
        }
    }
}
