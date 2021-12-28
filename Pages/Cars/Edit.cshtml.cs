using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Car_Rental.Models;
using System.IO;

namespace Car_Rental.Pages.Cars
{
    //Edits an existing car.
    public class EditModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public EditModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        //Holds the car model.
        [BindProperty]
        public Car Car { get; set; }


        //Get the form data using a lamda query.
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

        //Updates the car.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Car).State = EntityState.Modified;
            //saves the uploaded image.
            if (Car.UploadedFile != null)
            {
                Car.ImageUrl = Car.UploadedFile.FileName;
                var filePath = "./wwwroot/images/" + Car.UploadedFile.FileName;


                if (Car.UploadedFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Car.UploadedFile.CopyTo(stream);
                    }
                }
            }

          


            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.Id))
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
        //Checks whether the car exists.
        private bool CarExists(string id)
        {
            return _context.Car.Any(e => e.Id == id);
        }
    }
}
