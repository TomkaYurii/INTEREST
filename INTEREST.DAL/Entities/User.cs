﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.DAL.Entities
{
    public class User : IdentityUser
    {
        public int ProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
