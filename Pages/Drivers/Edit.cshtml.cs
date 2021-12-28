using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Car_Rental.Models;

namespace Car_Rental.Pages.Drivers
{
    //Edit the driver details.
    public class EditModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public EditModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

         //Holds the  driver model.
        [BindProperty]
        public Driver Driver { get; set; }

         //Gets the driver information using a lamda query.
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver = _context.Driver
                .Include(d => d.Car).FirstOrDefault(m => m.Id == id);

            if (Driver == null)
            {
                return NotFound();
            }
           ViewData["CarId"] = new SelectList(_context.Car, "Id", "CarRegNo");
            return Page();
        }

        //Updates the driver.
        public  IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Driver).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(Driver.Id))
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
        //Checks whether the driver exists.
        private bool DriverExists(string id)
        {
            return _context.Driver.Any(e => e.Id == id);
        }
    }
}
