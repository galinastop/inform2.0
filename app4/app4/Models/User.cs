﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app4.Models
{
    public class User: IdentityUser
    {
        public ICollection<Message> Messages { get; set; }
        public User()
        {
            Messages = new HashSet<Message>();
        }
    }

}
