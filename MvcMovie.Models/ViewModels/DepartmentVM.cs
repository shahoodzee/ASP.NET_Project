using MvcMovie.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.Models.ViewModels
{
    public class DepartmentVM
    {
        public Department department { get; set; } = new Department();
        public IEnumerable<Department> departments { get; set; } = new List<Department>();

    }
}
