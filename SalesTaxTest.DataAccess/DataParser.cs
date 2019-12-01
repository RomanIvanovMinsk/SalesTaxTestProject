using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using SalesTaxTest.DataAccess.Interfaces;

[assembly: InternalsVisibleTo("SalesTaxTest.Tests")]
namespace SalesTaxTest.DataAccess
{
    public class DataParser : IDataParse
    {
        ICategoryManager _categoryManager { get; set; }
        public DataParser(Interfaces.ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }


        public Product Parse(string input)
        {
            var parsedArray = input.Split(' ');
            int quantity;
            //Get quantity that always go first
            int.TryParse(parsedArray[0], out quantity);
            if (quantity <= 0)
            {
                throw new Exception("Quantity should be in correct format");
            }

            //Get price that always go last
            double price;
            double.TryParse(parsedArray[parsedArray.Length - 1]
               , NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-GB"), out price);
            if (price <= 0)
            {
                throw new Exception("Price should be in correct format");
            }

            var categories = _categoryManager.GetCategory(parsedArray);

            return new Product() { Name = GetName(parsedArray), Category = categories, Quantity = quantity, Price = price };
        }

        protected internal string GetName(string[] parsedArray)
        {
            var productName = "";
            for (var i = 1; (parsedArray.Length - 2) >  i; i++)
            {
                productName += parsedArray[i] + " ";
            }
            return productName.TrimEnd();
        }


    }
}
