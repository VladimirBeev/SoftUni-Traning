using System;
using System.Linq;
using System.Collections.Generic;
namespace _1.__Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] allUserNames = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < allUserNames.Length; i++)
            {
                bool valid = false;
                string currentWord = allUserNames[i];
                if (currentWord.Length > 3 && currentWord.Length < 16)
                {
                    
                    char [] chars = currentWord.ToCharArray();
                    for (int j = 0; j < chars.Length; j++)
                    {
                        char currenChar = chars[j];
                        if ((currenChar >= 48 && currenChar <= 57) || 
                            (currenChar>= 65 && currenChar<=90) || 
                            (currenChar>= 97 && currenChar<= 122) ||
                            (currenChar == 45) ||
                            (currenChar == 95))
                        {
                            valid = true;
                        }
                        else
                        {
                            valid = false;
                            break;
                        }
                    }
                }
                if (valid == true)
                {
                    Console.WriteLine(allUserNames[i]);
                }
            }
        }
    }
}
