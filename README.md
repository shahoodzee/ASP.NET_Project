# ASP.NET Project

# Banking App system Tutorial Via ASP>NET version 6 (Long Term Support)

In tis utorial we will look into step by sep tutorial of BAnking App using ASP.NET MCV frameowork.

# SETUP ENVIROMENT
right click the project directory and select *edit ptoject file*

this will give you this code.

  <Project Sdk="Microsoft.NET.Sdk.Web">
    <PropertyGroup>
      <TargetFramework>net6.0</TargetFramework>
      <Nullable>enable</Nullable>
      <ImplicitUsings>enable</ImplicitUsings>
    </PropertyGroup>
  </Project>


### 1. `<Project Sdk="Microsoft.NET.Sdk.Web">`: 
This line specifies the SDK (Software Development Kit) that your project is using. In this case, it's using the "Microsoft.NET.Sdk.Web" SDK, which is tailored for web applications built on the .NET platform.

### 2. `<PropertyGroup>`: 
This section defines various properties and settings for your project.

   - `<TargetFramework>net6.0</TargetFramework>`: This line specifies the target framework version for your project, which is .NET 6.0 in this case. It means your project is built to run on the .NET 6.0 runtime.

   - `<Nullable>enable</Nullable>`: This setting enables nullable reference types in your project. It allows you to specify whether a reference type (like strings or custom objects) can be null or not, helping you catch potential null reference exceptions at compile-time.

   - `<ImplicitUsings>enable</ImplicitUsings>`: This setting enables the use of implicit usings in your code. Implicit usings allow you to omit certain using directives for common namespaces in your code files.




# Main Method
In the proj directories there is program.cs file that is our cs program is converted into web program.
This code is from your `Program.cs` file in an ASP.NET project and is responsible for configuring the application's startup process. Here's a brief explanation:

1. `WebApplication.CreateBuilder(args)`: This line creates a web application builder, which is used to configure and build the ASP.NET application. It initializes the application with the provided command-line arguments (`args`).

2. `builder.Services.AddControllersWithViews()`: This line adds services to the dependency injection container for controllers and views, which are fundamental components for handling HTTP requests and rendering views.

3. `var app = builder.Build()`: This line builds the web application using the configured services and settings.

4. Conditional Configuration: The following block of code checks whether the application is running in a development environment:

   ```csharp
   if (!app.Environment.IsDevelopment())
   {
       // Configuration for non-development environments.
   }
   ```

   - In a non-development environment, it configures the application to use an exception handler for error handling and sets up HTTP Strict Transport Security (HSTS) for enhanced security.

5. `app.UseHttpsRedirection()`: This middleware redirects HTTP requests to HTTPS for secure communication.

6. `app.UseStaticFiles()`: This middleware enables serving static files (e.g., CSS, JavaScript, images) directly to clients.

7. `app.UseRouting()`: This middleware sets up routing for handling incoming HTTP requests and determining which controller action to execute based on the request URL.

8. `app.UseAuthorization()`: This middleware adds authorization handling, allowing you to secure specific parts of your application.

9. `app.MapControllerRoute(...)`: This method configures a default route for the controllers. It defines a route pattern that maps controller actions based on the URL structure. For example, it maps requests to the `Home` controller's `Index` action by default.

10. `app.Run()`: This starts the application and begins listening for incoming HTTP requests. It's the entry point for your ASP.NET application.

In summary, this code sets up a basic ASP.NET web application, configures middleware components, and defines routing and error handling logic. It's a standard configuration for many ASP.NET MVC applications, with optional adjustments based on whether the application is running in a development or non-development environment.
  
 # In-process hosting and Out-process hosting.
*By default Visual studio uses IIS Express which is a method of In-process hosting*

 In the context of ASP.NET, "in-process hosting" and "out-of-process hosting" refer to different ways of running and managing your web application within a web server. Each approach has its own advantages and trade-offs:

1. **In-Process Hosting**:

   - **In-process hosting** (also known as "in-process mode" or "in-proc") means that your web application runs within the same process as the web server. This is typically achieved using the ASP.NET Core in-process hosting model.

   - **Advantages**:
     - **Performance**: In-process hosting is generally faster because the application code runs in the same process as the web server. This reduces communication overhead.
     - **Simplicity**: It's easier to set up and manage because there is only one process to deal with.
   
   - **Disadvantages**:
     - **Scalability**: In-process hosting is not suitable for scaling your application across multiple server instances. If one instance crashes or needs to be taken down for maintenance, all requests to that instance are affected.
     - **Isolation**: There is limited process isolation. If your application encounters a critical error, it can potentially crash the entire web server process.

2. **Out-of-Process Hosting**:

   - **Out-of-process hosting** (also known as "out-of-process mode") means that your web application runs in a separate process from the web server. This is typically achieved using the ASP.NET Core out-of-process hosting model.

   - **Advantages**:
     - **Scalability**: Out-of-process hosting allows you to scale your application across multiple server instances or even across different physical servers. Each instance runs independently, so if one crashes or requires maintenance, it doesn't affect the others.
     - **Isolation**: It provides better process isolation. If your application encounters an issue, it's less likely to crash the entire web server.
   
   - **Disadvantages**:
     - **Slightly Slower**: Out-of-process hosting can introduce a small performance overhead because requests need to be marshaled between the web server and the application process.
     - **More Complex Setup**: Setting up and managing out-of-process hosting can be more complex compared to in-process hosting.

The choice between in-process and out-of-process hosting depends on your application's requirements. If you have a small application with low traffic and want the best performance, in-process hosting may be a good choice. However, for larger applications that need scalability, isolation, and fault tolerance, out-of-process hosting is often preferred.

In ASP.NET Core, you can configure the hosting model in your application's settings, allowing you to choose the one that best fits your needs.
By default its in process hostin gin visual studio but if u wanna make it in process hosting you will go to *edit project file*
And add the <AspNetCoreHostingmodel>OutofProcess</AspNetCoreHostingmodel> tag.

# LaunchSettings.json file in properties.
The `launchSettings.json` file in the `properties` directory of your project is used to configure various settings related to launching and debugging your ASP.NET application.

    {
      "iisSettings": {
        "windowsAuthentication": false,
        "anonymousAuthentication": true,
        "iisExpress": {
          "applicationUrl": "http://localhost:6178",
          "sslPort": 44359
        }
      },
      "profiles": {
        "MvcMovie": {
          "commandName": "Project",
          "dotnetRunMessages": true,
          "launchBrowser": true,
          "applicationUrl": "https://localhost:7249;http://localhost:5225",
          "environmentVariables": {
            "ASPNETCORE_ENVIRONMENT": "Development"
          }
        },
        "IIS Express": {
          "commandName": "IISExpress",
          "launchBrowser": true,
          "environmentVariables": {
            "ASPNETCORE_ENVIRONMENT": "Development"
          }
        }
      }
    }
  
Here's a brief explanation of the key parts of this file:

1. **iisSettings**: This section contains settings related to Internet Information Services (IIS) Express, a lightweight web server often used for local development.

   - `windowsAuthentication`: Specifies whether Windows Authentication is enabled (false in this case).
   - `anonymousAuthentication`: Specifies whether Anonymous Authentication is enabled (true in this case).
   - `iisExpress`: Contains information about the IIS Express configuration, including the application's base URL and SSL port.

2. **profiles**: This section defines different profiles or configurations for launching your application.

   - `"MvcMovie"`: This profile is configured to use the `dotnet run` command to start your ASP.NET application. It launches a browser, sets the application's URLs (both HTTP and HTTPS), and sets the `ASPNETCORE_ENVIRONMENT` environment variable to "Development."

   - `"IIS Express"`: This profile is configured to use IIS Express for launching your application. It also launches a browser and sets the `ASPNETCORE_ENVIRONMENT` environment variable to "Development."

These profiles provide options for debugging and launching your application in different ways, whether through Visual Studio or from the command line. The `launchBrowser` setting indicates whether a web browser should automatically open when you start debugging. The `ASPNETCORE_ENVIRONMENT` environment variable is set to "Development," which configures your application for development mode, enabling features like detailed error information.

Overall, this file helps streamline the development and debugging process by specifying how your ASP.NET application should behave when launched from various environments.
 
| Command       | ArspCorehostingmodel | internalWebserver | External Webserver |
| ------------- |:--------------------:| -----------------:|-------------------:|
| col 3 is      | right-aligned        | $1600             |                    |
| col 3 is      | right-aligned        | $1600             |                    |
| col 3 is      | right-aligned        | $1600             |                    |
| col 3 is      | right-aligned        | $1600             |                    |
| col 3 is      | right-aligned        | $1600             |                    |



# Coding Started 

# Create a User model.
open models folder in pro directory and write this following model.

    using System.ComponentModel.DataAnnotations;
    namespace MvcMovie.Models
    {
        public class User
        {
            [Key] //primary key
    
            public Guid Id { get; set; }
            [Required]  //datanotations
    
            public string FirstName { get; set; }
            [Required]
    
            public string LastName { get; set; }
            [Required]
    
            public string Email { get; set; }
            [Required]
    
            public string City { get; set; }
            
            public byte[] ImageData { get; set; }
    
            public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    
        }
    }

# Data Types in SQL


1. datetime	    From January 1, 1753 to December 31, 9999 with an accuracy of 3.33 milliseconds	  8 bytes
2. datetime2	    From January 1, 0001 to December 31, 9999 with an accuracy of 100 nanoseconds	    6-8 bytes
3. date	        Store a date only. From January 1, 0001 to December 31, 9999	                    3 bytes
4. time	        Store a time only to an accuracy of 100 nanoseconds	                              3-5 bytes
5. char(n)	      Fixed width character string	 8,000 characters(MaxSize)	                        Defined width
6. varchar(n)	  Variable width character string	8,000 characters(MaxSize)	                        2 bytes + number of chars
7. varchar(max)	Variable width character string	1,073,741,824 characters(MaxSize)	                2 bytes + number of chars
8. nvarchar	    Variable width Unicode string	4,000 characters(MaxSize)
9. nvarchar(max)	Variable width Unicode string	536,870,912 characters(MaxSize)	 

