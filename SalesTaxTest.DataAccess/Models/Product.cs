using System.Globalization;

namespace SalesTaxTest.DataAccess
{
    public class Product
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public System.Collections.Generic.List<Category> Category { get; set; } = new System.Collections.Generic.List<Category>();

        /// <summary>
        /// Store item price before adding a tax
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Calculated price
        /// </summary>
        public double Tax { get; set; }
        /// <summary>
        /// Sum Price and tax
        /// </summary>
        public double Total { get; set; }

        public override string ToString()
        {
            var ci = new CultureInfo("en-GB");
            var currencySymbol = ci.NumberFormat.CurrencySymbol;
            return this.Quantity + " " + this.Name + ": " + currencySymbol + this.Total;
        }
    }

    public  enum Category {
        Book,
        Food,
        Medical,
        All,
        Import    
    }
}