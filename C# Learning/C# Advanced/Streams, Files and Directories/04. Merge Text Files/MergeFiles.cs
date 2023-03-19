using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\input1.txt";
            var secondInputFilePath = @"..\..\..\input2.txt";
            var outputFilePath = @"..\..\..\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {

            using (StreamReader firstText = new StreamReader(firstInputFilePath))
            {
                string lineText = firstText.ReadLine();


                using (StreamReader secondText = new StreamReader(secondInputFilePath))
                {
                    string lineText2 = secondText.ReadLine();

                    using (StreamWriter write = new StreamWriter(outputFilePath))
                    {
                        while (lineText != null && lineText2 != null)
                        {
                            write.WriteLine(lineText);
                            lineText = firstText.ReadLine();
                            write.WriteLine(lineText2);
                            lineText2 = secondText.ReadLine();
                        }
                        while (lineText != null)
                        {
                            write.WriteLine(lineText);
                            lineText = firstText.ReadLine();
                        }
                        while (lineText2!= null)
                        {
                            write.WriteLine(lineText2);
                            lineText2 = secondText.ReadLine();
                        }
                    }

                }
            }
        }
    }
}

