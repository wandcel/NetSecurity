using System;
using System.Linq;
using Chinook.Core.DataAccess;
using Chinook.Core.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Web.Pages
{
    public class MyCustomerPageModel : PageModel
    {
        private readonly ChinookContext _context;
        public Customer Customer { get; set; }

        public MyCustomerPageModel(ChinookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void OnGet(int? id)
        {
            Customer = _context.Customers.FirstOrDefault(x => x.Id == id);
        }
    }
}
