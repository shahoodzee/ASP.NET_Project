using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MvcMovie.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class User
    {
        [Key] //primary key
		public Guid Id { get; set; }
		public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public byte[]? ImageData { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
