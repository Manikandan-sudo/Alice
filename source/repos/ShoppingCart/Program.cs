using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ShoppingCart
{
    class Program
    {
        private static IConfiguration _iconfiguration;
        static void Main(string[] args)
        {
            GetAppSettingsFile();
            PrintProducts();
        }
        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }
        static void PrintProducts()
        {
            var productDAL = new ProductDAL(_iconfiguration);
            var listProduct = productDAL.GetList();
            listProduct.ForEach(item =>
            {
                Console.WriteLine(item.ProductName +" "+ item.ProductCost);
            });
            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
        }
    }
}
    
