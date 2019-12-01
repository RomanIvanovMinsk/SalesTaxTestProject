using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxTest.DataAccess.Interfaces
{
    public interface ICategoryManager
    {
        List<DataAccess.Category> GetCategory(string[] input);
    }
}
