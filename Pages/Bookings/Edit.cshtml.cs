using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Car_Rental.Models;

namespace Car_Rental.Pages.Bookings
{
    //Allows to edit a booking.
    public class EditModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public EditModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        //Holds the booking model.
        [BindProperty]
        public Booking Booking { get; set; }


        // Gets the booking edit form data using lambda query.
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking =  _context.Booking
                .Include(b => b.Car)
                .Include(b => b.User).FirstOrDefault(m => m.BookingId == id);

            if (Booking == null)
            {
                return NotFound();
            }
           ViewData["CarId"] = new SelectList(_context.Car, "Id", "Id");
           ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return Page();
        }

        // Update the booking.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Booking).State = EntityState.Modified;

            try
            {
                 _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(Booking.BookingId))
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
        //Checks whether the booking exists.
        private bool BookingExists(string id)
        {
            return _context.Booking.Any(e => e.BookingId == id);
        }
    }
}
