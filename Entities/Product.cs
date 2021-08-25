using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Products")]
    public class Product
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int LikePoint { get; set; }
  
        public int CategoryId { get; set; }
      
        [Key]
        public int RestaurantId { get; set; }
        public string Description { get; set; }


    }
}