## Data Annotations
Data annotations in ASP.NET are a way to apply metadata to your model classes, indicating how they should be treated by the framework. These annotations are attributes you can apply to properties of your model classes. Here's a brief explanation of some common data annotations:

1. **[Required]**: This annotation specifies that a property must have a non-null value. It's used to enforce that a value is provided for the property.

   ```csharp
   [Required]
   public string Name { get; set; }
   ```

2. **[StringLength]**: This annotation sets the maximum and minimum length constraints for a string property.

   ```csharp
   [StringLength(50, MinimumLength = 2)]
   public string Title { get; set; }
   ```

3. **[Range]**: It specifies a range of acceptable values for numeric properties.

   ```csharp
   [Range(1, 100)]
   public int Age { get; set; }
   ```

4. **[EmailAddress]**: This annotation ensures that a property contains a valid email address.

   ```csharp
   [EmailAddress]
   public string Email { get; set; }
   ```

5. **[RegularExpression]**: You can use this annotation to specify a regular expression pattern that a property value must match.

   ```csharp
   [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
   public string Country { get; set; }
   ```

6. **[Compare]**: It's used for properties that should have matching values, such as password confirmation.

   ```csharp
   [Compare("Password")]
   public string ConfirmPassword { get; set; }
   ```

7. **[Display]**: This annotation provides metadata about how a property should be displayed, including its name, group name, and more.

   ```csharp
   [Display(Name = "Full Name")]
   public string Name { get; set; }
   ```

8. **[DataType]**: It specifies the data type of a property, which can be useful for customizing how it's displayed.

   ```csharp
   [DataType(DataType.Date)]
   public DateTime BirthDate { get; set; }
   ```

These data annotations help you define validation rules, customize display names, and provide additional metadata to control how your model properties are treated by ASP.NET 6.0. They play a crucial role in form validation and model binding within your application.

# install Microsoft.EntityFrameworkCore.SqlServer
right click peoj name and enter Nuget packages search `Microsoft.EntityFrameworkCore.SqlServer` and install latest version.

# Adding connection String
Goto your appsettings.json file and rewrite this following code.

    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=bank;Trusted_Connection=True;MultipleActiveResultSets=true"
      }
    }

Create a new directory data and add a class `ApplicationDbContext.cs` init write this following code in it.

    using Microsoft.EntityFrameworkCore;
    using MvcMovie.Models;
    
    namespace MvcMovie.Data
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                   :base(options)
            {
            
            }
            public DbSet<User> User { get; set; }
        }
    }

In summary, this code defines a database context class named ApplicationDbContext that is used to interact with a database in your ASP.NET application. It is configured to work with a "User" table in the database through the User property of type DbSet<User>. This DbContext is typically used for performing database operations like querying and saving data.

update your `program.cs`file in the flllowiung way the order of code lines is important.

    using Microsoft.EntityFrameworkCore;
    using MvcMovie.Data;
    
    var builder = WebApplication.CreateBuilder(args);
    
    // Add services to the container.
    builder.Services.AddControllersWithViews();
    //adding database services---------------------------------------------------------------------------
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<ApplicationDbContext>(options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DeafaultConnection"));
    });
    var app = builder.Build();
    
    //----------------------------------------------------------------------------------------------------
    
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    
    app.UseRouting();
    
    app.UseAuthorization();
    
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    
    app.Run();

# Install packager manager console
just search in Visual Studio and it will open it for you
Open again Nugetmaangepackages search for `Microsoft.EntityFrameworkCore.Tools` and install it.
**You need to install these particular set of tools to run your code properly.**
. Microsoft.EntityFrameworkCore
. Microsoft.EntityFrameworkCore.SqlServer
. Microsoft.EntityFrameworkCore.Tools
. Microsoft.VisualStudio.Web.CodeGeneration.Design


Now we can start migration process from package manager console. Open package manager console and write:
`add-migration AddUserToDatabase`

    "DefaultConnection": "Server=DESKTOP-MF0R5GF\\SQLEXPRESS;Database=bank;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"

First update the database and Trustcertificate=True
This will add User Model in the Database in the SqlServer. AddUserToDatabase file is generated. Naming Convention is written with respect to a class name.
Now update the database with the command `update-database`.
Now to check wether we are sucesful or not

Goto Tools-> Connect to db-> Give Credentials and select the database. (Server Explorer)And you can view your database from there.

# Add controller
right click `controllerfolder` and select Add and `controller`.Create an empty controller named `UserController`
This will give such default code 

    using Microsoft.AspNetCore.Mvc;
    
    namespace MvcMovie.Controllers
    {
        public class UserController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
        }
    }

# Add a view 
right click on this `View()` and select a new Razor view. `name-> view` `Template-> Empty(without model)` `Select Check box Use a layout page`.
This will open code in index.cshtml (Views->User->index.cshtml)

    @{
        ViewData["Title"] = "Index";
    }
    <h1>Index</h1>

You can edit this index.htmnl file to show the the users stored in the db. like :

    @model IEnumerable<User> 
    @{
        ViewData["Title"] = "User";
    }
    <head>
        <link rel="stylesheet" type="text/css" href="~/css/User.css">
    </head>
    
    
    <body>
        <section>
            <div class="contianer">
                <h5>List of users in our system.</h5>
                <h5>
                    <a asp-action="Create" asp-controller="user">Add a User</a>
                    <a asp-action="Search" asp-controller="user"> Seach a User</a>
                </h5>
    
                <table>
                    <thead>
                        <tr>
                            <th>UserId</th>
                            <th>First Name</th>
                            <th>Last name</th>
                            <th>Email</th>
                            <th>City</th>
                            <th>Image</th>
                        </tr>
                    </thead>
                    <tbody>
                        @foreach (var item in Model)
                        {
                            var base64String = Convert.ToBase64String(item.ImageData); // Move this line inside the code block
                            <tr>
                                <td>@item.Id</td>
                                <td>@item.FirstName</td>
                                <td>@item.LastName</td>
                                <td>@item.Email</td>
                                <td>@item.City</td>
                                <td>
                                    <img src="data:image/jpeg;base64,@base64String" alt="Image" />
                                </td>
                            </tr>
                        }
                    </tbody>
    
                </table>
    
    
    
            </div>
        </section>
    </body>
    

Now in order for this code to work. You need some actions code in controller file. So write this code in UserController file.

    using Microsoft.AspNetCore.Mvc;
    using MvcMovie.Data;
    using MvcMovie.Models;
    using System.ComponentModel;
    
    namespace MvcMovie.Controllers
    {
        public class UserController : Controller
        {
            private ApplicationDbContext _context;
    
            public  UserController(ApplicationDbContext context)
            {
                _context = context;
            }
    
            public IActionResult Index()//action
            {
                IEnumerable<User> users = _context.User; 
                return View(users);
            }
        }
    }

In this way we can create the rest of the views and their particular actions.


    using Microsoft.AspNetCore.Mvc;
    using MvcMovie.Data;
    using MvcMovie.Models;
    using System.ComponentModel;
    
    namespace MvcMovie.Controllers
    {
        public class UserController : Controller
        {
            private ApplicationDbContext _context;
    
            public  UserController(ApplicationDbContext context)
            {
                _context = context;
            }
    
            public IActionResult Index()//action
            {
                IEnumerable<User> users = _context.User; 
                return View(users);
            }
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]              //to prevent cross eye descripting attack.
            public IActionResult Create(User user , IFormFile ImageData)
            {
    
    			if (ImageData != null && ImageData.Length > 0 && ModelState.IsValid)
    			{
    				// Convert the uploaded image to a byte array
    				using (var stream = new MemoryStream())
    				{
    					ImageData.CopyTo(stream);
    					user.ImageData = stream.ToArray();
    				}
    				_context.Add(user);
    				_context.SaveChanges();
    			}
    			else
    			{
    				// Handle the case where no image was uploaded
    				ModelState.AddModelError("ImageData", "Please select an image file.");
    				return View(user);
    			}
                return RedirectToAction("Index");
            }
            public IActionResult Edit(string userId)
            {
                if (Guid.TryParse(userId, out Guid userGuid))
                {
                    // Retrieve user data based on the provided Guid
                    var user = _context.User.FirstOrDefault(u => u.Id == userGuid);
    
                    if (userId is null)
                    {
                        return NotFound();
                    }
    
                }
                return View("Search", userId); // Pass the user data to the Search view
            }
            [HttpGet]
    		public IActionResult Search(Guid? user_id)
    		{
    			return View();
    		}
            [HttpPost]
            public IActionResult SearchResult(string userId)
            {
                if (Guid.TryParse(userId, out Guid userGuid))
                {
                    // Retrieve user data based on the provided Guid
                    var user = _context.User.FirstOrDefault(u => u.Id == userGuid);
    
                    if (user != null)
                    {
                        return View("Search", user); // Pass the user data to the Search view
                    }
                }
    
                ModelState.AddModelError("userId", "Invalid User ID or User not found.");
                return View("Search"); // Display the search form with an error message
            }
        }
    }

The provided code is a part of an ASP.NET Core MVC application that deals with user management, including creating, editing, and searching for users in a database. Let's break down the key aspects of this code briefly:

1. **Controller Initialization and Dependency Injection:**
   - The `UserController` is defined as a controller class that inherits from `Controller`.
   - It has a constructor that takes an instance of `ApplicationDbContext` through dependency injection, allowing it to interact with the database.

2. **Index Action (`Index()`):**
   - The `Index` action retrieves a list of users from the database and passes them to the `Index` view for display.

3. **Create Actions (`Create()` and `Create(User user, IFormFile ImageData)`):**
   - The `Create` actions handle both GET and POST requests for creating new users.
   - The `HttpGet` `Create` action displays a blank form for creating a new user.
   - The `HttpPost` `Create` action processes the form submission.
     - It checks if an image (`ImageData`) was uploaded and if the form data is valid.
     - If an image is uploaded, it converts the image to a byte array and saves it along with user data to the database using `ApplicationDbContext`.
     - If no image is uploaded or the form is invalid, it adds a model error and redisplays the form.
     - After successfully creating a user, it redirects to the `Index` action to display the list of users.

