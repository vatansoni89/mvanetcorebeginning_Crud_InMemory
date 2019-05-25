using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;

        [TempData] // this can travel to another view.
        public string Message { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public ILogger<CreateModel> _logger { get; set; }

        public CreateModel(AppDbContext db, ILogger<CreateModel> logger)
        {
            _db = db;
            _logger = logger;
        }
        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            Message = $"Customer name {Customer.Name}  Added !!!";
            _logger.LogTrace(Message);
            return RedirectToPage("/Index");
        }
    }
}