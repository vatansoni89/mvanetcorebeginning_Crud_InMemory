using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _AppDbContext;

        public IList<Customer> Customers { get; private set; }

        public IndexModel(AppDbContext context)
        {
            _AppDbContext = context;
        }


        public async Task  OnGetAsync()
        {
            Customers = await _AppDbContext.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var xx = await _AppDbContext.Customers.FindAsync(id);

            if (xx !=null)
            {
                _AppDbContext.Customers.Remove(xx);

                await _AppDbContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
