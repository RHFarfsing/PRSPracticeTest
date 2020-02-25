using PRSLibrary;
using System.Linq;
using System;

namespace PRSPracticeTest {
    class Program {
        static void Main(string[] args) {
            var context = new PRSDbContext();
            //AddUser(context);
            GetAllUsers(context);

        }
        static void AddUser(PRSDbContext context) {
            var user = new User {
                Id = 0,
                Username = "RFarfsing",
                Password = "Qwerty11",
                Firstname = "Robert",
                Lastname = "Farfsing",
                Email = "rfarfsing@example.com",
            };
            context.Users.Add(user);
            var rA = context.SaveChanges();
            if (rA == 0) throw new Exception("Add Failed!");
            return;
        }
        static void GetAllUsers(PRSDbContext context) {
            var users = context.Users.ToList();
            foreach (var u in users) {
                Console.WriteLine(u);
            }
        }
    }
}
