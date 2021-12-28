using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Car_Rental.Models;

namespace Car_Rental.Pages.Bookings
{
    //Shows booking details.
    public class DetailsModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public DetailsModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }
        //Holds the booking model
        public Booking Booking { get; set; }

        //Gets the booking data with car and user info using lambda query.
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
            return Page();
        }
    }
}
