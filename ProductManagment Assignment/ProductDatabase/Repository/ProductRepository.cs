using ProductModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.Repository
{
    public class ProductRepository : IProdcutRepository
    {
        private readonly ProductDatabase.Database.ProductManagementEntities _db;

        public ProductRepository()
        {
            _db = new ProductDatabase.Database.ProductManagementEntities();
        }

        public int DeleteMany(string[] ids)
        {
            
            for (var i = 0; i < ids.Length; i++)
            {
                var p = _db.Products.Find(Convert.ToInt32(ids[i]));
                _db.Products.Remove(p);
            }
            
            _db.SaveChanges();
            return 1;
            
        }

        public int DeleteProduct(int id)
        {
            var product = _db.Products.Find(id);

            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();

                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<Product> GetAllProducts()
        {
            var products = _db.Products.ToList();
            List<Product> product = new List<Product>();
            foreach(var item in products)
            {
                Product p = new Product();
                p.Id = item.Id;
                p.Name = item.Name;
                p.Category = item.Category;
                p.Quantity = item.Quantity;
                p.Price = item.Price;
                p.Short_Description = item.Short_Description;
                p.Long_Description = item.Long_Description;
                p.Small_Image = item.Small_Image;
                p.Large_Image = item.Large_Image;

                product.Add(p);
            }

            return product;
        }

        public Product GetOneProduct(int id)
        {
            if (id > 0)
            {
                var item = _db.Products.Find(id);
                Product p = new Product();
                p.Id = item.Id;
                p.Name = item.Name;
                p.Category = item.Category;
                p.Quantity = item.Quantity;
                p.Price = item.Price;
                p.Short_Description = item.Short_Description;
                p.Long_Description = item.Long_Description;
                p.Small_Image = item.Small_Image;
                p.Large_Image = item.Large_Image;

                return p;
            }
            else
            {
                return null;
            }
        }

        public int InsertProduct(Product p)
        {
            try
            {
                Database.Product product = new Database.Product();


                product.Name = p.Name;
                product.Category = p.Category;
                product.Price = p.Price;
                product.Quantity = p.Quantity;
                product.Short_Description = p.Short_Description;
                product.Long_Description = p.Long_Description;
                product.Small_Image = p.Small_Image;
                product.Large_Image = p.Large_Image;

                _db.Products.Add(product);
                _db.SaveChanges();

                return 1;
            }
            catch
            {
                return 0;
            }
           
        }

        public int UpdateProduct(Product p)
        {
            var product = _db.Products.Find(p.Id);

            if (product != null)
            {
                product.Name = p.Name;
                product.Category = p.Category;
                product.Price = p.Price;
                product.Quantity = p.Quantity;
                product.Short_Description = p.Short_Description;
                product.Long_Description = p.Long_Description;
                if (p.Large_Image != "")
                {
                    product.Large_Image = p.Large_Image;
                }
                if (p.Small_Image != "")
                {
                    product.Small_Image = p.Small_Image;
                }

                _db.SaveChanges();

                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
