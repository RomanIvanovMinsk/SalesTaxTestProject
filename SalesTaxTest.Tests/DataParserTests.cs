using NUnit.Framework;
using SalesTaxTest.DataAccess;
using System;

namespace Tests
{
    public class Tests
    {
        string data;
        [SetUp]
        public void Setup()
        {
            data = "1 imported box of chocolates at £10.00";
        }

        [Test]
        public void DataParserProductExists()
        {
            var dataParser = new DataParser(new CategoryManager());

            var product = dataParser.Parse(data);
            Assert.IsTrue(product != null);
        }

        [Test]
        public void DataParserProductHasQuantity()
        {
            var dataParser = new DataParser(new CategoryManager());

            var product = dataParser.Parse(data);
            Assert.IsTrue(product.Quantity == 1);
        }

        [Test]
        public void DataParserProductHasName()
        {
            var dataParser = new DataParser(new CategoryManager());
            var parsedString = data.Split(" ");
            var name = dataParser.GetName(parsedString);
            Assert.IsTrue(name == "imported box of chocolates");
        }

        [Test]
        public void DataParserProductHasRightPrice()
        {
            var dataParser = new DataParser(new CategoryManager());

            var product = dataParser.Parse(data);
            Assert.IsTrue(product.Price == 10.00);
        }

        [Test]
        public void DataParserProductHasCategory()
        {
            var dataParser = new DataParser(new CategoryManager());

            var product = dataParser.Parse(data);
            Assert.IsTrue(product.Category.Contains(Category.Import));
        }

        [Test]
        public void DataParserProductCheckIncorrectPrice()
        {
            var dataParser = new DataParser(new CategoryManager());

            Assert.Throws<Exception>(() => { dataParser.Parse("1 imported box of chocolates at £sad"); });
        }

        [Test]
        public void DataParserProductCheckIncorrectQuantity()
        {
            var dataParser = new DataParser(new CategoryManager());
            Assert.Throws<Exception>(() => { dataParser.Parse("zsd imported box of chocolates at £10.00"); });
        }


    }
}