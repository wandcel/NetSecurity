using System;
using System.Linq;
using System.Security;
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
            if (!IsSearchStringValid(search))
                return;

            var customer = _context.Customers.FirstOrDefault(x => x.LastName == search);

            Result = EscapeStringOutput(customer != null
                ? $"{customer.FirstName} {customer.LastName}"
                : $"Search \"{search}\" did not find any customer.");
        }

        private static bool IsSearchStringValid(string search)
        {
            // todo: add more input-validation and change it to model and use standard-validatory
            return search != null && search.Length <= 20;
        }

        private static string EscapeStringOutput(string outputString)
        {
            // todo: add more output-validation
            return SecurityElement.Escape(outputString);
        }
    }
}
