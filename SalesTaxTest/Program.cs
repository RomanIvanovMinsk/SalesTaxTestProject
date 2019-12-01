using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxTest
{
    class Program
    {
        static List<DataAccess.Product> products = new List<DataAccess.Product>();
        /// <summary>
        /// calc = to process calculating;
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var dataParser = new DataAccess.DataParser(new DataAccess.CategoryManager());

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "calc")
                {
                    break;
                }
                var product = dataParser.Parse(input);
                products.Add(product);
            } 

            var taxCalculator = new BuisnessLogic.TaxCalculator();
            taxCalculator.Proceed(products);

            Console.ReadLine();
        }
    }
}
