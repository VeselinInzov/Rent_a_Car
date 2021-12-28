using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Car_Rental.Models;

namespace Car_Rental.Pages.Users
{
    //Edits the selected user.
    public class EditModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public EditModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        //Holds the user data.
        [BindProperty]
        public new User User { get; set; }

        //Gets the user data using a labmda query.
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = _context.User.FirstOrDefault(m => m.Id == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Updates the user.
        public  IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(User).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Checks whether the user exists.
        private bool UserExists(string id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
