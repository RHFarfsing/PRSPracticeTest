using PRSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSLibrary.Controller {
    public class RequestController {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<Request> GetAllRequest() {
            return context.Requests.ToList();
        }
        public Request GetByRequestPk(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            return context.Requests.Find(id);
        }
        public Request InsertRequest(Request request) {
            if (request == null) throw new Exception("Request cannot be null in an insert");
            context.Requests.Add(request);
            context.SaveChanges();
            return request;
        }
        public bool UpdateRequest(int id, Request request) {
            if (request == null) throw new Exception("Request cannot be null in an update");
            if (id != request.Id) throw new Exception("Id and Request.Id must match");
            return true;
        }
        public bool DeleteRequest(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero.");
            var request = context.Requests.Find(id);
            return DeleteRequest(request);
        }
        public bool DeleteRequest(Request request) {
            context.Requests.Remove(request);
            context.SaveChanges();
            return true;
        }
    }
}