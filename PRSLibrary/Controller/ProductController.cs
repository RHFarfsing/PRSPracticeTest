using Microsoft.EntityFrameworkCore;
using PRSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSLibrary.Controller {
    public class ProductController {
        private readonly AppDbContext context = new AppDbContext();
        public IEnumerable<Product> GetAllProducts() {
            return context.Products.ToList();
        }
        public Product GetProductByPk(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero.");
            return context.Products.Find(id);
        }
        public Product InsertProduct(Product product) {
            if (product == null) throw new Exception("Product cannot be null in a insert.");
            context.Products.Add(product);
            try {
                var rowsAffected = context.SaveChanges();
                if (rowsAffected == 0) throw new Exception("Insert failed.");
            } catch (DbUpdateException ex) {
                throw new Exception("PartNbr must be unique.",ex);
            }catch(Exception ex) {
                throw;
            }
            return product;
        }
        public bool UpdateProduct(int id, Product product) {
            if (product == null) throw new Exception("Product cannot be null in an update.");
            if (id != product.Id) throw new Exception("Id and product.Id must match.");
            context.Entry(product).State = EntityState.Modified;
            try {
                var rowsAffected = context.SaveChanges();
                if (rowsAffected == 0) throw new Exception("Update failed.");
            } catch (DbUpdateException ex) {
                throw new Exception("PartNbr must be unique.");
            } catch (Exception ex) {
                throw;
            }
            return true;
        }
        public bool DeleteProduct(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero.");
            var product = context.Products.Find(id);
            return DeleteProduct(product);
        }
        public bool DeleteProduct(Product product) {
            context.Products.Remove(product);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Delete failed.");
            return true;
        }

    }
}
