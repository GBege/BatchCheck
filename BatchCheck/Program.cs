using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BatchCheck
{
    class Program
    {
        static private char[] trimmedChars = {'^', '\r', '\n', ' '};

        [STAThread]
        static void Main(string[] args)
        {
            try {
                var input = args[0];
                var lines = File.ReadAllLines(input).SelectMany(xs => xs.Split(new char[] {'^'}, StringSplitOptions.RemoveEmptyEntries));
                var filtered = lines.Where(xs => xs.Trim(trimmedChars).StartsWith("-"));
                var result = String.Join("", filtered.ToArray());

                // - output
                Clipboard.SetText(result);
                Console.WriteLine(result);
            }
            catch(Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            }

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
