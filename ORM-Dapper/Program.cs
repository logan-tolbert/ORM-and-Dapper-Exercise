using DataAccessLibrary;
using System.Security.Policy;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main()
        {
            var data = new DataConfiguration();
            var conn = data.GetServerConfiguration();
            var departmentRepo = data.GetDepartmentRepo(conn);
            var productRepo = data.GetProductRepo(conn);

            var departments = departmentRepo.GetAllDepartments();
            var products = productRepo.GetAllProducts();

            Console.WriteLine("BestBuy Managment Console");

            foreach (var department in departments)
            {
                Console.WriteLine(department.Name);
            }


            productRepo.CreateProduct("Xbox", 499.00M, 8);

            var ids = productRepo.GetProductID("Xbox");


            foreach (var id in ids)
            {
                Console.WriteLine(id.ProductId);
            }


            productRepo.UpdateProductFull(
                961,
                "XboxOne",
                499.00M,
                8,
                10,
                "low");


            productRepo.DeleteProduct(965);


            foreach (var product in products)
            {
                if (product.ProductId == 965)
                {
                    Console.WriteLine("Deleted");
                }
            }

           
        }
    
    }
}
