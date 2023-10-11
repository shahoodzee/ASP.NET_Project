using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.Models.ViewModels
{
    public class UserVM
    {
        public User User { get; set; }
        //get all users
        //If your visew needs to display data from the User model alongside data from other sources or view-specific data, 
        //including a reference to User in your view model makes sense.This allows you to easily pass and display User-related information in the view.
        [ValidateNever]
        public IEnumerable<User> users { get; set; } = new List<User>();
        [ValidateNever]
        public IEnumerable<SelectListItem> departments { get; set; }

    }
}
