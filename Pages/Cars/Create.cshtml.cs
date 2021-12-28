using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Car_Rental.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Car_Rental.Pages.Cars
{
    //Provides  a facility to add a new car.
    public class CreateModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public CreateModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        //Gets the add cars form .
        public IActionResult OnGet()
        {
            return Page();
        }

        //Holds the car model.
        [BindProperty]
        public Car Car { get; set; }

        //Adds a car to the database
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
          
            //Saves the uplodaed image
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

            _context.Car.Add(Car);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}