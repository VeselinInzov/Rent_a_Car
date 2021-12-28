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
    //Get all drivers information.
    public class IndexModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public IndexModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        //Holds the list of drivers.
        public IList<Driver> Driver { get;set; }

        //Gets all drivers using a linq query.
        public void OnGet()
        {
           IQueryable<Driver> getAllDrivers = from driver in _context.Driver select driver;

            Driver = getAllDrivers.ToList<Driver>();

        }
    }
}
