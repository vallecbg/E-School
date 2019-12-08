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
            this.UserAnswers = new List<UserAnswer>();
        }
        //TODO: add firstname lastname
        public string Name { get; set; }

        public ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
