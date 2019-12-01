using NUnit.Framework;
using SalesTaxTest.BuisnessLogic;
using SalesTaxTest.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxTest.Tests
{
    public class TaxCalculatorTest
    {

        [Test]
        public void TestCase1()
        {
            var listInputs = new List<string>() { "1 book at £12.49", "1 music CD at £14.99", "1 chocolate bar at £0.85" };
            var listOfProducts = new List<Product>();
            var dataParser = new DataParser(new CategoryManager());
            foreach (var input in listInputs)
            {
                listOfProducts.Add(dataParser.Parse(input));
            }

            var taxCalculator = new TaxCalculator();
            taxCalculator.Proceed(listOfProducts);
            Assert.IsTrue(taxCalculator.SalesTaxes == 1.50 && taxCalculator.Total == 29.83);
        }


        [Test]
        public void TestCase2()
        {
            var listInputs = new List<string>() { "1 imported box of chocolates at £10.00", "1 imported bottle of perfume at £47.50" };
            var listOfProducts = new List<Product>();
            var dataParser = new DataParser(new CategoryManager());
            foreach (var input in listInputs)
            {
                listOfProducts.Add(dataParser.Parse(input));
            }

            var taxCalculator = new TaxCalculator();
            taxCalculator.Proceed(listOfProducts);
            Assert.IsTrue(taxCalculator.SalesTaxes == 7.65 && taxCalculator.Total == 65.15);
        }

        /// <summary>
        /// There is probably some missmatching in the task because when we get 0.05 from 11.25 it 
        /// gives us 0.5625 and the nearest 0.05 to it not 0.60 but 0.55.
        /// due to this case we lost 0.5 in the tax and in total result
        /// </summary>
        [Test]
        public void TestCase3()
        {

            var listInputs = new List<string>() {
                "1 imported bottle of perfume at £27.99",
                "1 bottle of perfume at £18.99",
                "1 packet of headache pills at £9.75",
                "1 imported box of chocolates at £11.25"};
            var listOfProducts = new List<Product>();
            var dataParser = new DataParser(new CategoryManager());
            foreach (var input in listInputs)
            {
                listOfProducts.Add(dataParser.Parse(input));
            }

            var taxCalculator = new TaxCalculator();
            taxCalculator.Proceed(listOfProducts);
            Assert.IsTrue(taxCalculator.SalesTaxes == 6.70 && taxCalculator.Total == 74.68);
          


        }
    }
}
