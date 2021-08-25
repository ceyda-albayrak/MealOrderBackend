using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper.Extensions.Linq.Core;

namespace Entities
{
    [Table("Categorys")]
    public class Category 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
