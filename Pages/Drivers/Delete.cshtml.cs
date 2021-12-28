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
    //Deletes an existing driver.
    public class DeleteModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public DeleteModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        //Holds the model
        [BindProperty]
        public Driver Driver { get; set; }

        //Gets the information about the driver using a lambda query.
        public  IActionResult OnGet(string id)
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

        //Removes the driver from  the database.
        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver =  _context.Driver.Find(id);

            if (Driver != null)
            {
                _context.Driver.Remove(Driver);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
