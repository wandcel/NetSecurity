using System;
using System.Linq;
using Chinook.Core.DataAccess;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Web.Pages
{
    public class CustomerSearchModel : PageModel
    {
        private readonly ChinookContext _context;
        public string Result { get; set; }

        public CustomerSearchModel(ChinookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void OnGet(string search)
        {
            if (search == null)
                return;

            var customer = _context.Customers.FirstOrDefault(x => x.LastName == search);

            Result = customer != null
                ? $"{customer.FirstName} {customer.LastName}"
                : $"Search \"{search}\" did not find any customer.";
        }
    }
}
