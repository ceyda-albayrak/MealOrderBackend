using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool Statu { get; set; }
    }
}