4. **Edit Action (`Edit(string userId)`):**
   - The `Edit` action handles both GET and POST requests for editing user information.
   - It takes a `userId` parameter as a string.
   - In the `HttpGet` version, it attempts to retrieve the user to edit based on the provided `userId`. If the user is found, it displays the edit form.
   - The `HttpPost` version of this action is missing. You should implement it to handle form submissions and update user data in the database.

5. **Search Actions (`Search()` and `SearchResult(string userId)`):**
   - The `Search` action is responsible for displaying a search form where users can input a user ID to search for.
   - The `SearchResult` action handles the search functionality. It takes a `userId` parameter as a string.
   - In the `HttpPost` version, it attempts to retrieve the user data based on the provided `userId`. If the user is found, it passes the user data to the `Search` view. If not found, it adds a model error and redisplays the search form.

Overall, this code provides basic functionality for creating, editing, and searching for users in an ASP.NET Core MVC application. However, you should implement the missing parts of the `Edit` action to enable user editing and ensure proper routing and view setup for a complete application. Additionally, consider adding error handling and validation to enhance the robustness of the application.


When we have created the views we would have right clicked the view() and associated a razor page (html file with it). If it had already been created we would have selected Go to View to check/edit the view.
The html pages Associated with views we need to implement them. So far we have:

1. **index.cshtml**
2. **Search.xshtml**
3. **Index.cshtml**
4. **Create.cshtml**

Search.cshtml

    @{
        ViewData["Title"] = "Search";
    }
    @model User
    
    <!DOCTYPE html>
    <html>
    <head>
        <title>Search User</title>
    
    </head>
    <body>
    
        <form method="post" asp-action="SearchResult">
            <label for="Id">Enter User ID:</label>
            <input type="text" id="Id" name="userId" />
            <button type="submit">Search</button>
        </form>
    
        <br />
    
        @if (Model != null)
        {
            <section class="vh-500" style="background-color: #f4f5f7;">
                <div class="container py-5 h-100">
                    <div class="row d-flex justify-content-center align-items-center h-100">
                        <div class="col col-lg-6 mb-4 mb-lg-0">
                            <div class="card mb-3" style="border-radius: .5rem;">
                                <div class="row g-0">
                                    <div class="col-md-4 gradient-custom text-center text-white"
                                         style="border-top-left-radius: .5rem; border-bottom-left-radius: .5rem;">
                                            <img src="data:image/jpeg;base64,@Convert.ToBase64String(Model.ImageData)"alt="Avatar" class="img-fluid my-5" style="width: 80px;" />
                                   
                                            <h5>@Model.FirstName @Model.LastName</h5>
                                        <i class="far fa-edit mb-5"></i>
                                    </div>
                                    <div class="col-md-8">
                                        <div class="card-body p-4">
                                            <h6>Information</h6>
                                            <hr class="mt-0 mb-4">
                                            <div class="row pt-1">
                                                <div class="col-6 mb-3">
                                                    <h6>Email</h6>
                                                    <p class="text-muted">@Model.Email</p>
                                                </div>
                                                <div class="col-6 mb-3">
                                                    <h6>City</h6>
                                                    <p class="text-muted">@Model.City</p>
                                                </div>
                                            </div>
                                            <h6>User ID</h6>
                                            <hr class="mt-0 mb-4">
                                            <p>@Model.Id</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </section>
        }
    </body>
    </html>


**Create.cshtml page**

    @{
        ViewData["Title"] = "Create";
    }
    
    @model User
    
    <head>
    	<!-- Include the CSS file -->
    	<link rel="stylesheet" type="text/css" href="~/css/createuserform.css">
    	<!-- Other head content -->
    </head>
    <script>
    	function validateForm() {
    		var fileInput = document.querySelector('input[type="file"]');
    		if (!fileInput.files[0]) {
    			alert('Please select an image file.');
    			return false;
    		}
    		else
    		{
    			alert('User is Added successfully')
    		}
    		return true;
    	}
    </script>
    <body>
    	<section>
    
    		<div class="card">
    			<h5>Add a User form</h5>
    			<a asp-action="Index" asp-controller="user"> Users</a>
    			<div class="User-Form">
    				<form method="post" enctype="multipart/form-data" onsubmit="return validateForm()" >
    
    					<input type="text" asp-for="FirstName" name="FirstName" placeholder="First name" required/>
    					<span asp-validation-for="FirstName" class="text-danger"></span>
    					<br />
    					<input type="text" asp-for="LastName" name="LastName" placeholder="last name" required/>
    					<span asp-validation-for="LastName" class="text-danger"></span>
    					<br />
    					<input type="email" asp-for="Email" name="Email" placeholder="Email" required/>
    					<span asp-validation-for="Email" class="text-danger"></span>
    					<br />
    					<input type="text" asp-for="City" name="City" placeholder="City" required/>
    					<span asp-validation-for="City" class="text-danger"></span>
    					<br />
    					 <input type="file" asp-for="ImageData" name="ImageData" onchange="fileCheck(this);" required/>
    					<span asp-validation-for="ImageData" class="text-danger"></span>
    					<br />
    					<button  type="submit">Create User</button>
    					<br />
    
    
    				</form>
    			</div>
    		</div>
    	</section>
    </body>

# Add the controller in the navabar present in `shared` `layout.cshtml` file.

      <!DOCTYPE html>
      <html lang="en">
      <head>
          <meta charset="utf-8" />
          <meta name="viewport" content="width=device-width, initial-scale=1.0" />
          <title>@ViewData["Title"] - MvcMovie</title>
          <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
          <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KyZXEAg3QhqLMpG8r+ckkEd5pMI0MEe3m5mL/4E3j3Se5t5C5ZMa1FiqO5f5uy5Kg" crossorigin="anonymous">
          <link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />
          <link rel="stylesheet" href="~/MvcMovie.styles.css" asp-append-version="true" />
      </head>
      <style>
          .myfooter{
              padding-top: 10rem;
          
          }
      </style>
      <body>
          <header>
              <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-primary border-bottom box-shadow mb-3">
                  <div class="container-fluid">
                      <a class="navbar-brand" href="#">
                          <img src="~/logo/bank.png" alt=" " width="30" height="30" class="d-inline-block align-text-top" />
                      </a>
                      <a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">MyBank</a>
                      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                              aria-expanded="false" aria-label="Toggle navigation">
                          <span class="navbar-toggler-icon"></span>
                      </button>
                      <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                          <ul class="navbar-nav flex-grow-1">
                              <li class="nav-item">
                                  <a class="nav-link text-dark" asp-area="User" asp-controller="Home" asp-action="Index">Home</a>
                              </li>
                              <li class="nav-item">
                                  <a class="nav-link text-dark" asp-area="Admin" asp-controller="User" asp-action="Index">Users</a>
                              </li>
                              <li class="nav-item">
                                  <a class="nav-link text-dark" asp-area="Admin" asp-controller="Deapartment" asp-action="Index">Departments</a>
                              </li>
                          </ul>
                      </div>
                  </div>
              </nav>
          </header>
          <div class="container">
              <main role="main" class="pb-3">
                  @RenderBody()
              </main>
          </div>
      
      
          <div class="myfooter container border-top border-bottom">
              <footer class="py-5">
                  <div class="row">
                      <div class="col-6 col-md-2 mb-3">
                          <h5>Section</h5>
                          <ul class="nav flex-column">
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">Home</a></li>
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">Features</a></li>
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">Pricing</a></li>
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">FAQs</a></li>
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">About</a></li>
                          </ul>
                      </div>
                      <div class="col-md-5 offset-md-1 mb-3">
                          <form>
                              <h5>Subscribe to our newsletter</h5>
                              <p>Monthly digest of what's new and exciting from us.</p>
                              <div class="d-flex flex-column flex-sm-row w-100 gap-2">
                                  <label for="newsletter1" class="visually-hidden">Email address</label>
                                  <input id="newsletter1" type="text" class="form-control" placeholder="Email address">
                                  <button class="btn btn-primary" type="button">Subscribe</button>
                              </div>
                          </form>
                      </div>
                      <div class="col-6 col-md-2 mb-3">
                          <h5>Section</h5>
                          <ul class="nav flex-column">
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">Home</a></li>
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">Features</a></li>
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">Pricing</a></li>
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">FAQs</a></li>
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">About</a></li>
                          </ul>
                      </div>
                      <div class="col-6 col-md-2 mb-3">
                          <h5>Section</h5>
                          <ul class="nav flex-column">
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">Home</a></li>
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">Features</a></li>
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">Pricing</a></li>
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">FAQs</a></li>
                              <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-muted">About</a></li>
                          </ul>
                      </div>
                  </div>
      
                  <div class="d-flex  flex-sm-row justify-content-between py-1 my-1">
                      <p>© 2022 Company, Inc. All rights reserved.</p>
                      <ul class="list-unstyled d-flex">
                          <li class="ms-3"><a class="link-dark" href="#"><svg class="bi" width="24" height="24"><use xlink:href="#twitter"></use></svg></a></li>
                          <li class="ms-3"><a class="link-dark" href="#"><svg class="bi" width="24" height="24"><use xlink:href="#instagram"></use></svg></a></li>
                          <li class="ms-3"><a class="link-dark" href="#"><svg class="bi" width="24" height="24"><use xlink:href="#facebook"></use></svg></a></li>
                      </ul>
                  </div>
              </footer>
          </div>
          <script src="~/lib/jquery/dist/jquery.min.js"></script>
          <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
          <script src="~/js/site.js" asp-append-version="true"></script>
          @await RenderSectionAsync("Scripts", required: false)
      </body>
      </html>

