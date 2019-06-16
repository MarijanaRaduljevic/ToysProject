using System;
using System.Collections.Generic;
using System.Text;

namespace ToysDomain
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
