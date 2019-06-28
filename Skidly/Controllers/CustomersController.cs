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
            var newCustomerViewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View(newCustomerViewModel);
        }

        public ActionResult Create()
        {
            return null;
        }

        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.Include(x => x.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}