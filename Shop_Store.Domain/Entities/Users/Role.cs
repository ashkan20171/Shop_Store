﻿using Shop_Store.Domain.Entities.Commons;
using System.Collections.Generic;

namespace Shop_Store.Domain.Entities.Users
{
    public class Role: BaseEntity
    {
         public string  Name { get; set; }
        public ICollection<UserInRole > UserInRoles { get; set; }
    }
}
