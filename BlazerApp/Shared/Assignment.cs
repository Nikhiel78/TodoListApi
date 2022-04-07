using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazerApp.Shared
{
    public class Assignment
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string Name{ get; set; }
        [Required]
        public int Status { get; set; }
    }
}
