using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Car_Rental.Models;

namespace Car_Rental.Pages.Users
{
    //Gets all the users.
    public class IndexModel : PageModel
    {
        //The database context used to connect the the database.
        private readonly Car_Rental.Models.Car_RentalContext _context;

        public IndexModel(Car_Rental.Models.Car_RentalContext context)
        {
            _context = context;
        }

        //Holds the list of users.
        public new IList<User> User { get;set; }

        //Gets all the users using a linq query.
        public void OnGet()
        {
            using(_context){

             IQueryable<User> getAllUsers =   from user in _context.User select user;

                User = getAllUsers.ToList<User>();
            }
            
        }
    }
}
