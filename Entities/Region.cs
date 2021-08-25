using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Entities
{
    public class Region
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
    }
}
