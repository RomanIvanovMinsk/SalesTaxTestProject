using System.Collections.Generic;
namespace SalesTaxTest.DataAccess
{
    public interface IDataParse
    {
        Product Parse(string input);
    }
}