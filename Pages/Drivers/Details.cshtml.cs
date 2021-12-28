using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Car_Rental.Models;

namespace Car_Rental.Pages.Drivers
{
    //Get the details of a car.
    public class DetailsModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public DetailsModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }
        //Holds the driver model
        public Driver Driver { get; set; }

        //Gets the details of the driver using a lamda query.
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver =  _context.Driver
                .Include(d => d.Car).FirstOrDefault(m => m.Id == id);

            if (Driver == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
