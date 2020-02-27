using PRSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSLibrary.Controller {
    public class RequestLinesController {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<RequestLine> GetAllRequestLine() {
            return context.RequestLines.ToList();
        }
        public RequestLine GetByRequestLinePK(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            return context.RequestLines.Find(id);
        }
        public RequestLine InsertRequestLine(RequestLine requestLine) {
            if (requestLine == null) throw new Exception("Requestline cannot be null in an insert.");
            context.RequestLines.Add(requestLine);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Insert failed.");
            return requestLine;
        } 
        public bool UpdateRequestLine(int id, RequestLine requestLine) {
            if (requestLine == null) throw new Exception("Requestline cannot be null in an update.");
            if (id != requestLine.Id) throw new Exception("Id and RequestLine.id must match.");
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Update failed.");
            return true;
        }
        public bool DeleteRequestLine(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero.");
            var requestLine = context.RequestLines.Find(id);
            return DeleteRequestLine(requestLine);
        }
        public bool DeleteRequestLine(RequestLine requestLine) {
            context.RequestLines.Remove(requestLine);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Delete failed.");
            return true;
        }
    }
}
