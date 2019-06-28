using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Skidly.Models;

namespace Skidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}