**Okay so far we have created all the webapges we needed  and all the necessary css needed. Next step is to seggregate the buisness layer into a new project to provide**

# NR Architechture with MVC 

## Creating A separate ".Models" project
1. Create a new project of classlibrary named `[projectname].Models`
2. Delete the already exisitng Class1.cs file we dont need it, we already have our models in the MvcMovie, Models folder.
3. Transfer the Models `ErrorViewModel` and `User.cs` model into the MvcModel.models create a new folder `Models` and paste them there.
4. If some errors arise in the naming conventions or usijng namespace remove them via "show potential fixes".

## Creating A separate ".DataAccessLayer" project
1. Create a new project of classlibrary named `[projectname].DataAccessLayer`
2. Delete the already exisitng Class1.cs file we dont need it, we already have our models in the MvcMovie, Data folder.
3. Transfer the Models `ErrorViewModel` and `User.cs` model into the MvcModel.models create a new folder `Data` and paste them there.
4. If some errors arise in the naming conventions or using namespace remove them via "show potential fixes".
4.1.  Change the  name of namespace into `[projectname].DataAccessLayer`Error on the Dbsetr line ? Right click it and select Install `Microsoft.Entity Core` and ``

![Screenshot 2023-09-13 111608](https://github.com/shahoodzee/ASP.NET-MVC-Tutorial/assets/93043483/bb0eeff6-b306-4a24-bcb8-b6adb5a93447)

## Transfer the migrations folder into .DataAccessLayer folder

**errors**
. In the `ApplicationDbContextModelSnapshot.cs`file replace `using data` with `using MvcMovie.DataAccessLayer;`
. In the 2nd file do the same thing.

**Errors From the old project MvcMovie**
Build the old project and u will see some errors due to transfer of files from one project to other
1. Use `using MvcMovie.DataAcessLayer` instead of `using data`
2. Use the same approach for other errors.

# Repository Pattern

Create a folder `Infrastructure` in Data folder of `MvcMovie.DataAccessLayer`.
Make folders in this format. And make interfaces of `Repository.cs` and `IRepository.cs` files in those folders.

      Infrastructure
            |
            |------> Repository ------> Repository.cs
            |------> IRepository------> IRepository.cs

We would be implementing all the general operations used in the system. We won't make update operation in this repository patteren nor save button. For save button we will use `UnitOfWork`.

*The Repository Pattern is a software design pattern commonly used in the development of applications, especially in the context of data access and database interaction. It is a structural pattern that separates the logic that retrieves data from a database (or any data source) from the rest of the application code. The primary goal of the Repository Pattern is to provide a higher-level, object-oriented interface for interacting with data, which makes the application more maintainable and testable.


* Repository Interface: Defines a set of methods or operations that can be performed on data entities. These methods typically include operations like Create, Read, Update, Delete (CRUD), as well as methods for querying and retrieving data.

* Concrete Repository: Implements the repository interface and provides the actual implementation of the data access operations. It interacts with the data source (e.g., a database) to perform CRUD operations.

* Data Entities: Represent the domain objects or data structures that the application works with. These entities typically map to tables in a database or other data sources.
* Client Code: The application code that uses the repository interface to interact with data. It is decoupled from the concrete data access implementation, which allows for easier testing and maintenance*
**IRepository.cs**
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MvcMovie.DataAccessLayer.Infrastructure.IRepository
    {
    	//internal interface IRepository  
    	public interface IRepository<T> where T : class	/*interface made public so it can be accessed*/
    	{
    		IEnumerable<T> GetAll();
    
    		T GetT(Expression<Func<T, bool>> predicate);
    
    		void Add(T entity);
    		void Delete(T entity);
    		void DeleteRange(T entity);	
    		//Deleting multiple data /// deleteing multiple objects of data in list.
    
    	}
    }

**Repository.cs**

    using Microsoft.EntityFrameworkCore;
    using MvcMovie.DataAccessLayer.Infrastructure.IRepository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    namespace MvcMovie.DataAccessLayer.Infrastructure.Repository
    {
    	public class Repository<T> : IRepository<T> where T : class
    	{
    		private readonly ApplicationDbContext _context;
    		private DbSet<T> _dbSet;
    
    		public Repository(ApplicationDbContext context)
    		{
    			_context = context;
    			_dbSet = _context.Set<T>();
    		}
    		public void Add(T entity)
    		{
    			_dbSet.Add(entity);
    		}
    
    		public void Delete(T entity)
    		{
    			_dbSet.Remove(entity);
    		}
    
    		public void DeleteRange(T entity)
    		{
    			_dbSet.RemoveRange(entity);
    		}
    
    		public IEnumerable<T>  GetAll()
    		{
    			return _dbSet.ToList();
    		}
    
    		public T GetT(Expression<Func<T, bool>> predicate)
    		{
    			return _dbSet.Where(predicate).FirstOrDefault();
    		}
    	}
    }

    Lets create another .cs file in `IRepository` folder namned `IUser` where we will implement the `update` functionality.

    Also we create the `IUnitOfWork.cs` file to make save changes functionality.
    **Remember We created the `IRepository.cs` and `Repository.cs` files to implement the common general functions THAN WE WILL IMPLEMNENT THE COMMON FUNCTIONS**.


# Defining Areas:

Areas define what set of controller actions different type of people accessing the system can have.
**Make Sure your solution is build first (ctrl B b4 u start making areas)**
We have two areas
1. Admin
2. Customer
Right click Solution `MvcMovie` Directory make two new Scaffold Items `MVC - Area`
1. Admin
2. Customer
This will mak two new folders in the `Areas` folder. Delete `Models` and `Data` from each folder.

#### Shifting of controller and views files
HomeController.cs goes into Customer Area Controller (Cut and paste)
UJserController.cs goes into Admin Area Controller.
Shift `Home` View from Views Directory to `User` Area Views
shift `User` View from Views Directory into `Admin` Area Views

CopybPAste View imports and view start .cshtml files into both `Admin` and `User` Views. 

Overall tree should lookn like this.
![Screenshot 2023-09-21 105116](https://github.com/shahoodzee/MvcMovie/assets/93043483/ee1387ab-d7e8-4242-b31c-220399f7dbc7)

also define the Areas in the controllers `UserController.cs` and `HomeController.cs`

      ##libraries 
      namespace MvcMovie.Areas.Admin.Controllers
      {
          [Area("Admin")]
          .......
      }

      ##libraries 
      namespace MvcMovie.Areas.Customer.Controllers
      {
          [Area("Customer")]
          .......
      }


# Creating a new model Department.

goto `MvcMovie.Models` and make a new model class in Models folder.

      using System;
      using System.Collections.Generic;
      using System.ComponentModel.DataAnnotations;
      using System.Linq;
      using System.Text;
      using System.Threading.Tasks;
      
      namespace MvcMovie.Models.Models
      {
          public class Department
          {
              public Guid D_id { get; set; }
              public string D_name { get; set; }
              public string D_description { get; set;}
              public DateTime CreatedDateTime { get; set; } = DateTime.Now;
              public DateTime UpdatedDateTime { get; set;} = DateTime.Now;
      
              public Guid Id { get; set; }//user ID from user.cs used as forgien key.
              public User User { get; set; }
          }
      }

When u add the object of User in the model,USer ID it is added as forgien key automatically.
      
Goto Package Manager Console

EntityFramework6\Add-Migrations addDept 
EntityFramework6\Update-Database
Just in case if its showing eerror that user table already exists goto your `Migrations` folder in `MvcMovie.DataAccessLayer` and comment out the code where you are adding the table 'user' in the database again.

## Adding department in NR Architecture


goto **IRepository** folder in `Infrastructure` and make DepartmentRepository.cs file init

    using MvcMovie.Models;
    using MvcMovie.Models.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MvcMovie.DataAccessLayer.Infrastructure.IRepository
    {
    	public interface IDepartmentRepository:IRepository<Department>
    	{
            void Update(Department department);
    	}
    }

Adding it in the `IUnitofWork.cs` file:

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MvcMovie.DataAccessLayer.Infrastructure.IRepository
    {
    	public interface IUnitOfWork
    	{
    		IUserRepository User { get; }
    		IDepartmentRepository Department { get; }
    		void Save();
    	}
    }

Implement the depaRTMENT INTERFACE IN THE **Repository** folder of `Infrastructure`as `DepartmentRepository.cs`

    using MvcMovie.DataAccessLayer.Infrastructure.IRepository;
    using MvcMovie.Models;
    using MvcMovie.Models.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MvcMovie.DataAccessLayer.Infrastructure.Repository
    {
    	public class DepartmentRepository : Repository<Department>, IDepartmentRepository 
    	{
    		//IUserRepositopry brings out the update interface.
    		//Repository<User> brings out the general common functions.
    		//Repository<User> brings out the general common functions.
    
    		private ApplicationDbContext _context;
    		
    		public DepartmentRepository(ApplicationDbContext context):base(context)
    		{
    			_context = context;	//initializing the context
    		}
    
    		public void Update(Department department)
    		{
    			//_context.Departments.Update(department);
    			var departmentdb = _context.Departments.FirstOrDefault(x => x.Id == department.D_id);
    			if (departmentdb != null)
    			{
                    departmentdb.D_name = department.D_name;
                }
    
    		}
    	}  
    }

add this implement of department interface in the `unitofwork.cs` as well

    using MvcMovie.DataAccessLayer.Infrastructure.IRepository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MvcMovie.DataAccessLayer.Infrastructure.Repository
    {
    	public class UnitOfWork : IUnitOfWork
    	{
    		private ApplicationDbContext _context;
    		public IUserRepository User { get; private set; }
    
            public IDepartmentRepository Department { get; private set; }
    
            public UnitOfWork(ApplicationDbContext context) //constructor
    		{
    			_context = context; //initializing the context
    			User = new UserRepository(context);
    			Department = new DepartmentRepository(context);	//NEW REPOSITROY OF CONTEXT
    		}
    		//unitofwork can call this privately variable User and this variable user has user repository class.
    		//and this user repository class can also call general repository.
    
    		void IUnitOfWork.Save()
    		{
    			_context.SaveChanges();
    		}
    	}
    }



Notice how we explicity made the update functions of both Department and User model.

## Ok so far we have developed mocels,ViewModels,Views and their actions .....

Its time to add `routes` in our project in our controller.
The idea is client side renderring. Where ypu send Json Respnonse from the server and it renders from the client.

We will send a Json reposnse from the controller and render it through Javascript. We will take the use of API AJAX calls.


**Open the uesr controller file we will implement the JSon response to show all the Users**
`Usercontroller.cs`

        #region APICALL
        public IActionResult AllUsers()//action
        {
            var users = _unitofWork.User.GetAll(); //we use the unitofwork getall() function to 
            return Json(new {data = users});
        }
        #endregion
Run your code and type URL -> **https://localhost:7249/Admin/User/AllUsers**
You will see the JSon Response of the data you saw earlier in the Table of `index.cshtml` file.

      {
          "data": [
              {
                  "id": "ac4c4ae8-98e4-4cd2-33fb-08dbc3d2e628",
                  "firstName": "Shahood",
                  "lastName": "Amir",
                  "email": "Shahood.bin.amir@gmail.com",
                  "city": "Sialkot",
                  "imageData": "/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAMCAgMCAgMDAwMEAwMEBQgFBQQEBQoHBwYIDAoMDAsKCwsNDhIQDQ4RDgsLEBYQERMUFRUVDA8XGBYUGBIUFRT/2wBDAQMEBAUEBQkFBQkUDQsNFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBT/wAARCAB4AHgDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD7zooooAKKKKACiiqeparaaPbPcXkqwQ/33/joAuUVwd58WLKNtttZXE/+277KfbfFiykdEubKWBP76PvoA7miqelaxZaxD5tjcLOn/j6VcoAKKKKACiiigAooooAKKKKACiiqeq6lFo+m3N7P9yFN+ygCa5uorGF5bmVYIU++7vsrxnxb4gfxHrDy/wDLtD8lun9xKp63rl34gvPtF5Lv/uJ/BF/uVQ8xKAF5p9M5rU0rwrrHiBEfT9PuJ0f/AJbbNif990AULa6uLG5S4tpWgmT+NH2V6L4V+IyXWy01XbBN/Bc/wP8A7/8AcrhtY8Oan4cmRNTtJbXf9x/vo/8AwOs3/WUAfQ9Fee/DfxU8839j3L7/AJP9Hd//AECvQqACiiigAooooAKKKKACuP8AijJ/xTyIv8Vwm/8A8frsKwfHOmvqvhu8SL/XQ/vk/wCAUAcf8K/B9v4m1K5lvk32dps/c/33evabbR9PtU2QWVvAn+xEiVwPwN/5Ampf9fSf+gV6XQBnzeH9KndJZNMs3dPuO9ulaFFFAEF/Y2+pWz295Es8L/fR0ryXxb8GZYHe40F/PT/nzd/nT/cf+OvYaKAPmjwfH/xVWmp9x0l+evb686sNH+w/Fq/iX7kLzTf99p/9nXotABRRRQAUUUUAFFFFABQm+R02/fop8MnlzI/9x6AK3gnQ/wDhGb/W9P8AlRJpUvIv9x/4P/HK66qv2FP7V/tBX/5d/J2f8D31aoAKKKKACiiigDzzTdHeTxPr2tSo2ya6e2if/YT5H/8AQK260tVSK1hSKJNiO7zf8Df/APbrNoAKKKKACiiigAooooAKKKKAN6wnSS2hTf8APsq1XO2EnkXiP/wB66KgAooooAKKKguZ/Jt3egDK1K6S6m+X+D5Kp0UUAFFFFABRRRQAUUUUAFFFFABW3pt99rTYz/vkrnrmdLWF5Zd2xPv7Eqzpv+lIlxFuT56AOloqlDdP/Em+pvtSf3HoAmd/LR3b+CsG81L7d93/AFKP8lXLzzbr5G+5/crK1KRNNTzZfkSgAoo/4Ayf79FABRRRQAUUUUAFFFFABRQkbyPsVN7vWrbeHLuf/WosCf7dAF/wlYrPHeNKqujL5Ox6vp4Zt7GHyrNNif3Ks6bapptt5UX3P9ur/nLQBgvY+X/BTPsn+zXQvIkaVW8zy/n2fJQBlJprz/dSri+H7TfDLOvnvD9zf9ytX+D/AGKY8lAHE+J4Ps+sP/02TfWVXbarpsWq7PN3I6fc2Vg3Phm7j/1W2dKAMeinzI8DeVKmx/7j0ygAooooAKs2FjLqM3lRJ/wP+5RRQB2em6bFpsO2L7/8b/36uUUUAHl0x40koooAEj2U+iigBnl0/wAuiigA8uiiigCteabb30OyWLfXGarpr6Vc+S3zo/3H/v0UUAU6KKKAP//Z",
                  "departmentId": 2,
                  "department": null,
                  "createdDateTime": "2023-10-03T10:37:57.4523553"
              }
          ]
      }
      
Now goto `root` folder and add a new Javascript file in the JS folder named `User.Js`. Add this file into to `index.cshtml` file.


    @section scripts {
    
        <script src="~/js/user.js"></script>
    
    }

**Do the same for Department.**
# Add the datatables in our project 

Gotot `shared\layout.cshtml` file:
Add the script     <script src="https://cdn.datatables.net/1.13.6/js/jquery.dataTables.min.js"></script> **in body section.**
Add the CSS     <link rel="stylesheet" href="https://cdn.datatables.net/1.13.6/css/jquery.dataTables.min.css" /> **in Head section**
****
## Add some more files for sweeralert2
These should be total css files in the link tags

      <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
      <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KyZXEAg3QhqLMpG8r+ckkEd5pMI0MEe3m5mL/4E3j3Se5t5C5ZMa1FiqO5f5uy5Kg" crossorigin="anonymous">
      <link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />
      <link rel="stylesheet" href="~/MvcMovie.styles.css" asp-append-version="true" />
      <link rel="stylesheet" href="~/css/bootsWtachTheme.css" />
      <link rel="stylesheet" href="~/css/bootsWatchTheme.css" asp-append-version="true" />
      <link rel="stylesheet" href="~/PracticeApp.styles.css" asp-append-version="true" />
      <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" />
      <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css">
      <link rel="stylesheet" href="//cdn.datatables.net/1.13.6/css/jquery.dataTables.min.css" />

And these should be scripts

      <script src="~/lib/jquery/dist/jquery.min.js"></script>
      <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.min.js" integrity="sha384-Rx+T1VzGupg4BHQYs2gCW9It+akI2MM/mndMCy36UVfodzcJcF0GGLxZIzObiEfa" crossorigin="anonymous"></script>
      <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
      <script src="~/js/site.js" asp-append-version="true"></script>
      <script src="//cdn.datatables.net/1.13.6/js/jquery.dataTables.min.js"></script>
      <script src="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>

## Using the databales to render our project 

goto view `Index.cshtml file` and update the following code by adding the script to show list of all users.
Some fields are made hideen on purpose.


    @model MvcMovie.Models.ViewModels.UserVM
    @{
        ViewData["Title"] = "User";  
    }
    <head>
        <link rel="stylesheet" type="text/css" href="~/css/User.css">
    </head>
    
    
    <body>
        @section scripts {
    
            <script>
                var dtable;
    
                $(document).ready(function () {
    
                    $('#myTable').DataTable({
                        "ajax": {
    
                            "url": "User/AllUsers"
                        },
    
                        "columns": [
                            //{ "data": 'id' },
                            { "data": 'firstName' },               //key value pair
                            { "data": 'lastName' },
                            { "data": 'email' },
                            { "data": 'city' },
                            { "data": 'departmentId' },
                            //{
                            //    "data": 'ImageData',
                            //    "render": function (data) 
                            //    {
                            //        // Display the image using a base64-encoded string
                            //        return '<img src="data:image/jpeg;base64,' + data + '" alt="User Image" width="100" />';
                            //    }
                            //},
                            //{ "data": 'createdDateTime' },
    
                        ]
                    });
    
                })
    
    
            </script>
    
        }
    
        <section>
            <div class="contianer">
                <h5>List of users in our system.</h5>
                <h5>
                    <a asp-action="Create" asp-controller="user">Create a User</a>
                    <a asp-action="Search" asp-controller="user"> Seach a User</a>
                    <a asp-action="Edit" asp-controller="user"> Edit a User</a>
                    <a asp-action="Delete" asp-controller="user"> Delete a User</a>
                </h5>
    
                <div class="container ">
                    <div class="table-responsive">
                        <table id="myTable" class="table table-primary table-hover border border-primary border-3">
                           
    
                            <thead class="table-light">
                                <tr>
    @*                                <th>UserId</th>*@
                                    <th>First Name</th>
                                    <th>Last name</th>
                                    <th>Email</th>
                                    <th>City</th>
                                    <th>Department</th>
    @*                                <th>Image</th>
                                    <th>Created At</th>*@
                                    
                                </tr>
                            </thead>
    
                            @*<tbody>
                                @foreach (var item in Model.users)
                                {
                                    //var base64String = Convert.ToBase64String(@item.ImageData); 
                                    <tr>
                                        @if (@item.FirstName is not null)
                                        {
                                            <td>@item.Id</td>
                                            <td>@item.FirstName</td>
                                            <td>@item.LastName</td>
                                            <td>@item.Email</td>
                                            <td>@item.City</td>
                                            <td>@item.DepartmentId</td>
    
                                            <td>
                                                <img src="data:image/jpeg;base64,@base64String" alt="Image" />
                                            </td>
                                            <td>@item.CreatedDateTime</td>
    
                                        }
                                    </tr>
                                }
                            </tbody>*@
    
                        </table>
                    </div>
    
                </div>
    
    
            </div>
        </section>
    </body>

You should something like this! ignore the actions tab we are going to implement them now!
    
![wd](https://github.com/shahoodzee/MvcMovie/assets/93043483/bb38cda3-fc5e-4de3-ad91-87964d98b3a8)

## Adding functionalities (Delete,Edit,Create,Search) in our very `Index.cshtml` file  using API handling ......

Ok this our Index.cshtml file ....
I have taken rid of `<tbody>` tag since we dont need it now the datais being rendered through AJAX call. Notice I have commented the dtags ImageData and for the moment.

      @model MvcMovie.Models.ViewModels.UserVM
      @{
          ViewData["Title"] = "User";
      }
      <head>
          <link rel="stylesheet" type="text/css" href="~/css/User.css">
      </head>
      
      
      <body>
          @section scripts 
          {
      
      
              <script>
                  var dtable;
      
                  $(document).ready(function () {
      
                      $('#myTable').DataTable({
                          "ajax": {
      
                              "url": "User/AllUsers"
                          },
      
                          "columns": [
                              { "data": 'id' },
                              { "data": 'firstName' },               //key value pair
                              { "data": 'lastName' },
                              { "data": 'email' },
                              { "data": 'city' },
                              { "data": 'departmentId' },
                              //{
                              //    "data": 'ImageData',
                              //    "render": function (data) 
                              //    {
                              //        // Display the image using a base64-encoded string
                              //        return '<img src="data:image/jpeg;base64,' + data + '" alt="User Image" width="100" />';
                              //    }
                              //},
                              //{ "data": 'createdDateTime' },
      
                              {
                                  "data":"id",			//actions colomun
                                  "render": function(data){
                                      return `<a onClick = RemoveUser('/Admin/User/DeleteUser/${data}') >
                                                  <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3-fill" viewBox="0 0 16 16">
                                                  <path d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z"></path>
                                                  </svg> 
                                              </a>
                                              <a onClick = EditUser('/Admin/User/EditUser?Id=${data}') data-toggle="modal" data-target="#editUserModal">
                                              <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-exposure" viewBox="0 0 16 16">
                                                  <path d="M8.5 4a.5.5 0 0 0-1 0v2h-2a.5.5 0 0 0 0 1h2v2a.5.5 0 0 0 1 0V7h2a.5.5 0 0 0 0-1h-2V4Zm-3 7a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1h-5Z"></path>
                                                  <path d="M8 0a8 8 0 1 0 0 16A8 8 0 0 0 8 0ZM1 8a7 7 0 1 1 14 0A7 7 0 0 1 1 8Z"></path>
                                              </svg>
                                              </a>`
                                              
                                  }
                              }
                          ]
      
                      });
      
                  })
      
                  
              </script>
      
          }
         
          <section>
      
      
      
              <div class="contianer">
                  <h5>List of users in our system.</h5>
                  <h5>
      
                      <a asp-action="Search" asp-controller="user" class="text-decoration-none">
                          Search a User
                          <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
                              <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z"></path>
                          </svg>
                      </a>
                      <a asp-action="Create" asp-controller="user" class="text-decoration-none">
                          Create a User
                          <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-plus" viewBox="0 0 16 16">
                              <path d="M6 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0zm4 8c0 1-1 1-1 1H1s-1 0-1-1 1-4 6-4 6 3 6 4zm-1-.004c-.001-.246-.154-.986-.832-1.664C9.516 10.68 8.289 10 6 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10z"></path>
                              <path fill-rule="evenodd" d="M13.5 5a.5.5 0 0 1 .5.5V7h1.5a.5.5 0 0 1 0 1H14v1.5a.5.5 0 0 1-1 0V8h-1.5a.5.5 0 0 1 0-1H13V5.5a.5.5 0 0 1 .5-.5z"></path>
                          </svg>
                      </a>
                      <a asp-action="Edit" asp-controller="user" class="text-decoration-none">
                          Edit a User
                          <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-exposure" viewBox="0 0 16 16">
                              <path d="M8.5 4a.5.5 0 0 0-1 0v2h-2a.5.5 0 0 0 0 1h2v2a.5.5 0 0 0 1 0V7h2a.5.5 0 0 0 0-1h-2V4Zm-3 7a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1h-5Z"></path>
                              <path d="M8 0a8 8 0 1 0 0 16A8 8 0 0 0 8 0ZM1 8a7 7 0 1 1 14 0A7 7 0 0 1 1 8Z"></path>
                          </svg>
                      </a>
                      <a asp-action="Delete" asp-controller="user" class="text-decoration-none">
                          Delete a User
                          <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3-fill" viewBox="0 0 16 16">
                              <path d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z"></path>
                          </svg>
                      </a>
                  </h5>
      
                  <div class="container ">
                      <div class="table-responsive">
                          <table id="myTable" class="table table-primary table-hover border border-primary border-3">
                             
      
                              <thead class="table-light">
                                  <tr>
                                      <th>UserId</th>
                                      <th>First Name</th>
                                      <th>Last name</th>
                                      <th>Email</th>
                                      <th>City</th>
                                      <th>Department</th>
                                      <th>Action</th>
                                      @*<th>Image</th>
                                      <th>Created At</th>*@
                                      
                                  </tr>
                              </thead>
      
      
      
                          </table>
                      </div>
      
                  </div>
      
      
              </div>
          </section>
      
      </body>



See the comment `Actions` coloumn. Our Ajax call is returning two anchor tags 1 for delete and 2 for editing the user. So each anchor tag works for each user row separately.
Both  anchor tags have Onclick events as u can see the html code.
Lets implement both functionalities......
For Removing a User We will send a Deete Request to our API Reigon DELETEApi present in our controller. Now you can use your previous controlller or just copy paste it into another and modify it a bit. I rather suggest just coopy paste and make anew controller.

anchor tag for remove user (already given)
      <a onClick = RemoveUser('/Admin/User/DeleteUser/${data}') >
        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3-fill" viewBox="0 0 16 16">
        <path d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z"></path>
        </svg> 
      </a>

**The api will look for DeleteUser in the DeleteAPi Reigon**

LETS IMPLEMEMNT OUR onlcikc event RemoveUser(). Its implemented through `sweetalert2`. The necessaeray files have been addded in the `layout.cshtml` file to use this.

              function RemoveUser(url) {
                  Swal.fire({
                      title: 'Are you sure?',
                      text: "You won't be able to revert this!",
                      icon: 'warning',
                      showCancelButton: true,
                      confirmButtonColor: '#3085d6',
                      cancelButtonColor: '#d33',
                      confirmButtonText: 'Yes, delete it!'
                  }).then((result) => {
                      if (result.isConfirmed) {
                          $.ajax({
                              url: url,
                              type: 'DELETE',
                              success: function (data) {
                                  if (data.success) {
                                      toastr.success(data.message);
                                      location.reload();
                                  }
                                  else {
                                      toastr.error(data.message);
                                  }
                              }
                          })
                      }
                  })
              }

Lets make an API Reigon where this delete request will go. Goto `UserController.cs`

This is your previous Delete `View` And `Action`

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

**The Delete api reigon will be as:**
  Notice the code is actually copied from `ConfirmDelete` Action
    
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
Test it!
The Anchor tags present in the `index.cshtml` file. 

              <h5>
                  <a asp-action="Search" asp-controller="user" class="text-decoration-none">
                      Search a User
                      <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
                          <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z"></path>
                      </svg>
                  </a>
                  <a asp-action="Create" asp-controller="user" class="text-decoration-none">
                      Create a User
                      <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-plus" viewBox="0 0 16 16">
                          <path d="M6 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0zm4 8c0 1-1 1-1 1H1s-1 0-1-1 1-4 6-4 6 3 6 4zm-1-.004c-.001-.246-.154-.986-.832-1.664C9.516 10.68 8.289 10 6 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10z"></path>
                          <path fill-rule="evenodd" d="M13.5 5a.5.5 0 0 1 .5.5V7h1.5a.5.5 0 0 1 0 1H14v1.5a.5.5 0 0 1-1 0V8h-1.5a.5.5 0 0 1 0-1H13V5.5a.5.5 0 0 1 .5-.5z"></path>
                      </svg>
                  </a>
                  <a asp-action="Edit" asp-controller="user" class="text-decoration-none">
                      Edit a User
                      <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-exposure" viewBox="0 0 16 16">
                          <path d="M8.5 4a.5.5 0 0 0-1 0v2h-2a.5.5 0 0 0 0 1h2v2a.5.5 0 0 0 1 0V7h2a.5.5 0 0 0 0-1h-2V4Zm-3 7a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1h-5Z"></path>
                          <path d="M8 0a8 8 0 1 0 0 16A8 8 0 0 0 8 0ZM1 8a7 7 0 1 1 14 0A7 7 0 0 1 1 8Z"></path>
                      </svg>
                  </a>
                  <a asp-action="Delete" asp-controller="user" class="text-decoration-none">
                      Delete a User
                      <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3-fill" viewBox="0 0 16 16">
                          <path d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z"></path>
                      </svg>
                  </a>
              </h5>
![Screenshot 2023-10-06 105611](https://github.com/shahoodzee/MvcMovie/assets/93043483/c7ac798f-0ad3-42fb-8a50-e0e835615e96)
              
Either u can comment it or discad it upto you. 

## Making Edit Functionality.

The ancor tag in the datable (already given)

                                        <a onClick = EditUser('/Admin/User/EditUser?Id=${data}') data-toggle="modal" data-target="#editUserModal">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-exposure" viewBox="0 0 16 16">
                                            <path d="M8.5 4a.5.5 0 0 0-1 0v2h-2a.5.5 0 0 0 0 1h2v2a.5.5 0 0 0 1 0V7h2a.5.5 0 0 0 0-1h-2V4Zm-3 7a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1h-5Z"></path>
                                            <path d="M8 0a8 8 0 1 0 0 16A8 8 0 0 0 8 0ZM1 8a7 7 0 1 1 14 0A7 7 0 0 1 1 8Z"></path>
                                        </svg>
                                        </a>

Lets impement `EditUser` OnCLick Event `EditUser()`.
Before that we need to create a `modal` that will reder a pop once user clicks on theanchor tag of `edit`.
So add this modal code in html body `Indexcshtml`.

        <!-- Modal for Editing User Details -->
        <div id="editUserModal" class="modal fade" tabindex="-1" role="dialog">

            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Edit User</h5>
                        <button onclick = "return closeForm()" type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>


                    <div class="modal-body">
                        <!-- Edit User Form -->
                        <form id="editUserForm">

                            <div class="form-group">
                                <label asp-for="User.FirstName">First Name</label>
                                <input type="text" class="form-control" id="editFirstName" name="FirstName" required>
                            </div>

                            <div class="form-group">
                                <label asp-for="User.LastName">Last Name</label>
                                <input type="text" class="form-control" id="editLastName" name="LastName" required>
                            </div>

                            <div class="form-group">
                                <label asp-for="User.City">City</label>
                                <input type="text" class="form-control" id="editCity" name="City" required>
                            </div>

                            <div class="form-group">
                                <select asp-for="User.DepartmentId" asp-items="@Model.departments" class="form-control" id="editDepartmentId" name="DepartmentId">
                                    <option>Select Department</option>
                                </select>

                            </div>

                        </form>
                    </div>
                    <div class="modal-footer">
                        <button onclick="return closeForm()" type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" id="saveChangesBtn">Save Changes</button>
                    </div>
                </div>
            </div>
        </div>

The MODAL HASfunctions like closeform() and savechangesform()
Add this `closeForm()` in the script.

            function closeForm() {
                $('#editUserModal').modal('hide');
            }

The modal will be populated by the data that will come from `EditUser()`. 

           function EditUser(url) {
                $.ajax({
                    url: url,
                    type: 'GET',
                    dataType: 'json', 
                    success: function (data) {
                        console.log(data)
                        if (data.success == false) 
                        {
                            return alert("Some error Found!")
                        }
                        else {
                            //Populate the modal form fields with user data
                            $('#editFirstName').val(data.user.firstName);
                            $('#editLastName').val(data.user.lastName);
                            $('#editCity').val(data.user.city);

                            var departmentList = data.departmentList;
                            // Function to populate the select element
                            const selectElement = document.getElementById('editDepartmentId');

                            // Clear existing options
                            selectElement.innerHTML = '';

                            // Add a default "Select Department" option
                            const defaultOption = document.createElement('option');
                            defaultOption.value = '';
                            defaultOption.textContent = 'Select Department';
                            selectElement.appendChild(defaultOption);

                            // Iterate through the DepartmentList and add options
                            departmentList.forEach(department => {
                                const option = document.createElement('option');
                                option.value = department.value; // Use the appropriate property for the value
                                option.textContent = department.text; // Use the appropriate property for the text
                                selectElement.appendChild(option);
                            });

                            // Show the modal
                            $('#editUserModal').modal('show');
                        }
                    }
                })

The editUser gets the User Details first usng a GEt requeest to url:`/Admin/User/EditUser?Id=${data}` and we receive user details in a JSON format.
**Also**
One mroe thing I did is get  the department List within the JSon response since themodal was not redering the departments as the object `Department`attribute `departments`
has not been initialzed in the API reigon of EditApi.

This is our EDITAPI Reigon in the `UserController`. ts not compleetre since we have not impemented `savechanges()` onclick event. 

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
		#endregion


Lets implemet the `SaveChanges()` funciton the javascript.***Add the onclinck event SaveForm() in the Save changes <button>**


            function SaveForm()
            {
                // Gather data from form fields
                const editedId = $('#edituserId').val()
                const editedFirstName = $('#editFirstName').val();
                const editedLastName = $('#editLastName').val();
                const editedCity = $('#editCity').val();
                const selectedDepartmentId = $('#editDepartmentId').val();

                // Create a data object to send to the server (adjust as needed)
                const formData = {
                    Id: editedId,
                    FirstName: editedFirstName,
                    LastName: editedLastName,
                    City: editedCity,
                    DepartmentId: selectedDepartmentId
                };

                // Perform an AJAX POST request to save the data
                $.ajax({
                    //url: `/Admin/User/SaveChanges`, // Replace with your server's endpoint
                    url: `/Admin/User/SaveChanges?Id=${editedId}&FirstName=${editedFirstName}&LastName=${editedLastName}&City=${editedCity}&DepartmentId=${selectedDepartmentId}`, // Replace with your server's endpoint
                    type: 'POST',
                    //contentType: 'application/json',
                    //data: JSON.stringify(formData),
                    dataType: 'json',
                    success: function (data) {
                        if (data.success){
                            // Handle the success response (e.g., show a success message)
                            Swal.fire({
                                icon: 'success',
                                title: 'user has been Updated Successfully',
                                showConfirmButton: false,
                                timer: 1000,
                            })
                        }
                        else {
                            alert('Error is here')
                        }

                    }

                });
            }
            function closeForm() {
                $('#editUserModal').modal('hide');
                location.reload();

            }
In this way we can also make API's for Creating and Reading a User.

## Making SignUp and Login Functionality using Identity.

Goto `Data.AccessLayer->Data->ApplicationDBContext`. Replace the DBContext as `IdentityDbContext`. You will get error cuz u have install some packages. Goto to NU package manager and install `Microsoft.AspNetCore.Identity.EntityFrameworkCore;` **Only installl a version 6 not from version 7. And make sure you add this package in all 3 project files `DataAccessLayer` `MvcMovie` and `MvcModels`**

The `ApplicationDbContext.cs` file will look like this.

	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;
	using MvcMovie.Models;
	using MvcMovie.Models.Models;
	
	namespace MvcMovie.DataAccessLayer
	{
	    //public class ApplicationDbContext : DbContext
	    public class ApplicationDbContext : IdentityDbContext
	    {
	        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
	               :base(options)
	        {
	        
	        }
	        public DbSet<User> User { get; set; }
	        public DbSet<Department> Departments { get; set; }    
	    }
	}
Now right click the MvcMovie and add a new scaffold item `Identity`.
![Screenshot 2023-10-09 111438](https://github.com/shahoodzee/MvcMovie/assets/93043483/e117a99d-65b5-4f50-bd82-7876d8f8a242)
Add all the files and use AppDbContext As shown in the figure. 


![Screenshot 2023-10-09 111517](https://github.com/shahoodzee/MvcMovie/assets/93043483/f6f3af02-3766-45fe-9204-62a3a7f1da5e)


This will add many custom files in our folder. 


![Screenshot 2023-10-09 113213](https://github.com/shahoodzee/MvcMovie/assets/93043483/aeee24de-922b-4a4f-81d6-ac3358010002)


![Screenshot 2023-10-09 114400](https://github.com/shahoodzee/MvcMovie/assets/93043483/ac6b1e6e-8d95-450e-8963-561a0237649b)

#### Add app.MapRazorPages(); in your Program.cs file to show RazrorPages on UI.
Many lines of code have been added in  `Program.cs` file Lets check them out.

	builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	    .AddEntityFrameworkStores<ApplicationDbContext>();

Remove the `options => options.SignIn.RequireConfirmedAccount = true` from it.
Add-migration `AddIdentityToDb` and `update-database`. you will see that additional tables have been added in the database.

# Warning!
Adding the identity will add a new `Data` directory in the folder of of `Identity` along with . You need to delete this directory other the compiler will get confuse as it will get 2 `AppDbContext` files one from `Identity` and one form `DataAccessLayer` 

Goto `layout.cshtml` file and `ul` for login partial page.

Uptill now you might be able to register a user/admin in the system.

## Identity Customization
You need to create a new model in the `MvcModels` named `ApplicationUser`.

	using Microsoft.AspNetCore.Identity;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	
	namespace MvcMovie.Models.Models
	{
	    public class ApplicationUser : IdentityUser
	    {
	        public string? FirstName { get; set; }
	        public string? LastName { get; set; }
	        public string? Email { get; set; }
	
	        public ApplicationUser(string? email)
	        {
	            Email = email;
	        }
	
	        public string? City { get; set; }
	        public byte[]? ImageData { get; set; }
	
	        public int DepartmentId { get; set; }
	        public Department Department { get; set; }
	        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
	
	    }
	}


Add this model in the `ApplicationDbContext.cs` file present `DataAccessLayer`
![Screenshot 2023-10-10 162051](https://github.com/shahoodzee/MvcMovie/assets/93043483/29d7cf0a-48eb-4ea8-9235-9106f42b1f3a)


Open the Database you will able to see this `ApplicationUser` model attributes in the `AppNetUsers` table. So modified the default table coloumns.
![Screenshot 2023-10-10 162314](https://github.com/shahoodzee/MvcMovie/assets/93043483/637c4f01-c3a3-4858-bd26-54ebe3fac405)

## Add Roles

We will be adding 3 roles in the system.
1- Admin
2- User
3- Employee (If admin decides to hire some employees to manage the system)

Right click Solution **MvcMovie** and add new **Class Library Project** named as `MvcMovie.CommonHelper`. Make a new `WebsiteRole.cs` file as;
	
 	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	
	namespace MvcMovie.CommonHelper
	{
	    public static class WebsiteRole
	    {
	        public const string Role_User = "User";
	        public const string Role_Admin = "Admin";
	        public const string Role_Employee = "Employee";
	
	    }
	
	}

So now we need to define role when we register a user.
SO goto \MvcMovie\Areas\Identity\Pages\Account\***Register.cshtml.cs**


Update the emailsender tag in the **RegisterModel{}**

	        public RegisterModel( 
	            UserManager<IdentityUser> userManager,
	            IUserStore<IdentityUser> userStore,
	            SignInManager<IdentityUser> signInManager,
	            ILogger<RegisterModel> logger,
	            IEmailSender emailSender, RoleManager<IdentityRole> roleManager)
	        {
	            _userManager = userManager;
	            _userStore = userStore;
	            _emailStore = GetEmailStore();
	            _signInManager = signInManager;
	            _logger = logger;
	            _emailSender = emailSender;
	            _roleManager = roleManager;
	        }

Update the **public async Task OnGetAsync(string returnUrl = null){}** and Add the 3 roles made.

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!_roleManager.RoleExistsAsync(WebsiteRole.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebsiteRole.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebsiteRole.Role_User)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebsiteRole.Role_Employee)).GetAwaiter().GetResult();
            }
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

Next come to program.cs file and comment the code of:
 
 	builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();

Also add **builder.Services.AddRazorPages();** before  **var app = builder.Build();** 
Your final Program.cs file will look like this:

	using Microsoft.EntityFrameworkCore;
	using MvcMovie.DataAccessLayer.Infrastructure.IRepository;
	using MvcMovie.DataAccessLayer.Infrastructure.Repository;
	using Microsoft.AspNetCore.Identity;
	using MvcMovie.DataAccessLayer.Data;
	
	var builder = WebApplication.CreateBuilder(args);
	
	// Add services to the container.
	builder.Services.AddControllersWithViews();
	builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
	//adding database services---------------------------------------------------------------------------
	builder.Services.AddControllersWithViews();
	
	builder.Services.AddDbContext<ApplicationDbContext>(options => {
	    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
	});
	
	//builder.Services.AddDefaultIdentity<IdentityUser>()
	//    .AddEntityFrameworkStores<ApplicationDbContext>();
	
	//add a role and default token provider.
	builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders()
	    .AddEntityFrameworkStores<ApplicationDbContext>();
	
	builder.Services.AddRazorPages();
	var app = builder.Build();
	
	//----------------------------------------------------------------------------------------------------
	
	// Configure the HTTP request pipeline.
	if (!app.Environment.IsDevelopment())
	{
	    app.UseExceptionHandler("/Home/Error");
	    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	    app.UseHsts();
	}
	
	app.UseHttpsRedirection();
	app.UseStaticFiles();
	
	app.UseRouting();
	app.UseAuthentication();
	
	app.UseAuthorization();
	app.MapRazorPages();
	
	app.MapControllerRoute(
	    name: "default",
	    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
	
	app.Run();

**Still you would be facing an issue when you go click the register button**
![Screenshot 2023-10-11 130459](https://github.com/shahoodzee/MvcMovie/assets/93043483/cac6ba5c-16ab-47a4-997b-21d6fbe4405b)

You need to implement the EmailSender class. Goto `MvcMovie.CommonHelper` and make `EmailSender` class and Inherit it with `IEmailSender`.
Install **using Microsoft.AspNetCore.Identity.UI.Services;** for this class `IEmailSender` to inherit.

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Identity.UI.Services;
	
	namespace MvcMovie.CommonHelper
	{
	    internal class EmailSender : IEmailSender
	    {
	        public Task SendEmailAsync(string email, string subject, string htmlMessage)
	        {
	            return Task.CompletedTask;
	        }
	    }
	}

Add this as adependency in `Program.cs`as:

	builder.Services.AddSingleton<IEmailSender,EmailSender>();

Add the library at top.

	using MvcMovie.CommonHelper;

 ## Cutomize Fields in the Register tag in navbar.
Goto `Register.cshtml.cs` file.
Goto the `InputModel` and add the rest of the fields you have in your `ApplicationUser` Model


        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }


            [DataType(DataType.PhoneNumber)]
            [RegularExpression("^[0-9]*$", ErrorMessage = "Phone Number should only contain digits.")]
            [Display(Name = "Phone Number")]
            [Required]
            public string PhoneNumber { get; set; }

            // The rest of the fields coming from the ApplicationUser.
            
	    public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? City { get; set; }
            public byte[]? ImageData { get; set; }

        }

 Now add these fields in the <Form> tag of the `Register.cshtml` file.

     <div class="col-md-6">
            <form id="registerForm" asp-route-returnUrl="@Model.ReturnUrl" method="post">

                <h2>Create a new account.</h2>
                <hr />
                <div asp-validation-summary="ModelOnly" class="text-danger"></div>

                <div class="myform col-12 py-2">
                    <input asp-for="Input.Email" class="input" aria-required="true" placeholder="Email" />
                    <span asp-validation-for="Input.Email" class="input-border"></span>
                <br />
            </div>
                <div class="myform col-12 py-2">
                    <input asp-for="Input.Password" class="input" aria-required="true" placeholder="Password" />
                    <span @*asp-validation-for="Input.Password"*@ class="input-border"></span>
                    <br />
                </div>
                <div class="myform col-6 py-2">
                    <input asp-for="Input.ConfirmPassword" class="input" aria-required="true" placeholder="Confirm Password" />
                    <span @*asp-validation-for="Input.ConfirmPassword"*@ class="input-border"></span>
                    <br />

                </div>

                <div class="myform col-6 py-2">
                    <input asp-for="Input.FirstName" class="input" aria-required="true" placeholder="FirstName" />
                    <span asp-validation-for="Input.FirstName" class="input-border"></span>
                    <br />
                </div>

                <div class="myform col-6 py-2">
                    <input asp-for="Input.LastName" class="input" aria-required="true" placeholder="LastName" />
                    <span asp-validation-for="Input.LastName" class="input-border"></span>
                    <br />
                </div>

                <div class="myform col-6 py-2">
                    <input asp-for="Input.City" class="input" aria-required="true" placeholder="City" />
                    <span asp-validation-for="Input.City" class="input-border"></span>
                </div>

                <div class="myform col-12 py-2">
                    <input asp-for="Input.PhoneNumber" class="input" aria-required="true" placeholder="Phone #" />
                    <span asp-validation-for="Input.PhoneNumber" class="input-border"></span>
                </div>
                <div class="myform col-12 py-2">
                <input asp-for="Input.ImageData" class="form-control" aria-required="true" placeholder="Phone #" type="file" id="ImageData" />
                    <span asp-validation-for="Input.ImageData" class="input-border"></span>
                </div>

                <button id="registerSubmit" type="submit" class="w-50 btn btn-lg btn-primary">Register</button>
                <hr />

            </form>
    </div>
    
![Screenshot 2023-10-11 160625](https://github.com/shahoodzee/ASP.NET_Project/assets/93043483/cf9aceea-a89a-49ae-aaa4-ed68359c754e)

We havent configured these Inputs with the database. So goto `Register.cshtml` file again. Goto onpostAsync Function.


 We do need this `CommonHelper` to create Roles in our website. But there is shortcut method as well.

 Explicitly Define roles in the `program.cs` file.

 using (var scope = app.Services.CreateScope() )
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] {"Admin" , "Employee" , "User"};

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

For `Admin` we will define its role by explicitly defining.

You can watch this youtube video on how to assign roles.
https://www.youtube.com/watch?v=Y6DCP-yH-9Q&pp=ygUiYXNzaWduaW5nIHJvbGVzIGluIEFTUC5ORVQgcHJvamVjdA%3D%3D

Our final **program.cs** file will look like this.

	using Microsoft.EntityFrameworkCore;
	using MvcMovie.DataAccessLayer.Infrastructure.IRepository;
	using MvcMovie.DataAccessLayer.Infrastructure.Repository;
	using Microsoft.AspNetCore.Identity;
	using MvcMovie.DataAccessLayer.Data;
	using Microsoft.AspNetCore.Identity.UI.Services;
	using MvcMovie.CommonHelper;
	
	var builder = WebApplication.CreateBuilder(args);
	
	// Add services to the container.
	builder.Services.AddControllersWithViews();
	builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
	//adding database services---------------------------------------------------------------------------
	builder.Services.AddControllersWithViews();
	
	builder.Services.AddDbContext<ApplicationDbContext>(options => {
	    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
	});
	
	//builder.Services.AddDefaultIdentity<IdentityUser>()
	//    .AddEntityFrameworkStores<ApplicationDbContext>();
	
	//add a role and default token provider.
	builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders()
	    .AddEntityFrameworkStores<ApplicationDbContext>();
	
	builder.Services.AddSingleton<IEmailSender, EmailSender>();
	builder.Services.AddRazorPages();
	var app = builder.Build();
	
	//----------------------------------------------------------------------------------------------------
	
	// Configure the HTTP request pipeline.
	if (!app.Environment.IsDevelopment())
	{
	    app.UseExceptionHandler("/Home/Error");
	    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	    app.UseHsts();
	}
	
	app.UseHttpsRedirection();
	app.UseStaticFiles();
	
	app.UseRouting();
	app.UseAuthentication();;
	
	app.UseAuthorization();
	app.MapRazorPages();
	
	app.MapControllerRoute(
	    name: "default",
	    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
	
	using (var scope = app.Services.CreateScope() )
	{
	    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
	
	    var roles = new[] {"Admin" , "Employee" , "User"};
	
	    foreach (var role in roles)
	    {
	        if (!await roleManager.RoleExistsAsync(role))
	        {
	            await roleManager.CreateAsync(new IdentityRole(role));
	        }
	    }
	}
	
	using (var scope = app.Services.CreateScope())
	{
		var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
	
	    // we only want the admin account single time.
	
	    string email = "admin@admin.com";
	    string password = "Test1234!";
	
	    if (await userManager.FindByEmailAsync(email) == null)
	    {
	        var user = new IdentityUser();
	        user.UserName = email;
			user.Email = email;
	
			await userManager.CreateAsync(user, password);
	
	        await userManager.AddToRoleAsync(user, "Admin");
	    }
	}
	
	app.Run();
So whenever your you login the website `AspNetUserRoles` gets populated. So a roleId is assigned against the userId of the user.
Now you that you have created these roles. We can go in `Areas` and use the Authorize() funciton to segregate the website functions based on website roles.

Next goto MvcMovie->Areas->Admin->Controller->UserController.cs.
Just add the Authorzie(Roles = 'Admin')
![Screenshot 2023-10-19 111249](https://github.com/shahoodzee/MvcMovie/assets/93043483/82ebf548-6de6-43b2-a19d-d288d7d5b86b)
