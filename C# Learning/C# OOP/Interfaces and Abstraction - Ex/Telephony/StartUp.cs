using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] webSites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                
                if (IsDigit(phoneNumbers[i]))
                {
                    if (phoneNumbers[i].Length == 7)
                    {
                        int num = int.Parse(phoneNumbers[i]);
                        IPhone phone = new StationaryPhone(num);
                        Console.WriteLine(phone.Call());
                    }
                    else if (phoneNumbers[i].Length==10)
                    {
                        int num = int.Parse(phoneNumbers[i]);
                        IPhone smartfone = new Smartphone(num);
                        Console.WriteLine(smartfone.Call());
                    }
                    else
                        Console.WriteLine("Invalid number!");
                }
                else
                    Console.WriteLine("Invalid number!");
            }

            for (int i = 0; i < webSites.Length; i++)
            {
                if (IsString(webSites[i]))
                {
                    IWeb mobilePhone = new Smartphone(webSites[i]);
                    Console.WriteLine(mobilePhone.WebUrl());
                }
                else
                    Console.WriteLine("Invalid URL!");
            }
        }

        private static bool IsString(string web)
        {
            bool isStr = true;
            for (int i = 0; i < web.Length; i++)
            {
                if (char.IsDigit(web[i]))
                {
                    isStr = false;
                }
            }
            return isStr;
        }

        private static bool IsDigit(string number)
        {
            bool isDigit = true;
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    isDigit = false;
                }
            }
            return isDigit;
        }
    }
}
