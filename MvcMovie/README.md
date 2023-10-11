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









