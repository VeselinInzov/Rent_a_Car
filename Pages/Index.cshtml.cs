using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Rental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Car_Rental.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public IndexModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; }

        public void OnGet()
        {

            using (_context) {

                IQueryable<Car>  getAllCarsQuery = from car  in _context.Car  select car;
                Car = getAllCarsQuery.ToList<Car>();
            }
            
        }
    }
}
