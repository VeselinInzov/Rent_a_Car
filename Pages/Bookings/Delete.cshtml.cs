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
    //Deletes an existing booking record.
    public class DeleteModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public DeleteModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        //Gets the delete booking confirmaton info.
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

        // Deletes the Booking on post.
        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking =  _context.Booking.Find(id);

            if (Booking != null)
            {
                _context.Booking.Remove(Booking);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
