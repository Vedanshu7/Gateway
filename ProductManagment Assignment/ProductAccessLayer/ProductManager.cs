using ProductAccessLayer.Interface;
using ProductDatabase.Repository;
using ProductModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAccessLayer
{
    public class ProductManager:IProductManager
    {
        private readonly IProdcutRepository productRepository;

        public ProductManager(IProdcutRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public int DeleteMany(string[] ids)
        {
            return productRepository.DeleteMany(ids);
        }

        public int DeleteProduct(int id)
        {
            return productRepository.DeleteProduct(id);
        }

        public List<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public Product GetOneProduct(int id)
        {
            return productRepository.GetOneProduct(id);
        }

        public int InsertProduct(Product p)
        {
            return productRepository.InsertProduct(p);
        }

        public int UpdateProduct(Product p)
        {
            return productRepository.UpdateProduct(p);
        }
    }
}
