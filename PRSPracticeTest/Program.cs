using PRSLibrary;
using System.Linq;
using System;
using PRSLibrary.Controller;
using System.Collections.Generic;

namespace PRSPracticeTest {
    class Program {
        static void Main(string[] args) {
            var context = new AppDbContext();
            var userCtrl = new UserController();
            var vendorCtrl = new VendorController();
            var productCtrl = new ProductController();
            var requestCtrl = new RequestController();
            var reLineCtrl = new RequestLineController();
        }
    }
}
