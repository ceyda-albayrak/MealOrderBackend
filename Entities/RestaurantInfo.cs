using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Entities
{
    [Table("RestaurantInfos")]
    public class RestaurantInfo
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
      
        public int RegionId { get; set; }
        public string Address { get; set; }

        [RegularExpression(@"^\(?\d{3}?\)??-??\(?\d{3}?\)??-??\(?\d{4}?\)??-?$", ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; }
        [Dapper.Contrib.Extensions.Key]
        public int UserId { get; set; }
        
    }
}
