using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Car_Rental.Models;

namespace Car_Rental.Pages.Drivers
{
    //Creates a Driver assigned to a car.
    public class CreateModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public CreateModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        //Gets the form data to create a driver.
        public IActionResult OnGet()
        {
        ViewData["CarId"] = new SelectList(_context.Car, "Id", "CarRegNo");
            return Page();
        }

         //Holds the model for the driver.
        [BindProperty]
        public Driver Driver { get; set; }

        //Adds a  driver to the database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Driver.Add(Driver);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}