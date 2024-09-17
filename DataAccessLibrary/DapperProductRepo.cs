using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ModelLibrary;

namespace DataAccessLibrary
{
    public class DapperProductRepo : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _connection.Query<ProductModel>("SELECT * FROM Products");
        }

        public IEnumerable<ProductModel> GetProductID(string productName)
        {
            return _connection.Query<ProductModel>("SELECT ProductID FROM products WHERE Name = @target",
                new
                {
                    target = productName
                });
        }
        public void CreateProduct(string newProductName, decimal newPrice, int newCategoryId)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryId);",
                new
                      {
                        name = newProductName,
                        price = newPrice,
                        categoryID = newCategoryId
                      });
        }

        public void UpdateProductFull(int id, string productName, decimal newPrice, int categoryId, int numOnSale, string stocklevel)
        {
            _connection.Execute("UPDATE products " +
                "SET Name = @name, Price = @price, CategoryID = @categoryId, OnSale = @onSale, StockLevel = @stockLevel " +
                "WHERE ProductID = @productID;",
                new
                      {
                        productID = id,
                        name = productName,
                        price = newPrice,
                        categoryID = categoryId,
                        onSale = numOnSale,
                        stockLevel = stocklevel
                      });
        }
     
        public void DeleteProduct(int id)
        {
            _connection.Execute("DELETE FROM products WHERE ProductID = @target;",
                new
                {
                    target = id
                });
            _connection.Execute("DELETE FROM sales WHERE ProductID = @target;",
                new
                {
                    target = id
                });
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @target;",
                new
                {
                    target = id
                });

        }
    }
}