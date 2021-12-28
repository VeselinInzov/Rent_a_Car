using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Car_Rental.Models;

namespace Car_Rental.Pages.Bookings
{
    //Creates a Booking record.
    public class CreateModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public CreateModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        //Gets the  Create booking form.
        public IActionResult OnGet(string id)
        {
        ViewData["CarId"] = new SelectList(_context.Car, "Id", "CarRegNo", id);
        ViewData["UserId"] = new SelectList(_context.User, "Id", "UserName");
            return Page();
        }

        //Bind the booking data to the booking model.
        [BindProperty]
        public Booking Booking { get; set; }

        //Adds the booking record to the database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}