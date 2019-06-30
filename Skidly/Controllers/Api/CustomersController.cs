using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using System.Net;
using Skidly.Models;

namespace Skidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET /api/customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        // GET /api/customers/1
        [HttpGet]
        public Customer GetCustomer(int id)
        {
            var customer = _dbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if(customer == null)
                throw  new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }

        // POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return customer;
        }

        // PUT /api/customer/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;
            customerInDb.DateOfBirth = customer.DateOfBirth;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _dbContext.SaveChanges();

        }

        // DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dbContext.Customers.Remove(customerInDb);
            _dbContext.SaveChanges();
        }
    }
}
