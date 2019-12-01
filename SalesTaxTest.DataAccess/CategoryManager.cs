using System;
using System.Collections.Generic;
using SalesTaxTest.DataAccess;

namespace SalesTaxTest.DataAccess
{
    public class CategoryManager: Interfaces.ICategoryManager
    {
        private const string IMPORTED = "imported";
        private HashSet<string> Food;
        private HashSet<string> Book;
        private HashSet<string> Medical;
        public CategoryManager()
        {
            InitialiseDictionaries();
        }
        private void InitialiseDictionaries()
        {
            Food = new HashSet<string>();
            Food.Add("chocolates");
            Food.Add("chocolate");
            Book = new HashSet<string>();
            Book.Add("book");

            Medical = new HashSet<string>();
            Medical.Add("headache");
            Medical.Add("pills");

        }

        public List<DataAccess.Category> GetCategory(string[] input)
        {
            List<DataAccess.Category> allCategories = new List<Category>();
            if (input.Length < 1)
            {
                throw new Exception("Product should contain at least one category");
            }
            bool notTaxFree = true;
            //check each word except words from exclude list in each dictionary
            for (var i = 1; (input.Length - 1) > i; i++)
            {
                //if we have match with some category apply it if it matches with comtains import so we add it Import Category
                if (input[i] == IMPORTED)
                {
                    allCategories.Add(Category.Import);
                    continue;
                }
                if (Food.Contains(input[i]) || Book.Contains(input[i]) || Medical.Contains(input[i]))
                {
                    notTaxFree = false;
                    break;
                }
            }

            if (notTaxFree)
            {
                allCategories.Add(Category.All);
            }

            return allCategories;
        }
    }
}
