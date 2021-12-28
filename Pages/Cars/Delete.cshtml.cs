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
    //Deletes an existing car.
    public class DeleteModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public DeleteModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        //Holds the car model
        [BindProperty]
        public Car Car { get; set; }

        //Gets the Car data from  a lambda query.
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car =  _context.Car.FirstOrDefault(m => m.Id == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        //Deletes a car . uses a linq query to get the car.
        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

      

              IQueryable<Car> findCarWithId =   from car in _context.Car where car.Id == id select car;
              Car = findCarWithId.FirstOrDefault();
            

            if (Car != null)
            {
                _context.Car.Remove(Car);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
