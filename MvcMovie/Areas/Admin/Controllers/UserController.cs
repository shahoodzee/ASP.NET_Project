using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using MvcMovie.DataAccessLayer;
using MvcMovie.DataAccessLayer.Infrastructure.IRepository;
using MvcMovie.DataAccessLayer.Infrastructure.Repository;
using MvcMovie.Models;
using MvcMovie.Models.Models;
using MvcMovie.Models.ViewModels;

namespace MvcMovie.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles ="Admin")]
	public class UserController : Controller
	{
		private const string ErrorMessage = "Please select an image file.";

		//private ApplicationDbContext _context;

		private IUnitOfWork _unitofWork;


		public UserController(IUnitOfWork unitOfWork)
		{
			_unitofWork = unitOfWork;
		}


		#region APICALL
		public IActionResult AllUsers()//action
		{
			var users = _unitofWork.User.GetAll(); //we use the unitofwork getall() function to 
			return Json(new { data = users });
		}
		#endregion

		#region EditAPICALL
		public IActionResult EditUser(string Id)
		{
            Guid guidId = new Guid(Id);

            UserVM userVM = new UserVM()
			{
				User = new(),
				departments = _unitofWork.Department.GetAll().Select(x =>
				new SelectListItem()
				{
					Text = x.D_name,
					Value = x.Id.ToString(),
				})
			};

            var user = _unitofWork.User.GetT(x => x.Id == guidId);
			var departments = userVM.departments;

			userVM.User = user;

			if (user != null)
			{
				return Json(new { success = true , User = user , DepartmentList = departments });
            }
			else
			{
				return Json(new { success = false });
			}
		}

		[HttpPost]
		public IActionResult SaveChanges(string Id, string FirstName, string LastName, string City, int DepartmentId)
		{
            Guid guidId = new Guid(Id);
				
            // Retrieve user data based on the provided Guid
            var user = _unitofWork.User.GetT(x => x.Id == guidId);

            // Update user properties
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.City = City;
            user.DepartmentId = DepartmentId;

            if (user != null)
            {
                // Save changes to the database
                _unitofWork.Save();

                // Return a response, such as a success message
                return Json(new { success = true, message = "Success in Editing the userId" });
            }
            else
            {
                return Json(new { success = false });
            }
        }

		#endregion


        #region DeleteAPICALL
        [HttpDelete]
		public IActionResult DeleteUser(string Id)
		{
            {
                Guid guidId = new Guid(Id);
                // Retrieve user data based on the provided Guid
                var user = _unitofWork.User.GetT(x => x.Id == guidId);

                if (user != null)
                {
                    // Delete the user
                    _unitofWork.User.Delete(user);
                    _unitofWork.Save();
                    return Json(new { success = true, message = "Success in deleting the userId" });
                }
                else
                {
                    //show error in JSON response
                    return Json(new { success = false, message = "Error in deleting the userId" });
                }
            }
		}
		#endregion

		public IActionResult Index()//action
		{
			UserVM userVM = new UserVM();
			userVM.users = _unitofWork.User.GetAll(); //we use the unitofwork getall() function to 
			return View(userVM);
		}


        [HttpGet]
		public IActionResult Create()
		{
			UserVM userVM = new UserVM()
			{
				departments = _unitofWork.Department.GetAll().Select(x =>
				new SelectListItem()
				{
					Text = x.D_name,
					Value = x.Id.ToString(),
				})
			};
			return View(userVM);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]              //to preveent cross eye descripting attack.
		public IActionResult Create(UserVM obj, User vm, IFormFile ImageData)
		{

			//if (ModelState.IsValid)
			{
				using (var stream = new MemoryStream())
				{
					ImageData.CopyTo(stream);
                    vm.ImageData = stream.ToArray(); ;
				}
				UserVM userVM = new UserVM();
				userVM.User = vm;
				userVM.User.DepartmentId = obj.User.DepartmentId;

				_unitofWork.User.Add(userVM.User);
                _unitofWork.Save();

			}

			return RedirectToAction("Index");

		}


		[HttpGet]
		public IActionResult Search()
		{
			return View();
		}
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchResult(string userId)
		{
			if (Guid.TryParse(userId, out Guid userGuid))
			{
				// Retrieve user data based on the provided Guid
				var user = _unitofWork.User.GetT(x => x.Id == userGuid);

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
			UserVM userVM = new UserVM()
			{
				departments = _unitofWork.Department.GetAll().Select(x =>
				new SelectListItem()
				{
					Text = x.D_name,
					Value = x.Id.ToString(),
				})
			};
			return View(userVM);
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserVM uservm,User userobj)
		{
			Guid userId = userobj.Id;
			// Retrieve the user from the database based on the provided ID
			var user = _unitofWork.User.GetT(x => x.Id == userId);

			if (user != null)
			{
				// Update user properties
				user.FirstName = userobj.FirstName;
				user.LastName = userobj.LastName;
				user.City = userobj.City;
				user.DepartmentId = uservm.User.DepartmentId;

				// Save changes to the database
				_unitofWork.Save();

				// Redirect to a success page or perform other actions
				return RedirectToAction("Index"); // Redirect to the user list, for example
			}
			else
			{
				ModelState.AddModelError("userId", "User not found.");
				return View("Edit"); // Display the edit form with an error message
			}
		}
		[HttpGet]
		public IActionResult Delete()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ConfirmDelete(string userId)
		{

			if (Guid.TryParse(userId, out Guid userGuid))
			{
				// Retrieve user data based on the provided Guid
				var user = _unitofWork.User.GetT(x => x.Id == userGuid);

				if (user != null)
				{
					// Delete the user
					_unitofWork.User.Delete(user);
					_unitofWork.Save();
				}

				// Redirect to a success page or perform other actions
			}
			else
			{
				// Display the delete form with an error message
				ModelState.AddModelError("userId", "User not found.");
				return View("Delete");
			}
			return View("Index");  //redirect to index page

		}




	}
}


























//public IActionResult EditUser(string Id)
//{
//          Guid guidId = new Guid(Id);

//          UserVM userVM = new UserVM()
//	{
//		User = new(),
//		departments = _unitofWork.Department.GetAll().Select(x =>
//		new SelectListItem()
//		{
//			Text = x.D_name,
//			Value = x.Id.ToString(),
//		})
//	};

//          var user = _unitofWork.User.GetT(x => x.Id == guidId);

//	userVM.User = user;

// //         if (user != null)
// //         {
// //             return Json(new { success = true, message = "Success in deleting the userId" });
// //         }
//	//else
//	//{
//	//	return Json(new { success = true, message = "Success in deleting the userId" });
//	//}
//          return View(userVM);
//      }