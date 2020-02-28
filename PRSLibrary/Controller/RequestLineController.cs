using Microsoft.EntityFrameworkCore;
using PRSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSLibrary.Controller {
    public class RequestLineController {
        private readonly AppDbContext context = new AppDbContext();
        private void RecalcRequestTotal(int requestId) {
            var request = context.Requests.Find(requestId);
            request.Total = request.requestLines.Sum(x => x.Quantity * x.Product.Price);
            context.SaveChanges();
        }
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
            try {
                context.SaveChanges();
                RecalcRequestTotal(requestLine.RequestId);
            }catch(DbUpdateException ex) {
                throw new Exception("Code must be unique", ex);
            } catch (Exception) {
                throw;
            }
            return requestLine;
        } 
        public bool UpdateRequestLine(int id, RequestLine requestLine) {
            if (requestLine == null) throw new Exception("Requestline cannot be null in an update.");
            if (id != requestLine.Id) throw new Exception("Id and RequestLine.id must match.");
            try {
                context.SaveChanges();
                RecalcRequestTotal(requestLine.RequestId);
            } catch (DbUpdateException ex) {
                throw new Exception("Code must be unique", ex);
            } catch (Exception) {
                throw;
            }
            return true;
        }
        public bool DeleteRequestLine(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero.");
            var requestLine = context.RequestLines.Find(id);
            return DeleteRequestLine(requestLine);
        }
        public bool DeleteRequestLine(RequestLine requestLine) {
            context.RequestLines.Remove(requestLine);
            context.SaveChanges();
            RecalcRequestTotal(requestLine.RequestId);
            return true;
        }
    }
}
