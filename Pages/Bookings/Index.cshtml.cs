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
    //Shows all bookings
    public class IndexModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public IndexModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        //Holds the booking model.
        public IList<Booking> Booking { get;set; }

        //Gets all booking using a lamda query.
        public void OnGet()
        {

            Booking = _context.Booking.Include(c => c.Car).Include(c => c.User).ToList<Booking>();
        }
    }
}
