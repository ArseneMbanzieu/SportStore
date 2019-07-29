using SportStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Data.Interface
{
    public interface IRepoProduct
    {
        IEnumerable<Product> Products { get;}
        void SaveProduct(Product product);
    }
}
