using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _AppDbContext;

        [BindProperty]
        public Customer Customer{get;set;}

        public EditModel(AppDbContext db)
        {
            _AppDbContext = db;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            Customer = await _AppDbContext.Customers.FindAsync(id);

            if (Customer ==null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        ///This also works, my style vatan
        //public async Task<IActionResult> OnPost() 
        //{
        //    Customer c = await _AppDbContext.Customers.FindAsync(Customer.Id);

        //    c.Name = Customer.Name;

        //    await _AppDbContext.SaveChangesAsync();

        //    return RedirectToPage("/Index");
        //}

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _AppDbContext.Attach(Customer).State = EntityState.Modified;

            try
            {
                
                await _AppDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException exx)
            {

                throw new Exception($"Customer {Customer.Id} not found!", exx);
            }

            return RedirectToPage("/Index");
        }
    }
}