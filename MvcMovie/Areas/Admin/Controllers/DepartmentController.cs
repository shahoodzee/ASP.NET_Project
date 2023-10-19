using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.DataAccessLayer;
using MvcMovie.DataAccessLayer.Infrastructure.IRepository;
using MvcMovie.Models;
using MvcMovie.Models.Models;
using MvcMovie.Models.ViewModels;
using System.ComponentModel;
using System.Data;

namespace MvcMovie.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class DepartmentController : Controller
    {
        private const string ErrorMessage = "Please select an image file.";
        //private ApplicationDbContext _context;
        private IUnitOfWork _unitofWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }
        public IActionResult Index()
        {
            DepartmentVM departmentVM = new DepartmentVM();
            departmentVM.departments = _unitofWork.Department.GetAll();
            return View(departmentVM);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]                                  //to preveent cross eye descripting attack.
        public IActionResult Create(Department department)
        {
			if (ModelState.IsValid)
            {
				//b4 unitofwork
				//_context.Add(user);
				//_context.SaveChanges(); 

				//after unitofwork
				_unitofWork.Department.Add(department);
                _unitofWork.Save();
            }
            else
            {
                ModelState.AddModelError("Invalid credentials",ErrorMessage);
                return View(department);
            }
            return RedirectToAction("Index");
        }

		[HttpGet]
		public IActionResult Search()
		{
			return View();
		}
		[HttpPost]
		public IActionResult SearchResult(int userId)
		{
			{
				// Retrieve user data based on the provided Guid
				var user = _unitofWork.Department.GetT(x => x.Id == userId);

				if (user != null)
				{
					return View("Search", user); // Pass the user data to the Search view
				}
			}

			ModelState.AddModelError("userId", "Invalid User ID or User not found.");
			return View("Search"); // Display the search form with an error message
		}

		public IActionResult Edit()
		{
			return View();
		}

		//[HttpPost]
		//public IActionResult Update(Guid userId, string firstName, string lastName, string city)
		//{
		//	// Retrieve the user from the database based on the provided ID

		//	var user = _unitofWork.User.GetT(x => x.Id == userId);

		//	if (user != null)
		//	{
		//		// Update user properties
		//		user.FirstName = firstName;
		//		user.LastName = lastName;
		//		user.City = city;

		//		// Save changes to the database
		//		_unitofWork.Save();

		//		// Redirect to a success page or perform other actions
		//		return RedirectToAction("Index"); // Redirect to the user list, for example
		//	}
		//	else
		//	{
		//		ModelState.AddModelError("userId", "User not found.");
		//		return View("Edit"); // Display the edit form with an error message
		//	}
		//}
		//[HttpGet]
		//public IActionResult Delete()
		//{
		//	return View();
		//}
		//[HttpPost]
		//public IActionResult ConfirmDelete(Guid userId)
		//{
		//	var user = _unitofWork.Department.GetT(x => x.D_id == userId);

		//	if (user != null)
		//	{
		//		// Delete the user
		//		_unitofWork.User.Delete(user);
		//		_unitofWork.Save();

		//		// Redirect to a success page or perform other actions
		//		return RedirectToAction("Index");
		//	}
		//	else
		//	{
		//		ModelState.AddModelError("userId", "User not found.");
		//		return View("Delete");
		//		// Display the delete form with an error message
		//	}
		//}
	}
}
