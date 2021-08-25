using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int RequiredDate { get; set; }
        public string Statu { get; set; }

    }
}
