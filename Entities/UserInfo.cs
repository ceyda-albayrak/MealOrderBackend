using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public int RegionId { get; set; }
        [RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; }

    }
}
