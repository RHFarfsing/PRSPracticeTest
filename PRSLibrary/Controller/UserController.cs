using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSLibrary.Controller {
    public class UserController {
        private readonly AppDbContext context = new AppDbContext();
        public User Login(string username, string password) {
            return context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
        public IEnumerable<User> GetAllUser() {
            return context.Users.ToList();
        }
        public User GetByUserPk(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero.");
            return context.Users.Find(id);
        }
        public User InsertUser(User user) {
            if(user == null) throw new Exception("User cannot be null in an insert.");
            context.Users.Add(user);
            try {
                var rowsAffected = context.SaveChanges();
                if (rowsAffected == 0) throw new Exception("Insert failed.");
            } catch(DbUpdateException ex) {
                throw new Exception("Username must be unique", ex);                
            }catch(Exception ex) {
                throw;
            }
            return user;            
        }
        public bool UpdateUser(int id, User user) {
            if (user == null) throw new Exception("user cannot be null in an update.");
            if (id != user.Id) throw new Exception("Id and User.Id must match.");
            context.Entry(user).State = EntityState.Modified;
            try {
                var rowsAffected = context.SaveChanges();
                if (rowsAffected == 0) throw new Exception("Update failed.");
            } catch (DbUpdateException ex) {
                throw new Exception("Username must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
            return true;
        }
        public bool DeleteUser(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero");
            var user = context.Users.Find(id);
            return DeleteUser(user);
        }
        public bool DeleteUser(User user) {
            context.Users.Remove(user);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Delete failed.");
            return true;
        }
    }
}

