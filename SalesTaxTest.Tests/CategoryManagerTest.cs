using NUnit.Framework;
using SalesTaxTest.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxTest.Tests
{
    public class CategoryManagerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CategoryManagerGetRightCountOfCategoriesOne()
        {
            var catManager = new CategoryManager();
            var parsedArray = "1 imported box of chocolates at £10.00".Split(' ');
            var arrOfCategories = catManager.GetCategory(parsedArray);
            Assert.IsTrue(arrOfCategories.Count == 1);
        }

        [Test]
        public void CategoryManagerGetRightCountOfCategoriesTwo()
        {
            var catManager = new CategoryManager();
            var parsedArray = "1 imported bottle of perfume at £47.50".Split(' ');
            var arrOfCategories = catManager.GetCategory(parsedArray);
            Assert.IsTrue(arrOfCategories.Count == 2);
        }

        [Test]
        public void CategoryManagerTestIfNoCategory()
        {
            var catManager = new CategoryManager();

            Assert.Throws<Exception>(() => { catManager.GetCategory(new string[] { }); });
        }
    }
}
