using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxTest.BuisnessLogic
{
    public  class TaxCalculator
    {
        Dictionary<DataAccess.Category, double> taxesViaCategory;
        public double SalesTaxes { get; set; }

        public double Total { get; set; }

        public TaxCalculator()
        {
            taxesViaCategory = new Dictionary<DataAccess.Category, double>();
            taxesViaCategory.Add(DataAccess.Category.All, 0.1d);
            taxesViaCategory.Add(DataAccess.Category.Import, 0.05d);
        }
        public DataAccess.Product Calculate(DataAccess.Product product)
        {
            foreach (var category in product.Category)
            {
                product.Tax += Math.Round((product.Price * taxesViaCategory[category]) / 0.05d, 0) * 0.05d;
            }

            product.Total = product.Price + product.Tax;

            return product;
        }

        public void Proceed(List<DataAccess.Product> products)
        {
            foreach (var product in products)
            {
                var afterTaxCalc = Calculate(product);
                SalesTaxes += afterTaxCalc.Tax;
                Total += afterTaxCalc.Total;

                Console.WriteLine(afterTaxCalc.ToString());
            }

            SalesTaxes = Math.Round(SalesTaxes, 2);
            Total = Math.Round(Total, 2);
            Console.WriteLine("Sales Taxes:" + SalesTaxes);
            Console.WriteLine("Total:" + Total);
        }
    }
}
