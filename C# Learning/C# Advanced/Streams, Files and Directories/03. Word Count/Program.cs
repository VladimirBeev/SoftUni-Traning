using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = (@"..\..\..\words.txt");
            string textPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader sr = new StreamReader(wordsFilePath))
            {
                int count = 0;
                string[] word = sr.ReadToEnd().Split(' ');

                using (StreamReader sw = new StreamReader(textFilePath))
                {
                    string[] text = sw.ReadToEnd().ToLower().Split(' ', '-', ',', '.', '?', '!');
                    Dictionary<string, int> wordCount = new Dictionary<string, int>();
                    foreach (string word2 in word)
                    {
                        foreach (var item in text)
                        {
                            if (word2 == item)
                            {
                                if (!wordCount.ContainsKey(word2))
                                {
                                    wordCount.Add(word2, 1);
                                }
                                else
                                    wordCount[word2]++;
                            }

                        }
                    }
                    using (var outText = new StreamWriter(outputFilePath))
                    {
                        foreach(var item in wordCount.OrderByDescending(x =>x.Value))
                        outText.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
            }

        }
    }
}

