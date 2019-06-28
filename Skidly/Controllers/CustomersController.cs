using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Skidly.Models;
using Skidly.ViewModels;

namespace Skidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _dbContext.Customers.Include(x => x.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult New()
        {
            var membershipTypes = _dbContext.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id == 0)
                _dbContext.Customers.Add(customer);
            else
            {
                var customerInDb = _dbContext.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.Include(x => x.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _dbContext.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}