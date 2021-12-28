using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Car_Rental.Models;

namespace Car_Rental.Pages.Cars
{
    //Gets all cars information.
    public class IndexModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public IndexModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        //Holds the cars model.
        public IList<Car> Car { get;set; }

        //Gets all the cars using a linq query.
        public void OnGet()
        {

            using (_context) {

              IQueryable<Car>  getAllCars  = from car in _context.Car select car;

               Car = getAllCars.ToList<Car>();

            }
               
        }
    }
}
