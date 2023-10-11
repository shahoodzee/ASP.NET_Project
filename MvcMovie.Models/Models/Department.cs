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
        [Key] //primary key

        public int Id { get; set; } 
        public string D_name { get; set; }
        public string D_description { get; set;}
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime UpdatedDateTime { get; set;} = DateTime.Now;

    }
}
