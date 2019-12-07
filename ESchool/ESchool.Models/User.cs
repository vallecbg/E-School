using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ESchool.Models
{
    public class User : IdentityUser
    {
        public User()
        {
        }

        public string Name { get; set; }
    }
}
