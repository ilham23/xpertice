using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace xpertice
{
    class Program
    {
        private static string filename = System.IO.File.ReadAllText("D:\\Xpert Eleven - A.F.C. JDT..html");
        
        static void Main(string[] args)
        {
            var regex = new Regex(@"<a id=""ctl00_hplMoney"" (.*?)>(.*?)<\/a>");

            var match = regex.Match(filename);

            var result = match.Groups[2].Value;
            Console.WriteLine("econ: " + result);

            regex = new Regex(@"<table (.*?) id=""ctl00_cphMain_dgPlayers""(.*?)>(.*?)<\/table>");
            match = regex.Match(filename);

            Console.ReadKey();
        }
    }
}
