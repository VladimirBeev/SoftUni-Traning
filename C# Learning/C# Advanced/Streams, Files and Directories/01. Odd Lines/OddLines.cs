using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader("input.txt");
            using (reader)
            {
                int counter = 0;
                string line = reader.ReadLine();
                using (var write = new StreamWriter("output.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 == 1)
                            write.WriteLine(line);
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}

