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
            context.SaveChanges();
            return requestLine;
        } 
        public bool UpdateRequestLine(int id, RequestLine requestLine) { }
        public bool DeleteRequestLine(int id) { }
        public bool DeleteRequestLine(RequestLine requestLine) { }
    }
}
