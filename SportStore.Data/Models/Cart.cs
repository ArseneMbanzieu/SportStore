using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Data.Models
{
    public class Cart
    {
        private List<Cartline> Cartlines = new List<Cartline>();
        public void AddItem(Product product, int quantity)
        {
            Cartline line = Cartlines.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if (line == null)
            {
                Cartlines.Add(new Cartline { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Product product)
        {
            Cartlines.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }
        public decimal ComputeTotalValue()
        {
            return Cartlines.Sum(p => p.Product.Price * p.Quantity);
        }
        public void Clear()
        {
            Cartlines.Clear();
        }
        public IEnumerable<Cartline> Lines
        {
            get { return Cartlines; }
        }

    }

    public class Cartline
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
