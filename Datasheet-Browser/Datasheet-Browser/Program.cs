using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Datasheet_Browser
{
    class Program
    {
        private static async void GetDatasheet(string oldInput)
        {
            string input = oldInput + ".pdf";
            var diodes = new Uri("https://www.diodes.com/assets/Datasheets/" + input);

            string file = String.Format(@"{0}\pdfs\", Environment.CurrentDirectory);

            string filepath = Path.Combine(file, input);

            Directory.CreateDirectory(file);

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(diodes, filepath);
            }

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(filepath)
            {
                UseShellExecute = true
            };
            p.Start();

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Find a datasheet for websites added to the database.");
            Console.WriteLine("If you want to contribute, consider adding more websites with good datasheet indexing.");
            Console.Write("Name: ");
            string input = Console.ReadLine();
            GetDatasheet(input);
        }
    }
}
