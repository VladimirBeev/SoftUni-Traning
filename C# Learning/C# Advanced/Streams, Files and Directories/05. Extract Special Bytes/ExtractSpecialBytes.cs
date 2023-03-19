using System;
using System.IO;

namespace ExtractSpecialBytes
{
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\example.png";
            string bytesFilePath = @"..\..\..\bytes.txt";
            string outputPath = @"..\..\..\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using(FileStream fs = new FileStream(binaryFilePath,FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(bytesFilePath))
                {
                    int file = int.Parse(sr.ReadLine());
                    int[] vs = new int[file];
                    using (FileStream output = new FileStream(outputPath, FileMode.Create))
                    {
                        var buf = new byte[1024];
                        while (true)
                        {
                            int bytesRead = fs.Read(buf, 0, buf.Length);
                            if (bytesRead == 0)
                                break;
                            for (byte i = 0; i < bytesRead; i++)
                            {
                                if (buf[i] == vs[i])
                                {
                                    output.Write(buf, 0, bytesRead);
                                }
                               
                            }
                        }
                    }
                }
            }
        }
    }
}

