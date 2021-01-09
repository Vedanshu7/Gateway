using ProductModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.Repository
{
    public interface IProdcutRepository
    {
        List<Product> GetAllProducts();

        int InsertProduct(Product p);

        int UpdateProduct(Product p);

        int DeleteProduct(int id);

        Product GetOneProduct(int id);

        int DeleteMany(string[] ids);
    }
}
