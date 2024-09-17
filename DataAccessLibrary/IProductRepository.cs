using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;

namespace DataAccessLibrary
{
    public interface IProductRepository
    {
       
        public IEnumerable<ProductModel> GetAllProducts();
        public void CreateProduct(string newProductName, decimal newPrice, int newCategoryId);
    }
}
