using PRSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSLibrary.Controller {
    public class RequestController {
        private readonly AppDbContext context = new AppDbContext();
        public const string StatusNew = "NEW";
        public const string StatusEdit = "EDIT";
        public const string StatusReview = "REVIEW";
        public const string StatusApproved = "APPROVED";
        public const string StatusRejected = "REJECTED";
        public IEnumerable<Request> GetRequestsToReviewNotOwn(int userId) {
            return context.Requests.Where(x => x.UserId != userId && x.Status == StatusReview).ToList();
        }
        public bool SetToReview(Request request) {
            if(request.Total <= 50) {
                request.Status = StatusApproved;
            }else {
            request.Status = StatusReview;
            }
            return UpdateRequest(request.Id, request);
        }
        public bool SetToAppoved(Request request) {
            request.Status = StatusApproved;
            return UpdateRequest(request.Id, request);
        }
        public bool SetToRejected(Request request) {
            request.Status = StatusRejected;
            return UpdateRequest(request.Id, request);
        }
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
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Insert failed.");
            return request;
        }
        public bool UpdateRequest(int id, Request request) {
            if (request == null) throw new Exception("Request cannot be null in an update");
            if (id != request.Id) throw new Exception("Id and Request.Id must match");
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Update failed.");
            return true;
        }
        public bool DeleteRequest(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero.");
            var request = context.Requests.Find(id);
            return DeleteRequest(request);
        }
        public bool DeleteRequest(Request request) {
            context.Requests.Remove(request);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Delete failed.");
            return true;
        }
    }
}