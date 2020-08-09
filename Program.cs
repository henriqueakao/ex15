using System;
using System.IO;
using System.Globalization;
using ex15.Entities;

namespace ex15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");
            string sourcePath = Console.ReadLine();

            try
            {
                string[] source = File.ReadAllLines(sourcePath);
                string targetFolder = Path.GetDirectoryName(sourcePath) + @"\out";
                string targetPath = targetFolder + @"\summary.csv";


                Directory.CreateDirectory(targetFolder);

                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach (string s in source)
                    {
                        string[] info = s.Split(',');
                        string name = info[0];
                        double price = double.Parse(info[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(info[2]);

                        Product product = new Product(name, price, quantity);

                        sw.WriteLine(product.Name + "," + product.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
