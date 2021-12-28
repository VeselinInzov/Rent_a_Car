using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Car_Rental.Models;

namespace Car_Rental.Pages.Users
{
    //Creates a user.
    public class CreateModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public CreateModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        //Gets the create form.
        public IActionResult OnGet()
        {
            return Page();
        }
        //Holds the user data.
        [BindProperty]
        public new User User { get; set; }

        //Adds the user to the database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.User.Add(User);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}