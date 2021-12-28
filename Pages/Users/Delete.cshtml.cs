using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Car_Rental.Models;

namespace Car_Rental.Pages.Users
{
    //Deletes an existing user.
    public class DeleteModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public DeleteModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }
        //Holds the user data.
        [BindProperty]
        public new User User { get; set; }

        //Gets the user data using a lamda query
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User =  _context.User.FirstOrDefault(m => m.Id == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Delets the user.
        public  IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User =  _context.User.Find(id);

            if (User != null)
            {
                _context.User.Remove(User);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
