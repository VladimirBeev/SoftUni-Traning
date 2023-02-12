using System;

namespace Vacation_Books_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int pagesinbook = int.Parse(Console.ReadLine());
            int pagesperhours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int sumpages = pagesinbook / pagesperhours;
            int hourssum = sumpages / days;
            Console.WriteLine(hourssum);
        }
    }
}
