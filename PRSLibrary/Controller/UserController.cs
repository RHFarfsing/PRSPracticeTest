using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSLibrary.Controller {
    class UserController {
        private AppDbContext AppDbContext { get; set; }
        static void GetAllUsers(AppDbContext context) {
            var users = context.Users.ToList();
            foreach (var u in users) {
                Console.WriteLine(u);
            }
        }
    }
}
