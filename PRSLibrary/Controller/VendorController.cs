using Microsoft.EntityFrameworkCore;
using PRSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSLibrary.Controller {
    public class VendorController {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<Vendor> GetAllVendors() {
            return context.Vendors.ToList();
        }
        public Vendor GetVendorByPk(int id) {
            if (id < 1) throw new Exception("Id has to be greater than zero.");
            return context.Vendors.Find(id);
        }
        public Vendor InsertVendor(Vendor vendor) {
            if (vendor == null) throw new Exception("Vendor cannot be null in an insert");
            context.Vendors.Add(vendor);
            try {
                var rowsAffected = context.SaveChanges();
                if (rowsAffected == 0) throw new Exception("Insert failed.");
            }catch(DbUpdateException ex) {
                throw new Exception("Code must be unique.", ex);
            }catch(Exception ex) {
                throw;
            }
            return vendor;
        }
        public bool UpdateVendor(int id, Vendor vendor) {
            if (vendor == null) throw new Exception("Vendor cannot be null in an update.");
            if (id != vendor.Id) throw new Exception("Id and Vendor.Id must match.");
            try {
                var rowsAffected = context.SaveChanges();
                if (rowsAffected == 0) throw new Exception("Update failed.");
            }catch(DbUpdateException ex) {
                throw new Exception("Code must be unique.", ex);
            }catch(Exception ex) {
                throw;
            }
            return true;
        }
        public bool DeleteVendor(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero");
            var vender = context.Vendors.Find(id);
            return DeleteVendor(vender);
        }
        public bool DeleteVendor(Vendor vendor) {
            context.Vendors.Remove(vendor);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Delete failed.");
            return true;
        }
    }
}
